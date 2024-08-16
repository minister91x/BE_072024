using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DAL
{
    public interface IEmployeeDAL
    {
         List<Employeer> Employeers_GetList();
         ReturrnData EmployeerInsertUpdate(Employeer employeer);
    }
}
