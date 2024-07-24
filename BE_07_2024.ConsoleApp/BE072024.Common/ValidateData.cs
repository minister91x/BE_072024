using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common_NetFrameWork.Common
{
    public static class ValidateData
    {
        public static bool CheckNull_Data(string input)
        {
            return string.IsNullOrEmpty(input) ? false : true;
        }
    }
}
