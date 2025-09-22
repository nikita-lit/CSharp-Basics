namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public class Bicycle : Vehicle
    {
        public Bicycle(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, int passengersCount)
            : base("Jalgratas", fuelType, fuelUsage, fuelPrice, distance, passengersCount)
        { }

        public override double GetFuelUsage()
        {
            return 0;
        }

        public override double CalcFuelPrice()
        {
            return 0;
        }
    }
}
