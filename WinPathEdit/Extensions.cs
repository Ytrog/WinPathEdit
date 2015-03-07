using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPathEdit
{
    static class Extensions
    {
        public static string AsString(this Enum e)
        {
            return Enum.GetName(e.GetType(), e);
        }
    }
}
