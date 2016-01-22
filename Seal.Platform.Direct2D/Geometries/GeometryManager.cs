using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2D = SharpDX.Direct2D1;
using Seal.Geometries;

namespace Seal.Platform.Direct2D.Geometries
{
    public class GeometryManager : IPathProvider
    {
        private readonly D2D.Factory factory;
        public GeometryManager(D2D.Factory factory)
        {
            if (factory != null)
                this.factory = factory;
            else
                throw new ArgumentNullException();
        }

        public IPath CreatePath(string data)
        {
            Path result = new Path(factory);

            using (var ctx = result.Open())
            {
                GeometryParser parser = new GeometryParser(result, ctx);
                parser.Parse(data);
                return result;
            }
        }
    }
}
