using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Media;
using D2D= SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D.Media
{
    public class SolidColorBrush:Brush, ISolidColorBrush
    {
        public SolidColorBrush(D2D.RenderTarget target, Color color)
        {
            if (target != null)
            {
                d2dBrush = new D2D.SolidColorBrush(target, color.ToD2D());
            }
            else
                throw new ArgumentNullException();
        }
        public Color Color
        {
            get
            {
                return (d2dBrush as D2D.SolidColorBrush).Color.ToSeal();
            }
            set
            {
                (d2dBrush as D2D.SolidColorBrush).Color = value.ToD2D();
            }
        }
    }
}
