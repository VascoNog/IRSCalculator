using IRSCalculator;
using static IRSCalculator.AuxMethods;
using static IRSCalculator.Calculator;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string filePath = @"D:\ReStart_Pessoal\IRSCalculator\IRSCalculator\fileInfo.txt";

var data = GetData(filePath);
PrintIRSStructure(data);


