var moneyChunks = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var prices = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));


var foodEaten = 0;

while (moneyChunks.Any() && prices.Any())
{
    var moneyChunk = moneyChunks.Last();
    moneyChunks.RemoveLast();

    var price = prices.First();
    prices.RemoveFirst();

    if (price <= moneyChunk)
    {
        foodEaten++;
        var difference = moneyChunk - price;
        if (difference > 0)
        {
            if (moneyChunks.Any())
            {
                difference += moneyChunks.Last();
                moneyChunks.RemoveLast();
            }

            moneyChunks.AddLast(difference);
        }
    }
}

if (foodEaten >= 4)
{
    Console.WriteLine($"Gluttony of the day! Henry ate {foodEaten} foods.");
} 
else if(foodEaten > 0)
{
    Console.WriteLine($"Henry ate: {foodEaten} food{(foodEaten == 1 ? string.Empty : "s")}.");
}
else
{
    Console.WriteLine("Henry remained hungry. He will try next weekend again.");
}