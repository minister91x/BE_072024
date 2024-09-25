using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IRoomGenericRepository _roomGenericRepository {  get; set; }
        public IHotelGenericRepository _hotelGenericRepository { get; set; }

        public BE_072024dDbContext _context;
        public UnitOfWork(IRoomGenericRepository roomGenericRepository, 
            IHotelGenericRepository hotelGenericRepository, BE_072024dDbContext context)
        {
            _roomGenericRepository = roomGenericRepository;
            _hotelGenericRepository = hotelGenericRepository;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
