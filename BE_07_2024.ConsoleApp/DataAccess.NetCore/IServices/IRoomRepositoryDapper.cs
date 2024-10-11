using DataAccess.NetCore.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.IServices
{
    public interface IRoomRepositoryDapper
    {
        Task<List<BE072024_HB_Rooms>> Room_GetAll(HB_RoomGetAllRequestData requestData);
        Task<ReturnData> Room_Insert(Room_InsertRequestData requestData);
    }
}
