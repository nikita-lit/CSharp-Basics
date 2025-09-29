using System.Text.Json;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public sealed class Player
    {
        public string Name { get; set; }
        public List<LevelStats> LevelsStats { get; private set; } = new();

        public Player(string name)
        {
            Name = name;
        }

        public void SavePlayerStatsToFile()
        {
            string json = JsonSerializer.Serialize(LevelsStats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetStatsPath(), json);
        }

        public void LoadPlayerStats()
        {
            try
            {
                string json = File.ReadAllText(GetStatsPath());
                LevelsStats = JsonSerializer.Deserialize<List<LevelStats>>(json);
            }
            catch (Exception e)
            {
                if (e is not FileNotFoundException)
                {
                    Console.WriteLine($"Error with file: {e.Message}");
                    Console.ReadKey();
                }
            }
        }

        public void SaveLevelStats(LevelStats stats)
        {
            LevelsStats.Add(stats);
            SavePlayerStatsToFile();
        }

        public List<LevelStats> GetLevelStats(int level) => LevelsStats.FindAll(x => x.Level == level).ToList();
        public string GetStatsPath() => Path.Combine(Program.GetBaseDir(), $"stats\\{Name.ToLower()}.json");
    }
}