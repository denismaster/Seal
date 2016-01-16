using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public class PathGeometry : IGeometry
    {
        private readonly IPath path;

        public PathGeometry(IPath path)
        {
            this.path = path;
        }
        public IPath Path
        {
            get
            {
                return path;
            }
        }
        public Rectangle Bounds
        {
            get
            {
                return path.Bounds;
            }
        }

        public bool Contains(ref Point p)
        {
            return path.Contains(ref p);
        }
    }
}
