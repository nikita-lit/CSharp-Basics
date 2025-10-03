namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public interface IMapObject
    {
        public Figure Figure { get; set; }

        public void Draw() { }
        public void Update() { }
        public abstract void Remove();

        public void OnHit(IMapObject hit) { }
    }
}
