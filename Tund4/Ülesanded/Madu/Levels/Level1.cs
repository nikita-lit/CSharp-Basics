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
            Objects.Add(new Rectangle(new Vector2(1, 0) + Offset, new Vector2(Width - 1, 1), '—'));
            Objects.Add(new Rectangle(new Vector2(1, Height + 1) + Offset, new Vector2(Width - 1, 1), '—'));
            Objects.Add(new Rectangle(new Vector2(0, 1) + Offset, new Vector2(1, Height), '|'));
            Objects.Add(new Rectangle(new Vector2(Width, 1) + Offset, new Vector2(1, Height), '|'));

            Objects.Add(new Rectangle(new Vector2(5, 2) + Offset, new Vector2(5, 2), '#'));

            foreach (var obj in Objects)
                Game.Map.AddObject(obj);
        }

        public override Vector2 GetSnakeSpawnPos() => new Vector2(10, 10) + Offset;
        public override Direction GetSnakeSpawnDir() => Direction.Right;
    }
}
