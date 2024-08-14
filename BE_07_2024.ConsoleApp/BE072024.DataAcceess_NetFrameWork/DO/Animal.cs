using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract string Eeat();
        public abstract string Sound();
        public abstract string Sound1();
        public virtual string ToString()
        {
            return string.Empty;
                 
        }

    }
}
