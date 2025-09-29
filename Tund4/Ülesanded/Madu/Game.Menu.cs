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
            var player = Players.Find(x => x.Name == name);

            if (player != null)
                Player = player;
            else
            {
                Player = new Player(name.Trim());
                Player.LoadPlayerStats();
            }
        }

        public static void ClearMenu()
        {
            AnsiConsole.Clear();

            var title = new FigletText("SNAKE GAME");
            title.LeftJustified();
            title.Color(Color.Green1);

            AnsiConsole.Write(title);
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
                case "Statistics": ClearMenu(); ShowStatistics(); break;
                case "Quit": Program.Stop(); break;
                default: Start(1); break;
            }
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
            prompt.AddChoices(["My statistics", "History", "Leaderboard", "Back"]);

            var input = AnsiConsole.Prompt(prompt);

            switch (input)
            {
                case "My statistics": ShowPlayerStatistics(); break;
                case "History": ShowHistory(); break;
                case "Leaderboard": ShowLeaderboard(); break;
                case "Back": ShowMenu(); break;
            }
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

        public static void ShowHistory()
        {
            ClearMenu();

            var list = Player.LevelsStats.OrderBy(x => x.StartTime);
            foreach (var stats in list)
            {
                var markup = new Markup($"Date: {stats.StartTime}\nLevel: {stats.Level+1}\nTime: {stats.Time:mm\\:ss}\nPoints: {stats.Points}\nLifes: {stats.Lifes}");
                var table = new Table();

                table.AddColumn($"Level: {stats.Level+1}");
                table.AddRow(markup);
                table.Border = TableBorder.Ascii2;

                AnsiConsole.Write(table);
            }

            if (!list.Any())
                AnsiConsole.MarkupLine("[red]No History[/]");

            Console.WriteLine();
            ShowStatistics();
        }

        public static void ShowLeaderboard()
        {
            ClearMenu();
            List<Panel> panels = new();

            for (int i = 0; i < GetLevelsCount(); i++)
            {
                var sb = new StringBuilder();
                Dictionary<Player, int> playersStats = new(); // игрок, лучший результат

                foreach (var player in Players)
                {
                    var levelStats = player.GetLevelStats(i).OrderByDescending(x => x.Points);
                    var bestStats = levelStats.FirstOrDefault();
                    int points = 0;
                    if (bestStats != null)
                        points = bestStats.Points;

                    playersStats[player] = points;
                }

                var players = playersStats.OrderByDescending(kv => kv.Value);

                int num = 0;
                foreach (var kv in players)
                {
                    num++;
                    sb.AppendLine($"{num}. {kv.Key.Name} - {kv.Value}");
                }

                var panel = new Panel(new Markup(sb.ToString()))
                {
                    Border = BoxBorder.None,
                };
                panels.Add(panel);
            }

            var table = new Table();
            table.Title("[blue bold]Leaderboard[/]");

            for (int i = 0; i < GetLevelsCount(); i++)
                table.AddColumn($"Level: {i + 1}");

            table.AddRow(panels.ToArray());
            table.Border = TableBorder.Ascii2;
            AnsiConsole.Write(table);

            Console.WriteLine();
            ShowStatistics();
        }
    }
}
