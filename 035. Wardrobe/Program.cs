using System.Text;

var n = int.Parse(Console.ReadLine());
var dic = new Dictionary<string, (Dictionary<string, int> clothToCount, List<string> orderOfClothes)>();
var colorsOrder = new List<string>();
for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
    var key = input[0];
    var items = input[1].Split(',');
    foreach (var item in items)
    {
        if (!dic.ContainsKey(key))
        {
            dic.Add(key, (new Dictionary<string, int>(), new List<string>()));
            colorsOrder.Add(key);
        }

        if (dic[key].clothToCount.ContainsKey(item))
        {
            dic[key].clothToCount[item]++;
        }
        else
        {
            dic[key].clothToCount.Add(item, 1);
            dic[key].orderOfClothes.Add(item);
        }
    }
}

var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
var searchedColor = command[0];
var searchCloth = command[1];

var sb = new StringBuilder();
foreach (var color in colorsOrder)
{
    sb.AppendLine($"{color} clothes:");
    foreach (var cloth in dic[color].orderOfClothes)
    {
        sb.AppendLine($"* {cloth} - {dic[color].clothToCount[cloth]}"
            + (searchedColor == color && searchCloth == cloth ? " (found!)" : string.Empty));
    }
}

Console.WriteLine(sb.ToString());