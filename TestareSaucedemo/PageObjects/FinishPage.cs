using OpenQA.Selenium;

namespace TestareSaucedemo.PageObjects
{
    public class FinishPage
    {

        private IWebDriver driver;
        private string finishMessageText;

        public FinishPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By finishMessage = By.ClassName("complete-text");
        private IWebElement txtFinishMessage => driver.FindElement(finishMessage);

        
        public string checkFinishedOrder()
        {
           return finishMessageText = txtFinishMessage.Text;
        }
    }
}
