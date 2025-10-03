using Spectre.Console;

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
        public static Snake Snake;
        public static FoodCreator FoodCreator;

        public const int LIFES_COUNT = 3;
        private static int _lifes = LIFES_COUNT;

        public static GameState State = GameState.NotStarted;
        public static bool IsPaused = false;

        private static int _points;
        private static DateTime _levelStartTime;

        public static void Init()
        {
            InitLevels();
            LoadPlayers();

            Program.PrecacheSound("eat.wav");
            Program.PrecacheSound("gameover.wav");
            Program.PrecacheSound("error.wav");
            Program.PrecacheSound("bg_music.wav");
        }

        public static void Start(int level)
        {
            Program.PlaySound("bg_music.wav");

            AnsiConsole.Clear();
            AnsiConsole.Cursor.Hide();

            State = GameState.InProgress;

            _levelStartTime = DateTime.Now;

            _lifes = LIFES_COUNT;
            _points = 0;

            Map = new Map();
            LoadLevel(level);

            SpawnSnake();
            FoodCreator = new FoodCreator();

            DrawInfo();

            ShowMessage("MÄNG ALGAB!");
            Thread.Sleep(1000);
            ClearMessage();
        }

        public static void Update()
        {
            if (State != GameState.InProgress)
                return;

            Map?.Update();
            Level?.Update();
            FoodCreator.Update();
        }

        public static void ClearGame()
        {
            _points = 0;

            UnloadLevel();

            Snake.Remove();
            Snake = null;

            Map.Clear();
            Map = null;

            State = GameState.NotStarted;
        }

        public static void End()
        {
            Program.StopSound("bg_music.wav");
            Program.PlaySound("gameover.wav");
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
                    Menu.Show();
                    return;
                }
            }

            if (State == GameState.InProgress)
            {
                Snake?.HandleKey(key);

                if (key == ConsoleKey.T)
                {
                    IsPaused = !IsPaused;
                    if (IsPaused)
                        ShowMessage("MÄNG ON PAUSIL");
                    else
                        ClearMessage();
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

        public static void OnSnakeHit()
        {
            if (_lifes > 1)
            {
                _lifes--;

                Program.PlaySound("error.wav");

                DrawInfo();

                ShowMessage("[bold red]Elu on kadunud![/]");
                Thread.Sleep(2000);
                ClearMessage();

                Snake.ResetLength();
                Snake.SetPos(Level.GetSnakeSpawnPos());
                Snake.Direction = Level.GetSnakeSpawnDir();
                Snake.Move();
                Snake.Direction = Level.GetSnakeSpawnDir();

                Map.Draw();
            }
            else
            {
                _lifes--;
                End();
            }
        }

        public static Snake CreateSnake()
        {
            Point head = new Point('¤');
            Point tail = new Point('*');
            return new Snake(
                Level.GetSnakeSpawnPos(), 
                head, 
                tail, 
                1, 
                Level.GetSnakeSpawnDir() 
            );
        }

        public static void SpawnSnake()
        {
            Snake = CreateSnake();
            Snake.Draw();
            Map.AddObject(Snake);
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

            string hearts = "";
            for (int i = 0; i < _lifes; i++)
                hearts += "♥";

            for (int i = 0; i < (LIFES_COUNT - _lifes); i++)
                hearts += "♡";

            string text = $"[cyan]Level {GetCurLevelIndex() + 1}[/] | [green]Punktid:[/] {_points} | [dodgerblue2]Pikkus:[/] {Snake?.GetLength()} | [red]Elud: {hearts}[/]";
            if (State == GameState.GameOver)
                text += "\n[red bold italic]MÄNG LÕPETATUD – Vajuta Enter jätkamiseks[/]";

            var panel = new Panel(new Markup(text))
            {
                Border = BoxBorder.Ascii,
            };

            AnsiConsole.Write(panel);
        }

        public static string CurMessage;

        public static void ShowMessage(string msg)
        {
            CurMessage = msg;
            Console.SetCursorPosition(0, 3);
            AnsiConsole.Write(new Markup(CurMessage));
        }

        public static void ClearMessage()
        {
            if (string.IsNullOrEmpty(CurMessage)) return;

            Console.SetCursorPosition(0, 3);
            Console.WriteLine(new string(' ', CurMessage.Length));
            CurMessage = "";
        }

        public static void TestMessage(string msg)
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine(msg);
        }
    }
}
