using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public interface IPath
    {
        Rectangle Bounds
        {
            get;
        }
        bool Contains(ref Point p);
        IPath Clone();
        IPathBuilder Open();
    }
}
