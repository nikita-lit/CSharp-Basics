namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class FoodCreator
    {
        private int _mapWidth;
        private int _mapHeight;
        private char _sym;

        public Random Rand = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _sym = sym;
        }

        public Point CreateFood()
        {
            int x = Rand.Next(2, _mapWidth - 2);
            int y = Rand.Next(2, _mapHeight - 2);
            var food = new Point(x, y, _sym);
            Console.ForegroundColor = ConsoleColor.Green;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.White;

            return food;
        }
    }
}
