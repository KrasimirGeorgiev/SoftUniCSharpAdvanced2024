var matrixDimensions = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
var matrix = new int[matrixDimensions[0]][];
for (int i = 0; i < matrixDimensions[0]; i++)
{
    matrix[i] = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
}

var counter = 0;
var rowIndex = 0;
var columnIndex = 0;
var nOfSubMatrix = 3;

if (matrixDimensions[0] > 2 && matrixDimensions[1] > 2)
{
    for (int i = 0; i < matrixDimensions[0] - 2; i++)
    {
        for (int j = 0; j < matrixDimensions[1] - 2; j++)
        {
            var currentCounter = 0;
            var currentRowIndex = 0;
            var currentColumnIndex = 0;
            for (int k = 0; k < nOfSubMatrix; k++)
            {
                for (int n = 0; n < nOfSubMatrix; n++)
                {
                    currentRowIndex = i + k;
                    currentColumnIndex = j + n;
                    currentCounter += matrix[i + k][j + n];
                }
            }

            if (counter < currentCounter)
            {
                counter = currentCounter;
                rowIndex = i;
                columnIndex = j;
            }
        }
    }
}

Console.WriteLine($"Sum = {counter}");

for (int i = rowIndex; i < rowIndex + 3; i++)
{
    for (int j = columnIndex; j < columnIndex + 3; j++)
    {
        Console.Write(matrix[i][j]);
        if (j != columnIndex + 2)
        {
            Console.Write(" ");
        }
    }

    Console.WriteLine();
}