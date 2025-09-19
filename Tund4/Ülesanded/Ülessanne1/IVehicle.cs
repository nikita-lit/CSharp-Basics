namespace CSharpBasics.Tund4.Ülesanded.Ülessanne1
{
    public interface IVehicle
    {
        public double GetFuelUsage(); // каждые 100 km
        public double GetFuelPrice();
        public double GetFuelPrice(double price);
        public double GetTraveledDistance();
    }
}
