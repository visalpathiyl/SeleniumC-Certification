using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFrameworkProject
{
    
    public class SortApplication
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://rahulshettyacademy.com/seleniumPractise/#/offers");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void arraySort()
        {
            ArrayList a = new ArrayList();
            SelectElement sl = new SelectElement(_driver.FindElement(By.Id("page-menu")));
            sl.SelectByText("20");

            IList<IWebElement>ls =_driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggies in ls)
            {
                a.Add(veggies.Text);
            }

            TestContext.Progress.WriteLine("Veggies before sorting : ");

            foreach(String n1 in a)
            {
                TestContext.Progress.WriteLine(n1);
            }

            TestContext.Progress.WriteLine("Veggies after sorting : ");

            a.Sort();

            foreach (String n1 in a)
            {
                TestContext.Progress.WriteLine(n1);
            }

            _driver.FindElement(By.XPath("//table[@class='table table-bordered']/thead/tr/th[1]/span[1]")).Click();

            ArrayList siteArray = new ArrayList();

            IList<IWebElement> siteSortedList = _driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement new1 in siteSortedList)
            {
                siteArray.Add(new1.Text);
            }

            TestContext.Progress.WriteLine("Site arrays after sorting : ");

            foreach (String n1 in siteArray)
            {
                TestContext.Progress.WriteLine(n1);
            }

            Assert.AreEqual(a, siteArray);

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
