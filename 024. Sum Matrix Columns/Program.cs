var rowsCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var matrix = new int[rowsCols[0], rowsCols[1]];

for (int row = 0; row < rowsCols[0]; row++)
{
    var inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < rowsCols[1]; col++)
    {
        matrix[row, col] = inputLine[col];
    }
}


for (int col = 0; col < rowsCols[1]; col++)
{
    var sum = 0;
    for (int row = 0; row < rowsCols[0]; row++)
    {
        sum += matrix[row, col];
    }

    Console.WriteLine(sum);
}