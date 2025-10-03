using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Level3 : Level
    {
        public Level3(Vector2 offset)
            : base(offset)
        {
            Size = new Vector2(65, 15);
        }

        public override void Init()
        {
            CreateWalls();

            Objects.Add(new Rectangle(new Vector2(5, 2) + Offset, new Vector2(5, 3), '#'));

            Objects.Add(new Rectangle(new Vector2(5, 7) + Offset, new Vector2(10, 1), '#'));
            Objects.Add(new Rectangle(new Vector2(15, 7) + Offset, new Vector2(1, 6), '#'));

            Objects.Add(new Rectangle(new Vector2(20, 2) + Offset, new Vector2(35, 2), '#'));

            //-------------------------------
            Objects.Add(new Rectangle(new Vector2(25, 7) + Offset, new Vector2(16, 1), '#'));
            Objects.Add(new Rectangle(new Vector2(25, 7 + 5) + Offset, new Vector2(16, 1), '#'));

            Objects.Add(new Rectangle(new Vector2(25, 7) + Offset, new Vector2(1, 2), '#'));
            Objects.Add(new Rectangle(new Vector2(25, 7 + 4) + Offset, new Vector2(1, 2), '#'));

            Objects.Add(new Rectangle(new Vector2(25 + 16, 7) + Offset, new Vector2(1, 2), '#'));
            Objects.Add(new Rectangle(new Vector2(25 + 16, 7 + 4) + Offset, new Vector2(1, 2), '#'));

            Objects.Add(new Rectangle(new Vector2(50, 7) + Offset, new Vector2(8, 6), '#'));

            var pos = new Vector2(20, 5) + Offset;
            var wall = new MovingWall(new Rectangle(Vector2.Zero, new Vector2(4, 1), '#'), false, pos, 20);
            Objects.Add(wall);

            var pos2 = new Vector2(2, 2) + Offset;
            var wall2 = new MovingWall(new Rectangle(Vector2.Zero, new Vector2(2, 1), '#'), true, pos2, 10);
            Objects.Add(wall2);
        }

        public override void Update() { }

        public override Vector2 GetSnakeSpawnPos() => new Vector2(12, 5) + Offset;
        public override Direction GetSnakeSpawnDir() => Direction.Right;
        public override int GetSnakeSpeed() => 120;
    }
}
