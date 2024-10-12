Predicate<int> isEven = IsEven;
Predicate<int> isOdd = IsOdd;

var range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var condition = Console.ReadLine();
var result = new List<int>();
for (int i = range[0]; i <= range[1]; i++)
{
    if (condition == "even" && IsEven(i)
        || condition == "odd" && IsOdd(i))
    {
        result.Add(i);
    }
}

Console.WriteLine(string.Join(" ", result));

static bool IsEven(int number) => number % 2 == 0;
static bool IsOdd(int number) => number % 2 != 0;