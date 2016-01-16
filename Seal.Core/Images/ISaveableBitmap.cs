using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Images
{
    public interface ISaveableBitmap:IBitmap
    {
        void Save(string filename);
    }
}
