using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Account_Login(LoginRequestData model)
        {
            var returnData = new LoginResponseData();
            try
            {
                // GỌI VÀO DB 
                // GỌI API 

                returnData.ResponseCode = 1;
                returnData.ResponseMes = "Đăng nhập thành công!";
                returnData.token = ""; // xử lý gọi API 
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(returnData);
        }
    }
}
