using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Figure
    {
        public Vector2 Position { get; private set; }
        public int X => (int)Position.X;
        public int Y => (int)Position.Y;

        public List<Point> List = new();

        public Figure() { }

        public Figure(Figure other)
        {
            List = other.List.ToList();
        }

        public void Draw()
        {
            foreach (Point p in List)
                p.Draw();
        }

        public void SetPos(Vector2 pos)
        {
            Vector2 currentPos = Position;
            Vector2 offset = pos - currentPos;

            foreach (Point p in List)
            {
                Vector2 pPos = p.Position;
                p.SetPos(pPos + offset);
            }

            Position = pos;
        }

        public bool IsHit(Figure figure)
        {
            foreach(Point p in List)
            {
                if (figure.IsHit(p))
                    return true;
            }

            return false;
        }

        public bool IsHit(Point point)
        {
            foreach (var p in List)
            {
                if (p.IsHit(point))
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            foreach (var point in List)
                point.Clear();
        }

        public void Remove()
        {
            foreach (var point in List)
                point.Clear();

            List.Clear();
        }
    }
}
