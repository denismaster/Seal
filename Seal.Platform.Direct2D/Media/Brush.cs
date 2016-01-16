using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Media;
using D2D = SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D.Media
{
    public abstract class Brush : IBrush, IDisposable
    {
        protected D2D.Brush d2dBrush;
        public D2D.Brush D2DBrush
        {
            get
            {
                return d2dBrush;
            }
        }

        public float Opacity
        {
            get
            {
                return d2dBrush.Opacity;
            }
        }

        public void Dispose()
        {
            d2dBrush.Dispose();
        }
    }
}
