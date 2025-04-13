using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFrameworkProject
{
    public class WindowHandlesProgram
    {

        IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void windowHandleTest()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindow = _driver.CurrentWindowHandle.ToString();
            _driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, _driver.WindowHandles.Count);

            String childWindow = _driver.WindowHandles[1];
            _driver.SwitchTo().Window(childWindow);
            //_driver.FindElement(By.XPath("//div[@class='header-upper']/div/div/div[2]/nav/div[2]/ul/li[8]/a")).Click();
            String content = _driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
            TestContext.Progress.WriteLine(content);

            String[] splittedArray = content.Split("at");

            String[] splittednTrimmed = splittedArray[1].Trim().Split(" ");
            TestContext.Progress.WriteLine(splittednTrimmed[0]);

            Assert.AreEqual(email, splittednTrimmed[0]);
            _driver.SwitchTo().Window(parentWindow);

            _driver.FindElement(By.Id("username")).SendKeys(splittednTrimmed[0]);
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
