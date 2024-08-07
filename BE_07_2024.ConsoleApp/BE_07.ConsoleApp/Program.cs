using BE072024.DataAcceess_NetFrameWork.Bussiness;
using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections;
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

            //var employeeBusiness = new EmployeerBussiness();
            //var filePath = @"C:\Users\Admin\source\repos\BE_07_2024\BE_07_2024.ConsoleApp\BE072024.DataAcceess_NetFrameWork\Template\Employeer_Insert_Template.xlsx";
            //var rs = employeeBusiness.NhapTuExcelFile(filePath);

            //Console.WriteLine("Kết quả {0}", rs.ReturrnMsg);

            //var list1 = employeeBusiness.DanhSach_NhanVien(0);
            //if (list1 != null && list1.Count > 0)
            //{
            //    Console.Write("List 1 \n");
            //    foreach (var item in list1)
            //    {
            //        Console.Write("{0} \n", item.EmployeerName);
            //    }
            //}

            //var list2 = employeeBusiness.DanhSach_NhanVien(5);
            //if (list2 != null && list2.Count > 0)
            //{
            //    Console.Write("List 2 \n");
            //    foreach (var item in list2)
            //    {
            //        Console.Write("{0} \n", item.EmployeerName);
            //    }
            //}

            BE072024.Common_NetFrameWork.Common.ValidateData.Swap<int>(10, 20);
            BE072024.Common_NetFrameWork.Common.ValidateData.Swap<string>("abc", "def");
            BE072024.Common_NetFrameWork.Common.ValidateData.Swap<long>(120, 100);

            var mygeneric = new BE072024.Common.MyGenericClass<string>();
            mygeneric.genericField = "string";


            var mygenericInt = new BE072024.Common.MyGenericClass<int>();
            mygenericInt.genericField = 123;

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(1, 1);
            keyValuePairs.Add(2, 1247);

            Dictionary<int, Employeer> keyValuePairsObject = new Dictionary<int, Employeer>();
            keyValuePairsObject.Add(1, new Employeer { });

            foreach (KeyValuePair<int, int> entry in keyValuePairs)
            {
                Console.Write("{0}-{1} \n", entry.Key, entry.Value);
            }

            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add(1);
            arrayList1.Add("abc");
            arrayList1.Add(true);

            foreach (var item in arrayList1)
            {
                Console.Write("{0} \n", item);
            }

           

            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", "abc");
            hashtable.Add(2, new Employeer { EmployeerId = "NV001", EmployeerName = "test" });
            hashtable.Add(3, true);

            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("Key: {0} - Value: {1}", item.Key, item.Value);
            }

            foreach (var key in hashtable.Keys)
            {
                Console.WriteLine("Key: {0} ", key);
            }

            SortedList mySL = new SortedList();
            mySL.Add("Third", "!");
            mySL.Add("Second", "World");
            mySL.Add("First", "Hello");

            
            // Displays the properties and values of the SortedList.
            Console.WriteLine("mySL");
            Console.WriteLine(" Count: {0}", mySL.Count);
            Console.WriteLine(" Capacity: {0}", mySL.Capacity);
            Console.WriteLine(" Keys and Values:");

            // Console.WriteLine("\t-KEY-\t-VALUE-");

            for (int i = 0; i < mySL.Count; i++)
            {
                Console.WriteLine("\t{0}:\t{1}", mySL.GetKey(i), mySL.GetByIndex(i));
            }

            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            Console.WriteLine("myStack");
            Console.WriteLine("\tCount: {0}", myStack.Count);
            Console.Write("\tValues:");

            foreach (Object obj in myStack)
            {
                Console.Write(" {0}", obj);
            }

            Queue myQ = new Queue();
            myQ.Enqueue("Hello");
            myQ.Enqueue("World");
            myQ.Enqueue("!");
            Console.WriteLine("myQ");
            Console.WriteLine("\tCount: {0}", myQ.Count); Console.Write("\tValues:");

            foreach (Object obj in myQ) Console.Write(" {0}", obj);

            Console.ReadKey();
        }


    }
}
