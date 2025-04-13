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
    public class FunctionalTest
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            _driver.Manage().Window.Maximize();
        }


        [Test]
        public void dropDown()
        {
           IWebElement dropDown = _driver.FindElement(By.XPath("//form[@id='login-form']/div[5]/select"));
            SelectElement sl = new SelectElement(dropDown);
            sl.SelectByText("Teacher");
            sl.SelectByIndex(0);
            sl.SelectByValue("consult");
        }

        [Test]
        public void radioButton()
        {
           IList <IWebElement> radioItemsList = _driver.FindElements(By.XPath("//input[@id='usertype']"));

            foreach(IWebElement radioItems in radioItemsList)
            {
                if (radioItems.GetAttribute("value").Equals("user"))
                {
                    radioItems.Click();
                }
            }

            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            _driver.FindElement(By.Id("okayBtn")).Click();
           bool radioSelected = _driver.FindElement(By.Id("okayBtn")).Selected;

            //Assert.IsTrue(radioSelected);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
