namespace _951._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tools = new LinkedList<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var substances = new LinkedList<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var challanges = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (tools.Any() && substances.Any() && challanges.Any()) 
            {
                var tool = tools.First();
                var substance = substances.Last();
                var result = tool * substance;
                var hasEqualChallange = challanges.Where(x => x == result).Any();
                if (hasEqualChallange) 
                {
                    challanges.Remove(result);
                    tools.RemoveFirst();
                    substances.RemoveLast();
                }
                else
                {
                    tool++;
                    tools.AddLast(tool);
                    tools.RemoveFirst();

                    substance--;
                    substances.RemoveLast();
                    if (substance > 0) 
                    {
                        substances.AddLast(substance);
                    }
                }
            }

            if (challanges.Any()) 
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            
            if (tools.Any())
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            if (substances.Any())
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            if (challanges.Any())
                Console.WriteLine($"Challenges: {string.Join(", ", challanges)}");
        }
    }
}
