namespace Parser;

internal class Parser
{
    private string InfForm { get; }

    public string PostForm { get; }

    private readonly Dictionary<char, int> _operationPriority = new()
    {
        { '(', 0 }, { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 3 }, { '^', 3 }, { '~', 4 }
    };

    public Parser(string expression)
    {
        InfForm = expression;
        PostForm = ToPostfix(InfForm);
    }

    private static string GetStringNumber(string expression, ref int pos)
    {
        var stringNumber = string.Empty;

        for (; pos < expression.Length; pos++)
        {
            var num = expression[pos];

            if (char.IsDigit(num))
                stringNumber += num;
            else
            {
                pos--;
                break;
            }
        }

        return stringNumber;
    }

    private string ToPostfix(string infixExpr)
    {
        var postfixExpr = string.Empty;
        Stack<char> stack = new();

        for (var i = 0; i < infixExpr.Length; i++)
        {
            var c = infixExpr[i];
      
            if (char.IsDigit(c))
            {
                postfixExpr += GetStringNumber(infixExpr, ref i) + " ";
            }
            else switch (c)
            {
                case '(':
                    stack.Push(c);
                    break;
                case ')':
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                        postfixExpr += stack.Pop();
                    stack.Pop();
                    break;
                }
                default:
                {
                    if (_operationPriority.ContainsKey(c))
                    {
                        var op = c;
                        if (op == '-' && (i == 0 || (i > 1 && _operationPriority.ContainsKey( infixExpr[i-1] ))))
                            op = '~';
				
                        while (stack.Count > 0 && ( _operationPriority[stack.Peek()] >= _operationPriority[op]))
                            postfixExpr += stack.Pop();
                        stack.Push(op);
                    }

                    break;
                }
            }
        }

        return stack.Aggregate(postfixExpr, (current, op) => current + op);
    }

    private static double Execute(char operation, double first, double second) => operation switch
    {
        '+' => first + second,
        '-' => first - second,
        '*' => first * second,
        '/' => first / second,
        '^' => Math.Pow(first, second),
        _ => 0
    };

    public double Calculate()
    {
        Stack<double> stack = new();

        for (var i = 0; i < PostForm.Length; i++)
        {
            var c = PostForm[i];

            if (char.IsDigit(c))
            {
                var number = GetStringNumber(PostForm, ref i);
                stack.Push(Convert.ToDouble(number));
            }
            else if (_operationPriority.ContainsKey(c))
            {
                if (c == '~')
                {
                    var last = stack.Any() ? stack.Pop() : 0;
                    
                    stack.Push(Execute('-', 0, last));

                    continue;
                }

                var second = stack.Any() ? stack.Pop() : 0;
                var first = stack.Any() ? stack.Pop() : 0;
                
                stack.Push(Execute(operation: c, first, second));
            }
        }

        return stack.Pop();
    }
}
