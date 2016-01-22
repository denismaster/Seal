using System;
using Seal;
using global::Cairo;
namespace Seal.Platform.Cairo
{
	public class DrawingContext:IDrawingContextImpl
	{
		public void DrawLine (Location From, Location To, Seal.Media.IBrush brush)
		{
			DrawLine (From, To);
		}

		public void DrawBitmap (Seal.Images.IBitmap bitmap)
		{
			throw new NotImplementedException ();
		}

		private readonly Context _context;

		public DrawingContext(Gdk.Drawable drawable)
		{
			_context = Gdk.CairoHelper.Create(drawable);
		}

		#region IDrawingContextImpl implementation

		public void BeginDraw ()
		{

		}

		public void EndDraw ()
		{

		}

		public void Clear (Color c)
		{
	

			_context.SetSourceRGBA (c.R / 255.0, c.G / 255.0, c.B / 255.0, c.A / 255.0);
			_context.Paint();
			_context.SetSourceRGBA (0.0, 0.0, 0.0, 1.0);
		}

		public void DrawLine (Location From, Location To)
		{

			_context.MoveTo(From.ToCairo());
			_context.LineTo(To.ToCairo());
			_context.Stroke();
		}

		public void DrawRectangle (Rectangle rect, Location where)
		{
			throw new NotImplementedException ();
		}

		public void DrawEllipse (Rectangle ellipse, Location where)
		{
			throw new NotImplementedException ();
		}

		public void DrawPath (Seal.Geometries.IPath path, Seal.Media.IBrush brush)
		{
			var impl = path as Seal.Platform.Cairo.Path;
			if (impl != null) 
			{
				_context.AppendPath(impl.CairoPath);
				_context.Stroke ();
			}
		}

		public void DrawRoundedRectangle (Rectangle rect, Location where, float alpha)
		{
			throw new NotImplementedException ();
		}

		public Matrix Transform {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			_context.Dispose ();
		}

		#endregion
	}
}

