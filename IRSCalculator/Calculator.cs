using System.Data;
using static IRSCalculator.AuxMethods;

namespace IRSCalculator;

public static class Calculator
{
    //public static double GetAmountToReduceMonthly(double grossSalary, List<IRSTableStructure> data)
    //{
    //    int numberBrackets = data.Count();
    //    int i;
    //    for (i = 0; i < numberBrackets; i++)
    //    {
    //        if (grossSalary <= data[i].RemMensal)
    //        {
    //            if (data[i].FormCalculo.ToLower() == "na")
    //                break;
    //            else
    //            {
    //                var calculationFormula = data[i].FormCalculo;
    //                var result = GetChangedCalculationFormula(calculationFormula, grossSalary);
    //                Console.WriteLine("Calculo da montante a abater: " + calculationFormula);
    //                return CalculateFormula(result);
    //            }
    //        }
    //        // Para salário superiores ao último escalão
    //        if (i == numberBrackets - 1)
    //            break;
    //    }l«
    //    return data[i].ParcelaAbater;
    //}

    public static double GetAmountToReduceMonthly(double grossSalary, List<IRSTableStructure> data)
    {
        // Encontra o escalão que corresponde ao salário
        var matchingBracket = data
            .FirstOrDefault(bracket => grossSalary <= bracket.RemMensal)
            ?? data.Last(); // Se não encontrar (==null, default de Inumerator), assume o último escalão.

        Console.WriteLine("Cálculo da montante a abater: " + matchingBracket.FormCalculo);
        if (matchingBracket.FormCalculo.ToLower() == "na")
           return matchingBracket.ParcelaAbater;
        else
           return CalculateFormula(ReplacingInCalculationFormula(matchingBracket.FormCalculo, grossSalary));
    }


    public static double CalculateFormula(string calculatioFormula)
    {
        var dataTable = new DataTable();
        var result = dataTable.Compute(calculatioFormula, null);
        return Convert.ToDouble(result);
    }

}