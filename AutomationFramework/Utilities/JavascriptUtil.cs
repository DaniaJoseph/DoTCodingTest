using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Utilities
{
    public class JavascriptUtil
	{
		private IWebDriver _driver;

        #region Constructor
        public JavascriptUtil(IWebDriver driver)
		{
			this._driver = driver;
		}
        #endregion

        #region Methods
        private IWebElement GetElement(By locator)
        {
            IWebElement element = _driver.FindElement(locator);
            return element;
        }        
        public void ScrollIntoView(By locator)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)_driver);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(locator));
        }     
        public void ClickElementByJS(By locator)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)_driver);
            js.ExecuteScript("arguments[0].click();", GetElement(locator));
        }
        public IWebElement ExpandRootElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement ele = (IWebElement)js.ExecuteScript("return arguments[0].shadowRoot.childNodes[1]", element);
            return ele;
        }
        #endregion
    }
}
