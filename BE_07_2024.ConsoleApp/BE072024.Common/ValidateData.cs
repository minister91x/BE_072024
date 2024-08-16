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

        public static bool CheckLength(string input)
        {
            return input.Length > 500 ? false : true;
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

        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Swap<T>(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;

        }


    }
}
