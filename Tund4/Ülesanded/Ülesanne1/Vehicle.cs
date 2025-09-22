namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    public enum FuelType
    {
        None,
        Petrol,
        Electricity,
    }

    public abstract class Vehicle : IVehicle
    {
        public string Type { get; set; }

        protected FuelType _fuelType;
        protected double _fuelUsage;
        public double FuelPrice;
        protected double _traveledDistance;
        public int PassengersCount;

        public Vehicle(string type, FuelType fuelType, double fuelUsage, double fuelPrice, double traveledDistance, int passengersCount)
        {
            Type = type;
            _fuelType = fuelType;
            _fuelUsage = fuelUsage;
            FuelPrice = fuelPrice;
            _traveledDistance = traveledDistance;
            PassengersCount = passengersCount;
        }

        public virtual double GetTraveledDistance()
        {
            return _traveledDistance;
        }

        public virtual double GetFuelUsage()
        {
            if (_fuelType == FuelType.None)
                return 0;

            return _fuelUsage;
        }

        public virtual double GetFuelPrice()
        {
            return GetFuelUsage() * (GetTraveledDistance() / 100) * FuelPrice;
        }

        public override string ToString()
        {
            if (_fuelType == FuelType.None)
                return $"[ Vahemaa: {GetTraveledDistance()} km ]";

            string fuelType = "l";
            if (_fuelType == FuelType.Electricity)
                fuelType = "kWh";

            return $"[ Kulu: {GetFuelUsage()} {fuelType}/100 km ][ Kütuse hind: {FuelPrice} euro ({fuelType} kohta) ][ Vahemaa: {GetTraveledDistance()} km ][ Reisijate arv: {PassengersCount} ]";
        }
    }
}
