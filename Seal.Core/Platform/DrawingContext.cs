using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Seal.Geometries;
namespace Seal.Platform
{
    public class DrawingContext:IDisposable
    {
        private readonly IDrawingContextImpl drawingContext;

        public DrawingContext(IDrawingContextImpl impl)
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
        public void DrawLine(Location from, Location to,Media.IBrush brush)
        {
            drawingContext.DrawLine(from, to,brush );
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
        public void DrawPath(IPath path, Media.IBrush brush)
        {
            drawingContext.DrawPath(path, brush);
        }
        public void DrawBitmap(Images.IBitmap bitmap)
        {
            drawingContext.DrawBitmap(bitmap);
        }
        public void Dispose()
        {
            drawingContext.Dispose();
        }
    }
}
