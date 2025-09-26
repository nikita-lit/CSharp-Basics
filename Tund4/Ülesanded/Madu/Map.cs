using System.Linq;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<IMapObject> Objects { get; private set; } = new();

        public Map(int width, int height)
        {
            Width = width; 
            Height = height;
        }

        public void AddObject(IMapObject obj)
        {
            if (obj == null || Objects.Contains(obj)) 
                return;

            Objects.Add(obj);
        }

        public void RemoveObject(IMapObject obj)
        {
            Objects.Remove(obj);
        }

        public IMapObject IsHit(IMapObject objA)
        {
            foreach (var objB in Objects)
            {
                if (objA != objB 
                    && objB.Figure.IsHit(objA.Figure))
                    return objB;
            }

            return null;
        }

        public void Draw()
        {
            foreach (var obj in Objects)
                obj.Draw();
        }

        public void Update()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                var obj = Objects[i];

                var isHit = IsHit(obj);
                if (isHit != null)
                    obj.OnHit(isHit);

                if (obj != null)
                    obj.Update();
            }
        }
    }
}