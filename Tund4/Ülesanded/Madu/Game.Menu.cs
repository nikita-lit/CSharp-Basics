using Spectre.Console;
using System.Text;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static Player Player { get; set; }

        public static void CreatePlayer()
        {
            var name = AnsiConsole.Prompt(new TextPrompt<string>("What's your name? => "));
            Player = new Player(name.Trim());
            Player.LoadPlayerStats();
        }

        public static void ShowMenu()
        {
            ClearMenu();

            if (Player == null)
            {
                CreatePlayer();
                ClearMenu();
            }

            AnsiConsole.MarkupLine($"Player: {Player.Name}");
            Console.WriteLine();

            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["Start Game", "Statistics", "Quit"]);

            var input = AnsiConsole.Prompt(prompt);
            switch (input)
            {
                case "Start Game": ShowStartGame(); break;
                case "Statistics":
                    ClearMenu();
                    ShowStatistics(); 
                    break;
                case "Quit": Program.Stop(); break;
                default: Start(1); break;
            }
        }

        public static void ClearMenu()
        {
            Console.Clear();

            var title = new FigletText("SNAKE GAME");
            title.LeftJustified();
            title.Color(Color.Green1);

            AnsiConsole.Write(title);
        }

        public static void ShowStartGame()
        {
            ClearMenu();

            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["Level 1", "Level 2", "Level 3", "Back"]);

            var input = AnsiConsole.Prompt(prompt);
            switch (input)
            {
                case "Level 1": Start(0); break;
                case "Level 2": Start(1); break;
                case "Level 3": Start(2); break;
                case "Back": ShowMenu(); break;
            }
        }

        public static void ShowStatistics()
        {
            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["My statistics", "Leaderboard", "Back"]);

            var input = AnsiConsole.Prompt(prompt);
            if (input == "Back")
                ShowMenu();
            else if (input == "My statistics")
                ShowPlayerStatistics();
            else if (input == "Leaderboard")
                ShowLeaderboard();
        }

        public static void ShowPlayerStatistics()
        {
            ClearMenu();

            var chart = new BarChart();
            chart.Width(60);

            for (int i = 0; i < GetLevelsCount(); i++)
            {
                var stats = Player.GetLevelStats(i);
                int points = 0;
                if (stats.Count > 0)
                    points = stats.Max(s => s.Points); // лучший результат

                chart.AddItem($"Level {i + 1}", points, Color.Green);
            }

            var panel = new Panel(chart)
            {
                Border = BoxBorder.Ascii,
                Header = new PanelHeader($"[blue bold]{Player.Name} - Best Level Points[/]").Centered(),
                Padding = new Padding(1, 1),
            };

            AnsiConsole.Write(panel);

            Console.WriteLine();
            ShowStatistics();
        }

        public static void ShowLeaderboard()
        {
            ClearMenu();

            var dict = new Dictionary<string, int>
            {
                { "Player1", 5 },
                { "Player2", 10 },
                { "Player3", 4 },
                { "Player4", 8 },
                { "Player5", 12 },
            };

            var dict2 = dict.OrderByDescending(x => x.Value);

            var sb = new StringBuilder();
            int num = 0;
            foreach (var kv in dict2)
            {
                num++;
                sb.AppendLine($"{num}. {kv.Key} = {kv.Value}p");
            }

            var panel = new Panel(new Markup(sb.ToString()))
            {
                Header = new PanelHeader("[blue bold]Leaderboard[/]").Centered(),
                Border = BoxBorder.Ascii,
                Padding = new Padding(2, 1),
            };

            AnsiConsole.Write(panel);

            Console.WriteLine();
            ShowStatistics();
        }
    }
}
