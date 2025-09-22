namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public class Bus : Vehicle
    {
        public Bus(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, int passengersCount)
            : base("Buss", fuelType, fuelUsage, fuelPrice, distance, passengersCount)
        { }

        public override double GetFuelPrice()
        {
            double totalCost = GetFuelUsage() * FuelPrice;
            if (PassengersCount > 0)
                return totalCost / PassengersCount;

            return totalCost;
        }
    }
}
