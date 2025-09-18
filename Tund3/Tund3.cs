namespace CSharpBasics.Tund3
{
    internal class Class
    {
        //задания 1, 2 и на выбор

        public static void Start()
        {
            /*
            string pathKuudtxt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\tund3\\kuud.txt");
            FileWrite(pathKuudtxt);

            Console.WriteLine();
            Console.WriteLine("--------------- File Read ---------------");
            FileRead(pathKuudtxt).ForEach(x => Console.WriteLine(x));*/

            Ülesanded.Ülesanne1.Start();
        }

        public static void FileWrite(string pathKuudtxt)
        {
            try
            {
                StreamWriter text = new StreamWriter(pathKuudtxt, true); // true = lisa lõppu
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();
                text.WriteLine(lause);
                text.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }

        public static List<string> FileRead(string pathKuudtxt)
        {
            List<string> kuude_list = new List<string>();
            try
            {
                foreach (string rida in File.ReadAllLines(pathKuudtxt))
                    kuude_list.Add(rida);
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }

            return kuude_list;
        }
    }
}
