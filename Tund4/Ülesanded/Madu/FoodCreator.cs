using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class FoodCreator
    {
        public List<Food> Foods { get; private set; } = new();

        public FoodCreator() { }

        public Food CreateFood(FoodType type)
        {
            int x = Random.Shared.Next((int)Game.Level.Offset.X, Game.Level.Width);
            int y = Random.Shared.Next((int)Game.Level.Offset.Y, Game.Level.Height);
            Vector2 pos = new Vector2(x, y);

            var food = new Food(pos, type);
            if (Game.Map.IsHit(food) != null)
                return null;

            food.Draw();
            return food;
        }

        public void SpawnFood(FoodType type)
        {
            var food = CreateFood(type);
            if (food != null)
            {
                Foods.Add(food);
                Game.Map.AddObject(food);
            }
        }

        public void Update()
        {
            if (Foods.Count <= 0)
            {
                if (Random.Shared.Next(0, 100) > 80)
                    SpawnFood(FoodType.Gold);

                SpawnFood(FoodType.Default);
            }
        }
    }
}
