using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess
{
    public class BaiTapBuoi1
    {
        public int TinhTong(string sothunhat,string sothuhai)
        {
            var isvalidSt1 = CSharpCoBan.Common.Validation.CheckData(sothunhat);
            if (!isvalidSt1)
            {
                // thông báo lỗi
                return -1;
            }
            var isvalidSt2 = CSharpCoBan.Common.Validation.CheckData(sothuhai);
            if (!isvalidSt1)
            {
                // thông báo lỗi
                return -2;
            }

            return Convert.ToInt32(sothunhat) + Convert.ToInt32(sothuhai);

        }
    }
}
