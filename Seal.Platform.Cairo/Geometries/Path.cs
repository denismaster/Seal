using System;
using Seal.Geometries;
namespace Seal.Platform.Cairo
{
	public class Path:IPath
	{
		private readonly PathBuilder _impl;

		public Path ()
		{
			_impl = new PathBuilder ();
		}

		#region IPath implementation

		public bool Contains (ref Point p)
		{
			throw new NotImplementedException ();
		}

		public IPath Clone ()
		{
			throw new NotImplementedException ();
		}

		public IPathBuilder Open ()
		{
			return _impl;
		}
		public global::Cairo.Path CairoPath 
		{
			get { return _impl.Path; }
		}

		public Rectangle Bounds {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

