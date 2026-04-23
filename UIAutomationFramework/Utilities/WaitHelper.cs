using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UIAutomationFramework.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            var timeout = ConfigurationHelper.GetSettings().ExplicitWaitInSeconds;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
        }

        public IWebElement WaitForElementToBeVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool WaitForUrlContains(string text)
        {
            return _wait.Until(d => d.Url.Contains(text, StringComparison.OrdinalIgnoreCase));
        }
    }
}