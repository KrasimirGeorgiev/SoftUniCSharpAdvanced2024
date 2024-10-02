var n = int.Parse(Console.ReadLine());
var list = new List<int>();
for (int i = 0; i < n; i++)
{
    list.Add(int.Parse(Console.ReadLine()));
}

var groupedElements = list.GroupBy(x => x, x => x);
Console.WriteLine(groupedElements.Where(g => g.Count() % 2 == 0).Select(x => x.Key).First());