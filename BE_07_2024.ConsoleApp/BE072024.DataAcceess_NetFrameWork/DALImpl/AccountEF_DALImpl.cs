using BE072024.DataAcceess_NetFrameWork.DAL;
using BE072024.DataAcceess_NetFrameWork.DO;
using BE072024.DataAcceess_NetFrameWork.EntitesFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DALImpl
{
    public class AccountEF_DALImpl : IAccountEF_DAL
    {
        BE_072024DBContext _context = new BE_072024DBContext();
        public List<Account> Account_GetList(Account_GetAllRequestData requestData)
        {
            try
            {
                var list = _context.account.ToList();

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturrnData Account_Insert(Account_InsertRequestData requestData)
        {
            var returnData = new ReturrnData();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.FullName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturrnCode = -1;
                    returnData.ReturrnMsg = "Dữ lieujd dầu vào  không hợp lệ";
                    return returnData;
                }

                var account = new Account
                {
                    FullName = requestData.FullName,
                    UserName = requestData.UserName,
                    Password = requestData.Password
                };

                _context.account.Add(account);
                var rs = _context.SaveChanges();

                if (rs == 0)
                {
                    returnData.ReturrnCode = -2;
                    returnData.ReturrnMsg = "Thêm mới thất bại";
                    return returnData;
                }

                returnData.ReturrnCode = 1;
                returnData.ReturrnMsg = "Thêm mới thành công !";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
