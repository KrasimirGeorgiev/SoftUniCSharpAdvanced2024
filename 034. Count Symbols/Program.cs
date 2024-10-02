using System.Text;

var input = Console.ReadLine().ToCharArray().GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
var sb = new StringBuilder();
foreach (var item in input.Keys.OrderBy(x => x))
{
    sb.AppendLine($"{item}: {input[item]} time/s");
}

Console.WriteLine(sb.ToString());