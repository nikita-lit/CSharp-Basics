namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public interface IVehicle
    {
        public string Type { get; set; }

        public double GetFuelUsage(); // каждые 100 km
        public double GetFuelPrice();
        public double GetTraveledDistance();
    }
}
