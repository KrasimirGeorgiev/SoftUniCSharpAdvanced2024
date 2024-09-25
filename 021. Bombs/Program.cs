using System.Text;

var n = int.Parse(Console.ReadLine());
var matrix = new int[n, n];
for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = inputLine[j];
    }
}

var bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
foreach (var bomb in bombs)
{
    var bombCoordinates = bomb.Split(',').Select(int.Parse);
    var row = bombCoordinates.First();
    var col = bombCoordinates.Last();
    var explodingCell = matrix[row, col];
    if (explodingCell > 0)
    {
        var currentRow = row - 1;
        var currentCol = col;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row + 1;
        currentCol = col;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row;
        currentCol = col - 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row;
        currentCol = col + 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row - 1;
        currentCol = col + 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row + 1;
        currentCol = col + 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row + 1;
        currentCol = col - 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        currentRow = row - 1;
        currentCol = col - 1;
        if (AreCoordinatesValid(currentRow, currentCol) && matrix[currentRow, currentCol] > 0)
            matrix[currentRow, currentCol] -= explodingCell;

        matrix[row, col] = 0;
    }
}

PrintMatrix();
void PrintMatrix()
{
    var sb = new StringBuilder();
    var aliveCelsCount = 0;
    var aliveCelsSum = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            var currentCel = matrix[i, j];
            if (currentCel > 0)
            {
                aliveCelsCount++;
                aliveCelsSum += currentCel;
            }
            
            sb.Append(currentCel);
            if (j != n - 1)
            {
                sb.Append(' ');
            }
        }

        sb.AppendLine();
    }

    Console.WriteLine($"Alive cells: {aliveCelsCount}");
    Console.WriteLine($"Sum: {aliveCelsSum}");
    Console.WriteLine(sb.ToString());

}

bool AreCoordinatesValid(int row, int col)
   => 0 <= row && row < n && 0 <= col && col < n;