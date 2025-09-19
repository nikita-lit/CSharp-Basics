namespace CSharpBasics.Tund4
{
    public abstract class Loom
    {
        public virtual string Tüüp => "Loom";
        public string Nimi;
        public uint Vanus;

        public Loom(string nimi, uint vanus) 
        {
            Nimi = nimi;
            Vanus = vanus;
        }

        public abstract void TeeHääl();
        public abstract void Liikumine();
        public abstract void Söömine();

        public void Info()
        {
            Console.WriteLine($"Loom Tüüp: {Tüüp} / Nimi: {Nimi} / Vanus: {Vanus}");
        }
    }

    public class Koer : Loom
    {
        public override string Tüüp => "Koer";

        public Koer(string nimi, uint vanus) 
            : base(nimi, vanus)
        { }

        public override void TeeHääl()
        {
            Console.WriteLine("Auh-auh!");
        }

        public override void Liikumine()
        {
            Console.WriteLine("Koer jookseb.");
        }

        public override void Söömine()
        {
            Console.WriteLine("Koer sööb liha.");
        }
    }

    public class Kass : Loom
    {
        public override string Tüüp => "Kass";

        public Kass(string nimi, uint vanus)
            : base(nimi, vanus)
        { }

        public override void TeeHääl()
        {
            Console.WriteLine("Meow!");
        }

        public override void Liikumine()
        {
            Console.WriteLine("Kass liigub vaikseti.");
        }

        public override void Söömine()
        {
            Console.WriteLine("Kass sööb kalu.");
        }
    }

    public class Hobune : Loom
    {
        public override string Tüüp => "Hobune";

        public Hobune(string nimi, uint vanus)
            : base(nimi, vanus)
        { }

        public override void TeeHääl()
        {
            Console.WriteLine("Pääh!");
        }

        public override void Liikumine()
        {
            Console.WriteLine("Hobune jookseb kiiruselt.");
        }

        public override void Söömine()
        {
            Console.WriteLine("Hobune sööb rohtu.");
        }
    }

    public class Lehm : Loom
    {
        public override string Tüüp => "Lehm";

        public Lehm(string nimi, uint vanus)
            : base(nimi, vanus)
        { }

        public override void TeeHääl()
        {
            Console.WriteLine("Muu!");
        }

        public override void Liikumine()
        {
            Console.WriteLine("Lehm liigub rahulikult.");
        }

        public override void Söömine()
        {
            Console.WriteLine("Lehm sööb rohtu.");
        }
    }

    internal class Class
    {
        public static void Start()
        {
            Kujundid.Class.Start();

            /*
            var pank = new Pank();

            var inimene = new Õpilane();
            inimene.Nimi = "Juku";
            inimene.Vanus = 30;
            inimene.Tervita();
            inimene.MidaTeeb();

            var töötaja = new Töötaja();
            töötaja.Nimi = "Mati";
            töötaja.Vanus = 45;
            töötaja.Ametikoht = "Autojuht";
            töötaja.Tervita();
            töötaja.MidaTeeb();*/

            /*
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

            var list = new List<Loom>
            {
                new Koer("Shrek", 10),
                new Kass("Shrek2", 4),
                new Hobune("Shrek3", 7),
                new Lehm("Shrek4", 2),
            };

            list.ForEach(x => x.Info());*/

            /*
            Console.WriteLine();

            töötaja.Tunnid = 130;

            pank.CreateAccount(töötaja, "1234");
            var acc = pank.GetAccount(töötaja, "1234");

            if (acc != null)
            {
                Console.WriteLine($"Algne konto on {acc.Saldo} eurot.");

                var palk = töötaja.ArvutaPalk();
                Console.WriteLine($"Palk on {palk}");
                pank.LisaRaha(töötaja, palk);

                acc.LisaRaha(1000);
                acc.VõtaRaha(200);

                acc.LisaRaha(500);
            }*/
        }
    }
}
