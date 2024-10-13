var points = int.Parse(Console.ReadLine());
var names = Console.ReadLine().Split();

Console.WriteLine(names.Where(x => NumberOfChars(x) >= points).First());

int NumberOfChars(string str)
    => str.Select(x => (int)x).Sum();
