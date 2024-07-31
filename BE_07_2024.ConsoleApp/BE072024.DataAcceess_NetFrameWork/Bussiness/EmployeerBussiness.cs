using BE072024.DataAcceess_NetFrameWork.DO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.Bussiness
{
    public class EmployeerBussiness
    {
        List<Employeer> listEmployeer = new List<Employeer>(); // khai báo tường mình
        public ReturrnData NhapDanhSach()
        {
            var returnData = new ReturrnData();
            try
            {
                var employeerID_Input = Console.ReadLine();
                var isvalid = BE072024.Common_NetFrameWork.Common.ValidateData.CheckNull_Data(employeerID_Input);
                if (!isvalid)
                {
                    returnData.ReturrnCode = (int)Ma_Loi.TEN_BI_TRONG;
                    returnData.ReturrnMsg = "Tên không được trống";
                    return returnData;
                }

                var emp = new Employeer();
                emp.EmployeerId = employeerID_Input;

                listEmployeer.Add(emp);
            }
            catch (Exception ex)
            {
                returnData.ReturrnCode = (int)Ma_Loi.EXCEPTION;
                returnData.ReturrnMsg = ex.StackTrace;
                return returnData;
            }
            returnData.ReturrnCode = (int)Ma_Loi.THANH_CONG;
            returnData.ReturrnMsg = "Thêm thành công";
            return returnData;
        }

        public ReturrnData NhapTuExcelFile(string filePath)
        {
            var returnData = new ReturrnData();
            var itemError = new StringBuilder();
            try
            {
                // NHẤN ALT+ ENTER 
                ExcelPackage.LicenseContext = LicenseContext.Commercial;

                FileInfo existingFile = new FileInfo(filePath);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count
                    for (int row = 2; row <= rowCount; row++)
                    {
                        // row=2 ý chỉ dữ liệu bắt đầu từ dòng số 2 trong file excel
                        // LẤY DỮ LIỆU THEO HÀNG VÀ CỘT
                        var maNhanVien = worksheet.Cells[row, 1].Value?.ToString().Trim();
                        var hoTen = worksheet.Cells[row, 2].Value?.ToString().Trim();
                        var ngaySinh = worksheet.Cells[row, 3].Value?.ToString().Trim();
                        var ngayVaoLam = worksheet.Cells[row, 4].Value?.ToString().Trim();

                        if (!CheckValidMaNhanvien(maNhanVien))
                        {
                            itemError.Append("Họ tên viên ở hàng số" + row + " cột số 1 bị trống");
                            continue;
                        }

                        if (!CheckValidNgaySinh(ngaySinh))
                        {
                            itemError.Append("Ngày sinh viên ở hàng số" + row + " cột số 3");
                            continue;
                        }


                        var emp = new Employeer();
                        emp.EmployeerId = maNhanVien;
                        emp.EmployeerName = hoTen;
                        emp.DateOfStart = DateTime.ParseExact(ngaySinh.Split(' ')[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        listEmployeer.Add(emp);
                    }
                }

                if (itemError != null)
                {
                    returnData.ReturrnCode = (int)Ma_Loi.THAT_BAI;
                    returnData.ReturrnMsg = itemError.ToString();
                    return returnData;
                }
            }
            catch (Exception ex)
            {

                returnData.ReturrnCode = (int)Ma_Loi.EXCEPTION;
                returnData.ReturrnMsg = ex.StackTrace;
                return returnData;
            }

            returnData.ReturrnCode = (int)Ma_Loi.THANH_CONG;
            returnData.ReturrnMsg = "Thêm thành công";
            return returnData;
        }


        public List<Employeer> DanhSach_NhanVien(int sonam)
        {
            var list = new List<Employeer>(); // biens ở dạng tự suy

            try
            {
                if (listEmployeer == null || listEmployeer.Count <= 0)
                {
                    return list;
                }

                // Lấy tất cả danh sách 
                if (sonam == 0)
                {
                    return listEmployeer;
                }

                // lấy theo điều kiện 
                var dateExprired = DateTime.Now.AddDays(-sonam);

                // cách 1 for /foreach: 
                for (int i = 0; i < listEmployeer.Count; i++)
                {
                    if (listEmployeer[i].DateOfStart.Year == dateExprired.Year)
                    {
                        list.Add(listEmployeer[i]);
                    }
                }

                //Cách 2 dùng linq
                var myList = listEmployeer.FindAll(s => s.DateOfStart.Year == dateExprired.Year);
                return myList;

            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }


        private bool CheckValidMaNhanvien(string manhanvien)
        {
            try
            {

                var IsValidMaNhanVien = BE072024.Common_NetFrameWork.Common.ValidateData.CheckNull_Data(manhanvien);
                if (!IsValidMaNhanVien)
                {
                    return false;
                }


                //string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                //foreach (var item in specialChar)
                //{
                //    if (manhanvien.Contains(item)) return true;
                //}

                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private bool CheckValidNgaySinh(string ngaysinh)
        {
            try
            {

                var checknull = BE072024.Common_NetFrameWork.Common.ValidateData.CheckNull_Data(ngaysinh);
                if (!checknull)
                {
                    return false;
                }


                var checkDateTime = BE072024.Common_NetFrameWork.Common.ValidateData.CheckValidDateTime(ngaysinh.Split(' ')[0]);
                if (!checkDateTime)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
