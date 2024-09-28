var n = int.Parse(Console.ReadLine());
var sumDiagonal = 0;
for (int row = 0; row < n; row++)
{
    var inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    sumDiagonal += inputLine[row];
}

Console.WriteLine(sumDiagonal);