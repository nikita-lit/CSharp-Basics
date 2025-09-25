namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<Figure> Figures { get; private set; } = new();
        public List<IMapObject> Objects { get; private set; } = new();
        public List<IMapObject> ObjectsToRemove { get; private set; } = new();

        public Map(int width, int height)
        {
            Width = width; 
            Height = height;
        }

        public void AddFigure(Figure figure)
        {
            Figures.Add(figure);
        }

        public void AddObject(IMapObject obj)
        {
            Objects.Add(obj);
        }

        public void RemoveObject(IMapObject obj)
        {
            ObjectsToRemove.Add(obj);
        }

        public bool IsHit(Figure figureA)
        {
            foreach (var figureB in Figures)
            {
                if (figureB.IsHit(figureA))
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

        public void Update()
        {
            foreach (var obj in Objects)
                obj.Update();

            foreach (var obj in ObjectsToRemove)
            {
                obj.Figure.Clear();
                Objects.Remove(obj);
            }
        }
    }
}