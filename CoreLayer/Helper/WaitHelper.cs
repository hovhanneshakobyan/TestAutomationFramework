using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CoreLayer.Helper
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElementVisible(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Element not visible after {timeoutInSeconds}s: {by}", ex);
                throw;
            }
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Element not clickable after {timeoutInSeconds}s: {by}", ex);
                throw;
            }
        }

        public static bool WaitForElementInvisible(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
    }
}
