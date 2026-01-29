using System.Reflection;
namespace App;
/// <summary>
/// Приводит к нужному формату для работы.
/// </summary>
public class ConverterOfData
{
    /// <summary>
    /// Из описания к значениям для кода.
    /// </summary>
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
    /// <summary>
    /// Из значений в коде к описанию.
    /// </summary>
    public static void ConvertObjectToDescription(string path)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
                
        string className = Path.GetFileNameWithoutExtension(path);
                
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == className);
        
        var props = type.GetProperties().Select(x => $"{x.Name};{x.PropertyType};{x.CanRead} {x.CanWrite}").ToArray();
        CreatorDescription.Create(props, path);
    }
}