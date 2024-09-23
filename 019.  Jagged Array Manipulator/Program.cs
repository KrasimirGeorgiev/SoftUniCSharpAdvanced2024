var n = int.Parse(Console.ReadLine());
var arr = new int[n][];

var currentRow = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

arr[0] = currentRow;
for (int i = 1; i < n; i++)
{
    arr[i] = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

    Operation? currentOperation = null;
    if (arr[i - 1].Length == arr[i].Length)
    {
        currentOperation = Operation.Multiplication;
    }
    else
    {
        currentOperation = Operation.Division;
    }

    TreverseAnArrayAndPerformOperationOnIt(arr[i - 1], currentOperation.Value);
    TreverseAnArrayAndPerformOperationOnIt(arr[i], currentOperation.Value);
}

var command = Console.ReadLine();
while (command != "End")
{
    try
    {
        var commandSpl = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

        if (commandSpl.Length == 4 && (commandSpl[0] == "Add" || commandSpl[0] == "Subtract"))
        {
            var row = int.Parse(commandSpl[1]);
            var col = int.Parse(commandSpl[2]);
            var number = int.Parse(commandSpl[3]);
            if (0 <= row && row < n && 0 <= col && col < arr[row].Length) 
            {
                if (commandSpl[0] == "Add") 
                {
                    arr[row][col] += number;
                }
                else
                {
                    arr[row][col] -= number;
                }
            }
        }
    }
    catch (Exception)
    {

    }

    command = Console.ReadLine();
}

printMatrix();

void printMatrix()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            Console.Write(arr[i][j]);
            if (j != arr[i].Length - 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}


void TreverseAnArrayAndPerformOperationOnIt(int[] arr, Operation operation)
{
    int PerformOperation(int number)
    {
        if (operation == Operation.Multiplication)
        {
            number *= 2;
        }
        else if (operation == Operation.Division)
        {
            number /= 2;
        }

        return number;
    }

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = PerformOperation(arr[i]);
    }
}

enum Operation
{
    Addition,
    Substraction,
    Multiplication,
    Division
}
