using System.Text;

namespace App;

public class CreatorClass
{
    public static void Create(IEnumerable<FieldOfClass> fields, string path)
    {
        var text = new StringBuilder();
        text.AppendLine($"public class {Path.GetFileNameWithoutExtension(path)}");
        text.AppendLine("{");
        foreach (var field in fields)
        {
            text.AppendLine($$"""   public {{field.Type}} _{{field.Name}} {{{field.Access}}}""");
        }
        text.AppendLine($"\tpublic {Path.GetFileNameWithoutExtension(path)}({fields.Select(x => $"{x.Type} {x.Name}").ToString()})");//
        text.AppendLine("\t{");

        foreach (var field in fields)
        {
            text.AppendLine($"\t\t\t_{field.Name} = {field.Name};");
        }
        text.AppendLine("\t}");
        text.AppendLine("}");

        File.AppendAllText(Path.ChangeExtension(path, ".cs"), text.ToString());
    }
}