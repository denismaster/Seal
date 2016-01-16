using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Platform;
using D2D = SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D
{
    public class DrawingContext : IDrawingContextImpl
    {
        private readonly D2D.RenderTarget _renderTarget;
        private readonly D2D.SolidColorBrush brush;
        private readonly D2D.SolidColorBrush fbrush;

        public DrawingContext(D2D.RenderTarget renderTarget)
        {
            _renderTarget = renderTarget;
            brush = new D2D.SolidColorBrush(_renderTarget, Colors.Gray.ToD2D());
            fbrush = new D2D.SolidColorBrush(_renderTarget, Colors.LightGray.ToD2D());
        }

        public Matrix Transform
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void DrawLine(Location From, Location To)
        {
            _renderTarget.DrawLine(From.ToD2D(), To.ToD2D(), brush);
        }

        public void DrawRectangle(Rectangle rect, Location where)
        {
            
            _renderTarget.DrawRectangle(rect.ToD2D(), brush);
        }

        public void DrawEllipse(Rectangle ellipse, Location where)
        {
            throw new NotImplementedException();
        }

        public void DrawRoundedRectangle(Rectangle rect, Location where, float alpha)
        {
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            EndDraw();
        }


        public void BeginDraw()
        {
            _renderTarget.BeginDraw();
        }

        public void EndDraw()
        {
            _renderTarget.EndDraw();
        }


        public void DrawPath(Seal.Geometries.IPath path, Seal.Media.IBrush brush)
        {
            var p = path as Path;
            //Здесь стоит проверка, не решит ли пользователь смешать два движка сразу.
            //Тогда теоретически может быть так, что p будет null, так что лучше проверить.
            var pBrush = brush as Media.Brush;
            if (p != null&&pBrush!=null)
            {
                _renderTarget.DrawGeometry(p.D2DPath,pBrush.D2DBrush, 1);
            }
        }


        public void Clear(Color c)
        {
            _renderTarget.Clear(c.ToD2D());
        }


        public void DrawGeometry(Seal.Geometries.IGeometry g, Seal.Geometries.GeometryType type)
        {
            throw new NotImplementedException();
        }

    }
}
