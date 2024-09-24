var n = int.Parse(Console.ReadLine());
var matrix = new char[n, n];
var knightCoordinates = new List<Tuple<int, int>>();

for (int i = 0; i < n; i++)
{
    var line = Console.ReadLine();
    for (var j = 0; j < n; j++)
    {
        var currentSymbol = char.ToLower(line[j]);
        matrix[i, j] = currentSymbol;
        if (currentSymbol == 'k')
        {
            knightCoordinates.Add(new Tuple<int, int>(i, j));
        }
    }
}

var knightAndItsTargets = new Dictionary<string, List<string>>();
var countOfTargetsToKnight = new Dictionary<int, List<string>>();
countOfTargetsToKnight.Add(1, new List<string>());
countOfTargetsToKnight.Add(2, new List<string>());
countOfTargetsToKnight.Add(3, new List<string>());
countOfTargetsToKnight.Add(4, new List<string>());
countOfTargetsToKnight.Add(5, new List<string>());
countOfTargetsToKnight.Add(6, new List<string>());
countOfTargetsToKnight.Add(7, new List<string>());
countOfTargetsToKnight.Add(8, new List<string>());

foreach (var coordinate in knightCoordinates)
{
    var currentKnight = matrix[coordinate.Item1, coordinate.Item2];
    var knightsInRange = GetKnightsInRange(coordinate.Item1, coordinate.Item2);
    if (knightsInRange.Count > 0)
    {
        knightAndItsTargets.Add($"{coordinate.Item1} {coordinate.Item2}", knightsInRange);
        countOfTargetsToKnight[knightsInRange.Count()].Add($"{coordinate.Item1} {coordinate.Item2}");
    }
}

var countOfRemovedKnights = 0;
for (int i = 8; i > 0; i--)
{
    while (countOfTargetsToKnight[i].Count > 0)
    {
        var knightToRemove = countOfTargetsToKnight[i].First();
        var targets = knightAndItsTargets[knightToRemove];
        foreach (var target in targets)
        {
            if(knightAndItsTargets[target].Count() - 1 > 0)
            {
                countOfTargetsToKnight[knightAndItsTargets[target].Count() - 1].Add(target);
            }

            countOfTargetsToKnight[knightAndItsTargets[target].Count()].Remove(target);
            knightAndItsTargets[target].Remove(knightToRemove);
        }

        countOfTargetsToKnight[i].Remove(knightToRemove);
        countOfRemovedKnights++;
    }
}

Console.WriteLine(countOfRemovedKnights);

List<string> GetKnightsInRange(int row, int col) 
{
    var list = new List<string>();

    var attackRow = row + 1;
    var attackCol = col + 2;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row + 2;
    attackCol = col + 1;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row + 1;
    attackCol = col - 2;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row + 2;
    attackCol = col - 1;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row - 1;
    attackCol = col - 2;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row - 2;
    attackCol = col - 1;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row - 1;
    attackCol = col + 2;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    attackRow = row - 2;
    attackCol = col + 1;
    if (AreCoordinatesValid(attackRow, attackCol) && matrix[attackRow, attackCol] == 'k')
        list.Add($"{attackRow} {attackCol}");

    return list;
}

bool AreCoordinatesValid(int row, int col)
{
    var isRowValid = 0 <= row && row < n;
    var isCoilValid = 0 <= col && col < n;
    return isRowValid && isCoilValid;
}


void printMatrix()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(matrix[i, j]);
            if (j != n - 1)
            {
                Console.Write("");
            }
        }

        Console.WriteLine();
    }
}