namespace Parser
{
    internal static class Program
    {
        public static void Main()
        {
            const string expression = "(((1+2)*5)^2+5)*2";
            // const string expression = "(-15/(7-(1+1))*3-(2+(1+1)))";
            Parser parser = new(expression: expression);

            Console.WriteLine($"Start expression : {expression}");
            Console.WriteLine($"Postfix form     : {parser.PostForm}");
            Console.WriteLine($"Result           : {parser.Calculate()}");
        }
    }
}