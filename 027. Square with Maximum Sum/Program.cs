var rowsCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var matrix = new int[rowsCols[0], rowsCols[1]];

for (int row = 0; row < rowsCols[0]; row++)
{
    var inputLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < rowsCols[1]; col++)
    {
        matrix[row, col] = inputLine[col];
    }
}

int? maxSum = null;
int? rowIndex = null;
int? colIndex = null;

for (int row = 0; row < rowsCols[0] - 1; row++)
{
    for (int col = 0; col < rowsCols[1] - 1; col++)
    {
        var currentSum = matrix[row, col] + matrix[row, col + 1] 
            + matrix[row + 1, col] + matrix[row + 1, col + 1];
        if (currentSum > maxSum || maxSum == null) 
        { 
            maxSum = currentSum;
            rowIndex = row;
            colIndex = col;
        }
    }
}

Console.WriteLine($"{matrix[rowIndex!.Value, colIndex!.Value]} {matrix[rowIndex!.Value, colIndex!.Value + 1]}");
Console.WriteLine($"{matrix[rowIndex!.Value + 1, colIndex!.Value]} {matrix[rowIndex!.Value + 1, colIndex!.Value + 1]}");

Console.WriteLine(maxSum);
