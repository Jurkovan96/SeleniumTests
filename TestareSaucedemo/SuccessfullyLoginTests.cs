using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestareSaucedemo.PageObjects;

namespace TestareSaucedemo
{
    [TestClass]
    public class SuccessfullyLoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");

            loginPage = new LoginPage(driver);
        }

      
        
        [TestMethod]
        public void CorrectLoginStandardUser()
        {
           var products = loginPage.LoginApplication("standard_user", "secret_sauce");
           products.CheckImageAppears();

           Assert.AreEqual(products.imagePresent, products.successfullyReturnedImg);
        }

        [TestMethod]
        public void CorrectLoginProblemUser()
        {
            var products = loginPage.LoginApplication("problem_user", "secret_sauce");
            products.CheckImageAppears();

            Assert.AreEqual(products.imagePresent, products.unsuccessfullyReturnedImg);
        }

        [TestMethod]
        public void CorrectLoginBadPerformanceUser()
        {
            var products = loginPage.LoginApplication("performance_glitch_user", "secret_sauce");
            products.CheckImageAppears();

            Assert.AreEqual(products.imagePresent, products.successfullyReturnedImg);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
