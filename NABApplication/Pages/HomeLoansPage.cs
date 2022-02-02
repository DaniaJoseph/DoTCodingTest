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

        #region Element Locators
        private By _pageHeader = By.XPath("(//h1[text()='Home Loans'])[1]");
		private By _requestCallBackLink = By.XPath("//span[text()='Request a call back']");
		private By _bookAnAppointment = By.XPath("//span[text()='Book an appointment']");

		//ADDITINAL CODE
		private JavascriptUtil _javascriptUtil;

		private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
		private By _buyingAproperty = By.CssSelector("div[aria-label='Buying a property']>div>div>p:nth-child(1)");
		private By _1applicant = By.CssSelector("#applicatnts-form > fieldset > div > div > div > label:nth-child(1) > span.Radiostyle__CustomRadio-ejyijk-0.SSABCustomRadio-hxnFFh.ciJiFM.fHHUyj");
		private By _applicantFormNextButton = By.CssSelector("#applicatnts-form > p > button");
		private By _fullorPartTimeEmployment = By.CssSelector("#income-form > fieldset > div > div > div > label:nth-child(1) > span.Checkboxstyle__CustomCheckbox-tk9n2c-0.SSABCustomCheckbox-lolqDD.fABBwW.fMJtph");
		private By _incomeFormNextButton = By.CssSelector("#income-form > p.Styledp-iPxeNv.dVTyqH > button");
		private By _moneySaved = By.CssSelector("#deposit-form > fieldset > div > div > div > label:nth-child(1) > span.Label-idxVLZ.iyyITP");
		private By _depositFormNEXTButton = By.CssSelector("#deposit-form > p.Styledp-iPxeNv.dVTyqH > button");
		private By _enterSuburbTextBox = By.CssSelector("#location");
		private By _suburbTextBoxAutosuggest1 = By.CssSelector("#autosuggest-listbox-location-0");
		private By _locationFormNEXTButton = By.CssSelector("#location-form > p.Styledp-iPxeNv.dVTyqH > button");
		private By _videoCallOption = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.AppointmentSelectCol-jlmUBP.fKiecM.dbHahP > a:nth-child(3) > div > div > div > p.ListItemstyle__StyledLabel-sc-1lp3zzc-0.hPcUMr.label");
		private By _7thDateOption=By.CssSelector("button[value='7']");
		private By _845TimeOption = By.CssSelector("button[aria-label='08:45am']");
		private By _timeSlotFormNextButton = By.CssSelector("button[form='timeslot-form']");
		private By _firstNameTextBox = By.CssSelector("#firstName");
		private By _lastNameTextBox = By.CssSelector("#lastName");
		private By _emailTextBox = By.CssSelector("#email");
		private By _mobileTextBox = By.CssSelector("#mobile");
		private By _contactFormNextButton = By.CssSelector("button[form ='contact-form']");
		private By _appointmentDetailsText = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.ReviewConfirmationCol-bhndEV.fKiecM.ewikFm > h2:nth-child(3)");

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
			Thread.Sleep(1000);
			IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
			Thread.Sleep(1000);
			shadowRoot.FindElement(_buyingAproperty).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_1applicant).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_applicantFormNextButton).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_fullorPartTimeEmployment).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_incomeFormNextButton).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_moneySaved).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_depositFormNEXTButton).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_enterSuburbTextBox).SendKeys("3084");
			Thread.Sleep(1000);
			shadowRoot.FindElement(_suburbTextBoxAutosuggest1).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_locationFormNEXTButton).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_videoCallOption).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_7thDateOption).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_845TimeOption).Click();
			Thread.Sleep(1000);
			shadowRoot.FindElement(_timeSlotFormNextButton).Click();
			Thread.Sleep(1000);


			shadowRoot.FindElement(_firstNameTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "FirstName"));
			Thread.Sleep(1000);
			Console.WriteLine(ExcelReaderHelpers.ReadData(1, "FirstName"));
			shadowRoot.FindElement(_lastNameTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "LastName"));
			Thread.Sleep(1000);
			shadowRoot.FindElement(_emailTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "Email"));
			Thread.Sleep(1000);
			shadowRoot.FindElement(_mobileTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "Mobile"));
			Thread.Sleep(1000);
			Console.WriteLine(ExcelReaderHelpers.ReadData(1, "Mobile"));
			Thread.Sleep(1000);
			shadowRoot.FindElement(_contactFormNextButton).Click();
			Thread.Sleep(1000);
			Assert.IsTrue(shadowRoot.FindElement(_appointmentDetailsText).Displayed);
		}


		#endregion
	}
}
