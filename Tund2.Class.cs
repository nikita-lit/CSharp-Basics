namespace CSharpBasics.Tund2
{
    internal class Person
    {
        public string Name;
        public string LastName = "Tundmatu";
        public int BirthYear = 2000;

        public Person() { }

        public Person(string name, string lastName, int birthYear)
        {
            Name = name;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public void Print()
        {
            Console.WriteLine($"Isiku andmed: {Name} {LastName}, Sündinud: {BirthYear}");
        }
    }
}
