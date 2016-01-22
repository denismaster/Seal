using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Platform;

using D2D = SharpDX.Direct2D1;
using DW = SharpDX.DirectWrite;
using WIC = SharpDX.WIC;
namespace Seal.Platform.Direct2D
{
    public class Engine:IEngine
    {
        private readonly D2D.Factory s_d2D1Factory = new D2D.Factory();

        private readonly DW.Factory s_dwfactory = new DW.Factory();

        private readonly WIC.ImagingFactory s_imagingFactory = new WIC.ImagingFactory();

        public IRenderTarget CreateRenderTarget(IPlatformHandle handle, int width, int height)
        {
            if (handle.Type == PlatformType.D2D)
                return new Direct2D.RenderTarget(s_d2D1Factory, handle.Handle,width, height);
            else
                throw new NotSupportedException(String.Format("Cannot create {0} target with D2D Engine",handle.Type));
        }
        public Seal.Geometries.IPathProvider CreateGeometryManager()
        {
            return new Geometries.GeometryManager(this.s_d2D1Factory);
        }
        public Images.IBitmapProvider CreateBitmapProvider()
        {
            throw new NotImplementedException();
        }
        public Seal.Geometries.IPath CreateStreamGeometry()
        {
            return new Path(this.s_d2D1Factory);
        }
    }
}
