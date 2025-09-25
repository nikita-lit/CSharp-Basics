namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class FoodCreator
    {
        private char _sym;

        public Random Rand = new Random();

        public FoodCreator(char sym)
        {
            _sym = sym;
        }

        public Food CreateFood()
        {
            int x = Rand.Next(2, Madu.Map.Width - 2);
            int y = Rand.Next(2, Madu.Map.Height - 2);

            var food = new Food(x, y, _sym, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.White;

            return food;
        }
    }
}
