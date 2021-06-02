using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestareSaucedemo.PageObjects;

namespace TestareSaucedemo
{
    [TestClass]
    public class AddToCartTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage products;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");

            loginPage = new LoginPage(driver);

            products = loginPage.LoginApplication("standard_user", "secret_sauce");
        }

        [TestMethod]

        public void AddToCartProduct()
        {
            products.addProduct(2);

            var expectedResult = products.numberOfProductsInCart.ToString();

            Assert.AreEqual(expectedResult, products.itemAddedText);

        }
        [TestMethod]
        public void AddToCartProducts()
        {
            products.addProduct(3);
            products.addProduct(4);
            products.addProduct(5);

            var expectedResult = products.numberOfProductsInCart.ToString();

            Assert.AreEqual(expectedResult, products.itemAddedText);
        }
        [TestMethod]
        public void AddToCartProductsThenRemoveSome()
        {
            products.addProduct(3);
            products.addProduct(4);
            products.addProduct(5);
            products.removeSpecificProduct(5);
            products.removeSpecificProduct(4);
            products.addProduct(2);
            products.removeSpecificProduct(2);
            products.addProduct(5);

            var expectedResult = products.numberOfProductsInCart.ToString();
            Assert.AreEqual(expectedResult, products.itemAddedText);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                products.removeProduct();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
