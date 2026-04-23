using Microsoft.Extensions.Configuration;
using UIAutomationFramework.Config;

namespace UIAutomationFramework.Utilities
{
    public static class ConfigurationHelper
    {
        private static readonly Lazy<TestSettings> Settings = new(() =>
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetSection("TestSettings").Get<TestSettings>()
                   ?? throw new InvalidOperationException("TestSettings section is missing or invalid.");
        });

        public static TestSettings GetSettings() => Settings.Value;
    }
}