using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class RoomRepository : IRoomRepository
    {
        BE_072024dDbContext _context;
        public RoomRepository(BE_072024dDbContext context)
        {
            _context = context;
        }
        public async Task<List<BE072024_HB_Rooms>> Room_GetAll(HB_RoomGetAllRequestData requestData)
        {
            var list = new List<BE072024_HB_Rooms>();
            try
            {
                list = _context.bE072024_HB_Rooms.ToList();
                if (!string.IsNullOrEmpty(requestData.RoomNumber))
                {
                    list = list.FindAll(s => s.RoomNumber.ToLower().Contains(requestData.RoomNumber.ToLower()));
                }
            }
            catch (Exception ex)
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
                if (requestData == null
                    || requestData.HotelID <= 0
                    || string.IsNullOrEmpty(requestData.RoomNumber)
                    || requestData.IsActive < 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu không hợp lệ";
                    return returnData;
                }

                var req = new BE072024_HB_Rooms
                {
                    HotelID = requestData.HotelID,
                    RoomNumber = requestData.RoomNumber,
                    RoomSquare = requestData.RoomSquare,
                    IsActive = requestData.IsActive
                };
                _context.bE072024_HB_Rooms.Add(req);

                var rs = _context.SaveChanges();// trả về số dòng được thay đổi 
                if (rs == 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMessage = "Thêm mới thất bại";
                    return returnData;
                }

                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Thêm mới thành công";
                return returnData;

            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -99;
                returnData.ReturnMessage = ex.Message;
                return returnData;
            }

        }
    }
}
