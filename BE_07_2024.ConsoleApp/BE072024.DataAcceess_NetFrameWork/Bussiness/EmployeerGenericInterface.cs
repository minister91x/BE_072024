using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common
{
    public class EmployeerGenericInterface<Employeer> : IGenericInterface<Employeer>
    {
        public List<Employeer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Employeer item)
        {
            throw new NotImplementedException();
        }

        public void Update(Employeer item)
        {
            throw new NotImplementedException();
        }
    }
}
