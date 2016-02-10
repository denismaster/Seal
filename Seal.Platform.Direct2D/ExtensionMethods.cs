using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2D = SharpDX.Mathematics.Interop;

namespace Seal.Platform.Direct2D
{
    public static class ExtensionMethods
    {
        public static Rectangle ToSeal(this D2D.RawRectangleF r)
        {
            return new Rectangle(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
        }

        public static D2D.RawPoint ToD2D(this Point p)
        {
            return new D2D.RawPoint()
            {
                X = p.X,
                Y = p.Y
            };
        }

        public static D2D.RawRectangleF ToD2D(this Rectangle r)
        {
            return new D2D.RawRectangleF(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }

        public static D2D.RawVector2 ToD2D(this Location p)
        {
            return new D2D.RawVector2()
            {
                X = p.X,
                Y = p.Y
            };
        }

        public static SharpDX.Size2F ToD2D(this Size p)
        {
            return new SharpDX.Size2F(p.Width, p.Height);
        }
        public static D2D.RawColor4 ToD2D(this Seal.Color color)
        {
            return new D2D.RawColor4(
                (float)(color.R / 255.0),
                (float)(color.G / 255.0),
                (float)(color.B / 255.0),
                (float)(color.A / 255.0));
        }
        public static Color ToSeal(this D2D.RawColor4 color)
        {
            byte alpha = (byte)(color.A*255);
            byte red = (byte)(color.R*255);
            byte green = (byte)(color.G*255);
            byte blue = (byte)(color.B*255);
            return Color.FromArgb(alpha, red, green, blue);
        }
        public static D2D.RawMatrix3x2 ToD2D(this Seal.Matrix matrix)
        {
            return new D2D.RawMatrix3x2()
            {
                M11 = matrix.M11,
                M12 = matrix.M12,
                M21 = matrix.M21,
                M22 = matrix.M22,
                M31 = matrix.M31,
                M32 = matrix.M32
            };
        }
        public static Seal.Matrix ToSeal(this D2D.RawMatrix3x2 matrix)
        {
            return new Matrix(matrix.M11, matrix.M12, matrix.M21, matrix.M22, matrix.M31, matrix.M32);
        }
    }
}
