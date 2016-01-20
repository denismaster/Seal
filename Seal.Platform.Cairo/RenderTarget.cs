using System;
using Seal;
using Seal.Platform;
using global::Cairo;
namespace Seal.Platform.Cairo
{
	public class RenderTarget:IRenderTarget
	{
		public Seal.Images.IBitmapProvider CreateBitmapProvider ()
		{
			throw new NotImplementedException ();
		}

		private readonly Gtk.Widget  _window;

		public RenderTarget (Gtk.Widget window)
		{
			this._window = window;
		}

		#region IRenderTarget implementation

		public Seal.Platform.DrawingContext CreateDrawingContext ()
		{
			var ctx = new Seal.Platform.DrawingContext (new DrawingContext (_window.GdkWindow));
			return ctx;
		}

		public Seal.Media.ISolidColorBrush CreateSolidColorBrush (Color c)
		{
			throw new NotImplementedException ();
		}

		public void Resize (int width, int height)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

