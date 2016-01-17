using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Geometries;
using D2D=SharpDX.Direct2D1;
namespace Seal.Platform.Direct2D
{
    public class Path:IPath
    {
        private readonly D2D.PathGeometry _path;

        public Path(D2D.Factory factory)
        {
            if(factory==null)
            {
                throw new ArgumentNullException();
            }
            _path = new D2D.PathGeometry(factory);
        }

        protected Path(D2D.PathGeometry geometry)
        {
            if(geometry ==null)
            {
                throw new ArgumentNullException();
            }
            _path = geometry;
        }
        public D2D.PathGeometry D2DPath
        {
            get
            {
                return _path;
            }
        }
        public  Rectangle Bounds
        {
            get
            {
                return _path.GetBounds().ToSeal();
            }
        }
        
        public IPath Clone()
        {
            var result = new D2D.PathGeometry(_path.Factory);
            var sink = result.Open();
            _path.Stream(sink);
            sink.Close();
            return new Path(result);
        }

        public IPathBuilder Open()
        {
            return new PathBuilder(_path.Open());
        }

        public bool Contains(ref Point point)
        {
            var p = point.ToD2D();
            return _path.FillContainsPoint(p) || _path.StrokeContainsPoint(p,1);
        }
    }
}
