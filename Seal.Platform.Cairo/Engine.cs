using System;
using Seal.Platform;
using Seal;
using global::Cairo;
namespace Seal.Platform.Cairo
{
	public class Engine:IEngine
	{
		public Engine ()
		{
		}

		#region IEngine implementation

		public IRenderTarget CreateRenderTarget (IPlatformHandle handle, int width, int height)
		{
			var window = handle as Gtk.Widget;
			if (window == null)
				throw new NotSupportedException ("Cannot create Cairo Engine for this handle");
			window.DoubleBuffered = true;
			return new RenderTarget(window);
		}

		public Seal.Images.IBitmapProvider CreateBitmapProvider ()
		{
			throw new NotImplementedException ();
		}

		public Seal.Geometries.IGeometryManager CreateGeometryManager ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

