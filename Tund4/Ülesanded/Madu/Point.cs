using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Point
    {
        public Vector2 Position { get; private set; }
        public char Sym;

        public int X => (int)Position.X;
        public int Y => (int)Position.Y;

        public Point() { }

        public Point(Vector2 pos, char sym)
        {
            Position = pos;
            Sym = sym;
        }

        public Point(char sym)
        {
            Position = Vector2.Zero;
            Sym = sym;
        }

        public Point(Point p)
        {
            Position = p.Position;
            Sym = p.Sym;
        }

        public void SetPos(Vector2 pos)
        {
            Clear();
            Position = pos; 
        }

        public void SetPos(int x, int y)
        {
            Clear();
            Position = new Vector2(x, y); 
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    SetPos((int)Position.X, (int)Position.Y - 1);
                    break;
                case Direction.Down:
                    SetPos((int)Position.X, (int)Position.Y + 1);
                    break;
                case Direction.Left:
                    SetPos((int)Position.X - 1, (int)Position.Y);
                    break;
                case Direction.Right:
                    SetPos((int)Position.X + 1, (int)Position.Y);
                    break;
            }
        }

        public bool IsHit(Point p)
        {
            return Position == p.Position;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Sym;
        }
    }
}
