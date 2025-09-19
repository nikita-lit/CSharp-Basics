namespace CSharpBasics.Tund4.Ülesanded.Ülessanne1
{
    //-----------------------------------
    // OSA 5 - Ülesanne: Sõidukite liidese rakendamine C# keeles
    //-----------------------------------
    internal class Class
    {
        public class Car : Vehicle
        {
            public Car(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, uint passengersCount)
                : base(fuelType, fuelUsage, fuelPrice, distance, passengersCount)
            { }
        }

        public class Bicycle : Vehicle
        {
            public Bicycle(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, uint passengersCount)
                : base(fuelType, fuelUsage, fuelPrice, distance, passengersCount)
            { }
        }

        public class Bus : Vehicle
        {
            public Bus(FuelType fuelType, double fuelUsage, double fuelPrice, double distance, uint passengersCount)
                : base(fuelType, fuelUsage, fuelPrice, distance, passengersCount)
            { }

            public override double GetFuelUsage()
            {
                return ((_fuelUsage / 100) * _traveledDistance) * PassengersCount;
            }
        }

        public static void Start()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            while (true)
            {
                Console.Write("Sisesta sõiduki tüüp (Auto, Jalgratas, Buss) => ");
                string tüüp = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(tüüp))
                    break;

                Console.WriteLine();

                try
                {
                    switch (tüüp)
                    {
                        case "auto":
                            Console.Write("Kas auto on elektriline? (jah/ei) => ");
                            string electric = Console.ReadLine().ToLower();
                            bool isElectric = electric == "jah";

                            FuelType fuelType = FuelType.Petrol;

                            if (isElectric)
                            {
                                fuelType = FuelType.Electricity;
                                Console.Write("Sisesta kütusekulu (kWh/100 km) => ");
                            }
                            else
                                Console.Write("Sisesta kütusekulu (l/100 km) => ");

                            double fuel = double.Parse(Console.ReadLine());

                            Console.Write("Sisesta vahemaa (km) => ");
                            double dist = double.Parse(Console.ReadLine());

                            if (isElectric)
                                Console.Write("Sisesta kütuse hind (kWh kohta) => ");
                            else
                                Console.Write("Sisesta kütuse hind (liitri kohta) => ");

                            double price = double.Parse(Console.ReadLine());

                            vehicles.Add(new Car(fuelType, fuel, price, dist, 1));
                            break;
                        default:
                            Console.WriteLine("Tundmatu sõiduki tüüp.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Viga! {ex.Message}");
                }

                Console.WriteLine();

                double totalCost = 0;
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.ToString());
                    totalCost += vehicle.GetFuelPrice();
                }

                Console.WriteLine($"Summa: {totalCost:F2} euro");
                Console.WriteLine();
            }
        }
    }
}
