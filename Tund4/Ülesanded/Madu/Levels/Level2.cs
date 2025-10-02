using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Level2 : Level
    {
        public Level2(Vector2 offset)
            : base(offset)
        {
            Size = new Vector2(16, 20);
        }

        public override void Init()
        {
            CreateWalls();

            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, 2) + Offset, new Vector2(6, 1), '#'));
            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, Height/2) + Offset, new Vector2(6, 1), '#'));
            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, Height - 3) + Offset, new Vector2(6, 1), '#'));
        }

        public override Vector2 GetSnakeSpawnPos() => new Vector2(Width / 2, 4) + Offset;
        public override Direction GetSnakeSpawnDir() => Direction.Down;
        public override int GetSnakeSpeed() => 150;
    }
}
