namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public static class Program
    {
        public static bool IsRunning { get; private set; } = false;

        public static void Start()
        {
            Console.SetWindowSize(300, 300);
            Console.SetBufferSize(300, 300);

            IsRunning = true;

            Game.ShowMenu();

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
            IsRunning = false;
        }
    }
}
