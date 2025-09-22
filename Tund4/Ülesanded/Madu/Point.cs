namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Point
    {
        public int X; 
        public int Y;
        public char Sym;

        public Point() { }

        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Sym = sym;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            Sym = p.Sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.Right)
                X += offset;
            else if (direction == Direction.Left)
                X -= offset;
            else if (direction == Direction.Up)
                Y -= offset;
            else if (direction == Direction.Down)
                Y += offset;
        }

        public bool IsHit(Point p)
        {
            return p.X == X && p.Y == Y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }

        public void Clear()
        {
            Sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Sym;
        }
    }
}
