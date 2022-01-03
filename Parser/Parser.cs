using System.Text;

namespace Parser;

internal static class Parser
{
    public static IEnumerable<string> ReadTextLines(string fileName, Encoding encoding)
    {
        IEnumerable<string> textLines;

        if (!File.Exists(fileName))
            throw new FileNotFoundException($"[Occured in {nameof(ReadTextLines)}] No such file!");
            
        try
        {
            textLines = File.ReadLines(fileName, encoding);
            textLines = textLines.Where(x => x != "");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new DirectoryNotFoundException($"[Occured in {nameof(ReadTextLines)}] Wrong filename!");
        }

        return textLines;
    }

    public static void ShowTextLines(IEnumerable<string> textLines)
    {
        try
        {
            var enumerable = textLines.ToList();
            Console.WriteLine($"Strings amount : {enumerable.Count()}");
            foreach (var textLine in enumerable)
                Console.WriteLine($"{textLine}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"[Occured in {nameof(ShowTextLines)}] No info in file!");
        }
    }
}