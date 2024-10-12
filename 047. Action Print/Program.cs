using System.Text;

var input = Console.ReadLine();

Action<string> displayMessage = x => printMessage(x);

displayMessage(input);

void printMessage(string message)
{
    var input = message.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
    var sb = new StringBuilder();
    foreach (var line in input)
    {
        sb.AppendLine(line);
    }
    Console.WriteLine(sb.ToString());
}