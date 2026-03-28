using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace CoreLayer.Configuration
{
    public static class FrameworkConfig
    {
        public static string BrowserType { get; private set; }
        public static string AppUrl { get; private set; }
        public static string TestDataPath { get; private set; }

        static FrameworkConfig() => Init();

        public static void Init()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            BrowserType = configuration["BrowserType"] ?? "Chrome";
            AppUrl = configuration["ApplicationUrl"] ?? "";
            TestDataPath = configuration["TestDataPath"] ?? "";
        }
    }
}