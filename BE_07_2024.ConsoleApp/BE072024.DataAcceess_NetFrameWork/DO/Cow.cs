using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public class Cow : Animal
    {
        public override string Eeat()
        {
            return "cỏ";
        }

        public override string Sound()
        {
            return "be be";
        }

        public override string Sound1()
        {
            throw new NotImplementedException();
        }
    }
}
