//using System.Runtime.CompilerServices;
//using System.Text.Json;

//namespace IRSCalculator.Extensions;

//public static class AllExtensions
//{
//    public static string ToJson(this object obj)
//    {
//        return JsonSerializer.Serialize(obj) + "Extension";
//    }

//    public static List<IRSTableStructure> FromJson(this string json)
//    {
//        foreach (var item in json)
//        {
//            item.ToString();
//        }

//        return JsonSerializer.Deserialize<List<IRSTableStructure>>(json);
//    }
//}