using Spectre.Console;
using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public enum GameState
    {
        NotStarted,
        InProgress,
        GameOver,
    }

    public partial class Game
    {
        public static Map Map;
        public static Level Level;
        public static Snake Snake;
        public static FoodCreator FoodCreator;

        public static GameState State = GameState.NotStarted;
        public static bool IsPaused = false;

        private static int _points;
        private static DateTime LevelStartTime;

        public static void Start(int level)
        {
            Console.Clear();
            State = GameState.InProgress;

            LevelStartTime = DateTime.Now;

            Map = new Map();

            if (level == 1)
                Level = new Level1(new Vector2(0, 4));
            else if (level == 2)
                Level = new Level2(new Vector2(0, 4));
            else if (level == 3)
                Level = new Level3(new Vector2(0, 4));

            Map.Draw();

            SpawnSnake();

            FoodCreator = new FoodCreator('$');
            SpawnFood();

            DrawInfo();
        }

        public static void Update()
        {
            if (State != GameState.InProgress)
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

        public static void ClearGame()
        {
            _points = 0;

            Snake.Remove();
            Snake = null;

            Map.Clear();
            Map = null;

            State = GameState.NotStarted;
        }

        public static void End()
        {
            State = GameState.GameOver;
            SavePlayerCurrentLevelStats();
            DrawInfo();
        }

        public static void HandleKey(ConsoleKey key)
        {
            if (State == GameState.GameOver)
            {
                if (key == ConsoleKey.Enter)
                {
                    ClearGame();
                    ShowMenu();
                    return;
                }
            }

            if (State == GameState.InProgress)
            {
                Snake?.HandleKey(key);

                if (key == ConsoleKey.T)
                {
                    IsPaused = !IsPaused;
                    DrawGamePause();
                }
                else if (key == ConsoleKey.Escape)
                {
                    End();
                }
            }
        }

        public static void AddPoints(int count)
        {
            _points = _points + count;
            DrawInfo();
        }

        public static Snake CreateSnake()
        {
            Point head = new Point('¤');
            Point tail = new Point('*');
            return new Snake(Level.GetSnakeSpawnPos(), head, tail, 1, Direction.Right, $"Snake {Random.Shared.Next(0, 1000)}");
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

        public static void ClearInfo()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 50));
            }
        }

        public static void DrawInfo()
        {
            ClearInfo();
            Console.SetCursorPosition(0, 0);

            string text = $"[green]Points:[/] {_points} | [dodgerblue2]Length:[/] {Snake.GetLength()} | [red]Lifes: ♥♥♥[/]";
            if (State == GameState.GameOver)
                text += "\n[red bold italic]GAME OVER - Press Enter to continue[/]";

            var panel = new Panel(new Markup(text));
            panel.Border = BoxBorder.Ascii;
            AnsiConsole.Write(panel);
        }

        public static void DrawGamePause()
        {
            string gamePaused = "GAME PAUSED";
            if (IsPaused)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(gamePaused);
            }
            else
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(new string(' ', gamePaused.Length));
            }
        }

        public static void TestMessage(string msg)
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine(msg);
        }
    }
}
