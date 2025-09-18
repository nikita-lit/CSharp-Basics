namespace CSharpBasics.Tund4
{
    public class Transport
    {
        public string Nimi;
        public float Kaal;
        public float Kiirus;

        public Transport() { }

        public Transport(string nimi, float kaal, float kiirus)
        {
            Nimi = nimi;
            Kaal = kaal;
            Kiirus = kiirus;
        }

        public void Sõida()
        {
            Console.WriteLine($"{Nimi} sõidab kiirusega {Kiirus} km/h. Kaal on {Kaal} kg");
        }
    }
}
