using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestareSaucedemo.PageObjects
{
   public class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CartPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(checkout));
        }

        private By checkout = By.CssSelector("#cart_contents_container>div>div.cart_footer>a.btn_action.checkout_button");
        private IWebElement btnCheckout => driver.FindElement(checkout);

        public CheckoutInformationsPage checkoutProducts()
        {
            btnCheckout.Click();
            return new CheckoutInformationsPage(driver);
        }

    }
}
