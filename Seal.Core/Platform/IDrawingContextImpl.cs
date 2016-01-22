using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Seal.Platform
{
    public interface IDrawingContextImpl:IDisposable
    {
        Matrix Transform
        {
            get;
            set;
        }
        void BeginDraw();
        void EndDraw();
        void Clear(Color c);
        void DrawLine(Location From, Location To,Seal.Media.IBrush brush);
        void DrawRectangle(Rectangle rect, Location where);
        void DrawEllipse(Rectangle ellipse, Location where);
        void DrawPath(Geometries.IPath path, Seal.Media.IBrush brush);
        void DrawRoundedRectangle(Rectangle rect, Location where,float alpha);
        void DrawBitmap(Images.IBitmap bitmap);
    }
}
