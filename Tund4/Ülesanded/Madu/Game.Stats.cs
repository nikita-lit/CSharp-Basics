namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static List<Player> Players { get; private set; } = new();

        public static void SavePlayerCurrentLevelStats()
        {
            TimeSpan time = DateTime.Now - LevelStartTime;
            var stats = new LevelStats
            {
                Level = GetCurLevelIndex(),
                Lifes = 3,
                Points = _points,
                StartTime = LevelStartTime,
                Time = time,
            };

            Player.SaveLevelStats(stats);
            LoadPlayers();
        }

        public static void LoadPlayers()
        {
            Players.Clear();

            var files = Directory.GetFiles(Path.Combine(Program.GetBaseDir(), "stats"));
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file).ToLower();
                var player = new Player(name);
                player.LoadPlayerStats();
                Players.Add(player);
            }
        }
    }
}
