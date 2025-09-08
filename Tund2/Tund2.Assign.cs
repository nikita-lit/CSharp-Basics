namespace CSharpBasics.Tund2
{
    internal class Assign
    {
        public static void Start()
        {
            GenereeriRuudud(0, 10);

            var result2 = AnalüüsiArve(From_numbers());
            Console.WriteLine($"Summa: {result2.Item1}");
            Console.WriteLine($"Keskmine: {result2.Item2}");
            Console.WriteLine($"korrutis: {result2.Item3}");

            Inimised();
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

            var statistika = Statistika(people);

            Console.WriteLine($"Vanuste summa: {statistika.Item1}");
            Console.WriteLine($"Vanuste keskmine: {statistika.Item2}");
            Console.WriteLine($"Vanim inimene: {statistika.Item3.Name}, {statistika.Item3.Age} aastat");
            Console.WriteLine($"Noorim inimene: {statistika.Item4.Name}, {statistika.Item4.Age} aastat");
        }

        public static Tuple<int, double, Person, Person> Statistika(List<Person> people)
        {
            int sum = people.Sum(i => i.Age);
            double average = people.Average(i => i.Age);

            Person oldest = people.OrderByDescending(i => i.Age).First();
            Person youngest = people.OrderBy(i => i.Age).First();

            return Tuple.Create(sum, average, oldest, youngest);
        }
    }
}