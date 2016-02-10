using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Platform;
using D2D = SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D
{
    public class RenderTarget:IRenderTarget
    {
        private readonly D2D.RenderTarget _renderTarget;

        public RenderTarget(D2D.Factory factory,IntPtr hwnd, int width, int height)
        {

            D2D.RenderTargetProperties renderTargetProperties = new D2D.RenderTargetProperties
            {
            };

            D2D.HwndRenderTargetProperties hwndProperties = new D2D.HwndRenderTargetProperties
            {
                Hwnd = hwnd,
                PixelSize = new SharpDX.Size2(width, height),
                PresentOptions = D2D.PresentOptions.Immediately
            };

            _renderTarget = new D2D.WindowRenderTarget(
                factory,
                renderTargetProperties,
                hwndProperties);
        }

        public Seal.Platform.IDrawingContext CreateDrawingContext()
        {
            return new Platform.DrawingContext(new Direct2D.DrawingContext(_renderTarget));
        }

        public void Resize(int width, int height)
        {
            var target = _renderTarget as D2D.WindowRenderTarget;
            if(target!=null)
            {
                target.Resize(new SharpDX.Size2(width, height));
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Dispose()
        {
            _renderTarget.Dispose();
        }
        public Seal.Media.ISolidColorBrush CreateSolidColorBrush(Color c)
        {
            return new Media.SolidColorBrush(this._renderTarget, c);
        }

        public Seal.Geometries.IPathProvider CreateGeometryManager()
        {
            return new Geometries.GeometryManager(this._renderTarget.Factory);
        }
        public Images.IBitmapProvider CreateBitmapProvider()
        {
            return new Imaging.WicBitmapProvider(this._renderTarget);
        }
    }
}
