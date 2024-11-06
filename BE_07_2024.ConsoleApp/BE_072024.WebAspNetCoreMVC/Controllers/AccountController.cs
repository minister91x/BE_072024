using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public async Task<JsonResult> Account_Login(LoginRequestData model)
        {
            var returnData = new LoginResponseData();
            try
            {
                var API_BASE_URL = _configuration["Setting:API_BASE_URL"] ?? "";
                var URL = _configuration["Setting:URL_LOGIN"] ?? "";


                var RequestJson = JsonConvert.SerializeObject(model);
                var result = await BE_072024.Netcore.Common.HttpClientHelper.HttpSenPost(API_BASE_URL, URL, RequestJson);

                if (!string.IsNullOrEmpty(result))
                {
                    returnData = JsonConvert.DeserializeObject<LoginResponseData>(result);
                }

                return Json(returnData);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData);
        }
    }
}
