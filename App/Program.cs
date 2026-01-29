using App;
//Тут как и говорилось в задании ввод не сделан
//Предпологается что файлы запускаются из этой же папки с проектом
string path = """C:\Users\stryg\RiderProjects\cs-practice-additional-4.1\App\OOO.cs""";//"""C:\Users\stryg\RiderProjects\cs-practice-additional-4.1\App\OOO.csv"""

var cts = new CancellationTokenSource();
Console.CancelKeyPress +=(_,_)=>
{
    cts.Cancel();
};
//Тут сделал чисто для cs и csv файлов
if (Path.GetExtension(path) == ".csv")
{
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
}
else if (Path.GetExtension(path) == ".cs")
{
    try
    {
        ConverterOfData.ConvertObjectToDescription(path);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}
else
{
    throw new Exception("File is not a .csv file or .cs file.");
}