using System.Security.Cryptography;

var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var row = -1;
var col = -1;
var jPoints = 300;
var enemiesCount = 0;

for (int i = 0; i < n; i++)
{
    var inputLine = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        var currentSymbol = inputLine[j];
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 'E')
        {
            enemiesCount++;
        }
        else if (currentSymbol == 'J')
        {
            row = i;
            col = j;
        }
    }
}

while (enemiesCount > 0 && jPoints > 0)
{
    var command = Console.ReadLine();
    matrix[row, col] = '-';
    if (command == "up")
    {
        row--;
    }
    else if (command == "down")
    {
        row++;
    }
    else if (command == "left")
    {
        col--;
    }
    else if (command == "right")
    {
        col++;
    }

    if (matrix[row, col] == 'R')
    {
        jPoints = 300;
    } 
    else if (matrix[row, col] == 'E') 
    {
        enemiesCount--;
        if (enemiesCount > 0)
        {
            jPoints -= 100;
        }
    }

    matrix[row, col] = 'J';
}

if(enemiesCount == 0)
{
    Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
}
else
{
    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{row}, {col}]!");
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