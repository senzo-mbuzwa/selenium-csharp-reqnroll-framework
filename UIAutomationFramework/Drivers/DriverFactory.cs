using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using UIAutomationFramework.Utilities;

namespace UIAutomationFramework.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var settings = ConfigurationHelper.GetSettings();

            IWebDriver driver = settings.Browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new NotSupportedException($"Browser '{settings.Browser}' is not supported.")
            };

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(settings.ImplicitWaitInSeconds);

            return driver;
        }
    }
}