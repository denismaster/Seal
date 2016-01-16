using System;
using Seal.Media;
namespace Seal.Platform
{
    public interface IRenderTarget : IDisposable
    {
        DrawingContext CreateDrawingContext();
        ISolidColorBrush CreateSolidColorBrush(Color c);
        void Resize(int width, int height);
    }
}
