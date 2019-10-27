using AutomationFramework.WEB.Driver;
using AutomationFramework.WEB.Helpers;
using NUnit.Framework;

namespace UiTestProject.Tests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public static void Initialize()
        {
            DriverService.Driver.Navigate().GoToUrl(UrlResolver.GetUrl("Main"));
        }

        [TearDown]
        public static void TestFixtureTearDown()
        {
            DriverService.Quit();
        }
    }
}
