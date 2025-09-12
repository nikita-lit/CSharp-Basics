using System.Reflection;

namespace CSharpBasics.Tund3
{
    class Toode
    {
        public string Name;
        public double Calories;

        public Toode(string name, double calories)
        {
            Name = name;
            Calories = calories;
        }
    }

    class Inimene
    {
        public string Name;
        public int Age;
        public string Gender;
        public double Height;
        public double Weight;
        public double ActivityLevel;

        public Inimene(string name, int age, string gender, double height, double weight, double activityLevel)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Height = height;
            Weight = weight;
            ActivityLevel = activityLevel;
        }
    }

    internal class Assign
    {
        public static void Start()
        {
            Ül1();
        }

        public static List<Toode> Ül1_FindProducts()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\tooted.txt");
            List<Toode> list = new List<Toode>();

            foreach (string line in File.ReadAllLines(path))
            {
                string[] split = line.Split('=');
                string name = split[0];
                double cal = double.Parse(split[1]);
                list.Add(new Toode(name, cal));
            }

            return list;
        }

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

        public static double Ül1_CalcCal(Inimene inim)
        {
            if (inim.Gender == "n")
                return 655.1 
                    + (9.563 * inim.Weight) 
                    + (1.85 * inim.Height) 
                    - (4.676 * inim.Age) 
                    * inim.ActivityLevel;
            else
                return 66.5 
                    + (13.75 * inim.Weight) 
                    + (5.003 * inim.Height) 
                    - (6.775 * inim.Age) 
                    * inim.ActivityLevel;
        }

        public static void Ül1()
        {
            var tooted = Ül1_FindProducts();
            Console.WriteLine("Toodete nimekiri: ");
            tooted.ForEach(x => Console.WriteLine(x.Name + ", " + x.Calories + " cal"));

            Console.WriteLine();

            while(true)
            {
                Console.Write("Kas te soovite lisada rohkem tooteid? (jah/ei) => ");
                string input = Console.ReadLine().ToLower();
                if (input == "jah")
                {
                    Ül1_AddProduct();
                    tooted = Ül1_FindProducts();
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

            Inimene person = new Inimene(
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

            foreach (Toode toode in tooted)
            {
                double amount = ((cals / toode.Calories) * 100);
                Console.WriteLine($"{toode.Name}: {Math.Round(amount, 2)} g");
            }
        }
    }
}
