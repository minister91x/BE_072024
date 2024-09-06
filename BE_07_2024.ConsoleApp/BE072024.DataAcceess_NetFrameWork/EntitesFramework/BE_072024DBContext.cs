using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.EntitesFramework
{
    public class BE_072024DBContext : System.Data.Entity.DbContext
    {
        public BE_072024DBContext() : base("BE_072024_EF_ConnectionString")
        {
        }
        public virtual DbSet<Account> account { get; set; }
    }
}
