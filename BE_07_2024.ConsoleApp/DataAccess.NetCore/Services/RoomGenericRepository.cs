using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class RoomGenericRepository : GenericRepository<BE072024_HB_Rooms>, IRoomGenericRepository
    {
        public RoomGenericRepository(BE_072024dDbContext context) : base(context)
        {
        }
    }
}
