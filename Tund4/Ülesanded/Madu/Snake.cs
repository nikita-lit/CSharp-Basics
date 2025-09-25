namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Snake : IMapObject
    {
        public Figure Figure { get; set; } = new();
        public Direction Direction;

        public Snake(Point tail, int length, Direction direction)
        {
            Direction = direction;
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move( i, Direction);
                Figure.List.Add( p );
            }
        }

        private DateTime _updateTime = DateTime.Now;

        public void Update()
        {
            if (Madu.IsPaused) return;

            if ((DateTime.Now - _updateTime).TotalMilliseconds >= 100)
            {
                _updateTime = DateTime.Now;

                foreach (var obj in Madu.Map.Objects)
                {
                    if (obj is Food food && Eat(food))
                    {
                        Madu.AddPoints(food.Points);
                        return;
                    }
                }

                Move();
            }
        }

        public void Draw()
        {
            Figure.Draw();
        }

        public void Remove() { }

        public void Move()
        {
            Point tail = Figure.List.First();
            Figure.List.Remove(tail);

            Point head = GetNextPoint();
            Figure.List.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = Figure.List.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, Direction);
            return nextPoint;
        }

        public bool IsHit()
        {
            return Madu.Map.IsHit(Figure) || IsHitTail();
        }

        public bool IsHitTail()
        {
            var head = Figure.List.Last();
            for (int i = 0; i < Figure.List.Count - 2; i++)
            {
                if (head.IsHit(Figure.List[i]))
                    return true;
            }

            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && Direction != Direction.Right)
                Direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow && Direction != Direction.Left)
                Direction = Direction.Right;
            else if (key == ConsoleKey.UpArrow && Direction != Direction.Down)
                Direction = Direction.Up;
            else if (key == ConsoleKey.DownArrow && Direction != Direction.Up)
                Direction = Direction.Down;
        }

        public bool Eat(Food food)
        {
            Point head = GetNextPoint();
            if (food.Figure.IsHit(head))
            {
                food.Remove();
                Figure.List.Add(new Point(head));
                return true;
            }

            return false;
        }
    }
}
