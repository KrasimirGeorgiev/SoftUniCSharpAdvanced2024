using System.Text;

namespace _963._ExamTask3
{
    internal class Creature
    {
        public Creature(string name, string kind, int health, string abilities)
        {
            Name = name;
            Kind = kind;
            Health = health;
            Abilities = abilities.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string Name { get; set; }
        public string Kind { get; set; }
        public int Health { get; set; }
        public List<string> Abilities { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} ({Kind}) has {Health} HP".TrimEnd());
            sb.AppendLine($"Abilities: {string.Join(", ", Abilities)}".TrimEnd());
            return sb.ToString().TrimEnd();//
        }
    }
}
