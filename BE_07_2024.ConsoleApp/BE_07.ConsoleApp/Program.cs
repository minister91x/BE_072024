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

        //<kiểu trả về > <tên hàm> (<tham sô> , <tham số>);

        // tham trị -> truyền giá trị vào biến
        static int TongHaiSo(int soThuNhat, int soThuHai)
        {
            try
            {
                soThuHai = 0;
                var tong = soThuNhat / soThuHai;
                return tong;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message :{0}", ex.Message);
                Console.WriteLine("StackTrace :{0}", ex.StackTrace);
                Console.WriteLine("Source :{0}", ex.Source);
                throw ex;
            }
            finally
            {
                Console.WriteLine("finally");
            }

            return 0;
        }

        static int TraHaiGiaTri(int a, out int TotalRecord)
        {
            TotalRecord = 200;
            return 100;
        }

        void Tong(int sothunhat, int sothu2)
        {
            ///
        }

        List<int> DanhSachSo()
        {
            return new List<int>();
        }
        public static void UserInput(string s)
        {
            if (s.Length > 2)
            {
                Exception e = new DataTooLongExeption();
                throw e;    // lỗi văng ra
            }
            //Other code - no exeption
        }

        static void ThamChieu(ref int bien_duoc_tham_chieu)
        {
            bien_duoc_tham_chieu = bien_duoc_tham_chieu * bien_duoc_tham_chieu;
            Console.WriteLine(bien_duoc_tham_chieu);

        }

        static void ThamChieuWith_Out(out int bien)
        {
            bien = 10000;
        }
        static void Main(string[] args)
        {
            int myVariable = 10;
            var myNumber = 112;
            var myString = "MrQuan";

            Console.WriteLine("Xin chào các bạn");

            // buổi 2 -------------------------------

            // cách của huy
            int thang = 9;
            List<int> list = new List<int>();



            //for (int i = 1; i <= 12; i++)
            //{
            //    switch (i)
            //    {
            //        case 1: list.Add(1); break;
            //        case 2: break;
            //        case 3: break;
            //        case 4: break;
            //        case 5: break;
            //        case 6: break;
            //        case 7: break;
            //        case 8: break;
            //        case 9: break;
            //        case 10: break;
            //        case 11: break;
            //        case 12: break;
            //    }
            //}


            //for (int i = 0; i < list.Count; i++)
            //{
            //    // in ra
            //}


            //for (int i = 1; i <= 12; i++)
            //{
            //    switch (i)
            //    {
            //        case 1:
            //        case 3:
            //        case 5:
            //        case 8:
            //        case 10:
            //        case 11:
            //        case 12:
            //            Console.Write("lớn hơn 30 ngày");
            //            break;
            //        default:
            //            Console.Write("Không lớn hơn 30 ngày");
            //    }
            //}

            //int myValiable = 10;
            //if (myValiable > 11)
            //{
            //    Console.Write("Không lớn hơn 30 ngày");
            //}
            //else
            //{
            //    Console.Write("Không lớn hơn 30 ngày");
            //}

            //var text = myValiable > 11 ? "HON 11"
            //     : myValiable > 15 ? " HON 15"
            //     : myValiable > 20 ? "HON 20" : "KHONG VAO CASE NÀO";

            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(i);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write("for item {0} \n", i);
            //}

            //foreach (var item in list)
            //{
            //    Console.Write("foreach item {0} \n", item);
            //}
            //...

            try
            {
                int tong = TongHaiSo(10, 20);
                Console.Write("tong  {0} \n", tong);
            }
            catch (Exception ex)
            {

                //throw ex;
            }

            int bien_thamchieu = 10; // zzzzz
            ///bien_duoc_tham_chieu -> zzzzz
           //bien_duoc_tham_chieu=100 -> 
            ThamChieu(ref bien_thamchieu);

            Console.Write("bien_thamchieu  {0} \n", bien_thamchieu);

            int biensohai;
            ThamChieuWith_Out(out biensohai);

            Console.Write("biensohai  {0} \n", biensohai);
            int a = 100;
            int totalRecord;
            TraHaiGiaTri(a, out totalRecord);
            Console.Write("a  {0} \n", a);
            Console.Write("totalRecord  {0} \n", totalRecord);

            UserInput("acbd");
            Console.ReadKey();
        }


    }
}
