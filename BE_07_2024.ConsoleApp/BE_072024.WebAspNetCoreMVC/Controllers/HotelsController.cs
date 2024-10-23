using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class HotelsController : Controller
    {
        // đi tìm trong thư mục views -> folder ( folder có tên giống tên của controller)
        // từ thư mục giống tên của controlleer -> file trùng với tên của action result
        //Views/Hotels/Index.cshtml 

       
        public IActionResult Index()
        {
            // return View();
            //return View("~/Views/Home/Privacy.cshtml");

            var model = new List<Employeer>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    model.Add(new Employeer
                    {
                        Firstname = i % 2 == 0 ? "MR" : "Ms",
                        LastName = i.ToString(),
                        Email = i + "@gmail.com"
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(model); 
        }

        [HttpPut]
        public IActionResult Index(int id)
        {
            // return View();
            return View("~/Views/Home/Privacy.cshtml");
        }

    }
}
