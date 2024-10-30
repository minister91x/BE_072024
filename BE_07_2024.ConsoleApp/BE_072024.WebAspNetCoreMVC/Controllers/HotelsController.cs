using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class HotelsController : Controller
    {
        // đi tìm trong thư mục views -> folder ( folder có tên giống tên của controller)
        // từ thư mục giống tên của controlleer -> file trùng với tên của action result
        //Views/Hotels/Index.cshtml 


        private IConfiguration _configuration;

        public HotelsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {


            var model = new List<BE072024_HB_Rooms>();// View Model
            try
            {
                var API_BASE_URL = _configuration["Setting:API_BASE_URL"] ?? "";
                var URL = _configuration["Setting:URL"] ?? "";

                var requestData = new HB_RoomGetAllRequestData { RoomNumber = "" };
                var jsonData = JsonConvert.SerializeObject(requestData);

                var json_result = await BE_072024.Netcore.Common.HttpClientHelper.HttpSenPost(API_BASE_URL, URL, jsonData);

                if (!string.IsNullOrEmpty(json_result))
                {
                    // convert json_result -> list Object
                    model = JsonConvert.DeserializeObject<List<BE072024_HB_Rooms>>(json_result);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return View(model);
        }

        [HttpPut]
        public IActionResult Index(int id)
        {
            // return View();
            return View("~/Views/Home/Privacy.cshtml");
        }

    }
}
