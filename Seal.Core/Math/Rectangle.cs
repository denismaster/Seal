using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal
{
    public struct Rectangle
    {
        public float X, Y, Width, Height;
        public Rectangle(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
    }
}
