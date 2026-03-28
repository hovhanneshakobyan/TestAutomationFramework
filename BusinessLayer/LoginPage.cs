using CoreLayer.Driver;
using CoreLayer.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;   

namespace BusinessLayer
{
    public class LoginPage
    {
        private IWebDriver Driver => DriverManager.Driver;

        private readonly By UsernameField = By.CssSelector("#user-name");
        private readonly By PasswordField = By.CssSelector("#password");
        private readonly By LoginButton = By.CssSelector("#login-button");
        private readonly By ErrorMessage = By.CssSelector("[data-test='error']");

        public void EnterUsername(string username)
        {
            WaitHelper.WaitForElementVisible(Driver, UsernameField).Clear();
            Driver.FindElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            WaitHelper.WaitForElementVisible(Driver, PasswordField).Clear();
            Driver.FindElement(PasswordField).SendKeys(password);
        }

        public void ClickLogin()
        {
            WaitHelper.WaitForElementClickable(Driver, LoginButton).Click();
        }

        public string GetLoginError()
        {
            try
            {
                var errorElement = WaitHelper.WaitForElementVisible(Driver, ErrorMessage, timeoutInSeconds: 8);
                string errorText = errorElement.Text.Trim();
                Logger.Info($"Captured error message: \"{errorText}\"");
                return errorText;
            }
            catch
            {
                Logger.Warn("No error message element visible on page");
                return string.Empty;
            }
        }

        public void ClearInputs()
        {
            Logger.Info("Clearing both username and password fields");
            SafeClearField(UsernameField);
            SafeClearField(PasswordField);
        }

        private void SafeClearField(By by)
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(Driver, by, 5);

                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys("");

                Logger.Info($"Safely cleared field: {by}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to safely clear field {by}", ex);
            }
        }

        //  UC-1 and UC-2 
        public void PerformUC1_EmptyCredentials()
        {
            Logger.Info("Executing UC-1: Enter any credentials then clear both fields");
            EnterUsername("anyuser123");
            EnterPassword("anypass123");
            ClearInputs();          
            ClickLogin();
        }

        //Uc2
        public void PerformUC2_OnlyUsernameProvided()
        {
            Logger.Info("Executing UC-2: Enter username, enter password, then clear password only");
            EnterUsername("standard_user");
            EnterPassword("anypass123");

            SafeClearField(PasswordField);

            ClickLogin();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}