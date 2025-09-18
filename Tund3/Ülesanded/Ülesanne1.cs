namespace CSharpBasics.Tund3.Ülesanded
{
    public class Product
    {
        public string Name;
        public double Calories;

        public Product(string name, double calories)
        {
            Name = name;
            Calories = calories;
        }
    }

    public class Person
    {
        public string Name;
        public int Age;
        public string Gender;
        public double Height;
        public double Weight;
        public double ActivityLevel;

        public Person(string name, int age, string gender, double height, double weight, double activityLevel)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Height = height;
            Weight = weight;
            ActivityLevel = activityLevel;
        }
    }

    //-----------------------------------
    // OSA 5 - Ülesanne 1: Kalorite kalkulaator klassidega
    //-----------------------------------
    internal class Ülesanne1
    {
        public static void Start()
        {
            var products = Ül1_FindProducts();
            Console.WriteLine("Toodete nimekiri: ");
            products.ForEach(x => Console.WriteLine(x.Name + ", " + x.Calories + " cal"));

            Console.WriteLine();

            while (true)
            {
                Console.Write("Kas te soovite lisada rohkem tooteid? (jah/ei) => ");
                string input = Console.ReadLine().ToLower();
                if (input == "jah")
                {
                    Ül1_AddProduct();
                    products = Ül1_FindProducts();
                }
                else
                    break;
            }

            Console.WriteLine();
            Console.Write("Sisesta oma nimi => ");
            string name = Console.ReadLine();

            Console.Write("Vanus => ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Sugu (m/n) => ");
            string gender = Console.ReadLine().ToLower();

            Console.Write("Pikkus (cm) => ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Kaal (kg) => ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Aktiivsustase: ");
            Console.WriteLine("1. Vähe aktiivne (1.2)");
            Console.WriteLine("2. Kergelt aktiivne (1.375)");
            Console.WriteLine("3. Mõõdukalt aktiivne (1.55)");
            Console.WriteLine("4. Väga aktiivne (1.725)");
            Console.Write("Vali number => ");
            int activityChoice = int.Parse(Console.ReadLine());

            double activityFactor = 1.2;

            if (activityChoice == 1)
                activityFactor = 1.2;
            else if (activityChoice == 2)
                activityFactor = 1.375;
            else if (activityChoice == 3)
                activityFactor = 1.55;
            else if (activityChoice == 4)
                activityFactor = 1.725;

            Person person = new Person(
                name,
                age,
                gender,
                height,
                weight,
                activityFactor
            );

            double cals = Ül1_CalcCal(person);
            Console.WriteLine();
            Console.WriteLine($"{person.Name}, sinu päevane energiavajadus on umbes {Math.Round(cals, 0)} cal.");

            Console.WriteLine();
            Console.WriteLine("Toidud ja sobiv päevane kogus (grammides):");

            Console.WriteLine();

            foreach (Product product in products)
            {
                double amount = ((cals / product.Calories) * 100);
                Console.WriteLine($"{product.Name}: {Math.Round(amount, 2)} g");
            }
        }

        //-----------------------------------
        public static List<Product> Ül1_FindProducts()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\tooted.txt");
            List<Product> list = new List<Product>();

            foreach (string line in File.ReadAllLines(path))
            {
                string[] split = line.Split('=');
                string name = split[0];
                double cal = double.Parse(split[1]);
                list.Add(new Product(name, cal));
            }

            return list;
        }

        //-----------------------------------
        public static void Ül1_AddProduct()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\tooted.txt");

            try
            {
                StreamWriter text = new StreamWriter(path, true); // true = lisa lõppu
                Console.WriteLine("Sisesta toode nimi => ");
                string name = Console.ReadLine();

                Console.WriteLine("Sisesta toode kaal => ");
                double cal = double.Parse(Console.ReadLine());

                text.WriteLine($"{name}={cal}");
                text.Close();

                Console.WriteLine($"Toode {name} lisatud!");
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }

        //-----------------------------------
        public static double Ül1_CalcCal(Person person)
        {
            if (person.Gender == "n")
                return 655.1
                    + (9.563 * person.Weight)
                    + (1.85 * person.Height)
                    - (4.676 * person.Age)
                    * person.ActivityLevel;
            else
                return 66.5
                    + (13.75 * person.Weight)
                    + (5.003 * person.Height)
                    - (6.775 * person.Age)
                    * person.ActivityLevel;
        }
    }
}
