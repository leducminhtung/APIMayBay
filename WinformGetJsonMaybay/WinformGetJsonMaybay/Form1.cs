using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformGetJsonMaybay
{
    
    public partial class Form1 : Form
    {
        IWebDriver driver;
        
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

        public Form1()
        {
            InitializeComponent();
           

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            driver = new ChromeDriver("C:\\Users\\Le Duc Minh Tung\\source\\repos\\WinformGetJsonMaybay\\WinformGetJsonMaybay\\bin\\Debug", options);
          
            driver.Navigate().GoToUrl("https://www.etrip4u.com/tim-ve-may-bay/SGN-HAN-20220106-100");
            
            string str1 = driver.PageSource;
            var elements = driver.FindElements(By.XPath("//*[@id=\"0\"]/td[1]/span[1]/strong"));
            string before = " class=\"flightJson\" value=\"";
        

            string input = getBetween(str1, before, "}");
            string json = input.Replace("&quot;", "\"");


            int x = 0;



        }

        
    }
}
