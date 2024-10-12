var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
var operation = Console.ReadLine();

while (operation != "end")
{
    if (operation == "add")
        input = input.Select(Add).ToList();
    else if (operation == "multiply")
        input = input.Select(Multiply).ToList();
    else if (operation == "subtract")
        input = input.Select(Substract).ToList();
    else if (operation == "print")
        PrintTheCollection(input);

    operation = Console.ReadLine();
}


static int Add(int n) => n++;

static int Multiply(int n) => n * 2;

static int Substract(int n) => n--;

static void PrintTheCollection(List<int> list)
{
    Console.WriteLine(string.Join(' ', list));
}