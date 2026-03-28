using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

using OpenQA.Selenium;
using System.Threading;
using CoreLayer.Configuration;

namespace CoreLayer.Driver
{
    public static class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> _driver = new();

        public static IWebDriver Driver => _driver.Value;

        public static void Init()
        {
            if (_driver.Value == null)
            {
                var browser = Enum.Parse<BrowserTypes>(FrameworkConfig.BrowserType);
                _driver.Value = DriverFactory.CreateDriver(browser);
                _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            }
        }

        public static void Quit()
        {
            if (_driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
                _driver.Value = null;
            }
        }
    }
}