using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        BE_072024dDbContext _context;
        public GenericRepository(BE_072024dDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<int> Insert(T t)
        {
            _context.Add(t);
            //return _context.SaveChanges();

            return 1;
        }
    }
}
