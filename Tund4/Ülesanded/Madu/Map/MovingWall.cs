using System.Numerics;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public class MovingWall : IMapObject
    {
        public Figure Figure { get; set; }

        private Vector2 _startPos;
        private DateTime _time;
        private int _offset = 0;
        private int _maxOffset = 0;
        private bool _back = false;
        private bool _inverse = false;
        private bool _y = true;

        public MovingWall(Rectangle rectangle, bool y, Vector2 startPos, int maxOffset, bool inverse = false) 
        {
            Figure = new Figure(rectangle.Figure);
            _y = y;
            _startPos = startPos;
            _maxOffset = maxOffset;
            Figure.SetPos(startPos);
            _inverse = inverse;
        }

        public void Update()
        {
            if (_time < DateTime.Now)
            {
                if (_offset > _maxOffset)
                    _back = true;
                else if (_offset <= 0)
                    _back = false;

                var pos = Game.Level.Offset;

                if (!_inverse)
                {
                    if (_y)
                        pos = new Vector2(_startPos.X, _startPos.Y + _offset);
                    else
                        pos = new Vector2(_startPos.X + _offset, _startPos.Y);
                }
                else
                {
                    if (_y)
                        pos = new Vector2(_startPos.X, _startPos.Y - _offset);
                    else
                        pos = new Vector2(_startPos.X - _offset, _startPos.Y);
                }

                    Figure.SetPos(pos);
                Figure.Draw();
                _time = DateTime.Now + TimeSpan.FromSeconds(0.5f);

                if (_back)
                    _offset--;
                else
                    _offset++;
            }
        }

        public void OnHit(IMapObject hit) 
        {
            if (hit is Food)
                hit.Remove();
        }

        public void Remove()
        {
            Figure.Remove();
            Game.Map.RemoveObject(this);
        }
    }
}
