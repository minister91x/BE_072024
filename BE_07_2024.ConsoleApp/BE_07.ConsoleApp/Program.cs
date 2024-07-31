using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            var myStruct2 = new AnimalStruct();

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

            // Bài 4
            var dateNow = DateTime.Now; // UTC+ 7 
            var dateUtcNow = DateTime.UtcNow.AddHours(7);
            var dateUtcNow2 = DateTime.UtcNow;

            var timeSpan = new TimeSpan(0, -7, 0, 0);

            dateUtcNow2 = dateUtcNow2.Add(timeSpan);

            Console.Write("dateNow  {0} \n", dateNow);
            Console.Write("dateUtcNow  {0} \n", dateUtcNow);
            Console.Write("dateUtcNow2  {0} \n", dateUtcNow2);


            // tính số ngày mình được sinh ra sử dụng datetime 
            // dùng hàm SubDate

            DateTime aDateTime = DateTime.Now;
            DateTime birthday = new DateTime(1991, 02, 08);
            TimeSpan interval = aDateTime.Subtract(birthday);

            Console.Write("TotalDays  {0} \n", interval.TotalDays);

            var datestring1 = aDateTime.ToString("dd/MM/yyyy HH:mm:ss tt");
            var datestring3 = aDateTime.ToString("d/M/yyyy");
            var datestring2 = aDateTime.ToString("dd/MMMM");
            var datestring4 = aDateTime.ToString("dd/MMM");
            Console.Write("datestring1  {0} \n", datestring1);
            Console.Write("datestring2  {0} \n", datestring2);
            Console.Write("datestring3  {0} \n", datestring3);
            Console.Write("datestring3  {0} \n", datestring4);

            var dayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Console.Write("dayInMonth  {0} \n", dayInMonth);

            var myString = "a_b_c";

            //DateTime dateValue;
            //if (!DateTime.TryParseExact(myString, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            //{
            //    Console.Write("{0} không phải định dạng ngày tháng \n", myString);
            //}

            //var myDatTime = DateTime.ParseExact(myString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ////  Console.Write("dayInMonth  {0} \n", myDatTime.AddDays(1).ToString("dd/MM/yyyy"));

            var arrstr = myString + "def";


            Console.ReadKey();
        }


    }
}
