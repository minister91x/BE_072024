using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static bool IsNumberic(string input)
        {
            int n;
            bool isNumeric = int.TryParse("123", out n);
            return isNumeric;
        }

        public static bool CheckValidDateTime(string input)
        {

            DateTime dateValue;
            if (!DateTime.TryParseExact(input, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            {
                return false;

            }

            return true;
        }
    }
}
