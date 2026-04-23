using OpenQA.Selenium;
using UIAutomationFramework.Utilities;

namespace UIAutomationFramework.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly ElementActions Actions;
        protected readonly WaitHelper Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Actions = new ElementActions(driver);
            Wait = new WaitHelper(driver);
        }
    }
}