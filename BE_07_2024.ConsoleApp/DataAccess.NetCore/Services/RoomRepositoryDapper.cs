using BE_072024.NetCoreAPI.Dapper;
using Dapper;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class RoomRepositoryDapper : BaseApplicationService, IRoomRepositoryDapper
    {
        public RoomRepositoryDapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<BE072024_HB_Rooms>> Room_GetAll(HB_RoomGetAllRequestData requestData)
        {
            var list = new List<BE072024_HB_Rooms>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RoomNumber", requestData.RoomNumber);
                list = await DbConnection.QueryAsync<BE072024_HB_Rooms>("SP_Hotel_GetAll", parameters);
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public async Task<ReturnData> Room_Insert(Room_InsertRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@HotelID", requestData.HotelID);
                parameters.Add("@RoomNumber", requestData.RoomNumber);
                parameters.Add("@RoomSquare", requestData.RoomSquare);
                parameters.Add("@IsActive", requestData.IsActive);
                await DbConnection.ExecuteAsync("SP_Hotel_InsertUpdate", parameters);
               
                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Thêm mới thành công !";
                return returnData;

            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
