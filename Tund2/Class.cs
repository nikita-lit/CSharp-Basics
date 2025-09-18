namespace CSharpBasics.Tund2
{
    internal class Person
    {
        public string Name;
        public string LastName = "Tundmatu";
        public int Age = 16;

        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"Isiku andmed: {Name} {LastName}");
        }
    }
}
