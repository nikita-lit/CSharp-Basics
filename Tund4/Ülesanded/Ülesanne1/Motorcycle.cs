namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, int passengersCount)
            : base("Mootorratas", fuelType, fuelUsage, fuelPrice, distance, passengersCount)
        { }
    }
}
