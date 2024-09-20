using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IRoomServices _roomServices;
        public HotelController(IRoomServices roomService)
        {
            _roomServices = roomService;
        }

        [HttpPost("Room_GetAll")]
        public async Task<ActionResult> Room_GetAll(HB_RoomGetAllRequestData requestData)
        {
            var list = new List<BE072024_HB_Rooms>();
            try
            {
                list = await _roomServices.Room_GetAll(requestData);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(list);
        }

        [HttpPost("Room_Insert")]
        public async Task<ActionResult> Room_Insert(Room_InsertRequestData requestData)
        {
            try
            {
                var rs = await _roomServices.Room_Insert(requestData);
                return Ok(rs);
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
