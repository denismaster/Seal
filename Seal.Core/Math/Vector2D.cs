using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal
{
    public struct Vector2D
    {
        public float X, Y;

        public Vector2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2D(Vector2D u)
        {
            this.X = u.X;
            this.Y = u.Y;
        }
        public Vector2D(Location l)
        {
            this.X = l.X;
            this.Y = l.Y;
        }
    }
}
