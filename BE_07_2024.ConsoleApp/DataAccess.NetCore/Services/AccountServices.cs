using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class AccountServices : IAccountServices
    {
        BE_072024dDbContext _context;
        public AccountServices(BE_072024dDbContext context)
        {
            _context = context;
        }
        public async Task<LoginResponseData> AccountLogin(AccountLoginRequestData requestData)
        {
            var returnData = new LoginResponseData();
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

                var hashPassword = Security.ComputeSha256Hash(requestData.Password);

                var user = _context.user.ToList().FindAll(x => x.UserName
                  == requestData.UserName && x.Password == hashPassword).FirstOrDefault();

                if (user == null || user.UserID <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Tài khoản hoặc mật khẩu không đúng!";
                    return returnData;
                }


                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Đăng nhập thành công!";
                returnData.user = user;
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> Account_UpdateRefeshToken(Account_UpdateRefeshTokenRequestData requestData)
        {

            try
            {
                var user = _context.user.ToList().FindAll(x => x.UserID
                 == requestData.UserId).FirstOrDefault();
                if (user == null || user.UserID <= 0)
                {
                    return -1;
                }
                user.Refeshtoken = requestData.RefeshToken;
                user.Exprired = requestData.Exprired;

                _context.user.Update(user);

                _context.SaveChanges();
                return 1;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Function> GetFunctionByCode(string code)
        {
            return _context.function.ToList().Where(s => s.FunctionCode == code).FirstOrDefault();
        }

        public async Task<UserPermission> GetPermissionByUserID(int UserId, int functionID)
        {
            return _context.userPermission.ToList()
                .Where(s => s.UserID == UserId && s.FunctionID == functionID).FirstOrDefault();
        }
    }
}
