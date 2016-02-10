using System;
using Seal.Media;
namespace Seal.Platform
{
    public interface IRenderTarget : IDisposable
    {
        IDrawingContext CreateDrawingContext();
        ISolidColorBrush CreateSolidColorBrush(Color c);
        Images.IBitmapProvider CreateBitmapProvider();
        Geometries.IPathProvider CreateGeometryManager();
        void Resize(int width, int height);
    }
}
