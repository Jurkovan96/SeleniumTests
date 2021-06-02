

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestareSaucedemo.PageObjects
{
    public class ProductsPage
    {
        private IWebDriver driver;
        public Boolean imagePresent;
        public String itemAddedText;
        public int numberOfProductsInCart = 0;

        public ProductsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By sortSelect = By.XPath("//select[@class='product_sort_container']");
        private IWebElement ddlSortSelect => driver.FindElement(sortSelect);

        private By products = By.CssSelector("[class=inventory_list]>div");
        private IList<IWebElement> lstProducts => driver.FindElements(products);

        private By addToCart = By.XPath("//*[@id='inventory_container']/div/div/div[3]/button");

        private IList<IWebElement> lstButtonsAddToCart => driver.FindElements(addToCart);

        private By remove = By.CssSelector("#inventory_container>div>div:nth-child(1)>div.pricebar>button");
        private IWebElement btnRemove => driver.FindElement(remove);


        private By itemAdded = By.CssSelector("#shopping_cart_container>a>span");
        private IWebElement txtItemAdded => driver.FindElement(itemAdded);

        private By cart = By.CssSelector("[data-icon='shopping-cart']");
        private IWebElement btnCart => driver.FindElement(cart);
        

        public void CheckImageAppears()
        {
            IWebElement imageFile = driver.FindElement(By.XPath("//*[@id='item_4_img_link']/img[@class='inventory_item_img']"));
            var js = (IJavaScriptExecutor)driver;
            imagePresent = (Boolean)js.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", imageFile);
        }

        public Boolean successfullyReturnedImg = true;
        public Boolean unsuccessfullyReturnedImg = false;

        public void SortProducts(string text)
        {
            var selectSorting = new SelectElement(ddlSortSelect);
            selectSorting.SelectByText(text);
        }

        public void addProduct(int index)
        {
            int i = 0;
            foreach (var element in lstButtonsAddToCart)
            {
                if(i == index)
                {
                    element.Click();
                }

                i++;
            }
            itemAddedText = txtItemAdded.Text;
            numberOfProductsInCart++;


        }
        public void removeSpecificProduct(int index)
        {
            int i = 0;
            foreach (var element in lstButtonsAddToCart)
            {
                if (i == index)
                {
                    element.Click();
                }

                i++;
            }
            itemAddedText = txtItemAdded.Text;
            numberOfProductsInCart--;
        }
        public void removeProduct()
        {
            btnRemove.Click();
        }

        public CartPage goToCart()
        {
            btnCart.Click();
            return new CartPage(driver);
        }

        public Boolean checkCartProducts()
        {
            try
            {
                driver.FindElement(itemAdded);
                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
