var command = Console.ReadLine();   
var vloggers = new Dictionary<string, (HashSet<string> Followers, HashSet<string> Following)>();

while (command != "Statistics")
{
	var commandSpl = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
	if (commandSpl.Length == 3)
	{
		var follower = commandSpl[0];
        var followee = commandSpl[2];

		if (follower != followee
			&& vloggers.TryGetValue(followee, out var followees)
			&& vloggers.TryGetValue(follower, out var followers))
		{
            followers.Following.Add(followee);
			followees.Followers.Add(follower);
        }

    }
    else
	{
		var joiner = commandSpl[0];
		if (!vloggers.ContainsKey(joiner))
		{
			vloggers.Add(joiner, (new HashSet<string>(), new HashSet<string>()));
        }
    }
	
    command = Console.ReadLine();
}

var count = vloggers.Count;
var counter = 1;

Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
foreach (var kv in vloggers.Keys.OrderByDescending(x => vloggers[x].Followers.Count()).ThenBy(x => vloggers[x].Following.Count()))
{
    Console.WriteLine($"{counter}. {kv} : {vloggers[kv].Followers.Count()} followers, {vloggers[kv].Following.Count()} following");
    if (counter == 1)
	{
		foreach (var follower in vloggers[kv].Followers.OrderBy(x => x))
		{
            Console.WriteLine($"*  {follower}");
        }
    }

	counter++;
}

