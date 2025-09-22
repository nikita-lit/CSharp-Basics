namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public class Car : Vehicle
    {
        public Car(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, int passengersCount)
            : base("Auto", fuelType, fuelUsage, fuelPrice, distance, passengersCount)
        { }
    }
}