var rowsCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Console.WriteLine(rowsCols[0]);
Console.WriteLine(rowsCols[1]);
int sum = 0;

for (int i = 0; i < rowsCols[0]; i++)
{
    sum += Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
}

Console.WriteLine(sum);