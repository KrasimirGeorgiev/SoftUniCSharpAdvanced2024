var n = int.Parse(Console.ReadLine());
var set = new HashSet<string>();
for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    foreach (var element in input)
    {
        set.Add(element);
    }
}

Console.WriteLine(string.Join(' ', set.OrderBy(x => x)));