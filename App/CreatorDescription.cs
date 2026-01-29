using System.Text;
namespace App;
/// <summary>
/// Создает описание для класса из его кода и загружает его.
/// </summary>
public class CreatorDescription
{
    /// <summary>
    /// Генерация и загрузка описания.
    /// </summary>
    public static void Create(string [] props, string path)
    {
        var text = new StringBuilder();
        
        text.AppendLine("#Name;Type;Access;");
        
        foreach (var i in props)
        {
            var stringF = i.Split(';');
            
            var name = stringF[0];
            
            var type = stringF[1] switch
            {
                "System.Boolean" => "Bool",
                "System.Int32" => "Int",
                "System.String" => "String",
                "System.DateTime" => "DateTime",
                "System.Double" => "Real",
                _ => throw new Exception("Unknown field type"),
            };
            
            var access= stringF[2] switch
            {
                "True False" => "RO",
                "True True" => "RW",
                _ => throw new Exception("Unknown field access"),
            };
            
            text.AppendLine($"{name};{type};{access};");
        }
        File.AppendAllText(Path.ChangeExtension(path, ".csv"), text.ToString());
    }
}