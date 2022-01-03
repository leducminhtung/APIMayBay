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
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Chrome;

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

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        public IActionResult Index()
        {

            /*IWebDriver driver = new OpenQA.Selenium.PhantomJS.PhantomJSDriver();
            driver.Navigate().GoToUrl("https://www.etrip4u.com/tim-ve-may-bay/SGN-HAN-20220106-100");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);*/


            IWebDriver driver;
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            driver = new ChromeDriver("C:\\Users\\Le Duc Minh Tung\\source\\repos\\WinformGetJsonMaybay\\WinformGetJsonMaybay\\bin\\Debug", options);

            driver.Navigate().GoToUrl("https://www.etrip4u.com/tim-ve-may-bay/SGN-HAN-20220106-100");

            string str1 = driver.PageSource;
            int dem = 0;
            while (dem < 5)
            {
                dem++;
                Thread.Sleep(5000);
                str1 = driver.PageSource;
            }

            var elements = driver.FindElements(By.XPath("//*[@id=\"0\"]/td[1]/span[1]/strong"));
            string before = " class=\"flightJson\" value=\"";


            string input = getBetween(str1, before, "}");
            string json = input.Replace("&quot;", "\"");


            int x = 0;



            /*var node = doc.DocumentNode.SelectNodes("//strong[@class = \"fight-airline\"]");
            int dem = 0;
            while (node == null && dem <5)
            {
                dem++;
                Thread.Sleep(5000);
                node = doc.DocumentNode.SelectNodes("//strong[@class = \"fight-airline\"]");
            }
            string dulieutext = "";
            int x = 0;
            if (node == null)
            {
                dulieutext = "";
                return View();
            }

            foreach (var data in node)
            {
                dulieutext += data.InnerText;
            }*/

            

            ViewBag.Dulieuweb = str1;

            /*var driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("https://www.etrip4u.com/tim-ve-may-bay/SGN-HAN-20220106-100");
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
       .Until(ExpectedConditions.ElementIsVisible(By.ClassName("flightJson")));
            string data = driver.FindElement(By.ClassName("flightJson")).Text;*/

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
