using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class VerticalLine : IMapObject
    {
        public Figure Figure { get; set; } = new Figure();

        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            for (int y = yUp; y < yDown; y++)
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
