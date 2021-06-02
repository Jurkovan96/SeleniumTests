using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestareSaucedemo.Controls
{
    public class MenuControls
    {
        public IWebDriver driver;

        public MenuControls(IWebDriver browser)
        {
            driver = browser;
        }

    }

    public class LoggedInMenuItemControls : MenuControls
    {

        private By cart = By.CssSelector("[data-icon='shopping-cart']");
        private IWebElement btnCart => driver.FindElement(cart);

        private By itemAdded = By.CssSelector("#shopping_cart_container>a>span");
        private IWebElement txtItemAdded => driver.FindElement(itemAdded);

        private By leftMenuButton = By.ClassName("bm-burger-button");
        private IWebElement btnLeft => driver.FindElement(leftMenuButton);

        private By allItems = By.Id("inventory_sidebar_link");
        private IWebElement linkAllItems => driver.FindElement(allItems);

        private By about = By.Id("about_sidebar_link");
        private IWebElement linkAbout => driver.FindElement(about);


        private By logout = By.Id("logout_sidebar_link");
        private IWebElement linkLogout => driver.FindElement(logout);


        private By resetApp = By.Id("reset_sidebar_link");
        private IWebElement linkReset => driver.FindElement(resetApp);


        public LoggedInMenuItemControls(IWebDriver browser) : base(browser)
        {
           
        }

        public Boolean chartHasProducts()
        {
            try
            {
                driver.FindElement(itemAdded);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
