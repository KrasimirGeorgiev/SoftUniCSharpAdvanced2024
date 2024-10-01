using System.Text;

var n = int.Parse(Console.ReadLine());
var set = new HashSet<string>();
var sb = new StringBuilder();
for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine();
    var isFirst = set.Add(input);
    if (isFirst)
    {
        sb.AppendLine(input);
    }
}

Console.WriteLine(sb.ToString());