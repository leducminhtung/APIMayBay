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
using Lib.Entity;

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
            driver = new ChromeDriver("C:\\Users\\Le Duc Minh Tung\\source\\repos\\APIMayBay\\WinformGetJsonMaybay\\WinformGetJsonMaybay\\bin\\Debug", options);

            driver.Navigate().GoToUrl("https://www.etrip4u.com/tim-ve-may-bay/SGN-HAN-20220106-100");

            string str1 = driver.PageSource;
            int dem = 0;
            while (dem < 5)
            {
                dem++;
                Thread.Sleep(5000);
                str1 = driver.PageSource;
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);

            var dataHang = doc.DocumentNode.SelectNodes("//strong[@class = \"fight-airline\"]");
            List<string> dsHang = new List<string>();
            foreach (var item in dataHang)
            {
                dsHang.Add(item.InnerText);
            }

            var TENCANGDI = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[2]/form[1]/div[1]/h2[2]/strong[1]");
            var TENCANGDEN = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[2]/form[1]/div[1]/h2[2]/strong[2]");

            var tables = doc.DocumentNode.SelectSingleNode("//table[@id = \"tblDepartureFlight\"]");
            var body = tables.SelectSingleNode("//tbody");
            var dataChuyenBay = body.SelectNodes(".//tr");
            List<ChuyenBayViewModel> dsChuyenBay = new List<ChuyenBayViewModel>();
            foreach (var datachuyenbay in dataChuyenBay)
            {
                ChuyenBayViewModel chuyenbay = new ChuyenBayViewModel();
                var infoChuyenBay = datachuyenbay.SelectNodes(".//td");
                foreach (var info in infoChuyenBay)
                {
                    string attributeValue = info.GetAttributeValue("class", "");
                    if (attributeValue.Equals("col-airlines-info"))
                    {
                        var dataMB = info.SelectSingleNode("//span[@class = \"flight-type\"]");
                        var datainfoMB = info.SelectNodes("//span[@class = \"flight-no\"]");
                        var TENMB = dataMB.SelectSingleNode("//span[3]");
                        for (int i = 0; i < datainfoMB.Count; i++)
                        {
                            if (i == 1) TENMB = datainfoMB[i];
                        }
                      
                        var TenHANG = info.SelectSingleNode("//span[@class = \"name-airlines\"]");
                        var MaCB = info.SelectSingleNode("//strong[@class = \"FlightNo show-responsive\"]");
                        /*var MACANGDI = info.SelectSingleNode("//input[@name = \"departureFlights[0].DepartureCity\"]");
                        var MACANGDEN = info.SelectSingleNode("//input[@name = \"departureFlights[0].ArrivalCity\"]");
                        var MAMB = info.SelectSingleNode("//input[@name = \"departureFlights[0].AirlineId\"]");
                        var MAHANG = info.SelectSingleNode("//input[@name = \"departureFlights[0].FlightAirline\"]");
                        var NGAYGIODI = info.SelectSingleNode("//input[@name = \"departureFlights[0].DepartureDate\"]");
                        var NGAYGIODEN = info.SelectSingleNode("//input[@name = \"departureFlights[0].ArrivalDate\"]");*/
                        var PICTURE = info.SelectSingleNode("//img[@class = \"best-logo\"]");




                        chuyenbay.TENHANG = TenHANG.InnerText;
                        chuyenbay.MaCB = MaCB.InnerText;
                        chuyenbay.TENCANGDI = TENCANGDI.InnerText;
                        chuyenbay.TENCANGDEN = TENCANGDEN.InnerText;
                        chuyenbay.TenMB = TENMB.InnerText;
                        /*chuyenbay.MACANGDI = MACANGDI.InnerText;
                        chuyenbay.MACANGDEN = MACANGDEN.InnerText;
                        chuyenbay.NgayDen = DateTime.Parse(NGAYGIODEN.InnerText);
                        chuyenbay.NgayDi = DateTime.Parse(NGAYGIODI.InnerText);*/
                    }
                    if (attributeValue.Equals("time departure"))
                    {

                    }

                }

                
            }





            ViewBag.Dulieuweb = dsChuyenBay;


            return View(dsChuyenBay);
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
