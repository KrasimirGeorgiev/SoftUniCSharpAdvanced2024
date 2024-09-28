var n = int.Parse(Console.ReadLine());
var pStarts = 2;

var matrix = new char[n, n];
var row = 0;
var col = -1;
for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = Char.Parse(inputLine[j]);
        if (matrix[i, j] == 'P')
        {
            row = i;
            col = j;
        }
    }
}

 while (true)
{
    var command = Console.ReadLine();

    var currentRow = row;
    var currentCol = col;
    if(command == "up")
    {
        currentRow--;
    }
    else if (command == "down")
    {
        currentRow++;
    }
    else if (command == "left")
    {
        currentCol--;
    }
    else if (command == "right")
    {
        currentCol++;
    }

    if (AreCoordinatesInsiteTheMatrix(currentRow, currentCol)) 
    {
        if (matrix[currentRow, currentCol] == '#')
        {
            pStarts--;
            currentRow = row;
            currentCol = col;
            if (pStarts <= 0)
                break;
        }
        else 
        {
            if (matrix[currentRow, currentCol] == '*')
            {
                pStarts++;
                matrix[currentRow, currentCol] = '.';
            }

            matrix[row, col] = '.';
            row = currentRow;
            col = currentCol;

            if (pStarts >= 10)
                break;
        }
    }
    else
    {
        var symbolAtInitialPosition = matrix[0, 0];
        currentRow = 0;
        currentCol = 0;
        if (matrix[currentRow, currentCol] == '#')
        {
            pStarts--;
            currentRow = row;
            currentCol = col;
            if (pStarts <= 0)
                break;
        }
        else
        {
            if (matrix[currentRow, currentCol] == '*')
            {
                pStarts++;
                matrix[currentRow, currentCol] = '.';
            }

            matrix[row, col] = '.';
            row = currentRow;
            col = currentCol;

            if (pStarts >= 10)
                break;
        }
        matrix[row, col] = '.';
    }
}

matrix[row, col] = 'P';
if (pStarts >= 10)
{
    Console.WriteLine("You won! You have collected 10 stars.");
}
else if(pStarts <= 0)
{
    Console.WriteLine("Game over! You are out of any stars.");
}

Console.WriteLine($"Your final position is [{row}, {col}]");

PrintMatrix();

void PrintMatrix()
{

    for (int i = 0; i < n; i++)
    {
        var line = "";
        for (int j = 0; j < n; j++)
        {
            var currentCel = matrix[i, j];

            line += currentCel;
            if (j != n - 1)
            {
                line += ' ';
            }
        }

        Console.WriteLine(line);
    }
}


bool AreCoordinatesInsiteTheMatrix(int row, int col)
   => 0 <= row && row < n && 0 <= col && col < n;