using BE072024.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.Bussiness
{
    public class ProductGeneric<Product> : IGenericInterface<Product>
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Product item)
        {
            // EF
            // DAPPER
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
