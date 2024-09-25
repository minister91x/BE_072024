using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRoomGenericRepository _roomGenericRepository { get; set; }
        public IHotelGenericRepository _hotelGenericRepository { get; set; }

        int SaveChange();
    }
}
