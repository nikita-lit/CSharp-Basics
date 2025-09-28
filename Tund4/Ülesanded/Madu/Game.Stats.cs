using System.Text.Json;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static void SavePlayerCurrentLevelStats()
        {
            TimeSpan time = DateTime.Now - LevelStartTime;
            var stats = new LevelStats
            {
                Level = Level.Num,
                Lifes = 3,
                Points = _points,
                StartTime = LevelStartTime,
                EndTime = time,
            };

            Player.SaveLevelStats(stats);
        }
    }
}
