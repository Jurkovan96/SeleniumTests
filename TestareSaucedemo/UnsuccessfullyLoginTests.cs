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
    public class UnsuccessfullyLoginTests
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
        public void Login_IncorrectUsername_CorrectPassword()
        {
            loginPage.LoginApplication("standard_userr", "secret_sauce");

            var expectedRes = "Epic sadface: Username and password do not match any user in this service";
            var actualRes = driver.FindElement(By.CssSelector("[data-test=error")).Text;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod] 
        public void Login_CorrectUsername_IncorrectPassword()
        {
            loginPage.LoginApplication("standard_user", "abcd");

            var expectedRes = "Epic sadface: Username and password do not match any user in this service";
            var actualRes = driver.FindElement(By.CssSelector("[data-test=error")).Text;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod] 
        public void Login_LockedUser()
        {
            loginPage.LoginApplication("locked_out_user", "secret_sauce");

            var expectedRes = "Epic sadface: Sorry, this user has been locked out.";
            var actualRes = driver.FindElement(By.CssSelector("[data-test=error")).Text;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
