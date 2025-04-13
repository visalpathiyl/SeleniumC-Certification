using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFrameworkProject
{
    public class SeleniumFirstTest
    {

        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
           _driver = new ChromeDriver();
           _driver.Navigate().GoToUrl("https://www.flipkart.com/?affid=affveve&affExtParam1=53172266f4d0230fa2a12b7f09bf34c0&affExtParam2=60827");
            _driver.Manage().Window.Maximize();
            //Test();

        }

        [Test]
        public void Test()
        {

            TestContext.Progress.WriteLine(_driver.Title);
            TestContext.Progress.WriteLine((_driver.Url));
        }

        [TearDown]
        public void TearDown()
        {
                _driver?.Quit();
                _driver?.Dispose();

        }
    }
}
