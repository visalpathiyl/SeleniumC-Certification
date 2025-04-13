using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NunitFrameworkProject
{
    public class AlertActionAutoSuggestive
    {
        IWebDriver _driver;
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            _driver.Manage().Window.Maximize();
        }


        [Test]
        public void AlertTest()
        {
            String name = "John";
            _driver.FindElement(By.Id("name")).SendKeys(name);
            _driver.FindElement(By.Id("confirmbtn")).Click();
            String alertContents =_driver.SwitchTo().Alert().Text;
            _driver.SwitchTo().Alert().Accept();

            StringAssert.Contains(name, alertContents);
        }


        [Test]
        public void AutoSuggestive()
        {
            _driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".ui-menu-item div")));
            IList<IWebElement> listofCountries = _driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach(IWebElement cont in listofCountries)
            {

                TestContext.Progress.WriteLine(cont.Text);
                if (cont.Text.Equals("India"))
                {
                    cont.Click();
                }
            }

            TestContext.Progress.WriteLine(_driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));

        }

        [Test]
        public void actionTest()
        {
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/#/Index");
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(By.XPath("//div[@class='header-upper']/div/div/div[2]/nav/div[2]/ul/li[9]/a"))).Perform();
            action.MoveToElement(_driver.FindElement(By.XPath("//div[@class='header-upper']/div/div/div[2]/nav/div[2]/ul/li[9]/ul/li[1]/a"))).Click().Perform();
        }

        [Test]
        public void dragAndDrop()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/droppable");
            Actions actions = new Actions(_driver);
            actions.DragAndDrop(_driver.FindElement(By.Id("draggable")), _driver.FindElement(By.Id("droppable"))).Perform();
        }


        [Test]
        public void iFrameMethod()
        {

            IWebElement frameScroll = _driver.FindElement(By.XPath("//iframe[@id='courses-iframe']"));
            IJavaScriptExecutor js= (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView[true];", frameScroll);
            _driver.SwitchTo().Frame("courses-iframe");
            _driver.FindElement(By.XPath("//div[@class='header-upper']/div/div/div[2]/nav/div[2]/ul/li[2]/a")).Click();
            _driver.SwitchTo().DefaultContent();
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
