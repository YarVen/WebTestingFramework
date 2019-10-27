using AutomationFramework.WEB.Driver;
using System;

namespace AutomationFramework.WEB.Components
{
    public abstract class Page 
    {
        public Page() { }

        /// <summary>
        /// Create the instance of page with access to page elements
        /// </summary>
        /// <typeparam name="TPageType">PageType</typeparam>
        public static TPageType Create<TPageType>() where TPageType : Page
        {
            TPageType instance = Activator.CreateInstance<TPageType>();
            new PageBuilder().Build(instance);
            return instance;
        }

        /// <summary>
        /// Get element value by name
        /// </summary>
        public HtmlElement GetControlByName(string name)
        {
            return (HtmlElement)GetType().GetField(name).GetValue(this);
        }

        /// <summary>
        /// Refresh all objects on the current page
        /// </summary>
        public void Refresh()
        {
            new PageBuilder().Build(this);
        }
    }
}