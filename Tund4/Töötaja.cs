namespace CSharpBasics.Tund4
{
    public interface ITööline
    {
        public double ArvutaPalk();
    }

    public class Töötaja : Inimene, ITööline
    {
        public string Ametikoht = "Keevitaja";
        public double Tunnitasu = 15.50;
        public uint Tunnid { get; set; }

        public override void MidaTeeb()
        {
            Console.WriteLine($"{Nimi} töötab ametikohal {Ametikoht}.");
        }

        public double ArvutaPalk()
        {
            return Tunnitasu * Tunnid;
        }
    }
}
