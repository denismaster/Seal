using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Seal.Platform
{
    public interface IDrawingContext:IDisposable
    {
        Matrix Transform
        {
            get;
            set;
        }
        void BeginDraw();
        void EndDraw();
        void Clear(Color c);
        void DrawBitmap(Images.IBitmap bitmap);
        void DrawLine(Location From, Location To,Seal.Media.IBrush brush, float width = 1.0f);
        void DrawRectangle(Rectangle rect, Location where, Seal.Media.IBrush brush,float width=1.0f);
        void DrawRoundedRectangle(Rectangle rect, Location where, float alpha);
        void DrawEllipse(Rectangle ellipse, Location where);
        void DrawPath(Geometries.IPath path, Seal.Media.IBrush brush,float width=1.0f);
        void FillPath(Geometries.IPath path, Seal.Media.IBrush brush);
        void FillRectangle(Rectangle rect, Location where, Seal.Media.IBrush brush);
    }
}
