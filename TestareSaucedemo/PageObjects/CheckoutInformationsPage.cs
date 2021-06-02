using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestareSaucedemo.PageObjects.InputData;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestareSaucedemo.PageObjects
{
    public class CheckoutInformationsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public string errorText;

        public CheckoutInformationsPage(IWebDriver browser)
        {
            driver = browser;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(submit));
        }

        private By firstName = By.CssSelector("[data-test='firstName']");
        private IWebElement txtFirstName => driver.FindElement(firstName);

        private By lastName = By.Id("last-name");
        private IWebElement txtLastName => driver.FindElement(lastName);

        private By zipCode = By.CssSelector("[data-test='postalCode']");
        private IWebElement txtZipCode => driver.FindElement(zipCode);

        private By cancel = By.XPath("//*[@id='checkout_info_container']/div/form/div[2]/a");
        private IWebElement btnCancel => driver.FindElement(cancel);


        private By submit = By.CssSelector("[type='submit']");
        private IWebElement btnSubmit => driver.FindElement(submit);

        private By error = By.CssSelector("[data-test='error']");
        private IWebElement lblError => driver.FindElement(error);

        public void completeCheckoutInformations()
        {
            CheckOutBO checkOutBO = new CheckOutBO();
            txtFirstName.SendKeys(checkOutBO.firstName);
            txtLastName.SendKeys(checkOutBO.lastName);
            txtZipCode.SendKeys(checkOutBO.zipCode);
        }

        public CheckoutOverviewPage submitOrder()
        {
            btnSubmit.Click();
            return new CheckoutOverviewPage(driver);  
        }

        public void submitWithErrors()
        {
            btnSubmit.Click();
            errorText = lblError.Text;
        }
    }
}
