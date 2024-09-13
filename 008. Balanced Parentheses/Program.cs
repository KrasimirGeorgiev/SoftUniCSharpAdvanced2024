var inputLine = Console.ReadLine();

var unclosedParentheses = new Stack<char>();
var openParenthesesToClosing = new Dictionary<char, char>(){ { '(', ')'}, { '[', ']' }, { '{', '}' } };
var closingParenthesesToOpening = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };

foreach (var parenthesis in inputLine)
{
    var areUnclosedParentheses = unclosedParentheses.Any();
    var isOpenParenthesis = openParenthesesToClosing.ContainsKey(parenthesis);
    
    // If there is no parantesis in the stack and the current one is a closing one
    var isInputWrong = !areUnclosedParentheses && !isOpenParenthesis;
    if (!isInputWrong)
    {
        // If there is an opening parantesis in the stack and the current parantesis is a closing one from a different type
        if (areUnclosedParentheses && !isOpenParenthesis)
        {
            var lastParenthesis = unclosedParentheses.Peek();
            var isLastParenthesisAnOpeningOne = openParenthesesToClosing.ContainsKey(lastParenthesis);
            var isLastParenthesisSameType = openParenthesesToClosing.TryGetValue(lastParenthesis, out var closingParenthesis) && closingParenthesis == parenthesis;
            if (isLastParenthesisSameType)
                unclosedParentheses.Pop();
            else
                isInputWrong = true;
        }
        else
        {
            unclosedParentheses.Push(parenthesis);
        }
    }


    if (isInputWrong)
    {
        unclosedParentheses.Push(parenthesis);
        break;
    }
}

var result = unclosedParentheses.Any() ? "NO" : "YES";
Console.WriteLine(result);