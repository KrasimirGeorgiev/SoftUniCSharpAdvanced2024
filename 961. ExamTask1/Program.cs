namespace _961._ExamTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strengths = new LinkedList<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var accuracies = new LinkedList<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var goals = 0;
            while (strengths.Any() && accuracies.Any()) 
            {
                var strength = strengths.Last();
                var accuracy = accuracies.First();
                var sum = strength + accuracy;
                if (sum == 100) 
                {
                    goals++;
                    strengths.RemoveLast();
                    accuracies.RemoveFirst();
                }
                else if (sum < 100)
                {
                    if (strength < accuracy) 
                    {
                        strengths.RemoveLast();
                    }
                    else if(accuracy < strength)
                    {
                        accuracies.RemoveFirst();
                    }
                    else
                    {
                        strengths.RemoveLast();
                        accuracies.RemoveFirst();
                        strengths.AddLast(sum);
                    }
                }
                else if (sum > 100)
                {
                    strengths.RemoveLast();
                    accuracies.RemoveFirst();
                    strengths.AddLast(strength - 10);
                    accuracies.AddLast(accuracy);
                }
            }
            if(goals == 0)
            {
                Console.WriteLine("Paul failed to score a single goal.");
            }
            else if (goals == 3) 
            {
                Console.WriteLine("Paul scored a hat-trick!");
            }
            else if(goals > 0 && goals < 3)
            {
                Console.WriteLine("Paul failed to make a hat-trick.");
            }
            else 
            {
                Console.WriteLine("Paul performed remarkably well!");
            }

            if (goals != 0)
            {
                Console.WriteLine($"Goals scored: {goals}");
            }

            if (strengths.Any())
            {
                Console.WriteLine($"Strength values left: {string.Join(", ", strengths.Reverse())}");
            }
            else if(accuracies.Any())
            {
                Console.WriteLine($"Accuracy values left: {string.Join(", ", accuracies)}");
            }
        }
    }
}
