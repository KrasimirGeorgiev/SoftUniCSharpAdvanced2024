var packages = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var couriers = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var weight = 0;

while (packages.Count > 0 && couriers.Count > 0)
{
    var package = packages.Last();
    packages.RemoveLast();

    var courier = couriers.First();
    couriers.RemoveFirst();

    if (package <= courier)
    {
        weight += package;
        courier = courier - (2 * package);
        if (courier > 0)
        {
            couriers.AddLast(courier);
        }
    }
    else
    {
        var ramaining = package - courier;
        packages.AddLast(ramaining);
        weight += courier;
    }
}

Console.WriteLine($"Total weight: {weight} kg");
if (packages.Count == 0 && couriers.Count == 0)
{
    Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
}
else if(couriers.Count == 0)
{
    Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: " + string.Join(", ", packages));
} 
else if(packages.Count == 0)
{
    Console.WriteLine($"Couriers are still on duty: " + string.Join(", ", couriers) + " but there are no more packages to deliver.");
}