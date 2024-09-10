var clothes = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

var capacityOfARack = int.Parse(Console.ReadLine());
var stack = new Stack<int>();
foreach (var item in clothes)
{
    stack.Push(item);
}

var numberOfRacks = 0;
var currentRackNumber = capacityOfARack;
if (stack.Peek() <= capacityOfARack)
{
    currentRackNumber -= stack.Pop();
    numberOfRacks++;

    foreach (var item in stack)
    {
        if (capacityOfARack - item < 0)
            break;

        if (currentRackNumber - item <= 0)
        {
            if (currentRackNumber - item == 0)
            {
                currentRackNumber = 0;
            }
            else
            {
                numberOfRacks++;
                currentRackNumber = capacityOfARack - item;
            }
        }
        else
        {
            currentRackNumber -= item;
        }
    }
}

Console.WriteLine(numberOfRacks);
