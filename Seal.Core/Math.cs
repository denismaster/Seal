
namespace Seal
{
    /// <summary>
    /// Structure that represents point on a surface. Similar to Point2F.
    /// </summary>
    public struct Location
    {
        private float _x;
        private float _y;
        /// <summary>
        /// Coordinate on X-Axis
        /// </summary>
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = (value < 0) ? 0 : value;
            }
        }
        /// <summary>
        /// Coordinate on Y-Axis
        /// </summary>
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = (value < 0) ? 0 : value;
            }
        }
        public Location(float X, float Y)
        {
            _x = 0;
            _y = 0;
            this.X = X;
            this.Y = Y;
        }
        public static Location operator +(Location u, Location v)
        {
            return new Location(u.X + v.X, u.Y + v.Y);
        }
        public static Location operator -(Location u, Location v)
        {
            return new Location(u.X - v.X, u.Y - v.Y);
        }
        public static Location operator *(Location u, float f)
        {
            return new Location(u.X * f, u.Y * f);
        }
    }
    /// <summary>
    /// Structure that represents rectangled size of the object.
    /// </summary>
    public struct Size
    {
        private float _width;
        private float _height;

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public static readonly Size Zero = new Size(0, 0);

        public Size(float width, float height)
        {
            _width= width;
            _height = height;   
        }

    }

}
