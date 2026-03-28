using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TestLayer.Data
{
    public class LoginTestCase
    {
        public string TestName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ExpectedError { get; set; }
    }

    public static class TestDataLoader
    {
        public static IEnumerable<LoginTestCase> LoadLoginData()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "LoginData.json");
            string json = File.ReadAllText(path);

            using var document = JsonDocument.Parse(json);
            foreach (var testCase in document.RootElement.GetProperty("TestCases").EnumerateArray())
            {
                yield return new LoginTestCase
                {
                    TestName = testCase.GetProperty("TestName").GetString(),
                    Username = testCase.GetProperty("Username").GetString(),
                    Password = testCase.GetProperty("Password").GetString(),
                    ExpectedError = testCase.TryGetProperty("ExpectedError", out var err)
                        ? err.GetString()
                        : null
                };
            }
        }
    }
}