using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IRoomRepository _roomServices;
        private IRoomGenericRepository _roomGenericRepository;
       private IUnitOfWork _unitOfWork;
        public HotelController(IRoomRepository roomService,
            IRoomGenericRepository roomGenericRepository, IUnitOfWork unitOfWork)
        {
            _roomServices = roomService;
            _roomGenericRepository = roomGenericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Room_GetAll")]
        public async Task<ActionResult> Room_GetAll(HB_RoomGetAllRequestData requestData)
        {
            var list = new List<BE072024_HB_Rooms>();
            try
            {
                //list = await _roomServices.Room_GetAll(requestData);
                list = await _roomGenericRepository.GetAll();
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
                // var rs = await _roomServices.Room_Insert(requestData);
                var request_hotel = new BE072024_HB_Hotels
                {
                    CreatedDate = DateTime.Now,
                    HotelName = "HOTEL_TEST",
                    Description="abc",
                };

                var room_request = new BE072024_HB_Rooms
                {
                    HotelID = requestData.HotelID,
                    IsActive = requestData.IsActive,
                    RoomNumber = requestData.RoomNumber,
                    RoomSquare= requestData.RoomSquare,
                };

                await _unitOfWork._hotelGenericRepository.Insert(request_hotel);

                await _unitOfWork._roomGenericRepository.Insert(room_request);

                var rs =  _unitOfWork.SaveChange();


                return Ok(rs);
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
