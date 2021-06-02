using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestareSaucedemo.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(loginElement));
        }
        private By loginElement = By.ClassName("fill-current");
        private IWebElement arrowElementForUserMenu => driver.FindElement(loginElement);

        private By email = By.Name("email");
        private IWebElement inputUserEmail => driver.FindElement(email);

        private By password = By.Name("password");
        private IWebElement inputUserPassword => driver.FindElement(password);

        private By loginButton = By.ClassName("border-2 rounded py-2px px-4 border-transparent");

        private IWebElement btnLogin => driver.FindElement(loginButton);

        public ProductsPage LoginApplication(string username, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginElement));
            arrowElementForUserMenu.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(email));
            inputUserEmail.SendKeys(username);
            inputUserPassword.SendKeys(password);
            btnLogin.Click();
            return new ProductsPage(driver);
        }

    }
}
