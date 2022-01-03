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
            var document = html.Load("https://vnexpress.net/gia-vang-trong-nuoc-tang-nguoc-chieu-the-gioi-4411484.html");
            var node = document.DocumentNode.SelectSingleNode("/html/body/section[4]/div/div[2]/h1");
            var node2 = document.DocumentNode.SelectSingleNode("/html/body/section[4]/div/div[2]/p");
            string dulieutext = node.InnerText;
            string dulieutext2 = node2.InnerText;

            ViewBag.Dulieuweb = dulieutext;
            ViewBag.Dulieuweb2 = dulieutext2;
            

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
