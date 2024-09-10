var ordersCapacity = int.Parse(Console.ReadLine());
var ordersForTheDay = Console.ReadLine()
						.Split(' ', StringSplitOptions.RemoveEmptyEntries)
						.Select(int.Parse)
						.ToArray();

var leftOrders = new Queue<int>();
var isDone = false;
var maxOrderOfTheDay = int.MinValue;
foreach (var order in ordersForTheDay)
{
	if (ordersCapacity - order >= 0 && !isDone)
	{
		ordersCapacity -= order;
    }
	else
	{
		leftOrders.Enqueue(order);
		isDone = true;
    }

	maxOrderOfTheDay = Math.Max(maxOrderOfTheDay, order);
}

if (ordersForTheDay.Any())	
	Console.WriteLine(maxOrderOfTheDay);

if (leftOrders.Count > 0)
{
	Console.WriteLine("Orders left: " + string.Join(" ", leftOrders));
}
else
{
    Console.WriteLine("Orders complete");
}
