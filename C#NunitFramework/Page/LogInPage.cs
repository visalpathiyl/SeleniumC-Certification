using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_NunitFramework.Page
{
    public class LogInPage
    {
        private IWebDriver _driver;

        public LogInPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement UserName => _driver.FindElement(By.Id("username"));
        public IWebElement Password => _driver.FindElement(By.Id("password"));
        public IWebElement SignInButton => _driver.FindElement(By.Id("signInBtn"));


        public void SignIn(String username, String password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            SignInButton.Click();
        }
    }
}
