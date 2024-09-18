using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class AccountServices : IAccountServices
    {
        public async Task<ReturnData> AccountLogin(AccountLoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu khong hợp lệ";
                    return returnData;

                }

                await Task.Yield();

                // xử lý gọi vào db 
                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Đăng nhập thành công!";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
