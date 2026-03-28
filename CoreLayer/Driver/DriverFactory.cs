using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Selenium Imports
//Chrome is already based on Chromium
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace CoreLayer.Driver
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(BrowserTypes types)
        {
            switch (types)
            {
                case BrowserTypes.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        ChromeOptions Coptions = new ChromeOptions();
                        Coptions.AddArgument("--incognito");
                        Coptions.AddArgument("--disable-infobars");
                        Coptions.AddArgument("--start-maximized");
                        Coptions.AddArgument("--disable-extensions");
                        Coptions.AddArgument("--disable-popup-blocking");

                        return new ChromeDriver(service, Coptions, TimeSpan.FromSeconds(30));
                    }
                case BrowserTypes.Edge:
                    var options = new EdgeOptions();
                    options.AddArgument("--inprivate");
                    options.AddArgument("--start-maximized");

                    return new EdgeDriver(options);

                default:
                    throw new ArgumentOutOfRangeException(nameof(types), types, null);
            }
        }
    }
}
