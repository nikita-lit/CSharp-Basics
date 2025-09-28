using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Level3 : Level
    {
        public override int Num => 3;

        public Level3(Vector2 offset) 
            : base(offset)
        {
            Size = new Vector2(35, 15);
            var map = Game.Map;

            map.AddObject(new Rectangle(new Vector2(1, 0) + Offset, new Vector2(Width - 1, 1), '—'));
            map.AddObject(new Rectangle(new Vector2(1, Height + 1) + Offset, new Vector2(Width - 1, 1), '—'));
            map.AddObject(new Rectangle(new Vector2(0, 1) + Offset, new Vector2(1, Height), '|'));
            map.AddObject(new Rectangle(new Vector2(Width, 1) + Offset, new Vector2(1, Height), '|'));

            map.AddObject(new Rectangle(new Vector2(5, 2) + Offset, new Vector2(5, 2), '#'));
        }

        public override Vector2 GetSnakeSpawnPos()
        {
            return new Vector2(10, 10) + Offset;
        }
    }
}
