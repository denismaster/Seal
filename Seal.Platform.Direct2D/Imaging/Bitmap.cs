using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Images;
using D2D = SharpDX.Direct2D1;
using SharpDX;
namespace Seal.Platform.Direct2D.Imaging
{
    class Bitmap : IBitmap
    {
        private readonly D2D.Bitmap bitmap;

        public Bitmap(D2D.Bitmap bitmap)
        {
            if (bitmap != null)
            {
                this.bitmap = bitmap;
            }
            else
            throw new ArgumentNullException();
        }
        public Size Size
        {
            get { return new Size(bitmap.Size.Width, bitmap.Size.Height); }
        }

        public D2D.Bitmap D2DBitmap
        {
            get
            {
                return bitmap;
            }
        }
    }
}
