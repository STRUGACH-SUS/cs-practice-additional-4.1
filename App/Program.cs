
using App;

string path = """C:\Users\htcbe\OneDrive\Рабочий стол\gg.txt""";

var cts = new CancellationTokenSource();
Console.CancelKeyPress +=(_,_)=>
{
    cts.Cancel();
};

try
{
    var contains = await File.ReadAllLinesAsync(path, cts.Token);
    var fields = ConverterOfData.ConvertDescriptionToClassWorkpiece(contains);
    CreatorClass.Create(fields, path);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}