using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public interface IGeometryManager
    {
        IGeometry CreateGeometry(GeometryType type);
        IPath CreatePath(string data);
    }
}
