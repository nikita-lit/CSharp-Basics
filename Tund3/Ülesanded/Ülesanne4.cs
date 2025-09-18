namespace CSharpBasics.Tund3.Ülesanded
{
    public class Film
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public Film(string title, int year, string genre)
        {
            Title = title;
            Year = year;
            Genre = genre;
        }
    }

    //-----------------------------------
    // OSA 5 - Ülesanne 4: Filmide kogu
    //-----------------------------------
    internal class Ülesanne4
    {
        public static void Start()
        {
            var films = new List<Film>
            {
                new Film("Shrek", 2001, "Ulme"),
                new Film("Saw", 2004, "Horror"),
                new Film("Tenet", 2020, "Ulme"),
                new Film("The Dark Knight", 2008, "Märul"),
                new Film("Titanic", 1997, "Draama")
            };

            Console.WriteLine("Ulme filmid: ");
            foreach (var film in FindFilmByGenre(films, "Ulme"))
                Console.WriteLine("     " + film.Title + " - " + film.Year);

            Console.WriteLine();
            Console.WriteLine("Uusim film:");
            var newest = FindNewestFilm(films);
            Console.WriteLine("     " + newest.Title + " - " + newest.Year);

            Console.WriteLine();
            Console.WriteLine("Grupeeritud žanrite järgi:");

            var groups = GroupByGenre(films);
            foreach (var group in groups)
            {
                Console.WriteLine();
                Console.WriteLine($"Žanr: {group.Key}");

                foreach (var film in group.Value)
                    Console.WriteLine("     " + film.Title + " - " + film.Year);
            }
        }

        //-----------------------------------
        public static List<Film> FindFilmByGenre(List<Film> films, string genre)
        {
            return films.Where(f => f.Genre.ToLower() == genre.ToLower()).ToList();
        }

        //-----------------------------------
        public static Film FindNewestFilm(List<Film> filmid)
        {
            return filmid.OrderByDescending(f => f.Year).First();
        }

        //-----------------------------------
        public static Dictionary<string, List<Film>> GroupByGenre(List<Film> filmid)
        {
            return filmid.GroupBy(f => f.Genre).ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
