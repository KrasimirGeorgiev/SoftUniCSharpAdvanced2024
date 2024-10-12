using System.Text;

var input = Console.ReadLine();

Action<string> printSirNames = x => displaySirNames(x);

printSirNames(input);

void displaySirNames(string input)
{
    var spl = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var sb = new StringBuilder();
    foreach (var s in spl)
    {
        sb.AppendLine($"Sir {s}");
    }

    Console.WriteLine(sb.ToString());
}