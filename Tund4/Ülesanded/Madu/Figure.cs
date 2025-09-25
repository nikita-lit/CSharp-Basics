namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Figure
    {
        public List<Point> List = new();

        public void Draw()
        {
            foreach (Point p in List)
            {
                p.Draw();
            }
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
            {
                point.Sym = ' ';
                point.Draw();
            }

            List.Clear();
        }
    }
}
