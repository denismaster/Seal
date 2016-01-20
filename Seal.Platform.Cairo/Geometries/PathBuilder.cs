using System;
using Seal.Geometries;
using Cair = global::Cairo;
namespace Seal.Platform.Cairo
{
	public class PathBuilder:IPathBuilder
	{
		private Cair.PointD _currentPoint;
		private readonly Cair.Context _context;
		private readonly Cair.ImageSurface _surf;
		public Cair.Path Path { get; private set; }
		public Rectangle Bounds { get; private set; }

		public PathBuilder(Cair.Path path = null)
		{

			_surf = new Cair.ImageSurface (Cair.Format.Argb32, 0, 0);
			_context = new Cair.Context (_surf);
			this.Path = path;

			if (this.Path != null) 
			{
				_context.AppendPath(this.Path);
			}
		}
		#region IPathBuilder implementation

		public void BeginFigure (Location startPoint, bool isFilled)
		{
			if (this.Path == null)
			{
				_context.MoveTo(startPoint.ToCairo());
				_currentPoint = startPoint.ToCairo();
			}
		}

		public void EndFigure (bool isClosed)
		{
			if (this.Path == null) 
			{
				if (isClosed)
					_context.ClosePath ();

				Path = _context.CopyPath ();
				Bounds = _context.FillExtents ().ToSeal ();
			}
		}

		public void LineTo (Location p)
		{
			if (this.Path == null)
			{
				_context.LineTo(p.ToCairo());
				_currentPoint = p.ToCairo();
			}
		}

		public void BezierTo (Location point3, Location point1, Location point2)
		{
			if (this.Path == null)
			{
				_context.CurveTo(point1.ToCairo(), point2.ToCairo(), point3.ToCairo());
				_currentPoint = point3.ToCairo();
			}
		}

		public void ArcTo (Location point, Size size, double rotationAngle, bool isLargeArc)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			_context.Dispose ();
			_surf.Dispose ();
		}

		#endregion
	}
}

