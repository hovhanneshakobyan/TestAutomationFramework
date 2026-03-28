using CoreLayer.Configuration;
using CoreLayer.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.CustomBDD
{
    public class BDDTestBase
    {
        [SetUp]
        public void BeforeScenario()
        {
            DriverManager.Init();
            DriverManager.Driver.Navigate().GoToUrl(FrameworkConfig.AppUrl);
        }

        [TearDown]
        public void AfterScenario()
        {
            DriverManager.Quit();
        }
    }

}
