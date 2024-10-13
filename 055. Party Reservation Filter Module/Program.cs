using System.ComponentModel.Design;

var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

var filters = new Dictionary<string, List<string>>();
var command = Console.ReadLine();
while (command != "Print")
{
    var commandSpl = command.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
    var possition = commandSpl[1];
    var possitionSubject = commandSpl[2];
    if (commandSpl[0] == "Add filter")
    {
        if (!filters.ContainsKey(possition))
        {
            filters.Add(possition, new List<string>() { possitionSubject });
        }
        else if (!filters[possition].Contains(possitionSubject))
        {
            filters[possition].Add(possitionSubject);
        }

    }
    else
    {
        if (filters.TryGetValue(possition, out var currentPossitions) && currentPossitions.Contains(possitionSubject))
        {
            currentPossitions.Remove(possitionSubject);
            if (!currentPossitions.Any())
            {
                filters.Remove(possition);
            }
        }
    }

    command = Console.ReadLine();
}

Console.WriteLine(string.Join(' ', names.Where(x => !FilterWordBy(x))));

bool FilterWordBy(string str)
{
    foreach (var filter in filters.Keys)
    {
        if (filter == "Starts with" && Filter(str, filters[filter], Possition.Starts))
            return true;
        else if (filter == "Ends with" && Filter(str, filters[filter], Possition.Ends))
            return true;
        else if (filter == "Length" && Filter(str, filters[filter], Possition.Length))
            return true;
        else if (filter == "Contains" && Filter(str, filters[filter], Possition.Contains))
            return true;
    }

    return false;
}

bool Filter(string str, List<string> filters, Possition possition)
{
    var match = false;
    foreach (var filter in filters)
    {
        switch (possition)
        {
            case Possition.Starts:
                match = str.StartsWith(filter);
                break;
            case Possition.Ends:
                match = str.EndsWith(filter);
                break;
            case Possition.Length:
                match = str.Length == int.Parse(filter);
                break;
            case Possition.Contains:
                match = str.Contains(filter);
                break;
            default:
                break;
        }

        if (match)
            break;
    }

    return match;
}

enum Commands
{
    Add,
    Remove,
    Print
}

enum Possition
{
    Starts,
    Ends,
    Length,
    Contains
}