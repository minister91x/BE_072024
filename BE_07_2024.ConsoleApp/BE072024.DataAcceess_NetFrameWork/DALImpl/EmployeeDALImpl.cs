using BE072024.Common_NetFrameWork.Common;
using BE072024.DataAcceess_NetFrameWork.DAL;
using BE072024.DataAcceess_NetFrameWork.DO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DALImpl
{
    public class EmployeeDALImpl : IEmployeeDAL, IEmployee2
    {
        List<Employeer> list = new List<Employeer>();
        public ReturrnData EmployeerInsertUpdate(Employeer employeer)
        {
            var returnData = new ReturrnData();
            try
            {
                if (employeer == null
                    || string.IsNullOrEmpty(employeer.EmployeerName))
                {
                    returnData.ReturrnCode = -1;
                    returnData.ReturrnMsg = "dữ liệu đầu vào không hợp";
                    returnData.Extend = DateTime.Now.ToString("dd/MM/yyyy HH:mm:sss") + "| " + JsonConvert.SerializeObject(employeer);
                    return returnData;
                }

                if (!ValidateData.CheckNull_Data(employeer.EmployeerName)
                   || !ValidateData.CheckLength(employeer.EmployeerName)
                   || !ValidateData.CheckXSSInput(employeer.EmployeerName))
                {
                    returnData.ReturrnCode = -2;
                    returnData.ReturrnMsg = "dữ liệu đầu vào không hợp";
                    return returnData;
                }

                // check trùng 
                if (list != null && list.Count > 0)
                {
                    var emplDb = list.Where(s => s.EmployeerName == employeer.EmployeerName).FirstOrDefault();
                    var isExits = emplDb != null || emplDb.EmployeerId > 0 ? false : true;
                    // nếu trùng thì báo lỗi
                    if (!isExits)
                    {

                        returnData.ReturrnCode = -3;
                        returnData.ReturrnMsg = "Nhân viên này đã tồn tại";
                        return returnData;
                    }

                }

                // Thêm 
                list.Add(employeer);
                returnData.ReturrnCode = 1;
                returnData.ReturrnMsg = "Thêm nhân viên thành công";
                return returnData;

            }
            catch (Exception ex)
            {
                returnData.ReturrnCode = -99;
                returnData.ReturrnMsg = ex.Message;
                return returnData;
            }
        }

        public List<Employeer> Employeers_GetList()
        {
            throw new NotImplementedException();
        }

        public List<Employeer> GetEmployeers()
        {
            throw new NotImplementedException();
        }
    }
}
