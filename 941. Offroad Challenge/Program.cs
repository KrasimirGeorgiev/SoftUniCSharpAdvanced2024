var fuelStack = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var consumtionQueue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var necessaryFuel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
var count = 0;
bool hasReachedAny = false;

while (fuelStack.Any() && consumtionQueue.Any())
{
    count++;
    var fuel = fuelStack.Peek();
    var consumtion = consumtionQueue.Peek();
    var necessary = necessaryFuel.Peek();

    if (fuel - consumtion >= necessary)
    {
        hasReachedAny = true;
        fuelStack.Pop();
        consumtionQueue.Dequeue();
        necessaryFuel.Dequeue();
        Console.WriteLine($"John has reached: Altitude {count}");
    }
    else 
    {
        Console.WriteLine($"John did not reach: Altitude {count}");
        Console.WriteLine("John failed to reach the top.");
        if (hasReachedAny)
        {
            Console.Write("Reached altitudes: ");
            var altitudeString = new List<string>();
            for (int i = 1; i < count; i++)
            {
                altitudeString.Add($"Altitude {i}");
            }

            Console.WriteLine(string.Join(", ", altitudeString));
        }
        else
        {
            Console.WriteLine("John didn't reach any altitude.");
        }

        return; 
    }

    if (necessaryFuel.Count == 0)
    {
        Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
        return;
    }
}
