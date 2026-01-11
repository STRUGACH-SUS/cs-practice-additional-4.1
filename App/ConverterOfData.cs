namespace App;

public class ConverterOfData
{
    public static IEnumerable<FieldOfClass> ConvertDescriptionToClassWorkpiece(string [] contains)
    {
        try
        {
            var fields = contains
                .Where(x => !x.Contains('#') && x!=String.Empty)
                .Select(x=>x.Split(';', StringSplitOptions.RemoveEmptyEntries))
                .ToArray()
                .Select(x => new FieldOfClass(x));
            return fields;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void ConvertObjectToDescription()
    {
        
    }
}