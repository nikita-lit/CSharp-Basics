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
            int x = Rand.Next((int)Game.Level.Offset.X, Game.Level.Width);
            int y = Rand.Next((int)Game.Level.Offset.Y, Game.Level.Height);
            Vector2 pos = new Vector2(x, y);

            var food = new Food(pos, _sym, 1);
            if (Game.Map.IsHit(food) != null)
                return null;

            food.Draw();

            return food;
        }
    }
}
