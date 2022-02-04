using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Utilities
{
    public class ElementUtil
    {
		private IWebDriver _driver;

        #region Constructor
        public ElementUtil(IWebDriver driver)
		{
			this._driver = driver;
		}
		#endregion

        #region GetElement
        /// <summary>
        /// Extension method for locating the element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>The webelement based on the locator</returns>
        public IWebElement GetElement(By locator)
		{
			IWebElement element = _driver.FindElement(locator);
			return element;
		}
		#endregion

		#region Get List of Elements
		/// <summary>
		/// Extension method for locating the list of elements
		/// </summary>
		/// <param name="locator"></param>
		/// <returns>List of Webelements based on the locator</returns>
		public IList<IWebElement> GetElements(By locator)
		{
			return _driver.FindElements(locator);
		}
		#endregion

		#region Enter value in textbox

		/// <summary>
		/// Extension method to clear the text field and enter the value in the text field
		/// </summary>
		/// <param name="locator"></param>
		/// <param name="value">Text to enter in the text field</param>
		public void DoSendKeys(By locator, String value)
		{
			IWebElement element = GetElement(locator);
			element.Clear();
			element.SendKeys(value);
		}
		#endregion

		#region Click on an element
		/// <summary>
		/// Extension method to click on the element
		/// </summary>
		/// <param name="locator"></param>
		public void DoClick(By locator)
		{
			GetElement(locator).Click();
		}
		#endregion

		#region Get the text of an element

		/// <summary>
		/// Extension method to get the text
		/// </summary>
		/// <param name="locator"></param>
		/// <returns>string</returns>
		public String GetTextOf(By locator)
		{
			return GetElement(locator).Text.Trim();
		}
        #endregion

        #region Element is displayed or not
        public bool DoCheckIsElementDisplayed(By locator)
		{
			List<IWebElement> elementDisplayed = GetElements(locator).ToList();
			if (elementDisplayed.Count > 0 && elementDisplayed[0].Displayed)
			{
				return true;
			}
			return false;
		}
        #endregion

        #region Wait Utils
        public String WaitForPageTitle(string title, int timeOut)
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title));
			return _driver.Title;
		}
        public void ClickWhenReady(By locator, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
        #endregion

        #region Window Handling Util
        public void SwitchWindow()
		{
			if (_driver.WindowHandles.Count > 1)
				_driver.WindowHandles.First(windowHandle =>
				{
					if (!windowHandle.Equals(_driver.CurrentWindowHandle))
					{
						_driver.SwitchTo().Window(windowHandle);
						return true;
					}
					else return false;
				});
			Thread.Sleep(2000);
		}
		public void CloseWindow()
		{
			_driver.Close();
			_driver.SwitchTo().Window(_driver.WindowHandles[0]);
		}
		public string GetNewWindowHeaderText(By locator)
		{
			SwitchWindow();
			string header = GetTextOf(locator);
			CloseWindow();
			return header;
		}
		public string GetNewWindowTitle()
		{
			SwitchWindow();
			string title = _driver.Title; ;
			CloseWindow();
			return title;
		}
		#endregion

		#region ElementIsVisible
		public void WaitForElementIsVisible(By locator)
		{
			new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
		}
		#endregion
	}
}
