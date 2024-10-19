using System.Text;

namespace _953._Automotive_Repair_Shop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
                Vehicles.Add(vehicle);
        }

        public bool RemoveVehicle(string vin)
        {
            var vehicleToRemove = Vehicles.Where(x => x.VIN == vin).FirstOrDefault();
            if (vehicleToRemove != null)
                return Vehicles.Remove(vehicleToRemove);

            return false;
        }

        public int GetCount()
            => Vehicles.Count();

        public Vehicle GetLowestMileage()
            => Vehicles.OrderBy(x => x.Mileage).First();

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
