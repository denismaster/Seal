using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Seal.Geometries;
namespace Seal.Platform
{
    public class DrawingContext:IDisposable,IDrawingContext
    {
        private readonly IDrawingContext drawingContext;

        public DrawingContext(IDrawingContext impl)
        {
            this.drawingContext = impl;
        }
        public void BeginDraw()
        {
            this.drawingContext.BeginDraw();
        }
        public void Clear(Color c)
        {
            this.drawingContext.Clear(c);
        }
        public void EndDraw()
        {
            this.drawingContext.EndDraw();
        }
        public void DrawLine(Location from, Location to,Media.IBrush brush,float width=1)
        {
            drawingContext.DrawLine(from, to,brush,width);
        }
        public void DrawRectangle(Rectangle rect)
        {
            throw new NotImplementedException();
        }
        public void DrawRoundedRectangle(Rectangle rect)
        {
            throw new NotImplementedException();
        }
        public void DrawEllipse(Rectangle rect)
        {
            throw new NotImplementedException();
        }
        public void DrawPath(IPath path, Media.IBrush brush,float width=1.0f)
        {
            drawingContext.DrawPath(path, brush,width);
        }
        public void DrawBitmap(Images.IBitmap bitmap)
        {
            drawingContext.DrawBitmap(bitmap);
        }
        public void Dispose()
        {
            drawingContext.Dispose();
        }

        public Matrix Transform
        {
            get
            {
                return drawingContext.Transform;
            }
            set
            {
                drawingContext.Transform = value;
            }
        }

        public void DrawRectangle(Rectangle rect, Location where)
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(Rectangle ellipse, Location where)
        {
            throw new NotImplementedException();
        }

        public void DrawRoundedRectangle(Rectangle rect, Location where, float alpha)
        {
            throw new NotImplementedException();
        }


        public void DrawRectangle(Rectangle rect, Location where, Media.IBrush brush, float width = 1.0f)
        {
            throw new NotImplementedException();
        }

        public void FillPath(IPath path, Media.IBrush brush)
        {
            drawingContext.FillPath(path, brush);
        }

        public void FillRectangle(Rectangle rect, Location where, Media.IBrush brush)
        {
            throw new NotImplementedException();
        }
    }
}
