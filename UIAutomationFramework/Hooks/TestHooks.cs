using OpenQA.Selenium;
using Reqnroll;
using UIAutomationFramework.Drivers;
using UIAutomationFramework.Utilities;
using AventStack.ExtentReports;
using UIAutomationFramework.Reporting;

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
            ExtentReportManager.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var settings = ConfigurationHelper.GetSettings();
            var test = ExtentReportManager.GetTest();

            if (_scenarioContext.TestError == null)
            {
                test.Pass("Scenario passed successfully.");
            }
            else
            {
                test.Fail($"Scenario failed: {_scenarioContext.TestError.Message}");

                if (settings.TakeScreenshotOnFailure)
                {
                    var screenshotPath = ScreenshotHelper.Capture(_driver, _scenarioContext.ScenarioInfo.Title);
                    test.AddScreenCaptureFromPath(screenshotPath);
                }
            }

            _driver.Quit();
            ExtentReportManager.FlushReport();
        }
    }
}