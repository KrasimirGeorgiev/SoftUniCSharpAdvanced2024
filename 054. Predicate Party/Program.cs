var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
var command = Console.ReadLine();
Func<string, string, string, bool> doesWordFitCriteria = DoesWordFitCriteria;

while (command.ToLower() != "party!")
{
    var inputSpl = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var operation = inputSpl[0];
    var startOrEnd = inputSpl[1];
    var subString = inputSpl[2];

    var currentList = new List<string>();
    foreach (var name in names)
    {
        if (doesWordFitCriteria(name, subString, startOrEnd))
        {
            if (operation.ToLower() == "double")
            {
                currentList.Add(name);
                currentList.Add(name);
            }
        }
        else
        {
            currentList.Add(name);
        }
    }

    names = currentList;
    command = Console.ReadLine();
}

if (names.Count > 0)
{
    Console.WriteLine(string.Join(", ", names) + " are going to the party!");
}
else 
{
    Console.WriteLine("Nobody is going to the party!");
}

bool DoesWordFitCriteria(string name, string subString, string possition)
{
    var fitsCriteria = false;
    if (possition.ToLower() == "startswith")
    {
        fitsCriteria = name.StartsWith(subString);
    } 
    else if(possition.ToLower() == "endswith")
    {
        fitsCriteria = name.EndsWith(subString);
    }
    else
    {
        fitsCriteria = name.Length == int.Parse(subString);
    }

    return fitsCriteria;
}

enum Possition
{
    Start,
    End
}
