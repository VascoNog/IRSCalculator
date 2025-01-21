using FluentResults;
using System.Data;
using static IRSCalculator.AuxMethods;

namespace IRSCalculator;

public static class Calculator
{
    public static double GetAmountToReduceMonthly(double grossSalary, List<IRSTableStructure> data)
    {
        int numberBrackets = data.Count();
        int i;
        for (i = 0; i < numberBrackets; i++)
        {
            if (grossSalary <= data[i].RemMensal)
            {
                if (data[i].FormCalculo.ToLower() == "na")
                    return data[i].ParcelaAbater;
                else
                {
                    var calculationFormula = data[i].FormCalculo;
                    calculationFormula = calculationFormula.Replace("%", "/100");
                    calculationFormula = calculationFormula.Replace("x", "*");
                    //calculationFormula = calculationFormula.Replace(".", ","); // Se substituir por vírgula da erro
                    calculationFormula = calculationFormula.Replace("R", grossSalary.ToString());
                    Console.WriteLine("Calculo da montante a abater: " + calculationFormula);
                    return CalculateFormula(calculationFormula);
                }
            }
            // Para salário superiores ao último escalão
            if (i == numberBrackets - 1)
                return data[i].ParcelaAbater;
        }
        return data[i].ParcelaAbater;
    }

    public static double CalculateFormula(string calculatioFormula)
    {
        var dataTable = new DataTable();
        var result = dataTable.Compute(calculatioFormula, null);
        return Convert.ToDouble(result);
    }
}