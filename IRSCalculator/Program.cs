using static IRSCalculator.AuxMethods;
using static IRSCalculator.Calculator;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string filePath = @"D:\ReStart_Pessoal\IRSCalculator\IRSCalculator\fileInfo.txt";

var data = GetData(filePath);
PrintIRSStructure(data);

Console.Write("Salário bruto: "); double grossSalary = double.Parse(Console.ReadLine());
Console.Write("Ano referente: "); int yearReference = int.Parse(Console.ReadLine());


var amountToReduceMonthly = GetAmountToReduceMonthly(grossSalary, GetInfoYearReference(data, yearReference));
Console.WriteLine("Montante a abater mensalmente: " + amountToReduceMonthly);

