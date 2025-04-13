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
    public class E2ETesting
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
        public void E2ETestFlow()
        {
            String[] products = {"iphone X", "Blackberry" };
            _driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            _driver.FindElement(By.Id("password")).SendKeys("learning");
            _driver.FindElement(By.Id("signInBtn")).Click();
            //Thread.Sleep(5000);
            //_driver.SwitchTo().Alert().Accept();
            //_driver.SwitchTo().DefaultContent();


            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='nav-link btn btn-primary']")));

           IList<IWebElement> actualProducts = _driver.FindElements(By.TagName("app-card"));

            foreach(IWebElement prod in actualProducts)
            {
                bool value = products.Contains(prod.FindElement(By.CssSelector(".card-title a")).Text);
                TestContext.Progress.WriteLine(value);
                if (value)
                {
                    prod.FindElement(By.CssSelector(".card-footer button")).Click();
                }


                TestContext.Progress.WriteLine(prod.FindElement(By.CssSelector(".card-title a")).Text);
                
            }

            _driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']")).Click();

            //Thread.Sleep(5000);

            IList<IWebElement> cartList = _driver.FindElements(By.XPath("//h4/a"));
            String[] actualArray = new String[cartList.Count];
            for (int i=0;i<cartList.Count; i++)
            {
                actualArray[i] = cartList[i].Text;
            }

            Assert.AreEqual(products, actualArray);
            _driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            _driver.FindElement(By.Id("country")).SendKeys("Ind");
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("India")));
            _driver.FindElement(By.LinkText("India")).Click();
            _driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            _driver.FindElement(By.XPath("//input[@class='btn btn-success btn-lg']")).Click();
            String successText = _driver.FindElement(By.XPath("//div[@class='alert alert-success alert-dismissible']")).Text;
            StringAssert.Contains("Success", successText);
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
