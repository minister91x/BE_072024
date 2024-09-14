using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Nhập số thứ nhất:");
            var input1 = Console.ReadLine();
            Console.WriteLine("Nhập số thứ hai:");
            var input2 = Console.ReadLine();

            var data = new CSharpCoBan.DataAccess.BaiTapBuoi1();

            var result = data.TinhTong(input1, input2);
            if (result < 0)
            {
                if (result == -1)
                {
                    Console.WriteLine("result ={0}", "Số thứ nhất không hợp lệ");
                }

                if (result == -2)
                {
                    Console.WriteLine("result ={0}", "Số thứ hai không hợp lệ");
                }
            }
            else
            {
                Console.WriteLine("result ={0}", result);
            }


            Console.ReadKey();
        }
    }
}
