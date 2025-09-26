using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static Map Map;
        public static Snake Snake;
        public static FoodCreator FoodCreator;

        public static bool IsGameStarted = false;
        public static bool IsPaused = false;

        private static int _points;

        public static void Start()
        {
            Console.Clear();
            IsGameStarted = true;

            Map = new Map(35, 15);
            Map.AddObject(new HorizontalLine(0, Map.Width, 0, '—'));
            Map.AddObject(new HorizontalLine(0, Map.Width, Map.Height, '—'));
            Map.AddObject(new VerticalLine(1, Map.Height, 0, '|'));
            Map.AddObject(new VerticalLine(1, Map.Height, Map.Width-1, '|'));

            Map.AddObject(new VerticalLine(1, 5, 8, '#'));

            Map.Draw();

            SpawnSnake();

            FoodCreator = new FoodCreator('$');
            SpawnFood();

            DrawPoints(_points);
        }

        public static void Update()
        {
            if (!IsGameStarted)
                return;

            Map?.Update();

            int foodCount = 0;
            for (int i = 0; i < Map.Objects.Count; i++)
            {
                var obj = Map.Objects[i];
                if (obj is Food)
                    foodCount++;
            }

            if (foodCount <= 0)
                SpawnFood();
        }

        public static void End()
        {
            DrawGameOver();
            Program.Stop();
        }

        public static void HandleKey(ConsoleKey key)
        {
            Snake?.HandleKey(key);

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

        public static void AddPoints(int count)
        {
            _points = _points + count;
            DrawPoints(_points);
        }

        public static Snake CreateSnake()
        {
            Point head = new Point('¤');
            Point tail = new Point('*');
            return new Snake(new Vector2(Map.Width/2, Map.Height/2), head, tail, 5, Direction.Right);
        }

        public static void SpawnSnake()
        {
            Snake = CreateSnake();
            Snake.Draw();
            Map.AddObject(Snake);
        }

        public static void SpawnFood()
        {
            var food = FoodCreator.CreateFood();
            if(food != null)
                Map.AddObject(food);
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
