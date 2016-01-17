using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public class RoundedRectangleGeometry:IGeometry
    {
        public Rectangle Bounds
        {
            get { throw new NotImplementedException(); }
        }

        public bool Contains(ref Point p)
        {
            throw new NotImplementedException();
        }
    }
}
