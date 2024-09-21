var matrixDimensions = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

var rowN = matrixDimensions[0];
var colN = matrixDimensions[1];

var matrix = new string[matrixDimensions[0]][];
for (int i = 0; i < matrixDimensions[0]; i++)
{
    matrix[i] = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
}

var command = Console.ReadLine();
while (command != "END")
{
    var coordinates = GetCoordinatesFromCommand(command);
    var isCommandValid = coordinates != null;

    if (isCommandValid)
    {
        isCommandValid = swapCells(coordinates.Item1, coordinates.Item2);
    }

    if (isCommandValid) 
    {
        printMatrix();
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }

    command = Console.ReadLine();
}

Tuple<Tuple<int, int>, Tuple<int, int>>? GetCoordinatesFromCommand(string command)
{
    Tuple<Tuple<int, int>, Tuple<int, int>> coordinates = null;
    var splitCommad = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (splitCommad.Length == 5 && splitCommad[0] == "swap")
    {
        try
        {
            var coordinatesA = new Tuple<int,int>(int.Parse(splitCommad[1]), int.Parse(splitCommad[2]));
            var coordinatesB = new Tuple<int, int>(int.Parse(splitCommad[3]), int.Parse(splitCommad[4]));
            coordinates = new Tuple<Tuple<int, int>, Tuple<int, int>>(coordinatesA, coordinatesB);
        }
        catch (Exception)
        {

        }
    }

    return coordinates;
}

bool swapCells(Tuple<int, int> cordinatesA, Tuple<int, int> cordinatesB)
{
    var aCordinatesAreValid = 0 <= cordinatesA.Item1 
        && cordinatesA.Item1 + 1 <= rowN
        && 0 <= cordinatesA.Item2
        && cordinatesA.Item2 + 1 <= colN;
    
    var bCordinatesAreValid = 0 <= cordinatesB.Item1
        && cordinatesB.Item1 + 1 <= rowN
        && 0 <= cordinatesB.Item2
        && cordinatesB.Item2 + 1 <= colN;

    var arecoordinatesValid = aCordinatesAreValid && bCordinatesAreValid;

    if (arecoordinatesValid)
    {
        var item1 = matrix[cordinatesA.Item1][cordinatesA.Item2];
        var item2 = matrix[cordinatesB.Item1][cordinatesB.Item2];
        matrix[cordinatesA.Item1][cordinatesA.Item2] = item2;
        matrix[cordinatesB.Item1][cordinatesB.Item2] = item1;
    }

    return arecoordinatesValid;
}

void printMatrix()
{
    for (int i = 0; i < rowN; i++)
    {
        for (int j = 0; j < colN; j++)
        {
            Console.Write(matrix[i][j]);
            if (j != colN - 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}