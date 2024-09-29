var n = int.Parse(Console.ReadLine());
var jArr = new long[n][];
var initialValue = 1;

for (int i = 0; i < n; i++)
{
    var row = new long[i + 1];
    for (int j = 0; j < i + 1; j++)
    {
        var currentNumber = initialValue;
        var firstN = AreCoordinatesValid(i - 1, j - 1) ? jArr[i - 1][j - 1] : 0;
        var secondN = AreCoordinatesValid(i - 1, j) ? jArr[i - 1][j] : 0;
        var resultN = (long)firstN + (long)secondN;
        resultN = resultN == 0 ? initialValue : resultN;
        row[j] = resultN;
    }

    jArr[i] = row;
}

PrintMatrix();

bool AreCoordinatesValid(int rowIndex, int colIndex)
{
    var isRowValid = 0 <= rowIndex && rowIndex < n;
    var isColValid = isRowValid && 0 <= colIndex && colIndex < jArr[rowIndex].Length;

    return isRowValid && isColValid;
}

void PrintMatrix()
{

    for (int i = 0; i < n; i++)
    {
        var nCols = jArr[i].Length;
        var result = "";
        for (int j = 0; j < nCols; j++)
        {
            result += jArr[i][j];

            if (j != nCols - 1)
            {
                result += ' ';
            }
        }

        Console.WriteLine(result);
    }
}