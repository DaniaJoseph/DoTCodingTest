using AutomationFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
    public class HomeLoansPage
	{
		private IWebDriver _driver;
		private ElementUtil _elementUtil;
		private JavascriptUtil _javascriptUtil;

		#region Element Locators
		private By _pageHeader = By.XPath("(//h1[text()='Home Loans'])[1]");
		private By _requestCallBackLink = By.XPath("//span[text()='Request a call back']");
		private By _bookAnAppointment = By.XPath("//span[text()='Book an appointment']");	
		#endregion

		#region Constructor
		public HomeLoansPage(IWebDriver driver)
		{
			this._driver = driver;
			_elementUtil = new ElementUtil(this._driver);
			_javascriptUtil = new JavascriptUtil(this._driver);
		}
        #endregion

        #region Methods
        public String GetHomeLoansPageTitle()
		{
            Console.WriteLine("Getting the home loans page title");
			return _elementUtil.WaitForPageTitle("Home loans - Flexible home loan options and calculators - NAB", 5);
		}
		public String GetHeaderValue()
		{
			if (_elementUtil.DoCheckIsElementDisplayed(_pageHeader))
			{
				return _elementUtil.GetTextOf(_pageHeader);
			}
			return null;
		}
		public CustomerAssistancePage GoToCustomerAssistance()
		{
			Thread.Sleep(1000);
			_elementUtil.DoClick(_requestCallBackLink);
			return new CustomerAssistancePage(_driver);
		}

		public void ClickOnBookAnAppointment()
		{
			Thread.Sleep(1000);
			_elementUtil.DoClick(_bookAnAppointment);
		}

		#endregion
	}
}
