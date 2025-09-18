namespace CSharpBasics.Tund4
{
    public class Töötaja : Inimene
    {
        public string Ametikoht = "Keevitaja";

        public override void MidaTeeb()
        {
            Console.WriteLine($"{Nimi} töötab ametikohal {Ametikoht}.");
        }
    }
}
