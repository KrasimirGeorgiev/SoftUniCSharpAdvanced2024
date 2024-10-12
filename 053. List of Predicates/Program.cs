var range = Enumerable.Range(1, int.Parse(Console.ReadLine()));
var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Func<int, int[], bool> isDevisible = isNumberDevisable;
var result = new List<int>();
foreach (var n in range)
{
    if (isNumberDevisable(n, numbers))
    {
        result.Add(n);
    }
}

Console.WriteLine(string.Join(' ', result));

bool isNumberDevisable(int n, int[] devisers)
{
    foreach (int deviser in devisers)
    {
        if (n % deviser != 0)
        {
            return false;
        }
    }

    return true;
}