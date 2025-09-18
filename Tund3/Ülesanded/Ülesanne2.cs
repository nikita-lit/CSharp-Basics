using System.Diagnostics.Metrics;

namespace CSharpBasics.Tund3.Ülesanded
{
    //-----------------------------------
    // OSA 5 - Ülesanne 2: Maakonnad ja pealinnad (sõnastik ja test)
    //-----------------------------------
    internal class Ülesanne2
    {
        public static void Start()
        {
            var data = LoadRegionData();
            OpenMenu(data);
        }

        private static void OpenMenu(Dictionary<string, string> data)
        {
            while (true)
            {
                ShowOptions();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Tundmatu valik!");
                    continue;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        FindRegionByCapital(data);
                        break;
                    case 2:
                        FindCapitalByRegion(data);
                        break;
                    case 3:
                        StartQuiz(data);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Tundmatu valik!");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ShowOptions()
        {
            Console.WriteLine("1. Leia maakond pealinna järgi");
            Console.WriteLine("2. Leia pealinn maakonna järgi");
            Console.WriteLine("3. Alusta mängu");
            Console.WriteLine("0. Välju");
            Console.Write("Valik => ");
        }

        private static Dictionary<string, string> LoadRegionData()
        {
            var result = new Dictionary<string, string>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\maakonnad.txt");

            try
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    var split = line.Split('=');
                    result[split[0]] = split[1];
                }
            }
            catch
            {
                Console.WriteLine("Viga failiga!");
            }

            return result;
        }

        private static void WriteToFile(string line)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\maakonnad.txt");

            try
            {
                var writer = new StreamWriter(path, true);
                writer.WriteLine(line);
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }

        private static void FindRegionByCapital(Dictionary<string, string> data)
        {
            Console.Write("Sisesta pealinna nimi => ");

            var capital = Console.ReadLine();
            var region = "";

            foreach (var pair in data)
            {
                if (pair.Value.ToLower() == capital.ToLower())
                {
                    region = pair.Key;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(region))
                Console.WriteLine($"{capital} asub {region}");
            else
            {
                Console.WriteLine("Linna ei leitud.");
                Console.Write("Sisesta maakonna nimi => ");
                var newRegion = Console.ReadLine();
                data[newRegion] = capital;

                WriteToFile($"{newRegion}={capital}");

                Console.WriteLine("Lisatud");
            }
        }

        private static void FindCapitalByRegion(Dictionary<string, string> data)
        {
            Console.Write("Sisesta maakonna nimi => ");
            var region = Console.ReadLine();

            if (data.ContainsKey(region))
                Console.WriteLine($"{region} pealinn on {data[region]}");
            else
            {
                Console.WriteLine("Maakonda ei leitud.");
                Console.Write("Sisesta pealinna nimi => ");
                var newCapital = Console.ReadLine();
                data[region] = newCapital;

                WriteToFile($"{region}={newCapital}");

                Console.WriteLine("Lisatud");
            }
        }

        private static void StartQuiz(Dictionary<string, string> data)
        {
            Console.WriteLine("Mäng algas.");

            int total = 0;
            int correct = 0;

            while (true)
            {
                var pair = data.ElementAt(Random.Shared.Next(data.Count));
                var region = pair.Key;
                var capital = pair.Value;

                bool askRegion = Random.Shared.Next(2) == 0;

                if (askRegion)
                {
                    Console.Write($"Mis on maakonna {region} pealinn? ");
                    var input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input)) 
                        break;

                    total++;
                    if (input.ToLower() == capital.ToLower())
                    {
                        correct++;
                        Console.WriteLine("Õige!");
                    }
                    else
                        Console.WriteLine($"Vale! Õige vastus: {capital}");
                }
                else
                {
                    Console.Write($"Millises maakonnas asub {capital}? ");
                    var input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input)) 
                        break;

                    total++;
                    if (input.ToLower() == region.ToLower())
                    {
                        correct++;
                        Console.WriteLine("Õige!");
                    }
                    else
                        Console.WriteLine($"Vale! Õige vastus: {region}");
                }
            }
        }
    }
}
