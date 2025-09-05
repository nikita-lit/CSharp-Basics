using System.Text;

namespace CSharpBasics.Tund1
{
    internal class Class
    {
        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.OutputEncoding = Encoding.UTF8;

            Assign.Start();

            /*
            // Part 2, Choices (switch, if and etc.)
            int monthNum = Random.Shared.Next(1, 12);
            string month = Methods.GetMonthName(monthNum);
            string season = Methods.GetSeasonName(monthNum);
            Console.WriteLine($"Kuu number: {monthNum}; Kuu nimi: {month}; See on {season}.");

            Console.Write("\nKas tahad dekodeerida arv->nimetusse? => ");
            string input = Console.ReadLine();
            if (input.ToLower() != "jah")
                Console.WriteLine("Ei taha, siis ei taha");
            else
            {
                try
                {
                    Console.Write("Nr => ");
                    monthNum = int.Parse(Console.ReadLine());

                    month = Methods.GetMonthName(monthNum);
                    season = Methods.GetSeasonName(monthNum);
                    Console.WriteLine($"Kuu number: {monthNum}; Kuu nimi: {month}; See on {season}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Viga! {ex.Message}");
                }
            }*/

            /*
            // Part 1; Data types, methods
            Random random = new();

            int randomA = random.Next(-100, 200);
            Console.WriteLine(randomA);

            Console.WriteLine("Kalkulaatori tulemus: " + Tund1Methods.Calculator(randomA, 2));

            Console.WriteLine("Tere tulemast!");
            Console.Write("Mis on sinu nimi? => ");

            string eesnimi = Console.ReadLine();
            Console.WriteLine($"{eesnimi}, Rõõm näha\n");

            int a = 1000;
            char character = 'A';

            Console.Write($"a on {a}, Sisesta b => ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"a + b = {a + b}");

            Console.WriteLine("Ujukomaarv");

            double d = double.Parse(Console.ReadLine());
            Console.WriteLine(d);

            float fl = float.Parse(Console.ReadLine());
            Console.WriteLine(fl);

            bool bol = true;
            Console.WriteLine(bol);*/
        }
    }
}
