using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace C_NunitFramework.Utilities
{
    public class BaseClass
    {




        String BrowserName;
        public IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            BrowserName = TestContext.Parameters["BrowserName"];
            BrowserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(BrowserName);
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            _driver.Manage().Window.Maximize();
        }


        public void InitBrowser(String Browser)
        {
            switch(Browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;

                case "FireFox":
                    _driver = new FirefoxDriver();
                    break;
                case "Edge":
                    _driver = new EdgeDriver();
                    break;

            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
            TestContext.Progress.WriteLine("Tear down completed");
        }
    }
}
