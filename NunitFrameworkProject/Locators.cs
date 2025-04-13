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
    public class Locators
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            _driver.Manage().Window.Maximize();
            //LocateElements();
        }

        [Test]
        public void LocateElements()
        {
            Console.WriteLine("Execution started");
            // _driver.FindElement(By.Name("q")).SendKeys("Mobile");

            String link = _driver.FindElement(By.LinkText("Withdraw Funds")).Text;
            //String hrefContetn = link.GetAttribute("href");
            //Console.WriteLine(hrefContetn);
            //_driver.FindElement(By.Id("femail")).Clear();
            String actualLink = "Withdraw Funds";

            Assert.AreEqual(link, actualLink);
            Console.WriteLine("Executed Test method");

        }

        [Test]
        public void CheckBox()
        {
            _driver.FindElement(By.Id("username")).SendKeys("erte");
            _driver.FindElement(By.Id("password")).SendKeys("werwe");
            _driver.FindElement(By.XPath("//input[@id='signInBtn']")).Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(_driver.FindElement(By.XPath("//input[@id='signInBtn']")), "Sign In"));

        }


        [TearDown]
        public void TeardDown()
        {
            _driver.Close();
        }
    }
}
