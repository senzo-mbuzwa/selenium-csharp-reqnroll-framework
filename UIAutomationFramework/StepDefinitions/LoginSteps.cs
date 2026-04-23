using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;
using UIAutomationFramework.Config;
using UIAutomationFramework.Pages;
using UIAutomationFramework.Utilities;

namespace UIAutomationFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly AccountsOverviewPage _accountsOverviewPage;
        private readonly TestSettings _settings;
        private string _actualErrorMessage = string.Empty;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WebDriver"] as IWebDriver
                      ?? throw new InvalidOperationException("WebDriver not found in ScenarioContext.");

            _loginPage = new LoginPage(_driver);
            _accountsOverviewPage = new AccountsOverviewPage(_driver);
            _settings = ConfigurationHelper.GetSettings();
        }

        [Given(@"the user navigates to the login page")]
        public void GivenTheUserNavigatesToTheLoginPage()
        {
            _loginPage.NavigateTo(_settings.BaseUrl);
        }

        [When(@"the user logs in with valid credentials")]
        public void WhenTheUserLogsInWithValidCredentials()
        {
            _loginPage.Login(_settings.Username, _settings.Password);
        }

        [Then(@"the accounts overview page should be displayed")]
        public void ThenTheAccountsOverviewPageShouldBeDisplayed()
        {
            _accountsOverviewPage.IsDisplayed().Should().BeTrue();
        }

        [When(@"the user logs in with invalid credentials")]
        public void WhenTheUserLogsInWithInvalidCredentials()
        {
            _loginPage.Login(_settings.InvalidUsername, _settings.InvalidPassword);
        }

        [Then(@"a login error message should be displayed")]
        public void ThenALoginErrorMessageShouldBeDisplayed()
        {
            _actualErrorMessage = _loginPage.GetLoginErrorMessage();
            _actualErrorMessage.Should().NotBeNullOrWhiteSpace();
            _actualErrorMessage.Should().Contain("The username and password could not be verified");
        }

        [When(@"the user logs in with blank credentials")]
        public void WhenTheUserLogsInWithBlankCredentials()
        {
            _loginPage.LoginWithBlankCredentials();
        }

        [Then(@"a required field validation message should be displayed")]
        public void ThenARequiredFieldValidationMessageShouldBeDisplayed()
        {
            _actualErrorMessage = _loginPage.GetLoginErrorMessage();
            _actualErrorMessage.Should().NotBeNullOrWhiteSpace();
            _actualErrorMessage.Should().Contain("Please enter a username and password");
        }
    }
}