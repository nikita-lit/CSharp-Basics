namespace CSharpBasics.Tund4
{
    public class Õpilane : Inimene
    {
        public string RühmKlass;
        public string Kool;

        public override void MidaTeeb()
        {
            Console.WriteLine($"{Nimi} õpib koolis.");
        }
    }
}
