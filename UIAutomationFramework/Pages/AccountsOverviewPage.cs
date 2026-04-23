using OpenQA.Selenium;

namespace UIAutomationFramework.Pages
{
    public class AccountsOverviewPage : BasePage
    {
        private readonly By _accountsOverviewHeader = By.XPath("//h1[contains(text(),'Accounts Overview')]");

        public AccountsOverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsDisplayed()
        {
            return Actions.IsDisplayed(_accountsOverviewHeader);
        }
    }
}