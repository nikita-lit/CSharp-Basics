namespace CSharpBasics.Tund4
{
    public class Veoauto : Transport
    {
        public float Kandevõime;

        public void Laadi()
        {
            Console.WriteLine($"{Nimi} laeb kaupa kandevõimega {Kandevõime} t.");
        }

        public new void Sõida()
        {
            Console.WriteLine($"{Nimi} (veoauto) sõidab kiirusega {Kiirus} km/h. Kaal on {Kaal} kg");
        }
    }
}
