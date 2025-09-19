namespace CSharpBasics.Tund4
{
    public class Konto
    {
        public string Password;
        private double _saldo;

        public double Saldo => _saldo;

        public Konto(string password)
        {
            Password = password;
        }

        public void LisaRaha(double summa)
        {
            if (summa > 0)
                _saldo += summa;

            Console.WriteLine($"Teie kontol on {_saldo} eurot.");
        }

        public void VõtaRaha(double summa)
        {
            if (summa > 0 && summa <= _saldo)
                _saldo -= summa;
            else
                Console.WriteLine("Teie kontol pole piisavalt raha.");

            Console.WriteLine($"Teie kontol on {_saldo} eurot.");
        }
    }
}
