var splitLine1 = Console.ReadLine().Split();
var numbersToPushInToStack = int.Parse(splitLine1[0]);
var numbersToPopFromTheStack = int.Parse(splitLine1[1]);
var numberToLookFor = int.Parse(splitLine1[2]);

var splitLine2 = Console.ReadLine().Split();

var stack = new Stack<int>();

var n = Math.Min(numbersToPushInToStack, splitLine2.Length);
for (int i = 0; i < n; i++)
{
    var currentNumberToAdd = int.Parse(splitLine2[i]);
    stack.Push(currentNumberToAdd);
}

while (numbersToPopFromTheStack > 0 && stack.Count() > 0)
{
    stack.Pop();
    numbersToPopFromTheStack--;
}

if (stack.Contains(numberToLookFor))
{
    Console.WriteLine("true");
}
else if (stack.Count() == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(stack.Min());
}