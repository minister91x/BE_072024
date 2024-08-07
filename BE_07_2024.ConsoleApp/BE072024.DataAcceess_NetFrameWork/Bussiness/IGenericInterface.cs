using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common
{
    public interface IGenericInterface<T>
    {
        List<T> GetAll();
        void Insert(T item);
        void Update(T item);
    }
}
