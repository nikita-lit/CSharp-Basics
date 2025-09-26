namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }

    public static class DirectionExt
    {
        public static Direction GetOpposite(this Direction direction)
        {
            if (direction == Direction.Right)
                return Direction.Left;
            else if (direction == Direction.Left)
                return Direction.Right;
            else if (direction == Direction.Up)
                return Direction.Down;
            else if (direction == Direction.Down)
                return Direction.Up;

            return Direction.Left;
        }
    }
}
