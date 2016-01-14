using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Media
{
    public interface ISolidColorBrush : IBrush
    {
        Color Color
        {
            get;
            set;
        }
    }
}
