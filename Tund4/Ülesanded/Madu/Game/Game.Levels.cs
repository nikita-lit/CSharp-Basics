using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        private static List<Level> _levels = new();
        private static int _curLevelIndex = 0;

        public static Level Level => _levels[_curLevelIndex];

        public static void InitLevels()
        {
            _levels.Add(new Level1(new Vector2(1, 5)));
            _levels.Add(new Level2(new Vector2(1, 5)));
            _levels.Add(new Level3(new Vector2(1, 5)));
        }

        public static void LoadLevel(int index)
        {
            if (index < 0 || index >= _levels.Count)
                return;

            UnloadLevel();

            _curLevelIndex = index;
            Level.Init();
            foreach (var obj in Level.Objects)
                Map.AddObject(obj);

            Snake?.SetPos(Level.GetSnakeSpawnPos());

            Map.Draw();
        }

        public static void UnloadLevel()
        {
            Level.Clear();
            Console.Clear();
            DrawInfo();
        }

        public static int GetCurLevelIndex() => _curLevelIndex;
        public static int GetLevelsCount() => _levels.Count;
    }
}
