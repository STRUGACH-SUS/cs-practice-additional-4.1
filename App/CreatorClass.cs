using System.Text;

namespace App;
/// <summary>
/// Создает код для класса из его описания и загружает его в файл.
/// </summary>
public class CreatorClass
{
    /// <summary>
    /// Генерация и загрузка кода.
    /// </summary>
    public static void Create(IEnumerable<FieldOfClass> fields, string path)
    {
        var code = new StringBuilder();
        code.AppendLine($"public class {Path.GetFileNameWithoutExtension(path)}");
        code.AppendLine("{");
        foreach (var field in fields)
        {
            code.AppendLine($$"""    public {{field.Type}} _{{field.Name}} {{{field.Access}}}""");
        }
        code.AppendLine(String.Empty);
        code.Append($"\tpublic {Path.GetFileNameWithoutExtension(path)} (");
        code.AppendJoin(',', fields.Select(x => $"{x.Type} {x.Name}"));
        code.Append(")");
        code.AppendLine(String.Empty);
        code.AppendLine("\t{");

        foreach (var field in fields)
        {
            code.AppendLine($"\t\t\t_{field.Name} = {field.Name};");
        }
        code.AppendLine("\t}");
        code.AppendLine("}");

        File.AppendAllText(Path.ChangeExtension(path, ".cs"), code.ToString());
    }
}