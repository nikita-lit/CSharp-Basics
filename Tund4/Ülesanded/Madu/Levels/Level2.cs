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

            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, 3) + Offset, new Vector2(6, 1), '#'));
            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, Height/2) + Offset, new Vector2(6, 1), '#'));
            Objects.Add(new Rectangle(new Vector2((Width / 2) - 3, Height - 3) + Offset, new Vector2(6, 1), '#'));

            var pos = new Vector2(1, 2) + Offset;
            var wall = new MovingWall(new Rectangle(Vector2.Zero, new Vector2(2, 1), '#'), true, pos, 15);
            Objects.Add(wall);

            var pos2 = new Vector2(Width-4, Height-2) + Offset;
            var wall2 = new MovingWall(new Rectangle(Vector2.Zero, new Vector2(2, 1), '#'), true, pos2, 15, true);
            Objects.Add(wall2);
        }

        public override void Update() { }

        public override Vector2 GetSnakeSpawnPos() => new Vector2(Width / 2, 5) + Offset;
        public override Direction GetSnakeSpawnDir() => Direction.Down;
        public override int GetSnakeSpeed() => 170;
    }
}
