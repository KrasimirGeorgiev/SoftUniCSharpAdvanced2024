using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates = new List<RealEstate>();
        }

        public int Capacity { get; set; }
        public List<RealEstate> RealEstates { get; set; }
        public int Count => RealEstates.Count;

        public bool AddRealEstate(RealEstate realEstate)
        {
            if (Count < Capacity && !RealEstates.Contains(realEstate))
            {
                RealEstates.Add(realEstate);
                return true;
            }

            return false;
        }

        public bool RemoveRealEstate(string address)
            => RealEstates.Remove(RealEstates.FirstOrDefault(r => r.Address == address));

        public List<RealEstate> GetRealEstates(string postalCode)
            => RealEstates.Where(x => x.PostalCode == postalCode).ToList();

        public RealEstate GetCheapest()
            => RealEstates.OrderBy(x => x.Price).First();

        public double GetLargest()
            => RealEstates.OrderByDescending(x => x.Size).First().Size;

        public string EstateReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Real estates available:");
            foreach (var realEstate in RealEstates)
            {
                sb.AppendLine(realEstate.ToString());
            }

            return sb.ToString().Trim();
        }

        public RealEstate GetRealEstate(string address)
            => RealEstates.FirstOrDefault(r => r.Address == address);
    }
}
