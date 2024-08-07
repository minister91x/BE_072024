using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common
{
    public class MyGenericClass<T>
    {
        public T genericField { get; set; }

        public T genericMethod(T genericParameter)
        {
            T rtn = default(T);

            Console.WriteLine("Field type: {0}, value: {1}", typeof(T).ToString(), genericField);
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}", typeof(T).ToString());

            return rtn;
        }

    }
}
