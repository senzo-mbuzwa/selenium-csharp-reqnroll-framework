namespace UIAutomationFramework.Config
{
    public class TestSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Browser { get; set; } = "Chrome";
        public int ImplicitWaitInSeconds { get; set; }
        public int ExplicitWaitInSeconds { get; set; }
        public bool TakeScreenshotOnFailure { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string InvalidUsername { get; set; } = string.Empty;
        public string InvalidPassword { get; set; } = string.Empty;
    }
}