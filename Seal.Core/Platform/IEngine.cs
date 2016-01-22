using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Geometries;
using Seal.Images;
namespace Seal.Platform
{
    public interface IEngine
    {
        IRenderTarget CreateRenderTarget(IPlatformHandle handle, int width, int height);
        IBitmapProvider CreateBitmapProvider();
        Geometries.IPathProvider CreateGeometryManager();
    }
}
