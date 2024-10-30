﻿using BE_072024.WebAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BE_072024.WebAspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? url_id)
        {
            // mở thư mục views tìm thư mục home(Tương ứng với HomeController )
            // //-> tìm file index.cshtml

            // trả dữ liệu nằm trong model về view 
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employeer employeer) // EDIT MODEL 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var a = 10;
            return Json(employeer);
        }

        [HttpPost("_ListEmployeerPartial")]
  
        public ActionResult _ListEmployeerPartial()
        {
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
