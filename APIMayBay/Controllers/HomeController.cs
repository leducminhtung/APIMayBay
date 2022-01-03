using APIMayBay.Models;
using HtmlAgilityPack;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APIMayBay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ChuyenBayService chuyenBayService;

        public HomeController(ILogger<HomeController> logger, ChuyenBayService chuyenBayService)
        {
            _logger = logger;
            this.chuyenBayService = chuyenBayService;
        }



        public IActionResult Index()
        {
            var html = new HtmlWeb();
            var document = html.Load("https://ngoahotanglong.vn/game-kinh-di-offline-pc/");
   
            var node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/main/div/div/div[1]/div/article");
            string dulieutext = "";

            foreach (var data in node)
            {
                dulieutext += data.InnerText;       
            }
            ViewBag.Dulieuweb = dulieutext;
         
            

            //List<Student> studentList = studentService.GetStudents();
            /* Student st = new Student();
             st.Id = Guid.NewGuid();
             st.Name = "Sinh Viên 1";
             st.Code = "1118";
             st.Phone = "123456789";
             st.Picture = "/images/nq3.jpg";
             studentService.InsertStudent(st);
            */
            return View();
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
