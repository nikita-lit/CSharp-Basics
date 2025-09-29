using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Food : IMapObject
    {
        public Figure Figure { get; set; } = new();
        public int Points { get; private set; }

        public Food(Vector2 pos, char sym, int points) 
        {
            var point = new Point(pos, sym);
            Figure.List.Add(point);

            Points = points;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Figure.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Remove()
        {
            Figure.Remove();
            Game.Map.RemoveObject(this);
        }
    }
}
