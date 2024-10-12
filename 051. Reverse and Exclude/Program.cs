var element = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
var devider = int.Parse(Console.ReadLine());
Predicate<string> isANumber = IsANumber;
Func<int, int, bool> isDevisable = IsDevisible;
ReverseList(element);
element = element.Where(x => !IsANumber(x) || (IsANumber(x) && !IsDevisible(int.Parse(x), devider))).ToList();
Console.WriteLine(string.Join(' ', element));
static bool IsANumber(string n)
    => int.TryParse(n, out var result);

static bool IsDevisible(int n, int devider)
    => n % devider == 0;

void ReverseList(List<string> input)
    => input.Reverse();