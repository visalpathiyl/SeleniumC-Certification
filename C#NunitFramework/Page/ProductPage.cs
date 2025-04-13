using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_NunitFramework.Page
{
    public class ProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        IList<IWebElement> arrayList => _driver.FindElements(By.TagName("app-card"));
        By cardTitle => By.CssSelector(".card-title a");
        public IWebElement getCard()
        {
            return (IWebElement)arrayList;
        }
    }
}
