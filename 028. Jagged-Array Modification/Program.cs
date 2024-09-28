var n = int.Parse(Console.ReadLine());
var jaggedArr = new int[n][];
for (int i = 0; i < n; i++)
{
    jaggedArr[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}

var command = Console.ReadLine();
while (command != "END")
{
    var commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var row = int.Parse(commands[1]);
    var col = int.Parse(commands[2]);
    var number = int.Parse(commands[3]);

    if (0 <= row && row < n && 0 <= col && col < jaggedArr[row].Length)
    {

        if (commands[0] == "Add")
        {
            jaggedArr[row][col] += number;
        }
        else if (commands[0] == "Subtract")
        {
            jaggedArr[row][col] -= number;
        }
    }
    else
    {
        Console.WriteLine("Invalid coordinates");
    }

    command = Console.ReadLine();
}

PrintMatrix();

void PrintMatrix()
{

    for (int i = 0; i < n; i++)
    {
        var nCols = jaggedArr[i].Length;
        var result = "";
        for (int j = 0; j < nCols; j++)
        {
            result += jaggedArr[i][j];

            if (j != nCols - 1)
            {
                result += ' ';
            }
        }

        Console.WriteLine(result);
    }
}