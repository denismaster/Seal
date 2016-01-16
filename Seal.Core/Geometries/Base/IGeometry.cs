using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public enum GeometryType
    {
        Rectangle,
        RoundedRectangle,
        Ellipse,
        Path
    }
    public interface IGeometry
    {
        Rectangle Bounds
        {
            get;
        }
        bool Contains(ref Point p);
    }
}
