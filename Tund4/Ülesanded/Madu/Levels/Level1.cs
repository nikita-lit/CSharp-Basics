using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Level1 : Level
    {
        public Level1(Vector2 offset) 
            : base(offset)
        {
            Size = new Vector2(35, 15);
        }

        public override void Init()
        {
            CreateWalls();

            Objects.Add(new Rectangle(new Vector2(5, 2) + Offset, new Vector2(5, 3), '#'));
            Objects.Add(new Rectangle(new Vector2(Width - 10, 2) + Offset, new Vector2(5, 3), '#'));

            Objects.Add(new Rectangle(new Vector2(5, Height - 5) + Offset, new Vector2(5, 3), '#'));
            Objects.Add(new Rectangle(new Vector2(Width - 10, Height - 5) + Offset, new Vector2(5, 3), '#'));
        }

        public override Vector2 GetSnakeSpawnPos() => new Vector2(Width/2, Height/2) + Offset;
        public override Direction GetSnakeSpawnDir() => Direction.Right;
        public override int GetSnakeSpeed() => 130;
    }
}
