using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestareSaucedemo.PageObjects;
using TestareSaucedemo.PageObjects.InputData;

namespace TestareSaucedemo
{
    [TestClass]
    public class CheckoutOrderTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage products;
        private CartPage cart;
        private CheckoutInformationsPage checkoutInfoPage;
        private CheckoutOverviewPage checkoutOverviewPage;
        private CheckOutBO checkOutBO = new CheckOutBO();

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");

            loginPage = new LoginPage(driver);

            products = loginPage.LoginApplication("standard_user", "secret_sauce");

            products.addProduct(1);
            cart = products.goToCart();
        }


        [TestMethod]
        public void CheckoutOrderAndContinueWithErrors()
        {
            checkoutInfoPage = cart.checkoutProducts();
            checkoutInfoPage.submitWithErrors();
            var expectedResult = "Error: First Name is required";

            Assert.AreEqual(expectedResult, checkoutInfoPage.errorText);
        }

        [TestMethod]
        public void CheckoutOrderSuccessfully()
        {
            checkoutInfoPage = cart.checkoutProducts();
            
            checkoutInfoPage.completeCheckoutInformations();
            checkoutOverviewPage = checkoutInfoPage.submitOrder();

            var expectedRes = true;
            checkoutOverviewPage.checkItemTotal();
            Assert.AreEqual( expectedRes,checkoutOverviewPage.itemTotalBoolean);

            checkoutOverviewPage.checkFinalTotal();
            Assert.AreEqual(expectedRes, checkoutOverviewPage.finalTotalBoolean);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
