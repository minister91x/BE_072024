using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork
{
    public class OtherBussiness
    {
        public void OtherTest()
        {
            var myStruct = new AnimalStruct(20, "bo", "chipchip");
            myStruct.sound = "meomeo";

        }
    }
}
