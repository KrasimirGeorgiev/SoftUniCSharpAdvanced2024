var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var row = -1;
var col = -1;
var energy = 15;
var nectar = 0;
var canRevive = true;
var reachedHive = false;
for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        var currentSymbol = inputLine[j];
        matrix[i, j] = currentSymbol;

        if (currentSymbol == 'B')
        {
            row = i;
            col = j;
        }
    }
}

var command = Console.ReadLine();
while (energy > 0 && !reachedHive)
{
    matrix[row, col] = '-';
    if (command == "up")
    {
        row--;
        if (row < 0)
            row = n - 1;
    }
    else if (command == "down")
    {
        row++;
        if (row >= n)
            row = 0;
    }
    else if (command == "left")
    {
        col--;
        if (col < 0)
            col = n - 1;
    }
    else if (command == "right")
    {
        col++;
        if (col >= n)
            col = 0;
    }

    var currentSymbol = matrix[row, col];
    if (currentSymbol != '-')
    {
        if (currentSymbol == 'H')
        {
            reachedHive = true;
        }
        else
        {
            nectar += currentSymbol - '0';
        }
    }

    matrix[row, col] = 'B';

    energy--;
    if (!reachedHive)
    {
        if (energy == 0 && canRevive && nectar > 30)
        {
            energy = nectar - 30;
            nectar = 30;
            canRevive = false;
        }

        if (energy > 0)
        {
            command = Console.ReadLine();
        }
    }
}



if (reachedHive)
{
    if (nectar >= 30)
    {
        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
    }
    else
    {
        Console.WriteLine("Beesy did not manage to collect enough nectar.");
    }
}
else
{
    Console.WriteLine($"This is the end! Beesy ran out of energy.");
}

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
            //if (j != n - 1)
            //{
            //    line += ' ';
            //}
        }

        Console.WriteLine(line);
    }
}