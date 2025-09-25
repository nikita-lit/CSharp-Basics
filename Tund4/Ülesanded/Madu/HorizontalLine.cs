namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x < xRight; x++)
            {
                Point p = new Point(x, y, sym);
                List.Add(p);
            }
        }
    }
}
