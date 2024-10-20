using System.Text;

namespace _963._ExamTask3
{
    internal class MythicalCreaturesHub
    {
        public MythicalCreaturesHub(int capacity)
        {
            Capacity = capacity;
            Creatures = new List<Creature>();
        }
        public List<Creature> Creatures { get; set; }

        public int Capacity { get; set; }

        public void AddCreature(Creature creature)
        {
            if (Creatures.Count() < Capacity && !Creatures.Where(x => x.Name.ToLower() == creature.Name.ToLower()).Any())
            {
                Creatures.Add(creature);
            }
            else
            {
                return;
            }
        }

        public bool RemoveCreature(string name)
        {
            var creature = Creatures.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault(); // mabe not tolower
            if (creature != null)
            {
                return Creatures.Remove(creature);
            }

            return false;
        }

        public Creature GetStrongestCreature()
        {
            return Creatures.OrderByDescending(x => x.Health).FirstOrDefault();
        }

        public string Details(string creatureName)
        {
            var creature = Creatures.Where(x => x.Name.ToLower() == creatureName.ToLower()).FirstOrDefault(); // maybe not tolower
            if (creature != null)
            {
                return creature.ToString();
            }
            else
            {
                return $"Creature with the name {creatureName} not found.";
            }
        }

        public string GetAllCreatures()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Mythical Creatures:".TrimEnd());
            foreach (var creature in Creatures.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{creature.Name} -> {creature.Kind}".TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
