using BE_072024.NetCoreAPI.Filter;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IRoomRepository _roomServices;
        private IRoomGenericRepository _roomGenericRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;

        public HotelController(IRoomRepository roomService,
            IRoomGenericRepository roomGenericRepository, IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _roomServices = roomService;
            _roomGenericRepository = roomGenericRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        [HttpPost("Room_GetAll")]
      //  [BE_072024Authorize("Room_GetAll", "VIEW")]
        public async Task<ActionResult> Room_GetAll(HB_RoomGetAllRequestData requestData)
        {
            var list = new List<BE072024_HB_Rooms>();
            try
            {
                //list = await _roomServices.Room_GetAll(requestData);

                var keyCache = "Room_GetAll";
                byte[] cachedData = await _cache.GetAsync(keyCache);

                if (cachedData != null)
                {
                    // Nếu trong caching có dâta thì gọi caching để lấy dữ liệu và trả vẻ Web
                    var cachedDataString = Encoding.UTF8.GetString(cachedData);
                    // convert data caching sang list object 
                    list = JsonConvert.DeserializeObject<List<BE072024_HB_Rooms>>(cachedDataString);
                    return Ok(list);
                }
                else
                {
                    // Nếu trong caching chưa có thì gọi database dể lấy dữ liệu
                    list = await _roomGenericRepository.GetAll();

                    //-> lưu dữ liêu vào caching
                    var cachedDataString = JsonConvert.SerializeObject(list);
                    var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                    await _cache.SetAsync(keyCache, dataToCache, options);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            //  ->trả về Web
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
                    Description = "abc",
                };

                var room_request = new BE072024_HB_Rooms
                {
                    HotelID = requestData.HotelID,
                    IsActive = requestData.IsActive,
                    RoomNumber = requestData.RoomNumber,
                    RoomSquare = requestData.RoomSquare,
                };

                await _unitOfWork._hotelGenericRepository.Insert(request_hotel);

                await _unitOfWork._roomGenericRepository.Insert(room_request);

                var rs = _unitOfWork.SaveChange();


                return Ok(rs);
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
