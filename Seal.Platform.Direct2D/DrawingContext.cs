using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Platform;
using D2D = SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D
{
    public class DrawingContext:IDrawingContext
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
                return _renderTarget.Transform.ToSeal();
            }
            set
            {
                _renderTarget.Transform = value.ToD2D();
            }
        }

        public void DrawLine(Location From, Location To, Seal.Media.IBrush brush, float width = 1)
        {
            var pBrush = brush as Media.Brush;
            if (pBrush != null)
                _renderTarget.DrawLine(From.ToD2D(), To.ToD2D(), pBrush.D2DBrush, width);
        }
        public void DrawEllipse(Rectangle ellipse, Location where)
        {
            //_renderTarget.DrawEllipse()
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


        public void DrawPath(Seal.Geometries.IPath path, Seal.Media.IBrush brush, float width = 1.0f)
        {
            var p = path as Path;
            //Здесь стоит проверка, не решит ли пользователь смешать два движка сразу.
            //Тогда теоретически может быть так, что p будет null, так что лучше проверить.
            var pBrush = brush as Media.Brush;
            if (p != null && pBrush != null && width >= 0)
            {
                _renderTarget.DrawGeometry(p.D2DPath, pBrush.D2DBrush, width);
            }
        }


        public void Clear(Color c)
        {
            _renderTarget.Clear(c.ToD2D());
        }




        public void DrawBitmap(Images.IBitmap bitmap)
        {
            var bmp = bitmap as Imaging.Bitmap;
            if (bmp != null)
            {
                _renderTarget.DrawBitmap(bmp.D2DBitmap, 1, D2D.BitmapInterpolationMode.Linear);
            }
        }


        public void DrawRectangle(Rectangle rect, Location where, Seal.Media.IBrush brush, float width = 1.0f)
        {
            var pBrush = brush as Media.Brush;
            if (pBrush != null)
                _renderTarget.DrawRectangle(rect.ToD2D(), pBrush.D2DBrush, width);
        }

        public void FillPath(Seal.Geometries.IPath path, Seal.Media.IBrush brush)
        {
            var p = path as Path;
            var pBrush = brush as Media.Brush;
            if (pBrush != null && p != null)
                _renderTarget.FillGeometry(p.D2DPath, pBrush.D2DBrush);
        }

        public void FillRectangle(Rectangle rect, Location where, Seal.Media.IBrush brush)
        {
            var pBrush = brush as Media.Brush;
            if (pBrush != null)
                _renderTarget.FillRectangle(rect.ToD2D(), pBrush.D2DBrush);
        }
    }
}
