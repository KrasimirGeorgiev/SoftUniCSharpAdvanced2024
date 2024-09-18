var matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
var matrix = new char[matrixDimensions[0]][];
for (int i = 0; i < matrixDimensions[0]; i++)
{
    matrix[i] = Console.ReadLine().Where(s => s != ' ').ToArray();
}

var counter = 0;

if (matrixDimensions[0] > 1 && matrixDimensions[1] > 1)
{
    for (int i = 0; i < matrixDimensions[0] - 1; i++)
    {
        for (int j = 0; j < matrixDimensions[1] - 1; j++)
        {
            var currentSymbol = matrix[i][j];
            if (currentSymbol == matrix[i][j + 1]
                && currentSymbol == matrix[i + 1][j + 1]
                && currentSymbol == matrix[i + 1][j])
            {
                counter++;
            } 
        }
    }
}

Console.WriteLine(counter);