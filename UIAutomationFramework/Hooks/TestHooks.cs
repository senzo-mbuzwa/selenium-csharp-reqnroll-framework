using OpenQA.Selenium;
using Reqnroll;
using UIAutomationFramework.Drivers;
using UIAutomationFramework.Utilities;

namespace UIAutomationFramework.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver = null!;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverFactory.CreateDriver();
            _scenarioContext["WebDriver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var settings = ConfigurationHelper.GetSettings();

            if (_scenarioContext.TestError != null && settings.TakeScreenshotOnFailure)
            {
                ScreenshotHelper.Capture(_driver, _scenarioContext.ScenarioInfo.Title);
            }

            _driver.Quit();
        }
    }
}