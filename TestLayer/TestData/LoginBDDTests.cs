using BusinessLayer;
using CoreLayer.Helper;
using NUnit.Framework;
using TestLayer.CustomBDD;
using TestLayer.Data;
using FluentAssertions;

namespace TestLayer.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginBDDTests : BDDTestBase
    {
        private LoginPage loginPage;
        private MainPage mainPage;

        [SetUp]
        public void SetupPages()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();
        }

        public static IEnumerable<LoginTestCase> LoginTestCases =>
            TestDataLoader.LoadLoginData();

        [Test]
        [TestCaseSource(nameof(LoginTestCases))]
        public void LoginBDD(LoginTestCase data)
        {
            Logger.Info($"=== Starting test: {data.TestName} ===");

            if (data.TestName.StartsWith("UC1_"))
            {
                loginPage.PerformUC1_EmptyCredentials();

                string error = loginPage.GetLoginError();
                error.Should().Contain(data.ExpectedError ?? "",
                    $"Test {data.TestName}: Expected error message not found");

                Logger.Info($"✓ UC-1 Error validated: {error}");
            }
            else if (data.TestName.StartsWith("UC2_"))
            {
                loginPage.PerformUC2_OnlyUsernameProvided();

                string error = loginPage.GetLoginError();
                error.Should().Contain(data.ExpectedError ?? "",
                    $"Test {data.TestName}: Expected error message not found");

                Logger.Info($"✓ UC-2 Error validated: {error}");
            }
            else // UC-3 Valid Login
            {
                loginPage.Login(data.Username, data.Password);

                bool isOnMainPage = mainPage.IsAt();
                isOnMainPage.Should().BeTrue(
                    $"Test {data.TestName}: Failed to reach main page after valid login");

                Logger.Info($"✓ Successfully logged in and Main page verified");
            }
        }
    }
}