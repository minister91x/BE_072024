using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public class NhanVien : Person
    {
        public NhanVien(string _firstName, string _lastname) : base(_firstName, _lastname)
        {
        }

        public string GetAddress()
        {
            Address = "Hà Nội";
            Email = "abc@gmail";
            return Address;
        }
    }
}
