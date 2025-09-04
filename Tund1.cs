namespace CSharpBasics
{
    internal class Startclass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Näide 0:");
            Console.WriteLine("Tere tulemast!");

            Example1();
            Example2();
        }

        public static void Example1()
        {
            Console.WriteLine("Näide 1:");

            Console.WriteLine("Tere tulemast!");
            string eesnimi = Console.ReadLine();
            Console.WriteLine("Tere, " + eesnimi);
        }

        public static void Example2()
        {
            Console.WriteLine("Näide 2:");

            Console.WriteLine("Tere tulemast!");
            string eesnimi = Console.ReadLine();
            Console.WriteLine("Tere, " + eesnimi);
            int arv1 = int.Parse(Console.ReadLine());
            int arv2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Arvude {0} ja {1} korrutis võrdub {2}", arv1, arv2, arv1 * arv2);
        }
    }
}
