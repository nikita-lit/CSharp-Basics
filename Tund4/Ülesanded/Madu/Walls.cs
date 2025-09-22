namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Walls
    {
        public List<Figure> Figures;

        public Walls(int mapWidth, int mapHeight)
        {
            Figures = new List<Figure>();

            Figures.Add(new HorizontalLine(0, mapWidth, 0, '+'));
            Figures.Add(new HorizontalLine(0, mapWidth, mapHeight, '+'));
            Figures.Add(new VerticalLine(0, mapHeight, 0, '+'));
            Figures.Add(new VerticalLine(0, mapHeight, mapWidth, '+'));       
        }

        public bool IsHit( Figure figure )
        {
            foreach (var f in Figures)
            {
                if (f.IsHit(figure)) 
                    return true;
            }

            return false;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var f in Figures)
                f.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
