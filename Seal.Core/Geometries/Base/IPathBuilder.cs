using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Seal.Geometries
{
    public interface IPathBuilder:IDisposable
    {
        void BeginFigure(Location startPoint, bool isFilled);
        void EndFigure(bool isClosed);

        void LineTo(Location p);

        void BezierTo(Location end, Location cp1, Location cp2);
        void ArcTo(Location point, Size size, double rotationAngle, bool isLargeArc);
    }
}
