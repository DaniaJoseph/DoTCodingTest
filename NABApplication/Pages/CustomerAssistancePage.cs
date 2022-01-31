using AutomationFramework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
	public class CustomerAssistancePage
	{
		private IWebDriver _driver;
		private ElementUtil _elementUtil;
		private JavascriptUtil _javascriptUtil;

		#region Element Locators
		private By _pageHeader = By.XPath("//h1[text()='Customer assistance directory']");
		private By _shadowRoot = By.Id("contact-form-shadow-root");		
		private By _rbNewHomeLoans = By.CssSelector("div#myRadioButtons-0");
		private By _btnNextFromNewHomeLoan = By.CssSelector("#main-container > div > div.sc-ifAKCX.Col__StyledCol-o7bhp7-0.ibULtI > section > div.sc-bdVaJa.iAQrVS > button");
		private By _rbBuyingNewProperty = By.CssSelector("div#myRadioButtons-0");
		private By _btnNext = By.CssSelector("#main-container > div > div.sc-ifAKCX.Col__StyledCol-o7bhp7-0.ibULtI > section > div.sc-bdVaJa.iAQrVS > button.Buttonstyle__StyledButton-sc-1vu4swu-3.cchfek > div > span");

		#endregion

		#region Constructor
		public CustomerAssistancePage(IWebDriver driver)
		{
			this._driver = driver;
			_elementUtil = new ElementUtil(this._driver);
			_javascriptUtil = new JavascriptUtil(this._driver);
		}
		#endregion

		#region Methods
		public String GetCustomerAssistanceDirectoryPageTitle()
		{
			Console.WriteLine("Getting the customer assistance directory title");
			return _elementUtil.WaitForPageTitle("Customer assistance directory | We’re here to help - NAB", 5);
		}
		public String GetHeaderValue()
		{
			if (_elementUtil.DoCheckIsElementDisplayed(_pageHeader))
			{
				return _elementUtil.GetTextOf(_pageHeader);
			}
			return null;
		}
		public CallBackFormPage GoToCallBackForm()
        {
			IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;			
			IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
			shadowRoot.FindElement(_rbBuyingNewProperty).Click();
			IWebElement ele = shadowRoot.FindElement(_btnNext);
			js.ExecuteScript("arguments[0].click();", ele);
			return new CallBackFormPage(_driver);
		}
		public void SelectLoanType()
		{
			IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
			shadowRoot.FindElement(_rbNewHomeLoans).Click();
			shadowRoot.FindElement(_btnNextFromNewHomeLoan).Click();
		}
		#endregion
	}
}


