var n = int.Parse(Console.ReadLine());
var matrix = new int[n][];
for (int i = 0; i < n; i++)
{
    matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}

var firstDiagonal = 0;
var secondDiagonal = 0;
for (int i = 0; i < n; i++)
{
    firstDiagonal += matrix[i][i];
    secondDiagonal += matrix[i][(n - 1) - i];
}

Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));