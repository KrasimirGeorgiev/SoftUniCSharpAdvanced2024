var n = int.Parse(Console.ReadLine());
var names = Console.ReadLine().Split();
Func<int, string, bool> filterByName = filterByN;

foreach (var name in names) 
{
	if (filterByName(n, name))
	{
        Console.WriteLine(name);
    }
}

bool filterByN(int n, string name)
    => name.Length <= n;