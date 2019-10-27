using AutomationFramework.WEB.Search;
using OpenQA.Selenium;

namespace AutomationFramework.WEB.Components
{
    public class HtmlButton : HtmlElement
    {
        public HtmlButton(SearchConfiguration searchConfig) : base(searchConfig) { }

        public HtmlButton(IWebElement webElement) : base(webElement) { }

        /// <summary>
        /// Move to a button and perform click
        /// </summary>
        public override void Click()
        {
            Focus();
            base.Click();
        }
    }
}