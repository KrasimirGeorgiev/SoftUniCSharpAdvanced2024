var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var row = -1;
var col = -1;
var fish = 0;
var fellIntoW = false;
for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        var currentSymbol = inputLine[j];
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 'S')
        {
            row = i;
            col = j;
        }
    }
}

var command = Console.ReadLine();

while (command != "collect the nets")
{
    matrix[row, col] = '-';

    var currentRow = row;
    var currentCol = col;
    if (command == "up")
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

    currentRow = ReturnValidIndex(currentRow, n);
    currentCol = ReturnValidIndex(currentCol, n);

    var currentSymbol = matrix[currentRow, currentCol];
    row = currentRow;
    col = currentCol;
    matrix[row, col] = 'S';
    
    if (currentSymbol == 'W')
    {
        fish = 0;
        fellIntoW = true;
        break;
    }
    else if (char.IsNumber(currentSymbol))
    {
        fish += currentSymbol - '0';
    }

    command = Console.ReadLine();
}

if (fellIntoW)
{
    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{row},{col}]");
}
else
{
    if (fish >= 20)
    {
        Console.WriteLine("Success! You managed to reach the quota!");
    }
    else
    {
        Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fish} tons of fish more.");
    }

    if (0 < fish)
    {
        Console.WriteLine($"Amount of fish caught: {fish} tons.");
    }

    PrintMatrix();
}

void PrintMatrix()
{

    for (int i = 0; i < n; i++)
    {
        var line = "";
        for (int j = 0; j < n; j++)
        {
            var currentCel = matrix[i, j];

            line += currentCel;
            //if (j != n - 1)
            //{
            //    line += ' ';
            //}
        }

        Console.WriteLine(line);
    }
}

int ReturnValidIndex(int n, int mLenght)
{
    if (n < 0)
    {
        return mLenght - 1;
    }
    else if (mLenght <= n)
    {
        return 0;
    }

    return n;
}