using static IRSCalculator.AuxMethods;
using static IRSCalculator.Calculator;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var data = GetData(@"D:\ReStart_Pessoal\IRSCalculator\IRSCalculator\fileInfo.txt");

while (true)
{
    Console.Clear();
    PrintIRSStructure(data);

    Console.Write("Salário bruto: "); double grossSalary = double.Parse(Console.ReadLine());
    Console.Write("Ano referente: "); int yearReference = int.Parse(Console.ReadLine());

    var amountToReduceMonthly = GetAmountToReduceMonthly(grossSalary, GetInfoYearReference(data, yearReference));
    Console.WriteLine("Montante a abater mensalmente: " + amountToReduceMonthly);

    Console.WriteLine();
    Console.Write("Digite '0'(zero) se quiser sair, ou qualquer botão para continuar: ");
    if (Console.ReadLine().ToLower() == "0")
        break;
}


















//Se quiser por exemplo, obter os tantos distintos que respeitam a um filtro
//Neste caso Ano > 2023

//var filteredDistinctYears = data
//    .Where(bracket => bracket.Ano < 2025)
//    .Select(bracket => bracket.Ano)
//    .Distinct()
//    .ToList();

//if (filteredDistinctYears != null)
//    foreach (var bracket in filteredDistinctYears)
//    {
//        Console.WriteLine(bracket); // $"bracket: {bracket.Ano} | {bracket.RemMensal} | {bracket.TaxaMarginalMax}");
//    }

// Obter a parcela a abater (Sem considerar que pode ser variável)
//Console.WriteLine();
//double grossSalary = 1056.45d;
//int yearReference = 2025;

//Obter o escalão respectivo:
//var yearData = data
//    .Where(bracket => bracket.Ano == yearReference)
//    .Select(bracket => bracket)
//    .ToList();

//var salaryLastBracket = yearData[yearData.Count() - 1].RemMensal;
//var respectiveBracket = yearData
//    .Where(bracket => grossSalary <= bracket.RemMensal
//        || (bracket.RemMensal == salaryLastBracket && grossSalary > salaryLastBracket))
//    .Select(bracket => bracket)
//    .ToList();

//foreach (var bracket in respectiveBracket)
//    Console.WriteLine(bracket.RemMensal);

//Console.WriteLine();
//if (grossSalary > salaryLastBracket)
//    Console.WriteLine(respectiveBracket[respectiveBracket.Count() - 1].ParcelaAbater);
//else if (grossSalary <= salaryLastBracket && respectiveBracket.First().FormCalculo == "na")
//    Console.WriteLine(respectiveBracket.First().ParcelaAbater);
//else if (grossSalary <= salaryLastBracket && respectiveBracket.First().FormCalculo != "na")
//{
//    var calculationFormula = respectiveBracket.First().FormCalculo;
//    Console.WriteLine("Calculo da montante a abater: " + calculationFormula);
//    var result = GetChangedCalculationFormula(calculationFormula, grossSalary);
//    Console.WriteLine(CalculateFormula(result));
//}

//Console.WriteLine(respectiveBracket.RemMensal);

//// Verificar se o cálculo é ou não variável
//if (respectiveBracket.FormCalculo.ToLower() == "na")
//    Console.WriteLine("Cálculo do montante a abater (Fixo): " + respectiveBracket.ParcelaAbater);
//else
//{
//    var calculationFormula = respectiveBracket.FormCalculo;
//    calculationFormula = GetChangedCalculationFormula(calculationFormula, grossSalary);
//    Console.WriteLine("Calculo do montante a abater (Variável): " + calculationFormula);
//    var result = CalculateFormula(calculationFormula);
//    Console.WriteLine(result);
//}