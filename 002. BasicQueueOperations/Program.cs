var splitLine1 = Console.ReadLine().Split();
var numbersToPushInToQueue = int.Parse(splitLine1[0]);
var numbersToPopFromTheQueue = int.Parse(splitLine1[1]);
var numberToLookFor = int.Parse(splitLine1[2]);

var splitLine2 = Console.ReadLine().Split();

var queue = new Queue<int>();

var n = Math.Min(numbersToPushInToQueue, splitLine2.Length);
for (int i = 0; i < n; i++)
{
    var currentNumberToAdd = int.Parse(splitLine2[i]);
    queue.Enqueue(currentNumberToAdd);
}

while (numbersToPopFromTheQueue > 0 && queue.Count() > 0)
{
    queue.Dequeue();
    numbersToPopFromTheQueue--;
}

if (queue.Contains(numberToLookFor))
{
    Console.WriteLine("true");
}
else if (queue.Count() == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(queue.Min());
}