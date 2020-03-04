using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Constants
{
    public static class ConstantsHelper
    {
        public static string AppendFormat(this string format, int index = 0)
        {
            return string.Concat("{", index, ":", format, "}");
        }
    }
}
