using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public abstract class Level
    {
        public Vector2 Offset { get; protected set; }
        public Vector2 Size { get; protected set; }
        public int Width => (int)Size.X;
        public int Height => (int)Size.Y;

        public List<IMapObject> Objects { get; protected set; } = new();

        public Level(Vector2 offset) 
        {
            Offset = offset;
        }

        public abstract void Init();

        public void Clear()
        {
            foreach (var obj in Objects)
                obj.Remove();
        }

        public abstract Vector2 GetSnakeSpawnPos();
        public abstract Direction GetSnakeSpawnDir();
    }
}
