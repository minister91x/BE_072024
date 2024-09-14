using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.Common
{
    public static class Validation
    {
        public static bool CheckData(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // kiểm tra xem có phải kiểu số không
          
            if (!int.TryParse(input, out int result))
            {
                return false;
            }

            if (Convert.ToInt32(input) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
