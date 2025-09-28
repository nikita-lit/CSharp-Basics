using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public abstract class Level
    {
        public const int MAX_LEVEL = 3;
        public virtual int Num => -1;

        public Vector2 Offset { get; protected set; }
        public Vector2 Size { get; protected set; }
        public int Width => (int)Size.X;
        public int Height => (int)Size.Y;

        public Level(Vector2 offset) 
        {
            Offset = offset;
        }

        public abstract Vector2 GetSnakeSpawnPos();
    }
}
