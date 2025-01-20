using FluentResults;
using IRSCalculator;

namespace IRSCalculator
{
    public static class AuxMethods
    {
        // Só preciso ler a informação externa
        // Assumir que nao posso alterar a informação externa
        public static Result<List<IRSTableStructure>> GetTaxInfoByYear(string filePath)
        {
            if (!File.Exists(filePath))
                return Result.Fail("Unable to find information");
            return Result.Ok(System.Text.Json.JsonSerializer.Deserialize<List<IRSTableStructure>>(File.ReadAllText(filePath)));
        }

        public static void PrintIRSStructure(List<IRSTableStructure> data)
        {
            List<int> allDistinctYears = data.Select(x => x.Ano).Distinct().ToList();

            // Itera pelos anos distintos

            // Os números da formatação representam os espaços reservados
            // E o sinal negativo significa que é alinhado à esquerda
            foreach (var year in allDistinctYears)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Taxas referentes ao ano: {year}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{"Remuneração",-15} {"TMM (%)",-12} {"A abater",-15} {"Formula calc",-30}");
                Console.ResetColor();

                foreach (var element in data)
                {
                    if (element.Ano == year)
                    {
                        Console.WriteLine($"{element.RemunecaoMensal,-15:C2} {element.TaxaMarginalMax,-12} {element.ParcelaAbater,-15:C2} {element.FormCalculo,-30}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}