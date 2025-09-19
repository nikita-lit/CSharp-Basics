namespace CSharpBasics.Tund4.Ülesanded.Ülessanne1
{
    public enum FuelType
    {
        None,
        Petrol,
        Electricity,
    }

    public abstract class Vehicle : IVehicle
    {
        protected FuelType _fuelType;
        protected double _fuelUsage;
        protected double _fuelPrice;
        protected double _traveledDistance;
        public uint PassengersCount;

        /// <param name="fuelUsage">l, kWh or 0</param>
        /// <param name="distance">km</param>
        public Vehicle(FuelType fuelType, double fuelUsage, double fuelPrice, double traveledDistance, uint passengersCount)
        {
            _fuelType = fuelType;
            _fuelUsage = fuelUsage;
            _fuelPrice = fuelPrice;
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

            return (_fuelUsage / 100);
        }

        public virtual double GetFuelPrice(double price)
        {
            return GetFuelUsage() * GetTraveledDistance() * price;
        }

        public virtual double GetFuelPrice()
        {
            return GetFuelUsage() * GetTraveledDistance() * _fuelPrice;
        }

        public override string ToString()
        {
            if (_fuelType == FuelType.None)
                return $"Vahemaa: {GetTraveledDistance()} km";

            if (_fuelType == FuelType.Electricity)
                return $"[ Kulu: {GetFuelUsage()} kWh/100 ][ Vahemaa: {GetTraveledDistance()} km ]";

            return $"[ Kulu: {GetFuelUsage()} l/100 ][ Vahemaa: {GetTraveledDistance()} km ]";
        }
    }
}
