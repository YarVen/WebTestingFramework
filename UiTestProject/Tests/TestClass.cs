using AutomationFramework.WEB.Components;
using AutomationTesting.WebDriverDemo.Pages;
using NUnit.Framework;

namespace UiTestProject.Tests
{
    [TestFixture]
    public class TestClass : TestBase
    {
        [Test]
        public void Test1()
        {
            string amount = "122";
            MainPage mainPage = Page.Create<MainPage>();
            mainPage.AmountInput.SetText(amount);
            var exchangeRatesList = mainPage.ExchangeRatesList;

            foreach (var el in exchangeRatesList)
            {
                float sale = float.Parse(el.Sale.GetText());
                float purchase = float.Parse(el.Purchase.GetText());

                Assert.IsTrue(sale > purchase, $"Current purchase rate ({purchase}) should be less than selling rate ({sale}) for {el.Сurrency.GetText()} currency");
            }
        }
    }
}