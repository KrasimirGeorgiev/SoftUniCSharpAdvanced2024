var n = int.Parse(Console.ReadLine());
var matrix = new int[n, n];
for (int row = 0; row < n; row++)
{
    var inputLine = Console.ReadLine();
    for (int col = 0; col < n; col++)
    {
        matrix[row, col] = inputLine[col];
    }
}

var symbol = char.Parse(Console.ReadLine());
var result = "";
for (int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        if (matrix[row, col] == symbol)
        {
            result = $"({row}, {col})";
            break;
        }
    }

    if (result != "")
        break;
}

if (result == string.Empty)
{
    result = $"{symbol} does not occur in the matrix";
}
    
Console.WriteLine(result);
