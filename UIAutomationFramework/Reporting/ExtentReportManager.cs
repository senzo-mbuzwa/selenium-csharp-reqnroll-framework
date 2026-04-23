using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace UIAutomationFramework.Reporting
{
    public static class ExtentReportManager
    {
        private static ExtentReports? _extent;
        private static ExtentTest? _feature;
        private static ExtentTest? _scenario;

        public static ExtentReports GetExtent()
        {
            if (_extent is null)
            {
                var reportDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "ExtentReports");
                Directory.CreateDirectory(reportDirectory);

                var reportPath = Path.Combine(reportDirectory, "ExtentReport.html");
                var sparkReporter = new ExtentSparkReporter(reportPath);

                sparkReporter.Config.DocumentTitle = "UI Automation Framework Report";
                sparkReporter.Config.ReportName = "Reqnroll UI Test Execution Report";

                _extent = new ExtentReports();
                _extent.AttachReporter(sparkReporter);
            }

            return _extent;
        }

        public static void CreateTest(string scenarioName)
        {
            _scenario = GetExtent().CreateTest(scenarioName);
        }

        public static ExtentTest GetTest()
        {
            if (_scenario is null)
                throw new InvalidOperationException("Scenario test has not been initialized.");

            return _scenario;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}