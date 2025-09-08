namespace CSharpBasics.Tund2
{
    internal class Class
    {
        public static void Start()
        {
            /*
            List<string> names = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. Nimi: ");
                names.Add(Console.ReadLine());
            }

            Console.WriteLine();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }*/

            /*
            int[] nums = new int[10];

            Console.WriteLine();

            int j = 0;
            while (j < 10)
            {
                Console.WriteLine(j + 1);
                nums[j] = Random.Shared.Next(1, 101);
                j++;
            }

            foreach (int i in nums)
                Console.WriteLine(i);

            Console.WriteLine();*/

            List<Person> persons = new List<Person>();

            int j = 0;
            do
            {
                Console.WriteLine(j + 1);
                Person person = new Person();

                Console.Write("Eesnimi: ");
                person.Name = Console.ReadLine();
                Console.Write("Perenimi: ");
                person.LastName = Console.ReadLine();

                persons.Add(person);
                j++;
            }
            while (j < 3);

            persons.Sort((x, y) => x.Name.CompareTo(y.Name));

            Console.WriteLine("Kokku on " + persons.Count + "isikud");
            foreach (Person person in persons)
                person.Print();

            Console.WriteLine("Kolmandal kohal on " + persons[2].Name + " isik");
        }
    }
}
