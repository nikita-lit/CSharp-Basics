namespace CSharpBasics.Tund4
{
    internal class Class
    {
        public static void Start()
        {
            /*
            var inimene = new Inimene();
            inimene.Nimi = "Juku";
            inimene.Vanus = 30;
            inimene.Tervita();

            var töötaja = new Töötaja();
            töötaja.Nimi = "Mati";
            töötaja.Vanus = 45;
            töötaja.Ametikoht = "Autojuht";
            töötaja.Tervita();
            */

            var veoauto = new Veoauto();
            veoauto.Nimi = "Volvo";
            veoauto.Kaal = 5000;
            veoauto.Kiirus = 60;
            veoauto.Kandevõime = 5;

            var auto = new Auto();
            auto.Nimi = "Mercedes";
            auto.Kaal = 1000;
            auto.Kiirus = 100;

            veoauto.Sõida();
            auto.Sõida();

            veoauto.Laadi();
        }
    }
}
