using OpenQA.Selenium;

namespace UIAutomationFramework.Utilities
{
    public static class ScreenshotHelper
    {
        public static string Capture(IWebDriver driver, string scenarioName)
        {
            if (driver is not ITakesScreenshot screenshotDriver)
                throw new InvalidOperationException("Driver does not support screenshots.");

            var screenshotsDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestResults",
                "Screenshots");

            Directory.CreateDirectory(screenshotsDirectory);

            var safeScenarioName = string.Concat(
                scenarioName.Split(Path.GetInvalidFileNameChars()));

            var filePath = Path.Combine(
                screenshotsDirectory,
                $"{safeScenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            screenshotDriver.GetScreenshot().SaveAsFile(filePath);

            return filePath;
        }
    }
}