namespace CSharpBasics.Tund4
{
    public class Pank
    {
        private Dictionary<Inimene, Konto> _accounts { get; set; } = new();

        public Pank() { }

        public void CreateAccount(Inimene inimene, string password)
        {
            if (_accounts.ContainsKey(inimene))
            {
                Console.WriteLine($"Inimesel {inimene.Nimi} on juba pangakonto olemas.");
                return;
            }

            var acc = new Konto(password);
            _accounts.Add(inimene, acc);
        }

        public Konto GetAccount(Inimene inimene, string password)
        {
            if (_accounts.ContainsKey(inimene) 
                && _accounts[inimene].Password == password)
                return _accounts[inimene];

            return null;
        }

        public void LisaRaha(Inimene inimene, double summa)
        {
            if (!_accounts.ContainsKey(inimene))
            {
                Console.WriteLine($"Inimene {inimene.Nimi} ei oma pangakontot.");
                return;
            }

            var acc = _accounts[inimene];
            acc.LisaRaha(summa);
        }
    }
}
