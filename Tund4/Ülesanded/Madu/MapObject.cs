namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public interface IMapObject
    {
        public Figure Figure { get; set; }
        public abstract void Draw();
        public abstract void Update();
        public abstract void Remove();
    }
}
