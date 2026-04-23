using OpenQA.Selenium;

namespace UIAutomationFramework.Utilities
{
    public class ElementActions
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _waitHelper;

        public ElementActions(IWebDriver driver)
        {
            _driver = driver;
            _waitHelper = new WaitHelper(driver);
        }

        public void EnterText(By locator, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));

            var element = _waitHelper.WaitForElementToBeVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public void Click(By locator)
        {
            var element = _waitHelper.WaitForElementToBeClickable(locator);
            element.Click();
        }

        public string GetText(By locator)
        {
            return _waitHelper.WaitForElementToBeVisible(locator).Text;
        }

        public bool IsDisplayed(By locator)
        {
            try
            {
                return _waitHelper.WaitForElementToBeVisible(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}