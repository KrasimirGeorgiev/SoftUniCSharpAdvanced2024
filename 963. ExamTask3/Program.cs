namespace _963._ExamTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var creature = new Creature("Gorak", "Orc", 100, "Smash, Roar");
            var creature2 = new Creature("Elora", "Elf", 80, "Heal, Arrow Shot");
            var creature3 = new Creature("Drakon", "Dragon", 200, "Fire Breath");
            var hub = new MythicalCreaturesHub(3);
            hub.AddCreature(creature);
            hub.AddCreature(creature2);
            hub.AddCreature(creature3);
            var asdf = hub.GetAllCreatures();
            var actualResult = $"Mythical Creatures:{Environment.NewLine}Drakon -> Dragon{Environment.NewLine}Elora -> Elf{Environment.NewLine}Gorak -> Orc";
            Console.WriteLine(asdf);
            Console.WriteLine(actualResult);
            Console.WriteLine(asdf == actualResult);
        }
    }
}
