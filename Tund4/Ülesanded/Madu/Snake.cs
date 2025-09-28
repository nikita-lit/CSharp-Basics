using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class Snake : IMapObject
    {
        public Figure Figure { get; set; } = new();
        public Point Head => Figure.List.FirstOrDefault();
        public Direction Direction;
        public string Name { get; set; }

        public Snake(Vector2 pos, Point head, Point tail, int length, Direction direction, string name)
        {
            Direction = direction;
            Figure.List.Add(head);
            Name = name;
            Head.SetPos(pos);
            AddTailSegment(tail, length, direction);
        }

        public void AddTailSegment(Point tail, int length, Direction direction)
        {
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.SetPos(Head.Position);
                p.Move(direction.GetOpposite());

                for (int j = 0; j < i; j++)
                    p.Move(direction.GetOpposite());

                Figure.List.Add(p);
            }
        }

        public int GetLength()
        {
            return Figure.List.Count - 1;
        }

        private DateTime _updateTime = DateTime.Now;

        public void Update()
        {
            if (Game.IsPaused) return;

            if ((DateTime.Now - _updateTime).TotalMilliseconds >= 100)
            {
                _updateTime = DateTime.Now;
                if (IsHitTail())
                    Game.End();
                else
                    Move();
            }
        }

        public void Draw()
        {
            Figure.Draw();
        }

        public void OnHit(IMapObject hit)
        {
            if (hit is Food food && Eat(food))
                Game.AddPoints(food.Points);
            else
                Game.End();
        }

        public void Remove() 
        {
            Figure.Clear();
            Game.Map.RemoveObject(this);
        }

        public void Move()
        {
            var tail = Figure.List;
            for (int i = tail.Count - 1; i > 0; i--)
            {
                tail[i].SetPos(tail[i - 1].Position);
            }

            Head.Move(Direction);

            for (int i = tail.Count - 1; i > 0; i--)
                tail[i].Draw();

            Head.Draw();
        }

        public bool IsHitTail()
        {
            var tail = Figure.List;
            for (int i = tail.Count - 1; i > 0; i--)
            {
                var point = tail[i];
                if (Head.IsHit(point))
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
            if (food.Figure.IsHit(Head))
            {
                food.Remove();
                AddTailSegment(Figure.List.Last(), 1, Direction);
                return true;
            }

            return false;
        }
    }
}
