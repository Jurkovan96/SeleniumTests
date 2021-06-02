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
    public class CheckoutOverviewPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Boolean itemTotalBoolean;
        public String itemTotalRes;
        public Boolean finalTotalBoolean;

        public CheckoutOverviewPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(finish));
        }

        private By productPrice = By.XPath("//*[@id='checkout_summary_container']/div/div[1]/div[3]/div[2]/div[2]");
        private IWebElement lbProductPrice => driver.FindElement(productPrice);

        private By itemTotal = By.CssSelector("#checkout_summary_container>div>div.summary_info >div.summary_subtotal_label");
        private IWebElement lblItemTotal => driver.FindElement(itemTotal);

        private By tax = By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[6]");
        private IWebElement lblTax => driver.FindElement(tax);

        private By total = By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[7]");
        private IWebElement lblTotal => driver.FindElement(total);

        private By finish = By.CssSelector("a.btn_action.cart_button");
        private IWebElement btnFinish => driver.FindElement(finish);

        private By cancel = By.CssSelector("a.cart_cancel_link.btn_secondary");
        private IWebElement btnCancel => driver.FindElement(cancel);



        public void checkItemTotal()
        {
            if(("Item total: "+ lbProductPrice.Text ) == lblItemTotal.Text)
            {
                itemTotalBoolean = true;
                itemTotalRes = lblItemTotal.Text;
            } else
            {
                itemTotalBoolean = false;
            }
        }


        public void checkFinalTotal()
        {
            var itemValue = String.Join("", lblItemTotal.Text.Where(char.IsDigit));
            var taxValue = String.Join("", lblTax.Text.Where(char.IsDigit));
            var totalValue = String.Join("", lblTotal.Text.Where(char.IsDigit));

            var res = (Int32.Parse(itemValue) + Int32.Parse(taxValue)).ToString();

            if(res == totalValue)
            {
                finalTotalBoolean = true;
            }
        }

        public FinishPage finishOrder()
        {
            btnFinish.Click();
            return new FinishPage(driver);
        }

        public ProductsPage cancelOrder()
        {
            btnCancel.Click();
            return new ProductsPage(driver);
        }
    }
}
