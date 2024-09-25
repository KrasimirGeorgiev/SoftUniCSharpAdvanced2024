var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var knightCoordinates = new List<Tuple<int, int>>();

for (int i = 0; i < n; i++)
{
    var line = Console.ReadLine();
    for (var j = 0; j < n; j++)
    {
        var currentSymbol = char.ToLower(line[j]);
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 'k')
        {
            knightCoordinates.Add(new Tuple<int, int>(i, j));
        }
    }
}

var count = 0;
for (int i = 8; i > 0; i--)
{
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            var currentChar = matrix[row, col];
            if (currentChar == 'k')
            {
                var currentCount = 0;
                var attackRow = row + 1;
                var attackCol = col + 2;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row + 2;
                attackCol = col + 1;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row + 1;
                attackCol = col - 2;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row + 2;
                attackCol = col - 1;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row - 1;
                attackCol = col - 2;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row - 2;
                attackCol = col - 1;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row - 1;
                attackCol = col + 2;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                attackRow = row - 2;
                attackCol = col + 1;
                if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
                    currentCount++;

                if (currentCount == i)
                {
                    count++;
                    matrix[row, col] = '0';
                }
            }
        }
    }
}

Console.WriteLine(count);

bool AreCoordinatesValid(int row, int col)
{
    var isRowValid = 0 <= row && row < n;
    var isCoilValid = 0 <= col && col < n;
    return isRowValid && isCoilValid;
}