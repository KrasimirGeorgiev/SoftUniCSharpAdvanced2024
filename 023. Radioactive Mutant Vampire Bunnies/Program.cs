var dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var nRows = dimensions[0];
var nCols = dimensions[1];

var row = 0;
var col = 0;

var bunnyCoordinates = new List<Tuple<int, int>>();
var bunnyCoordinates2 = new List<Tuple<int, int>>();

var hashSet = new HashSet<string>();
var matrix = new char[nRows, nCols];
for (int i = 0; i < nRows; i++)
{
    var inputLine = Console.ReadLine().ToLower();
    for (int j = 0; j < nCols; j++)
    {
        var currentSymbol = inputLine[j];
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 'p')
        {
            row = i;
            col = j;
        } 
        else if (currentSymbol == 'b')
        {
            bunnyCoordinates.Add(new Tuple<int, int>(i, j));
            hashSet.Add($"{i} {j}");
        }
    }
}

var result = "";
var commands = Console.ReadLine().ToLower();
foreach (var command in commands)
{
    var currentRow = row;
    var currentCol = col;
    if(command == 'u')
    {
        currentRow = row - 1;
    }
    else if (command == 'd')
    {
        currentRow = row + 1;
    }
    else if (command == 'l')
    {
        currentCol = col - 1;
    }
    else if(command == 'r')
    {
        currentCol = col + 1;
    }
    
    if(AreCoordinatesInsiteTheMatrix(currentRow, currentCol))
    {
        matrix[row, col] = '.';
        row = currentRow;
        col = currentCol;
        var isDead = false;
        if (matrix[row, col] == 'b')
        {
            result = $"dead: {row} {col}";
            isDead = true;
        }
        else
        {
            matrix[row, col] = 'p';
        }

        var message = BunniesMove();
        if (isDead)
            break;
        if (message != "")
        {
            result = message;
            break;
        }
        else
        {
            bunnyCoordinates.AddRange(bunnyCoordinates2);
            bunnyCoordinates2 = new List<Tuple<int, int>>();
        }
    }
    else
    {
        matrix[row, col] = '.';
        BunniesMove();
        result = $"won: {row} {col}";
        break;
    }
}

PrintMatrix();
Console.WriteLine(result);

void PrintMatrix()
{
    
    for (int i = 0; i < nRows; i++)
    {
        var line = "";
        for (int j = 0; j < nCols; j++)
        {
            var currentCel = matrix[i, j];

            line +=Char.ToUpper(currentCel);
            //if (j != nCols - 1)
            //{
            //    sb.Append(' ');
            //}
        }

        Console.WriteLine(line);
    }
}

bool AreCoordinatesInsiteTheMatrix(int row, int col)
    => 0 <= row && row < nRows && 0 <= col && col < nCols;

string BunniesMove()
{
    var result = string.Empty;
    foreach (var coordinate in bunnyCoordinates)
    {
        var currentRow = coordinate.Item1 - 1;
        var currentCol = coordinate.Item2;
        if (AreCoordinatesInsiteTheMatrix(currentRow, currentCol))
        {
            if (matrix[currentRow, currentCol] == 'p')
            {
                result = $"dead: {currentRow} {currentCol}";
            }
            else
            {
                if(hashSet.Add($"{currentRow} {currentCol}"))
                {
                    bunnyCoordinates2.Add(new Tuple<int, int>(currentRow, currentCol));
                }
            }

            matrix[currentRow, currentCol] = 'b';
        }

        currentRow = coordinate.Item1 + 1;
        currentCol = coordinate.Item2;
        if (AreCoordinatesInsiteTheMatrix(currentRow, currentCol))
        {
            if (matrix[currentRow, currentCol] == 'p')
            {
                result = $"dead: {currentRow} {currentCol}";
            }
            else
            {
                if (hashSet.Add($"{currentRow} {currentCol}"))
                {
                    bunnyCoordinates2.Add(new Tuple<int, int>(currentRow, currentCol));
                }
            }

            matrix[currentRow, currentCol] = 'b';
        }

        currentRow = coordinate.Item1;
        currentCol = coordinate.Item2 - 1;
        if (AreCoordinatesInsiteTheMatrix(currentRow, currentCol))
        {
            if (matrix[currentRow, currentCol] == 'p')
            {
                result = $"dead: {currentRow} {currentCol}";
            }
            else
            {
                if (hashSet.Add($"{currentRow} {currentCol}"))
                {
                    bunnyCoordinates2.Add(new Tuple<int, int>(currentRow, currentCol));
                }
            }

            matrix[currentRow, currentCol] = 'b';
        }

        currentRow = coordinate.Item1;
        currentCol = coordinate.Item2 + 1;
        if (AreCoordinatesInsiteTheMatrix(currentRow, currentCol))
        {
            if (matrix[currentRow, currentCol] == 'p')
            {
                result = $"dead: {currentRow} {currentCol}";
            }
            else
            {
                if (hashSet.Add($"{currentRow} {currentCol}"))
                {
                    bunnyCoordinates2.Add(new Tuple<int, int>(currentRow, currentCol));
                }
            }

            matrix[currentRow, currentCol] = 'b';
        }
    }

    return result;
}