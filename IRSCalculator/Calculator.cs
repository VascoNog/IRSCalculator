using FluentResults;
using static IRSCalculator.AuxMethods;

namespace IRSCalculator;

public static class Calculator
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



}