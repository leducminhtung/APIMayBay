using APIMayBay.BackgroundService;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using APIMayBay.Models;
using HtmlAgilityPack;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;


using OpenQA.Selenium;

using System.Threading;
using OpenQA.Selenium.Chrome;
using Lib.Entity;
using Lib;
using Lib.Repositories.Lib.Repositories;
using APIMayBay.Controllers;

namespace APIMayBay.ScheduleTask
{
    public class SampleTask1 : ScheduledProcessor
    {

        
        private ChuyenBayService chuyenBayService;
        private CangBayService cangBayService;
        private LoTuyenService loTuyenService;

        public SampleTask1(IServiceScopeFactory serviceScopeFactory, ChuyenBayService chuyenBayService,CangBayService cangBayService,LoTuyenService loTuyenService) : base(serviceScopeFactory)
        {
          
            this.chuyenBayService = chuyenBayService;
            this.cangBayService = cangBayService;
            this.loTuyenService = loTuyenService;
        }

        protected override string Schedule => "*/1 * * * *"; // every 1 min 

        public void LayDuLieuTuWeb(string url)
        {
            IWebDriver driver;
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            driver = new ChromeDriver("C:\\Users\\Le Duc Minh Tung\\source\\repos\\APIMayBay\\WinformGetJsonMaybay\\WinformGetJsonMaybay\\bin\\Debug", options);

            driver.Navigate().GoToUrl(url);

            string str1 = driver.PageSource;
            int dem = 0;
            while (dem < 5)
            {
                dem++;
                Thread.Sleep(4000);
                str1 = driver.PageSource;
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);






            var TENCANGDI = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[2]/form[1]/div[1]/h2[2]/strong[1]");
            var TENCANGDEN = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[2]/form[1]/div[1]/h2[2]/strong[2]");
            var dataNgayDi = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[1]/div/div[2]/span[1]/strong");

            string NgayDi = "";
            if (dataNgayDi != null)
            NgayDi = dataNgayDi.InnerText;

            var dataNgayDen = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/section/div/div[2]/div/div[1]/div/div[2]/span[2]/strong");
            string NgayDen = "";
            if (dataNgayDen != null)
            NgayDen = dataNgayDen.InnerText;


            //Bay di
            var dataTenHang = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//strong[@class = \"fight-airline\"]");
            var dataMaCB_TenMB = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//span[@class = \"flight-no\"]");
            var GioBay = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"time departure\"]//strong");
            var CangDi = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"time departure\"]//span[1]");
            var TGDi = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"time departure\"]//span[2]");

            var dataGiaNguoiLon = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.AdultFare\"]");
            var dataGiaTreEm = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.ChildFare\"]");
            var dataGiaEmBe = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.InfantFare\"]");

            var dataThuePhiSBNguoiLon = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.AdultCharge\"]");
            var dataThuePhiSBTreEm = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.ChildCharge\"]");
            var dataThuePhiSBEmBe = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.InfantCharge\"]");

            var dataDichVuNguoiLon = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.AdultServiceFee\"]");
            var dataDichVuTreEm = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.ChildServiceFee\"]");
            var dataDichVuEmBe = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//input[@name = \"departureFlights[0].FareInfo.InfantServiceFee\"]");



            var GioDen = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"time arrival\"]//strong");
            var CangDen = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"time arrival\"]//span[1]");
            var GiaNguoiLon = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//td[@class = \"price\"]//span[1]");

            var Logo = doc.DocumentNode.SelectNodes("//table[@id=\"tblDepartureFlight\"]//img[@class = \"best-logo\"]");

            //Bayve

            var dataTenHang_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//strong[@class = \"fight-airline\"]");
            var dataMaCB_TenMB_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//span[@class = \"flight-no\"]");
            var GioBay_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"time departure\"]//strong");
            var CangDi_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"time departure\"]//span[1]");
            var TGDi_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"time departure\"]//span[2]");

            var dataGiaNguoiLon_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.AdultFare\"]");
            var dataGiaTreEm_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.ChildFare\"]");
            var dataGiaEmBe_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.InfantFare\"]");

            var dataThuePhiSBNguoiLon_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.AdultCharge\"]");
            var dataThuePhiSBTreEm_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.ChildCharge\"]");
            var dataThuePhiSBEmBe_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.InfantCharge\"]");

            var dataDichVuNguoiLon_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.AdultServiceFee\"]");
            var dataDichVuTreEm_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.ChildServiceFee\"]");
            var dataDichVuEmBe_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//input[@name = \"returnFlights[0].FareInfo.InfantServiceFee\"]");


            var GioDen_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"time arrival\"]//strong");
            var CangDen_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"time arrival\"]//span[1]");
            var GiaNguoiLon_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//td[@class = \"price\"]//span[1]");

            var Logo_Ve = doc.DocumentNode.SelectNodes("//table[@id=\"tblReturnFlight\"]//img[@class = \"best-logo\"]");



            var SLNguoiLon = doc.DocumentNode.SelectSingleNode("//strong[@id = \"adultLabel\"]");
            var SLTreEm = doc.DocumentNode.SelectSingleNode("//strong[@id = \"childLabel\"]");
            var SLEmBe = doc.DocumentNode.SelectSingleNode("//strong[@id = \"infantLabel\"]");



            List<ChuyenBayViewModel> dsCB = new List<ChuyenBayViewModel>();
            if (dataTenHang != null)
            for (int i = 0; i < dataTenHang.Count; i++)
            {
                ChuyenBayViewModel chuyenBay = new ChuyenBayViewModel();
                chuyenBay.TENHANG = dataTenHang[i].InnerText;
                chuyenBay.MACANGDI = CangDi[i].InnerText;
             
                chuyenBay.TenMB = dataMaCB_TenMB[i].InnerText + " | " + dataMaCB_TenMB[i*2].InnerText;
                chuyenBay.TENCANGDI = TENCANGDI.InnerText;
                chuyenBay.TENCANGDEN = TENCANGDEN.InnerText;
                chuyenBay.MACANGDEN = CangDen[i].InnerText;
                string LoGoUrl = Logo[i].GetAttributeValue("src", "");
                chuyenBay.PICTURE = "https://www.etrip4u.com/" + LoGoUrl;
                chuyenBay.GIANGUOILON = Decimal.Parse(GiaNguoiLon[i * 2].InnerText.Replace(",", ""));

                string GiaVeTreEm = dataGiaTreEm[i].GetAttributeValue("value", "");
                string GiaVeEmBe = dataGiaEmBe[i].GetAttributeValue("value", "");
                string ThueSBNguoiLon = dataThuePhiSBNguoiLon[i].GetAttributeValue("value", "");
                string ThueSBTreEm = dataThuePhiSBTreEm[i].GetAttributeValue("value", "");
                string ThueSBEmBe = dataThuePhiSBEmBe[i].GetAttributeValue("value", "");
                string DichVuNguoiLon = dataDichVuNguoiLon[i].GetAttributeValue("value", "");
                string DichVuTreEm = dataDichVuTreEm[i].GetAttributeValue("value", "");
                string DichVuEmBe = dataDichVuEmBe[i].GetAttributeValue("value", "");

                chuyenBay.GIATREEM = Decimal.Parse(GiaVeTreEm);
                chuyenBay.GIAEMBE = Decimal.Parse(GiaVeEmBe);
                chuyenBay.THUEPHISANBAYNGUOILON = Decimal.Parse(ThueSBNguoiLon);
                chuyenBay.THUEPHISANBAYTREEM = Decimal.Parse(ThueSBTreEm);
                chuyenBay.THUEPHISANBAYEMBE = Decimal.Parse(ThueSBEmBe);
                chuyenBay.GIADICHVUNGUOILON = Decimal.Parse(DichVuNguoiLon);
                chuyenBay.GIADICHVUTREEM = Decimal.Parse(DichVuTreEm);
                chuyenBay.GIADICHVUEMBE = Decimal.Parse(DichVuEmBe);


                chuyenBay.SoLuongNguoiLon = Int32.Parse(SLNguoiLon.InnerText);
                chuyenBay.SoLuongTreEm = Int32.Parse(SLTreEm.InnerText);
                chuyenBay.SoLuongEmBe = Int32.Parse(SLEmBe.InnerText);
                chuyenBay.NgayDen = NgayDi.Substring(NgayDi.Length - 11);

                chuyenBay.NgayDi = NgayDi.Substring(NgayDi.Length - 11);

                chuyenBay.GioDen = GioDen[i].InnerText;
                chuyenBay.GioDi = GioBay[i].InnerText;

                string NgayGioDen = chuyenBay.NgayDen + " " + chuyenBay.GioDen;
                string NgayGioDi = chuyenBay.NgayDi + " " + chuyenBay.GioDi;

                chuyenBay.NgayGioDen = DateTime.Parse(NgayGioDen);
                chuyenBay.NgayGioDi = DateTime.Parse(NgayGioDi);


                int raw_TGBAY = Int32.Parse(TGDi[i].InnerText.Replace(":", ""));
                int gio = raw_TGBAY / 100;
                int phut = raw_TGBAY % 100;
                chuyenBay.ThoiGianBay = gio * 60 + phut;

                chuyenBay.TONGTIEN = chuyenBay.SoLuongNguoiLon * (chuyenBay.GIANGUOILON + chuyenBay.THUEPHISANBAYNGUOILON + chuyenBay.GIADICHVUNGUOILON) + chuyenBay.SoLuongTreEm * (chuyenBay.GIATREEM + chuyenBay.THUEPHISANBAYTREEM + chuyenBay.GIADICHVUTREEM)
                    + chuyenBay.SoLuongEmBe * (chuyenBay.GIAEMBE + chuyenBay.THUEPHISANBAYEMBE + chuyenBay.GIADICHVUEMBE);
                    chuyenBay.MaCB = chuyenBay.MACANGDEN + chuyenBay.MACANGDI + chuyenBay.NgayDi + chuyenBay.NgayDen + chuyenBay.TENHANG + chuyenBay.GIANGUOILON + chuyenBay.GIATREEM + chuyenBay.GIAEMBE + chuyenBay.NgayGioDen.ToString() + chuyenBay.NgayGioDi.ToString();
                    dsCB.Add(chuyenBay);
            }

            if (dataTenHang_Ve != null)
                for (int i = 0; i < dataTenHang_Ve.Count; i++)
            {
                ChuyenBayViewModel chuyenBay = new ChuyenBayViewModel();
                chuyenBay.TENHANG = dataTenHang_Ve[i].InnerText;
                chuyenBay.MACANGDI = CangDi_Ve[i].InnerText;
                
                chuyenBay.TenMB = dataMaCB_TenMB_Ve[i].InnerText + " | " + dataMaCB_TenMB_Ve[i * 2].InnerText;
                chuyenBay.TENCANGDI = TENCANGDI.InnerText;
                chuyenBay.TENCANGDEN = TENCANGDEN.InnerText;
                chuyenBay.MACANGDEN = CangDen_Ve[i].InnerText;
                string LoGoUrl = Logo_Ve[i].GetAttributeValue("src", "");
                chuyenBay.PICTURE = "https://www.etrip4u.com/" + LoGoUrl;
                chuyenBay.GIANGUOILON = Decimal.Parse(GiaNguoiLon_Ve[i * 2].InnerText.Replace(",", ""));

                string GiaVeTreEm = dataGiaTreEm_Ve[i].GetAttributeValue("value", "");
                string GiaVeEmBe = dataGiaEmBe_Ve[i].GetAttributeValue("value", "");
                string ThueSBNguoiLon = dataThuePhiSBNguoiLon_Ve[i].GetAttributeValue("value", "");
                string ThueSBTreEm = dataThuePhiSBTreEm_Ve[i].GetAttributeValue("value", "");
                string ThueSBEmBe = dataThuePhiSBEmBe_Ve[i].GetAttributeValue("value", "");
                string DichVuNguoiLon = dataDichVuNguoiLon_Ve[i].GetAttributeValue("value", "");
                string DichVuTreEm = dataDichVuTreEm_Ve[i].GetAttributeValue("value", "");
                string DichVuEmBe = dataDichVuEmBe_Ve[i].GetAttributeValue("value", "");

                chuyenBay.GIATREEM = Decimal.Parse(GiaVeTreEm);
                chuyenBay.GIAEMBE = Decimal.Parse(GiaVeEmBe);
                chuyenBay.THUEPHISANBAYNGUOILON = Decimal.Parse(ThueSBNguoiLon);
                chuyenBay.THUEPHISANBAYTREEM = Decimal.Parse(ThueSBTreEm);
                chuyenBay.THUEPHISANBAYEMBE = Decimal.Parse(ThueSBEmBe);
                chuyenBay.GIADICHVUNGUOILON = Decimal.Parse(DichVuNguoiLon);
                chuyenBay.GIADICHVUTREEM = Decimal.Parse(DichVuTreEm);
                chuyenBay.GIADICHVUEMBE = Decimal.Parse(DichVuEmBe);

                chuyenBay.SoLuongNguoiLon = Int32.Parse(SLNguoiLon.InnerText);
                chuyenBay.SoLuongTreEm = Int32.Parse(SLTreEm.InnerText);
                chuyenBay.SoLuongEmBe = Int32.Parse(SLEmBe.InnerText);
                chuyenBay.NgayDen = NgayDen.Substring(NgayDen.Length - 11);

                chuyenBay.NgayDi = NgayDen.Substring(NgayDen.Length - 11);

                chuyenBay.GioDen = GioDen_Ve[i].InnerText;
                chuyenBay.GioDi = GioBay_Ve[i].InnerText;

                string NgayGioDen = chuyenBay.NgayDen + " " + chuyenBay.GioDen;
                string NgayGioDi = chuyenBay.NgayDi + " " + chuyenBay.GioDi;

                chuyenBay.NgayGioDen = DateTime.Parse(NgayGioDen);
                chuyenBay.NgayGioDi = DateTime.Parse(NgayGioDi);


                int raw_TGBAY = Int32.Parse(TGDi_Ve[i].InnerText.Replace(":", ""));
                int gio = raw_TGBAY / 100;
                int phut = raw_TGBAY % 100;
                chuyenBay.ThoiGianBay = gio * 60 + phut;

                chuyenBay.TONGTIEN = chuyenBay.SoLuongNguoiLon * (chuyenBay.GIANGUOILON + chuyenBay.THUEPHISANBAYNGUOILON + chuyenBay.GIADICHVUNGUOILON) + chuyenBay.SoLuongTreEm * (chuyenBay.GIATREEM + chuyenBay.THUEPHISANBAYTREEM + chuyenBay.GIADICHVUTREEM)
                    + chuyenBay.SoLuongEmBe * (chuyenBay.GIAEMBE + chuyenBay.THUEPHISANBAYEMBE + chuyenBay.GIADICHVUEMBE);
                chuyenBay.MaCB = chuyenBay.MACANGDEN + chuyenBay.MACANGDI + chuyenBay.NgayDi + chuyenBay.NgayDen + chuyenBay.TENHANG + chuyenBay.GIANGUOILON + chuyenBay.GIATREEM + chuyenBay.GIAEMBE + chuyenBay.NgayGioDen.ToString() + chuyenBay.NgayGioDi.ToString();
                dsCB.Add(chuyenBay);
            }



            if (dsCB != null)
            foreach (var chuyenbay in dsCB)
            {
                chuyenBayService.InsertChuyenBay(chuyenbay);
            }

            //return Task.CompletedTask;
            
            driver.Close();

        }

        public override async Task ProcessInScope(IServiceProvider scopeServiceProvider) 
        {

            string urlbase = "https://www.etrip4u.com/tim-ve-may-bay/";
            var dsCangBay = cangBayService.GetCangBays();
            var dsCangBay2 = cangBayService.GetCangBays();
            DateTime homnay = DateTime.Now;
            
            int ngaycuoithang = DateTime.DaysInMonth(homnay.Year, homnay.Month);
           
            // Mot chieu
            foreach (var cangdi in dsCangBay)
            {
                foreach (var cangden in dsCangBay2)
                {
                    if (cangden == cangdi) continue;
                    else
                    {
                        for (int i = homnay.Day; i <= ngaycuoithang; i++)
                        {
                            string day = "";
                            if (i < 10) day = "0" + i.ToString();
                            else day = i.ToString();

                            string month = "";
                            if (homnay.Month < 10) month = "0" + homnay.Month.ToString();
                            else month = homnay.Month.ToString();

                            string ngaydi = homnay.Year.ToString() + month.ToString() + day.ToString();
                            string urlLayData = urlbase + cangdi.MaCB + "-" + cangden.MaCB + "-" + ngaydi + "-" + "111";
                            /*LayDuLieuTuWeb(urlLayData);*/

                        }

                        

                    }    
                    
                }
                
                

            }

            //Khu hoi
            foreach (var cangdi in dsCangBay)
            {
                foreach (var cangden in dsCangBay2)
                {
                    if (cangden == cangdi) continue;
                    else
                    {
                        for (int i = homnay.Day; i < ngaycuoithang; i++)
                        {

                            for (int v = i + 1; v < ngaycuoithang; v++)
                            {

                                string day = "";
                                if (i < 10) day = "0" + i.ToString();
                                else day = i.ToString();

                                string month = "";
                                if (homnay.Month < 10) month = "0" + homnay.Month.ToString();
                                else month = homnay.Month.ToString();

                                string ngaydi = homnay.Year.ToString() + month.ToString() + day;



                                string day2 = "";
                                if (v < 10) day2 = "0" + v.ToString();
                                else day2 = v.ToString();

                                string month2 = "";
                                if (homnay.Month < 10) month2 = "0" + homnay.Month.ToString();
                                else month2 = homnay.Month.ToString();

                                string ngayve = homnay.Year.ToString() + month2.ToString() + day2.ToString();



                                string urlLayData = urlbase + cangdi.MaCB + "-" + cangden.MaCB + "-" + ngaydi + "-" + ngayve + "-" + "111";
                                /*LayDuLieuTuWeb(urlLayData);*/
                            }



                        }



                    }

                }



            }

            


            await Task.Run(() => {
                return Task.CompletedTask;
            });
        }
    }

}