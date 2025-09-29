namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public static class Program
    {
        public static bool IsRunning { get; private set; } = false;

        public static void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(100, 100);
            Console.SetBufferSize(100, 100);

            Game.Init();
            Game.ShowMenu();
            IsRunning = true;

            while (IsRunning)
            {
                Update();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    HandleKey(key.Key);
                }
            }
        }

        public static void Update()
        {
            Game.Update();
        }

        public static void HandleKey(ConsoleKey key)
        {
            Game.HandleKey(key);
        }

        public static void Stop()
        {
            Console.Clear();
            IsRunning = false;
        }
    }
}
