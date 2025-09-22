using System.Xml.Linq;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Snake : Figure
    {
        public Direction Direction;

        public Snake(Point tail, int length, Direction direction)
        {
            Direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move( i, Direction);
                pList.Add( p );
            }
        }

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);

            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, Direction);
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }

            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                Direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow)
                Direction = Direction.Right;
            else if (key == ConsoleKey.UpArrow)
                Direction = Direction.Up;
            else if (key == ConsoleKey.DownArrow)
                Direction = Direction.Down;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Sym = head.Sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
