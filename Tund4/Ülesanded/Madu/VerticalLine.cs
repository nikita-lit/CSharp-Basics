namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            for (int y = yUp; y < yDown; y++)
            {
                Point p = new Point(x, y, sym);
                List.Add(p);
            }
        }
    }
}
