using BE072024.Common.DBConnect.SqlServer;
using BE072024.DataAcceess_NetFrameWork.DAL;
using BE072024.DataAcceess_NetFrameWork.DO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DALImpl
{
    public class AccountDALImpl : IAccountDAL
    {
        public List<Account> Account_GetList(Account_GetAllRequestData requestData)
        {
            var list = new List<Account>();
            try
            {
                // Bước 1 : mở connection
                var connect = SqlDbHepler.GetSqlConnection();

                // bƯỚC 2: SQlCommand để thao tác với dữ liệ
                var cmd = new SqlCommand("SP_Account_GetList", connect);
                //cmd.CommandType = System.Data.CommandType.Text;

                // chỉ cho sqlcommand biết là loại nào ( commandtext hay storeprocedure)
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // truyển tham số qua parameter
                cmd.Parameters.AddWithValue("@UserId", requestData.ID);

                // Bước 3: nhận kết quả 
                var rs = cmd.ExecuteReader();
                // convert từ SqlDataReader  -> List<Account>
                while (rs.Read())
                {
                    var account = new Account();
                    account.ID = rs["ID"] != DBNull.Value ? Convert.ToInt32(rs["ID"].ToString()) : 0;
                    account.UserName = rs["UserName"] != DBNull.Value ? rs["UserName"].ToString() : "";
                    account.FullName = rs["FullName"] != DBNull.Value ? rs["FullName"].ToString() : "";
                    list.Add(account);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
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

                // Bước 1 : mở connection
                var connect = SqlDbHepler.GetSqlConnection();

                // bƯỚC 2: SQlCommand để thao tác với dữ liệ
                var cmd = new SqlCommand("SP_Account_Insert", connect);
                //cmd.CommandType = System.Data.CommandType.Text;

                // chỉ cho sqlcommand biết là loại nào ( commandtext hay storeprocedure)
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // truyển tham số qua parameter
                cmd.Parameters.AddWithValue("@UserName", requestData.UserName);
                cmd.Parameters.AddWithValue("@Password", requestData.Password);
                cmd.Parameters.AddWithValue("@FullName", requestData.FullName);
                cmd.Parameters.AddWithValue("@ResponseCode", System.Data.SqlDbType.Int)
                    .Direction = System.Data.ParameterDirection.Output;

                // Bước 3: nhận kết quả 
                var rs = cmd.ExecuteNonQuery();

                connect.Close();

                var output = cmd.Parameters["@ResponseCode"].Value != DBNull.Value 
                    ? Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value)
                    : 0;

                if (output <= 0)
                {
                    switch (output)
                    {
                        case -1:
                            returnData.ReturrnCode = -1;
                            returnData.ReturrnMsg = "Đã trùng tài khoản";
                            return returnData;
                        default:
                            returnData.ReturrnCode = -99;
                            returnData.ReturrnMsg = "Hệ thông đang bận";
                            return returnData;
                    }
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
