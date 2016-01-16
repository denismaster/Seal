using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Platform.Direct2D
{
    public class PlatformHandle:IPlatformHandle
    {
        private readonly IntPtr handle;
        private readonly PlatformType type;

        public PlatformHandle(IntPtr handle, PlatformType type)
        {
            this.handle = handle;
            this.type = type;
        }

        public IntPtr Handle
        {
            get { return handle; }
        }

        public PlatformType Type
        {
            get { return type; }
        }
    }
}
