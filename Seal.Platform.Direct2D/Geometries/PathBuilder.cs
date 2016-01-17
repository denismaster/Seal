using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2D = SharpDX.Direct2D1;

using Seal.Geometries;
namespace Seal.Platform.Direct2D
{
    public class PathBuilder:IPathBuilder
    {
        private readonly D2D.GeometrySink _sink;

        public PathBuilder(D2D.GeometrySink sink)
        {
            if(sink==null)
            {
                throw new ArgumentNullException();
            }
            _sink = sink;
        }


        public void BeginFigure(Location startPoint, bool isFilled)
        {
            _sink.BeginFigure(startPoint.ToD2D(), isFilled ? D2D.FigureBegin.Filled : D2D.FigureBegin.Hollow);
        }

        public void EndFigure(bool isClosed)
        {
            _sink.EndFigure(isClosed ? D2D.FigureEnd.Closed : D2D.FigureEnd.Open);
        }

        public void LineTo(Location p)
        {
            _sink.AddLine(p.ToD2D());
        }

        public void BezierTo(Location end, Location cp1, Location cp2)
        {
            _sink.AddBezier(new D2D.BezierSegment
            {
                Point1 = cp1.ToD2D(),
                Point2 = cp2.ToD2D(),
                Point3 = end.ToD2D(),
            });
        }

        public void ArcTo(Location point, Size size, double rotationAngle, bool isLargeArc)
        {
            _sink.AddArc(new D2D.ArcSegment
            {
                Point = point.ToD2D(),
                Size = size.ToD2D(),
                RotationAngle = (float)rotationAngle,
                ArcSize = isLargeArc ? D2D.ArcSize.Large : D2D.ArcSize.Small,
                SweepDirection = D2D.SweepDirection.Clockwise,
            });
        }

        public void Dispose()
        {
          _sink.Close();
            _sink.Dispose();
        }
    }
}
