using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestareSaucedemo.PageObjects;

namespace TestareSaucedemo
{
    [TestClass]
    public class SortingProductsTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private List<ChromeWebElement> results;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.ro/");

            Thread.Sleep(2000);

            //loginPage = new LoginPage(driver);
        }

        [TestMethod]
        public void SortProductsAscendingByName()
        {
            
            
            
            //var products = loginPage.LoginApplication("standard_user", "secret_sauce");
           // products.SortProducts("Name (A to Z)");

            //var expectedRes = "Sauce Labs Backpack";
            //var actualRes = driver.FindElement(By.XPath("//*[@id='item_4_title_link']/div")).Text;

            //Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void SortProductsDescendingByName()
        {
            //var products = loginPage.LoginApplication("problem_user", "secret_sauce");
            //products.SortProducts("Name (Z to A)");

            //var expectedRes = "Test.allTheThings() T-Shirt (Red)";
            //var actualRes = driver.FindElement(By.XPath("//*[@id='item_3_title_link']/div")).Text;

            //Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void SortProductsDescendingByPrice()
        {
            //var products = loginPage.LoginApplication("performance_glitch_user", "secret_sauce");
            //products.SortProducts("Price (high to low)");

            //var expectedRes = "$49.99";
            //var actualRes = driver.FindElement(By.CssSelector("#inventory_container>div>div:nth-child(1)>div.pricebar>div")).Text;


            //Assert.AreEqual(expectedRes, actualRes);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
