using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public class Bird : Animal
    {
        public override string Eeat()
        {
            return "sâu";
        }

        public override string Sound()
        {
            return "chíp chíp";
        }

        public override string Sound1()
        {
            throw new NotImplementedException();
        }
    }
}
