using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestareSaucedemo.Controls;
using TestareSaucedemo.PageObjects;
using TestareSaucedemo.PageObjects.InputData;

namespace TestareSaucedemo
{
    [TestClass]
    public class FinishOrderTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage products;
        private CartPage cart;
        private standardLoginBO standardLoginBO = new standardLoginBO();
        private CheckoutInformationsPage checkoutInfoPage;
        private CheckoutOverviewPage checkoutOverviewPage;
        private FinishPage finishPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");

            loginPage = new LoginPage(driver);


            products = loginPage.LoginApplication(standardLoginBO.username, standardLoginBO.password);

            products.addProduct(1);
            cart = products.goToCart();
            checkoutInfoPage = cart.checkoutProducts();
            checkoutInfoPage.completeCheckoutInformations();
            checkoutOverviewPage = checkoutInfoPage.submitOrder();

        }
        
        [TestMethod]
        public void finishOrderCheckout()
        {
            finishPage = checkoutOverviewPage.finishOrder();

            var expectedRes = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";
            Assert.AreEqual(expectedRes, finishPage.checkFinishedOrder());


            //check if cart is empty after finishing the order
            var menuItem = new LoggedInMenuItemControls(driver);
            var chartHasItems = false;
            Assert.AreEqual(chartHasItems, menuItem.chartHasProducts());
        }

        [TestMethod]
        public void cancelOrder()
        {
            products = checkoutOverviewPage.cancelOrder();

            var cartHasProducts = true;
            Assert.AreEqual(cartHasProducts, products.checkCartProducts());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
