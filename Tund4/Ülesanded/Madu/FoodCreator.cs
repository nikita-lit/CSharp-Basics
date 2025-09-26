using System.Numerics;

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
            int x = Rand.Next(2, Game.Map.Width - 2);
            int y = Rand.Next(2, Game.Map.Height - 2);
            Vector2 pos = new Vector2(x, y);

            var food = new Food(pos, _sym, 1);
            if (Game.Map.IsHit(food) != null)
                return null;

            Console.ForegroundColor = ConsoleColor.Green;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.White;

            return food;
        }
    }
}
