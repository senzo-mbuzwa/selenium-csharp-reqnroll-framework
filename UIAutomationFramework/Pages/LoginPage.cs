using OpenQA.Selenium;

namespace UIAutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameInput = By.Name("username");
        private readonly By _passwordInput = By.Name("password");
        private readonly By _loginButton = By.CssSelector("input[value='Log In']");
        private readonly By _errorMessage = By.CssSelector("p.error");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Login(string username, string password)
        {
            Actions.EnterText(_usernameInput, username);
            Actions.EnterText(_passwordInput, password);
            Actions.Click(_loginButton);
        }

        public void LoginWithBlankCredentials()
        {
            Actions.Click(_loginButton);
        }

        public string GetLoginErrorMessage()
        {
            return Actions.GetText(_errorMessage);
        }
    }
}