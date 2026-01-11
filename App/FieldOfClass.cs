namespace App;

public class FieldOfClass
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Access { get; set; }

    public FieldOfClass(string []  content)
    {
        Name = content[0];
        
        Type = content[1].ToLower().Trim() switch
        {
            "bool" => "bool",
            "int" => "int",
            "string" => "string",
            "datetime" => "DateTime",
            "real" => "double",
            _ => throw new Exception("Unknown field type"),
        };
        
        
        Access = content[2].ToLower().Trim() switch
        {
            "ro" => "get",
            "rw" => "get, set",
            _ => throw new Exception("Unknown field access"),
        };
    }
}