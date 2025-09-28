using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    class Rectangle : IMapObject
    {
        public Figure Figure { get; set; } = new Figure();

        public Rectangle(Vector2 pos, Vector2 size, char sym)
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    Point p = new Point(new Vector2(pos.X + i, pos.Y + j), sym);
                    Figure.List.Add(p);
                }
            }
        }

        public void Draw()
        {
            Figure.Draw();
        }

        public void Remove()
        {
            Figure.Clear();
            Game.Map.RemoveObject(this);
        }
    }
}
