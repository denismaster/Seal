using System;
using Seal.Geometries;
namespace Seal.Platform.Cairo
{
	public class GeometryManager:IGeometryManager
	{
		public GeometryManager ()
		{
		}

		#region IGeometryManager implementation

		public IGeometry CreateGeometry (GeometryType type)
		{
			throw new NotImplementedException ();
		}

		public IPath CreatePath (string data)
		{
			Path result = new Path();

			using (var ctx = result.Open())
			{
				GeometryParser parser = new GeometryParser(result, ctx);
				parser.Parse(data);
				return result;
			}
		}

		#endregion
	}
}

