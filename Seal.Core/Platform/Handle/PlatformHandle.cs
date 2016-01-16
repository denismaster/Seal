using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Platform
{
    public interface IPlatformHandle
    {
        IntPtr Handle
        {
            get;
        }

        PlatformType Type
        {
            get;
        }
    }
}
