using System.Text;

var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
var list1 = new List<string>(inputs[0]);
for (int i = 0; i < inputs[0]; i++)
{
    var input = Console.ReadLine();
    list1.Add(input);
}

var list2 = new List<string>(inputs[1]);
for (int i = 0; i < inputs[1]; i++)
{
    var input = Console.ReadLine();
    list2.Add(input);
}

var set = list2.Distinct().ToHashSet();
var sb = new StringBuilder();
var resultList = new List<string>();
foreach (var input in list1.Distinct())
{
    if (set.Contains(input))
    {
        resultList.Add(input);
    }
}

Console.WriteLine(string.Join(" ", resultList));