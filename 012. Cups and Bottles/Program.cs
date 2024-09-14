var cupsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
var bottlesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
var initialCupsCount = cupsQueue.Count();
var initialBottlesCount = bottlesStack.Count();
var wastedWaterInLiters = 0;
var currentCupValue = -1;
while (cupsQueue.Any() && bottlesStack.Any())
{
    var currentCup = currentCupValue == -1 ? cupsQueue.Peek() : currentCupValue;
    var currentBottle = bottlesStack.Pop();

    if (currentBottle < currentCup)
    {
        currentCupValue = currentCup - currentBottle;
    }
    else
    {
        wastedWaterInLiters += currentBottle - currentCup;
        cupsQueue.Dequeue();
        currentCupValue = -1;
    }
}

if (cupsQueue.Any())
{
    Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
}
else
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
}

Console.WriteLine($"Wasted litters of water: {wastedWaterInLiters}");