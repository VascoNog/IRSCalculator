using FluentResults;
using System.Data;


// using IRSCalculator.Extensions;
using System.Text.Json;

namespace IRSCalculator
{
    public static class AuxMethods
    {
        public static List<IRSTableStructure> GetData(string filePath)
        {
            var result = GetTaxInfoByYear(filePath);

            // Verificar resultado pelo Fluent Results
            if (result.IsSuccess)
            {
                return result.Value;
            }
            else
            {
                throw new Exception(result.Errors[0].Message);
            }
        }

        // Só preciso ler a informação externa
        // Assumir que nao posso alterar a informação externa
        public static Result<List<IRSTableStructure>> GetTaxInfoByYear(string filePath)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };

            if (!File.Exists(filePath))
                return Result.Fail("Unable to find information");
            var json = File.ReadAllText(filePath);
            return Result.Ok(JsonSerializer.Deserialize<List<IRSTableStructure>>(json, options));
        }

        public static void PrintIRSStructure(List<IRSTableStructure> data)
        {
            // escalão = bracket
            List<int> allDistinctYears = data.Select(bracket => bracket.Ano).Distinct().ToList();

            // Itera pelos anos distintos

            // Os números da formatação representam os espaços reservados
            // E o sinal negativo significa que é alinhado à esquerda
            foreach (var year in allDistinctYears)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Taxas referentes ao ano: {year}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{"Remuneração",-15} {"TMM (%)",-17} {"Parcela a abater",-19} {"Formula de calculo",-21}");
                Console.ResetColor();

                foreach (var element in data)
                {
                    if (element.Ano == year)
                    {
                        Console.WriteLine($"{element.RemMensal,-15:C2} {element.TaxaMarginalMax,-17} {element.ParcelaAbater,-19:C2} {element.FormCalculo,-21}");
                    }
                }
                Console.WriteLine();
            }
        }

        public static List<IRSTableStructure> GetInfoYearReference(List<IRSTableStructure> data, int yearReference)
        {
            List<IRSTableStructure> infoYearReference = new List<IRSTableStructure>();
            foreach (var element in data)
                if (element.Ano == yearReference)
                    infoYearReference.Add(element);
            return infoYearReference;
        }

    }
}