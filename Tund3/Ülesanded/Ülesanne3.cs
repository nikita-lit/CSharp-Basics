namespace CSharpBasics.Tund3.Ülesanded
{
    public class Student
    {
        public string Name;
        public List<int> Grades = new List<int>();

        public Student(string nimi)
        {
            Name = nimi;
        }

        public void AddGrade(int grade)
        {
            if (grade < 1 || grade > 5)
            {
                Console.WriteLine($"Viga! Hinne - {grade}, Ainult 1-5");
                return;
            }

            Grades.Add(grade);
        }
    }

    //-----------------------------------
    // OSA 5 - Ülesanne 3: Õpilased ja hinnete analüüs
    //-----------------------------------
    internal class Ülesanne3
    {
        public static void Start()
        {
            var nikita = new Student("Nikita");
            nikita.AddGrade(4);
            nikita.AddGrade(5);
            nikita.AddGrade(5);

            var vlad = new Student("Vlad");
            vlad.AddGrade(2);
            vlad.AddGrade(5);
            vlad.AddGrade(4);
            vlad.AddGrade(4);

            var genrih = new Student("Genrih");
            genrih.AddGrade(2);
            genrih.AddGrade(3);
            genrih.AddGrade(2);
            genrih.AddGrade(4);


            var students = new List<Student>();
            students.Add(nikita);
            students.Add(vlad);
            students.Add(genrih);

            students.Sort((a, b) => GetStudentAverageGrade(b).CompareTo(GetStudentAverageGrade(a)));
            foreach (var student in students)
                Console.WriteLine($"{student.Name} - Keskmine hind [{Math.Round(GetStudentAverageGrade(student), 1)}]");

            var best = students.First();
            Console.WriteLine();
            Console.WriteLine($"Kõrgeim keskmine on {Math.Round(GetStudentAverageGrade(best), 1)}, õpilasel {best.Name}");
        }

        public static double GetStudentAverageGrade(Student student)
        {
            return student.Grades.Average();
        }
    }
}
