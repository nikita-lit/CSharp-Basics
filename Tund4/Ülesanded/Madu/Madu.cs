namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    internal class Madu
    {
        public static Map Map;
        public static Snake Snake;
        public static FoodCreator FoodCreator;

        public static bool IsPaused = false;

        private static int _points;

        public static void AddPoints(int count)
        {
            _points = _points + count;
            DrawPoints(_points);
        }

        public static Snake CreateSnake()
        {
            Point p = new Point(15, 5, '*');
            return new Snake(p, 4, Direction.Right);
        }

        public static void Start()
        {
            Console.SetWindowSize(300, 300);
            Console.SetBufferSize(300, 300);

            Map = new Map(35, 15);
            Map.AddFigure(new HorizontalLine(0, Map.Width, 0, '+'));
            Map.AddFigure(new HorizontalLine(0, Map.Width, Map.Height, '+'));
            Map.AddFigure(new VerticalLine(0, Map.Height, 0, '+'));
            Map.AddFigure(new VerticalLine(0, Map.Height, Map.Width, '+'));
            Map.Draw();

            Snake = CreateSnake();
            Snake.Draw();
            Map.AddObject(Snake);

            FoodCreator = new FoodCreator('$');
            Map.AddObject(FoodCreator.CreateFood());

            DrawPoints(_points);

            while (true)
            {
                Map.Update();

                if (Snake.IsHit())
                    break;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (!IsPaused)
                        Snake.HandleKey(key.Key);

                    HandleKey(key.Key);
                }
            }

            DrawGameOver();
        }

        public static void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.T)
            {
                IsPaused = !IsPaused;
                string gamePaused = "GAME PAUSED";

                if (IsPaused)
                {
                    Console.SetCursorPosition(Map.Width + 5, 1);
                    Console.WriteLine(gamePaused);
                }
                else
                {
                    Console.SetCursorPosition(Map.Width + 5, 1);
                    Console.WriteLine(new string(' ', gamePaused.Length));
                }
            }
        }

        public static void DrawGameOver()
        {
            string gameOver = "<== GAME OVER ==>";
            Console.SetCursorPosition((Map.Width / 2) - (gameOver.Length / 2), Map.Height / 2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(gameOver);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public static void DrawPoints(int points)
        {
            Console.SetCursorPosition(Map.Width + 5, 0);
            Console.WriteLine($"POINTS: {points}");
        }
    }
}
