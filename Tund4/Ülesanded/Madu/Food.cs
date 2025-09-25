namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Food : IMapObject
    {
        public Figure Figure { get; set; } = new();
        public int Points { get; private set; }

        public Food(int x, int y, char sym, int points) 
        {
            var point = new Point(x, y, sym);
            Figure.List.Add(point);

            Points = points;
        }

        public void Update() { }

        public void Draw()
        {
            Figure.Draw();
        }

        public void Remove()
        {
            Madu.Map.RemoveObject(this);
        }
    }
}
