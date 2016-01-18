using System;
using Seal;
using Seal.Platform;
using Seal.Media;
using Seal.Geometries;
using Seal.Platform.Cairo;
namespace TestAppCairo
{
	[System.ComponentModel.ToolboxItem (true)]
	public class SealControl : Gtk.DrawingArea,IPlatformHandle
	{
		IEngine engine;
		IRenderTarget target;

		public SealControl ()
		{
			engine = new Engine();
			target = engine.CreateRenderTarget(this, this.Allocation.Width, this.Allocation.Height);
		}

		protected override bool OnButtonPressEvent (Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent (ev);
		}

		protected override bool OnExposeEvent (Gdk.EventExpose ev)
		{
			base.OnExposeEvent (ev);
			using (var ctx = target.CreateDrawingContext())
			{
				ctx.Clear (Colors.SkyBlue);
				ctx.DrawLine (new Location(0,0), new Location(100,100));
			};
			return true;
		}

		protected override void OnSizeAllocated (Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated (allocation);
			// Insert layout code here.
		}

		protected override void OnSizeRequested (ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}

		public PlatformType Type {
			get {
				return PlatformType.Cairo;
			}
		}
	}
}

