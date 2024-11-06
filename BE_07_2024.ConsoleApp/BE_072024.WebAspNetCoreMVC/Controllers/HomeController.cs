using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index(int? url_id)
        {
            var token = Request.Cookies["BE_072024_TOKEN"] ?? "";
            if (string.IsNullOrEmpty(token))
            {
                return Redirect("/Account/Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Employeer employeer) // EDIT MODEL 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var a = 10;
            return Json(employeer);
        }

        [HttpPost]
        public async Task<ActionResult> _ListEmployeerPartial(HB_RoomGetAllRequestData requestData)
        {
            var model = new List<BE072024_HB_Rooms>();
            var msg = string.Empty;
            try
            {
                var API_BASE_URL = _configuration["Setting:API_BASE_URL"] ?? "";
                var URL = _configuration["Setting:URL"] ?? "";

                var jsonData = JsonConvert.SerializeObject(requestData);

                var token = Request.Cookies["BE_072024_TOKEN"] ?? "";

                var json_result = await BE_072024.Netcore.Common.HttpClientHelper.HttpSenPostWithToken(API_BASE_URL, URL, jsonData, token);

                if (string.IsNullOrEmpty(json_result))
                {
                    // convert json_result -> list Object
                    msg = "Bạn không có quyền thực hiện chức năng này";
                    ViewBag.Message = msg;
                    return PartialView(model);
                   
                }
                else
                {
                    ViewBag.Message = "";
                    model = JsonConvert.DeserializeObject<List<BE072024_HB_Rooms>>(json_result);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
