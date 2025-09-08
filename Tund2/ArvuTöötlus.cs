using System.IO;

namespace CSharpBasics.Tund2
{
    internal class ArvuTöötlus
    {
        public static void Main(string[] args)
        {
            GenereeriRuudud(0, 10);

            var result2 = AnalüüsiArve(From_numbers());
            Console.WriteLine($"Summa: {result2.Item1}");
            Console.WriteLine($"Keskmine: {result2.Item2}");
            Console.WriteLine($"korrutis: {result2.Item3}");
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
    }
}
