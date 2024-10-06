using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public bool AddShark(Shark shark)
        {
            if (Capacity > GetCount && !Species.Contains(shark))
            {
                Species.Add(shark);
                return true;
            }

            return false;
        }

        public bool RemoveShark(string kind)
            => Species.Remove(Species.Where(x => x.Kind == kind).FirstOrDefault());

        public string GetLargestShark()
            => Species.OrderByDescending(x => x.Length).First().ToString();

        public double GetAverageLength()
            => Species.Select(x => x.Length).Average();

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
