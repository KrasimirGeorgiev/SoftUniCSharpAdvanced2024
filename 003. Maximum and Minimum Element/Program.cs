
internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var currentCommant = line[0];

            switch (currentCommant)
            {
                case 1: stack.Push(line[1]); break;
                case 2:
                    if (stack.Count() > 0)
                    {
                        stack.Pop();
                    }
                    break;
                case 3:
                    if (stack.Count() > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    break;
                case 4:
                    if (stack.Count() > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    break;
            }
        }

        if (stack.Count() > 0) 
        {
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}