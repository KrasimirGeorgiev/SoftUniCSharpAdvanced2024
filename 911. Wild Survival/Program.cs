var beesInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
var beesQueue = new LinkedList<int>();
foreach (var bees in beesInput)
{
    beesQueue.AddLast(bees);
}

var beeEatersInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
var beeEatersStack =  new LinkedList<int>();
foreach (var eater in beeEatersInput)
{
    beeEatersStack.AddLast(eater);
}

while (beesQueue.Any() && beeEatersStack.Any())
{
    var bees = beesQueue.First();
    beesQueue.RemoveFirst();

    var beeEaters = beeEatersStack.Last() * 7;
    beeEatersStack.RemoveLast();
    if (bees > beeEaters)
    {
        var leftBees = bees - beeEaters;
        beesQueue.AddLast(leftBees);
    }
    else if(beeEaters > bees)
    {
        var leftBeeEaters = (beeEaters - bees) / 7;
        if ((beeEaters - bees) % 7 != 0) 
        {
            leftBeeEaters++;
        }

        if (beeEatersStack.Any())
        {
            leftBeeEaters += beeEatersStack.Last();
            beeEatersStack.RemoveLast();
        }

        beeEatersStack.AddLast(leftBeeEaters);
    }
}

Console.WriteLine("The final battle is over!");
if (beesQueue.Count > 0)
{
    Console.WriteLine($"Bee groups left: " + string.Join(", ", beesQueue));
}
else if(beeEatersStack.Count > 0)
{
    Console.WriteLine($"Bee-eater groups left: " + string.Join(", ", beeEatersStack));
}
else
{
    Console.WriteLine("But no one made it out alive!");
}