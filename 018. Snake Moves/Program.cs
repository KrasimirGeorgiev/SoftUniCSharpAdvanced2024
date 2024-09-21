var rowCol = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

var snake = Console.ReadLine();
var matrix = new char[rowCol[0], rowCol[1]];
var snakeIndex = 0;
var isLeftToRightOrder = true;
for (int i = 0; i < rowCol[0]; i++)
{
    var columnInitialValue = isLeftToRightOrder ? 0 : rowCol[1] - 1;
    while ((isLeftToRightOrder && columnInitialValue < rowCol[1]) 
        || (!isLeftToRightOrder && 0 <= columnInitialValue)) 
    {
        
        matrix[i, columnInitialValue] = snake[snakeIndex];
        snakeIndex = (snakeIndex + 1) % snake.Length;

        if (isLeftToRightOrder)
        {
            columnInitialValue++;
        }
        else
        {
            columnInitialValue--;
        }
    }

    isLeftToRightOrder = !isLeftToRightOrder;
}

printMatrix();

void printMatrix()
{
    for (int i = 0; i < rowCol[0]; i++)
    {
        for (int j = 0; j < rowCol[1]; j++)
        {
            Console.Write(matrix[i, j]);
            if (j != rowCol[1] - 1)
            {
                Console.Write("");
            }
        }

        Console.WriteLine();
    }
}