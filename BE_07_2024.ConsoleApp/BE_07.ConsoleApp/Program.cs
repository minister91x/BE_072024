using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_07.ConsoleApp
{
    internal class Program
    {
        int toancuc = 100; // toàn cục


        static void Main(string[] args)
        {
            int myVariable = 10;
            //var myNumber = 112;
            //var myString = "MrQuan";
            //var bussiness = new BE072024.DataAcceess_NetFrameWork.Bai2_Bussiness();
            //var other = new BE072024.DataAcceess_NetFrameWork.OtherBussiness();
            //try
            //{
            //    int tong = bussiness.TongHaiSo(10, 20);
            //    Console.Write("tong  {0} \n", tong);
            //}
            //catch (Exception ex)
            //{

            //    //throw ex;
            //}

            //int bien_thamchieu = 10; // zzzzz
            /////bien_duoc_tham_chieu -> zzzzz
            ////bien_duoc_tham_chieu=100 -> 
            //bussiness.ThamChieu(ref bien_thamchieu);

            //Console.Write("bien_thamchieu  {0} \n", bien_thamchieu);

            //int biensohai;
            //bussiness.ThamChieuWith_Out(out biensohai);

            //Console.Write("biensohai  {0} \n", biensohai);
            //int a = 100;
            //int totalRecord;
            //bussiness.TraHaiGiaTri(a, out totalRecord);
            //Console.Write("a  {0} \n", a);
            //Console.Write("totalRecord  {0} \n", totalRecord);

            //bussiness.UserInput("acbd");


            var myStruct = new AnimalStruct(10, "cat", "bebe");
            // var chan = myStruct.soChan;
            myStruct.sound = "meomeo";
            Console.Write("SoChan  {0} \n", myStruct.Get_SoChan());
            Console.Write("Sound  {0} \n", myStruct.Sound());
            Console.Write("Name  {0} \n", myStruct.Name);

            if (myVariable == (int)TRANG_THAI_GIAO_DICH.THATBAI) // THAT_BAI
            {

            }

            if (myVariable == (int)TRANG_THAI_GIAO_DICH.THANH_CONG) 
            {

            }

            char[] my_string = { 'H', 'e', 'l', 'l', 'o', '\0' };

            for (int i = 0; i < my_string.Length; i++)
            {
                var value = my_string[i];
                Console.Write("value  {0} \n", value);
            }

            foreach (var item in my_string)
            {
                Console.Write("item  {0} \n", item);
            }
            Console.ReadKey();
        }


    }
}
