﻿using DataAccess.NetCore.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.IServices
{
    public interface IAccountServices
    {
        Task<LoginResponseData> AccountLogin(AccountLoginRequestData requestData);
        Task<int> Account_UpdateRefeshToken(Account_UpdateRefeshTokenRequestData requestData);

        Task<Function> GetFunctionByCode(string code);
        Task<UserPermission> GetPermissionByUserID(int UserId, int functionID);

        Task<int> User_Sessions_Insert(User_Sessions sessions);

        Task<int> Account_LogOut(string token);
    }
}
