using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    class HorizontalLine : IMapObject
    {
        public Figure Figure { get; set; } = new Figure();

        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x < xRight; x++)
            {
                Point p = new Point(new Vector2(x, y), sym);
                Figure.List.Add(p);
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
