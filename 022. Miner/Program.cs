using System.Net.WebSockets;

var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var coalCount = 0;
var startRow = -1;
var startCol = -1;

var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine().Where(x => x != ' ').ToArray();
    for (int j = 0; j < n; j++)
    {
        var currentSymbol = inputLine[j];
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 's')
        {
            startRow = i;
            startCol = j;
        } else if(currentSymbol == 'c')
        {
            coalCount++;
        }
    }
}
var isExit = false;
foreach (var command in commands)
{
    if (coalCount <= 0)
    {
        break;
    }
    var currentRow = startRow;
    var currentCol = startCol;
    if (command == "up")
    {
        currentRow = startRow - 1;
        currentCol = startCol;

    }
    else if (command == "right")
    {
        currentRow = startRow;
        currentCol = startCol + 1;
    }
    else if (command == "left")
    {
        currentRow = startRow;
        currentCol = startCol - 1;
    }
    else if (command == "down")
    {
        currentRow = startRow + 1;
        currentCol = startCol;
    }

    if (AreCoordinatesValid(currentRow, currentCol))
    {
        startRow = currentRow;
        startCol = currentCol;

        var currentSymbol = matrix[startRow, startCol];
        if (currentSymbol == 'c')
        {
            coalCount--;
            matrix[startRow, startCol] = '*';
        }
        else if(currentSymbol == 'e')
        {
            isExit = true;
            Console.WriteLine($"Game over! ({startRow}, {startCol})");
        }
    }
}

if (!isExit)
{
    if (coalCount <= 0)
    {
        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
    }
    else
    {
        Console.WriteLine($"{coalCount} coals left. ({startRow}, {startCol})");
    }
}

bool AreCoordinatesValid(int row, int col)
   => 0 <= row && row < n && 0 <= col && col < n;