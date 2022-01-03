using System.Text;

namespace Parser
{
    internal static class Program
    {
        public static void Main()
        {
            const string fileName = "../../../TestFile.txt";
            var encoding = Encoding.UTF8;
            
            try
            {
                var textLines = Parser.ReadTextLines(fileName: fileName, encoding: encoding);
                Parser.ShowTextLines(textLines: textLines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}