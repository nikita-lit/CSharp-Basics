using System;

namespace CSharpBasics.Tund2
{
    internal class Assign
    {
        public static void Start()
        {
            // ül 1
            //GenereeriRuudud(0, 10);

            // ül 2
            //var result2 = AnalüüsiArve(From_numbers());
            //Console.WriteLine($"Summa: {result2.Item1}");
            //Console.WriteLine($"Keskmine: {result2.Item2}");
            //Console.WriteLine($"korrutis: {result2.Item3}");

            // ül 3
            //Inimised();

            // ül 4
            //Console.WriteLine();
            //Console.Write("Sisesta märksõna => ");
            //string input = Console.ReadLine();
            //Console.WriteLine("Tubli! Märksõna oli " + KuniMärksõnani(input));

            // ül 5
            //ArvaArv();

            // ül 6
            SuurimNeljarv();

            // ül 7
            //GenereeriKorrutustabel(5, 10);
        }

        public static int[] GenereeriRuudud(int min, int max)
        {
            Random rnd = new Random();

            int N = rnd.Next(min, max + 1);
            int M = rnd.Next(min, max + 1);

            Console.WriteLine($"Juhuslikud arvud: {N} ja {M}");

            int size = Math.Abs(M - N) + 1;
            int[] squares = new int[size];

            if (N <= M)
            {
                for (int i = N; i <= M; i++)
                {
                    squares[i - N] = i * i;
                    Console.WriteLine($"{i} - {squares[i - N]}");
                }
            }
            else
            {
                for (int i = N; i >= M; i--)
                {
                    squares[N - i] = i * i;
                    Console.WriteLine($"{i} - {squares[N - i]}");
                }
            }

            return squares;
        }

        public static double[] From_numbers()
        {
            Console.WriteLine();
            Console.Write("Sisesta 5 numbrit => ");

            double[] numbers = new double[5];
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }

            return numbers;
        }

        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double sum = 0;
            double product = 1;

            foreach (double num in arvud)
            {
                sum += num;
                product *= num;
            }

            double average = sum / arvud.Length;
            return Tuple.Create(sum, average, product);
        }

        public static void Inimised()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta {i + 1}. inimese nimi => ");
                string name = Console.ReadLine();

                int age;
                while (true)
                {
                    Console.Write($"Sisesta {name} vanus => ");
                    if (!int.TryParse(Console.ReadLine(), out age) && age <= 0)
                        Console.WriteLine("Viga!");
                    else
                        break;
                }

                people.Add(new Person(name, age));
            }

            var stats = Statistika(people);

            Console.WriteLine($"Vanuste summa: {stats.Item1}");
            Console.WriteLine($"Vanuste keskmine: {stats.Item2}");
            Console.WriteLine($"Vanim inimene: {stats.Item3.Name}, {stats.Item3.Age} aastat");
            Console.WriteLine($"Noorim inimene: {stats.Item4.Name}, {stats.Item4.Age} aastat");
        }

        public static Tuple<int, double, Person, Person> Statistika(List<Person> people)
        {
            int sum = people.Sum(i => i.Age);
            double average = people.Average(i => i.Age);

            Person oldest = people.OrderByDescending(i => i.Age).First();
            Person youngest = people.OrderBy(i => i.Age).First();

            return Tuple.Create(sum, average, oldest, youngest);
        }

        public static string KuniMärksõnani(string märksõna)
        {
            List<string> strings = new List<string>();
            string fraas = "";

            do
            {
                Console.WriteLine("Arva ära!");
                fraas = Console.ReadLine();
            }
            while (fraas.ToLower() != märksõna.ToLower());

            return fraas;
        }

        public static void ArvaArv()
        {
            int randNum = Random.Shared.Next(1, 100);
            int num = 0;
            int tryCount = 5;

            do
            {
                Console.WriteLine($"Arva ära! {tryCount} katset.");
                num = int.Parse(Console.ReadLine());
                if (num < randNum)
                    Console.WriteLine("Liiga väike");
                else if (num > randNum)
                    Console.WriteLine("Liiga suur");
                else if (num != randNum)
                    Console.WriteLine("Vale!");

                tryCount--;
            }
            while(num != randNum && tryCount > 0);

            if (tryCount <= 0)
                Console.WriteLine("Katse ei ole jäänud!");
            else
                Console.WriteLine($"Õige!");

            Console.WriteLine($"Arv oli {randNum}");

            Console.WriteLine();
            Console.Write("Kas te soovite uuesti mängida? (jah/ei) => ");

            string input = Console.ReadLine().ToLower();
            if (input == "jah")
            {
                Console.WriteLine();
                ArvaArv();
            }
        }

        public static void SuurimNeljarv()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i+1}. Arv");

                while(true)
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num >= 0 && num < 10)
                    {
                        list.Add(num);
                        break;
                    }
                    else
                        Console.WriteLine("Vale arv! Ainult 0-9");
                }

                Console.WriteLine();
            }

            list.Sort((x, y) => y.CompareTo(x));

            string result = string.Join("", list);
            Console.WriteLine("Suurim neliarvuline arv: " + result);
        }

        public static void GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
        {
            /*
            for (int i = 1; i <= ridadeArv; i++)
            {
                for (int j = 1; j <= veergudeArv; j++)
                {
                    Console.Write($"{i * j} ");
                }
                Console.WriteLine();
            }
            */
        }
    }
}