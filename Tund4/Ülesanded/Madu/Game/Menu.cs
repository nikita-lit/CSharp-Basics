using Spectre.Console;
using System.Text;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public static class Menu
    {
        public static void LogIn()
        {
            ClearMenu();

            if (Game.Player != null)
                Game.Player = null;

            LogInPlayer();
            ClearMenu();
        }

        public static void LogInPlayer()
        {
            var name = AnsiConsole.Prompt(new TextPrompt<string>("Mis su nimi on? => "));
            var player = Game.Players.Find(x => x.Name == name);

            if (player != null)
                Game.Player = player;
            else
            {
                Game.Player = new Player(name.Trim());
                Game.Player.LoadPlayerStats();
            }
        }

        public static void ClearMenu()
        {
            AnsiConsole.Clear();

            var title = new FigletText("USSI MÄNG");
            title.LeftJustified();
            title.Color(Color.Green1);

            AnsiConsole.Write(title);
        }

        public static void Show()
        {
            ClearMenu();

            if (Game.Player == null)
                LogIn();

            AnsiConsole.MarkupLine($"Mängija: {Game.Player.Name}");
            Console.WriteLine();

            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["Alusta mängu", "Statistika", "Logi Välja", "Välju"]);

            var input = AnsiConsole.Prompt(prompt);
            switch (input)
            {
                case "Alusta mängu": ShowStartGame(); break;
                case "Statistika": ClearMenu(); ShowStatistics(); break;
                case "Logi Välja": LogIn(); Show(); break;
                case "Välju": Program.Stop(); break;
                default: Game.Start(1); break;
            }
        }

        public static void ShowStartGame()
        {
            ClearMenu();

            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["Level 1", "Level 2", "Level 3", "Tagasi"]);

            var input = AnsiConsole.Prompt(prompt);
            switch (input)
            {
                case "Level 1": Game.Start(0); break;
                case "Level 2": Game.Start(1); break;
                case "Level 3": Game.Start(2); break;
                case "Tagasi": Show(); break;
            }
        }

        public static void ShowStatistics()
        {
            var prompt = new SelectionPrompt<string>();
            prompt.AddChoices(["Minu statistika", "Ajalugu", "Edetabel", "Tagasi"]);

            var input = AnsiConsole.Prompt(prompt);

            switch (input)
            {
                case "Minu statistika": ShowPlayerStatistics(); break;
                case "Ajalugu": ShowHistory(); break;
                case "Edetabel": ShowLeaderboard(); break;
                case "Tagasi": Show(); break;
            }
        }

        public static void ShowPlayerStatistics()
        {
            ClearMenu();
            var chart = new BarChart();
            chart.Width(60);

            for (int i = 0; i < Game.GetLevelsCount(); i++)
            {
                var stats = Game.Player.GetLevelStats(i);
                int points = 0;
                if (stats.Count > 0)
                    points = stats.Max(s => s.Points); // лучший результат

                chart.AddItem($"Level {i + 1}", points, Color.Green);
            }

            var panel = new Panel(chart)
            {
                Border = BoxBorder.Ascii,
                Header = new PanelHeader($"[blue bold]{Game.Player.Name} - Parimad tasemepunktid[/]").Centered(),
                Padding = new Padding(1, 1),
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();

            ShowStatistics();
        }

        public static void ShowHistory()
        {
            ClearMenu();

            var list = Game.Player.LevelsStats.OrderBy(x => x.StartTime);
            foreach (var stats in list)
            {
                var markup = new Markup($"Kuupäev: {stats.StartTime}\nLevel: {stats.Level + 1}\nAeg: {stats.Time:mm\\:ss}\nPunktid: {stats.Points}\nElud: {stats.Lifes}");
                var table = new Table();

                table.AddColumn($"[blue bold]Level: {stats.Level + 1}[/]");
                table.AddRow(markup);
                table.Border = TableBorder.Ascii2;

                AnsiConsole.Write(table);
            }

            if (!list.Any())
                AnsiConsole.MarkupLine("[red]Ajalugu puudub[/]");

            Console.WriteLine();
            ShowStatistics();
        }

        public static void ShowLeaderboard()
        {
            ClearMenu();
            List<Panel> panels = new();

            for (int i = 0; i < Game.GetLevelsCount(); i++)
            {
                var sb = new StringBuilder();
                Dictionary<Player, int> playersStats = new(); // игрок, лучший результат

                foreach (var player in Game.Players)
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
            table.Title("[blue bold]Edetabel[/]");

            for (int i = 0; i < Game.GetLevelsCount(); i++)
                table.AddColumn($"Level: {i + 1}");

            table.AddRow(panels.ToArray());
            table.Border = TableBorder.Ascii2;
            AnsiConsole.Write(table);

            Console.WriteLine();
            ShowStatistics();
        }
    }
}
