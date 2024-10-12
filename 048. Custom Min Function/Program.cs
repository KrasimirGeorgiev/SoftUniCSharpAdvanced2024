var input = Console.ReadLine();

Func<string, int> returnMinNumber = (x) => smallestNumber(x);

Console.WriteLine(returnMinNumber(input));
int smallestNumber(string numbersInput)
{
    var minNumber = numbersInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Min();
    return minNumber;
}