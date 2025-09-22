namespace CSharpBasics.Tund4.Ülesanded.Ülesanne1
{
    //-----------------------------------
    // OSA 5 - Ülesanne: Sõidukite liidese rakendamine C# keeles
    //-----------------------------------
    internal class Class
    {
        public static void Start()
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            List<string> vehiclesNames = new List<string>()
            {
                "auto",
                "jalgratas",
                "buss",
                "mootorratas",
            };

            while (true)
            {
                Console.Write("Kasutada txt-faili (Sõidukid.text) sisendandmetena? (jah/ei) => ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "jah")
                {
                    vehicles = LoadDataFromTXT(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund4\\ülesanded\\ülesanne1\\sõidukid.txt"));
                    break;
                }

                Console.Write("Sisesta sõiduki tüüp (");
                vehiclesNames.ForEach(x => Console.Write(" "+x));
                Console.Write(" ) või 'ei', et lõpetada => ");

                string type = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(type))
                    break;

                if (type == "ei")
                    break;

                if (!vehiclesNames.Contains(type))
                {
                    Console.WriteLine("Tundmatu sõiduki tüüp.");
                    break;
                }

                Console.WriteLine();

                try
                {
                    FuelType fuelType = FuelType.Petrol;
                    bool isElectric = false;
                    double fuel = 0;
                    double price = 0;
                    int passengers = 1;

                    if (type == "auto" || type == "buss" || type == "mootorratas")
                    {
                        Console.Write($"Kas {type} on elektriline? (jah/ei) => ");
                        string electric = Console.ReadLine().ToLower();
                        isElectric = electric == "jah";

                        if (isElectric)
                        {
                            fuelType = FuelType.Electricity;
                            Console.Write("Sisesta kütusekulu (kWh/100 km) => ");
                        }
                        else
                            Console.Write("Sisesta kütusekulu (l/100 km) => ");

                        fuel = double.Parse(Console.ReadLine());

                        if (isElectric)
                            Console.Write("Sisesta kütuse hind (kWh kohta) => ");
                        else
                            Console.Write("Sisesta kütuse hind (liitri kohta) => ");

                        price = double.Parse(Console.ReadLine());
                    }

                    Console.Write("Sisesta vahemaa (km) => ");
                    double dist = double.Parse(Console.ReadLine());

                    if (type == "buss")
                    {
                        while(true)
                        {
                            Console.Write("Sisesta reisijate arv => ");
                            passengers = int.Parse(Console.ReadLine());
                            if (passengers > 0)
                                break;
                            else if (passengers <= 0)
                                Console.WriteLine("Viga! Reisijate arv ei saa olla 0 või negatiivne.");
                        }
                    }

                    vehicles.Add(CreateVehicle(type, fuelType, fuel, price, dist, passengers));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Viga! {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            double totalCost = 0;
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Type + ": ");
                Console.WriteLine(vehicle.ToString());
                totalCost += vehicle.GetFuelPrice();
                Console.WriteLine($"Hind: {vehicle.GetFuelPrice()} euro");
                Console.WriteLine();
            }

            Console.WriteLine($"Summa: {totalCost:F2} euro");
            Console.WriteLine();
        }

        public static List<IVehicle> LoadDataFromTXT(string path)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            try
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] split = line.Split('=');
                    string type = split[0];
                    string data = split[1];

                    string[] split2 = data.Split(";");

                    FuelType fuelType = (FuelType)int.Parse(split2[0]);
                    double fuel = double.Parse(split2[1]); 
                    double price = double.Parse(split2[2]); 
                    double dist = double.Parse(split2[3]);
                    int passengers = 1;

                    if (type == "buss")
                        passengers = int.Parse(split2[4]);

                    vehicles.Add(CreateVehicle(type, fuelType, fuel, price, dist, passengers));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Viga failiga! {e}");
            }

            return vehicles;
        }

        public static IVehicle CreateVehicle(string type, FuelType fuelType, double fuel, double price, double dist, int passengers)
        {
            if (type == "auto")
                return new Car(fuelType, fuel, price, dist, 1);
            else if (type == "buss")
                return new Bus(fuelType, fuel, price, dist, passengers);
            else if (type == "jalgratas")
                return new Bicycle(FuelType.None, 0, 0, dist, 1);
            else if (type == "mootorratas")
                return new Motorcycle(fuelType, fuel, price, dist, 1);

            return null;
        }
    }
}
