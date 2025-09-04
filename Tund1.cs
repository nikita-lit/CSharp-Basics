using System.Text;

namespace CSharpBasics.Tund1
{
    internal class Startclass
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.OutputEncoding = Encoding.UTF8;

            Random random = new();

            int randomA = random.Next(-100, 200);
            Console.WriteLine(randomA);

            Tund1Methods methods = new Tund1Methods();
            Console.WriteLine("Kalkulaatori tulemus: " + methods.Calculator(randomA, 2));

            /*
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

            bool b = true;
            Console.WriteLine(b);*/
        }
    }
}
