using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public enum FoodType
    {
        Default,
        Gold,
        Poison,
    }

    public class Food : IMapObject
    {
        public Figure Figure { get; set; } = new();
        public FoodType Type { get; private set; }

        public Food(Vector2 pos, FoodType type)
        {
            Type = type;

            var point = new Point(pos, GetSym());
            Figure.List.Add(point);
        }

        public void Draw()
        {
            Console.ForegroundColor = GetColor();
            Figure.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public char GetSym()
        {
            if (Type == FoodType.Gold)
                return '£';

            return '$';
        }

        public ConsoleColor GetColor()
        {
            if (Type == FoodType.Gold)
                return ConsoleColor.Yellow;

            if (Type == FoodType.Poison)
                return ConsoleColor.Red;

            return ConsoleColor.Green;
        }

        public int GetPoints()
        {
            if (Type == FoodType.Gold)
                return 2;

            if (Type == FoodType.Poison)
                return -3;

            return 1;
        }

        public void Remove()
        {
            Game.FoodCreator.Foods[Type].Remove(this);
            Figure.Remove();
            Game.Map.RemoveObject(this);
        }
    }
}
