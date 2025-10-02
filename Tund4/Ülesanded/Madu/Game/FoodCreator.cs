using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class FoodCreator
    {
        public Dictionary<FoodType, List<Food>> Foods { get; private set; } = new();
        public Food GoldFood { get; private set; }
        private DateTime _goldFoodSpawnTime;
        private DateTime _poisonFoodSpawnTime;

        public FoodCreator() 
        {
            Foods[FoodType.Default] = new List<Food>();
            Foods[FoodType.Gold] = new List<Food>();
            Foods[FoodType.Poison] = new List<Food>();
            _poisonFoodSpawnTime = DateTime.Now + TimeSpan.FromSeconds(Random.Shared.Next(3, 6));
        }

        public Food CreateFood(FoodType type)
        {
            for (int i = 0; i < 10; i++) 
            {
                int x = Random.Shared.Next(0, Game.Level.Width);
                int y = Random.Shared.Next(0, Game.Level.Height);
                Vector2 pos = new Vector2(x, y) + Game.Level.Offset;

                var food = new Food(pos, type);
                if (Game.Map.IsHit(food) == null)
                {
                    food.Draw();
                    return food;
                }
            }

            return null;
        }

        public Food SpawnFood(FoodType type)
        {
            var food = CreateFood(type);
            if (food != null)
            {
                Foods[type].Add(food);
                Game.Map.AddObject(food);
            }

            return food;
        }

        public void Update()
        {
            if (Game.IsPaused) return;

            if (Foods[FoodType.Default].Count <= 0)
                SpawnFood(FoodType.Default);

            if (_poisonFoodSpawnTime < DateTime.Now)
            {
                var poisonFoods = Foods[FoodType.Poison].ToList();
                for (int i = 0; i < poisonFoods.Count; i++)
                    poisonFoods[i].Remove();

                poisonFoods.Clear();

                for (int i = 0; i < Random.Shared.Next(1, 5); i++)
                    SpawnFood(FoodType.Poison);

                _poisonFoodSpawnTime = DateTime.Now + TimeSpan.FromSeconds(Random.Shared.Next(3, 6));
            }

            if (GoldFood != null)
            {
                if ((DateTime.Now - _goldFoodSpawnTime).Seconds > 3)
                {
                    GoldFood.Remove();
                    GoldFood = null;
                    _goldFoodSpawnTime = DateTime.Now + TimeSpan.FromSeconds(Random.Shared.Next(4, 8));
                }
            }
            else
            {
                if (_goldFoodSpawnTime < DateTime.Now)
                {
                    GoldFood = SpawnFood(FoodType.Gold);
                    _goldFoodSpawnTime = DateTime.Now;
                }
            }
        }
    }
}
