namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static void SavePlayerCurrentLevelStats()
        {
            TimeSpan time = DateTime.Now - LevelStartTime;
            var stats = new LevelStats
            {
                Level = GetCurLevelIndex(),
                Lifes = 3,
                Points = _points,
                StartTime = LevelStartTime,
                EndTime = time,
            };

            Player.SaveLevelStats(stats);
        }
    }
}
