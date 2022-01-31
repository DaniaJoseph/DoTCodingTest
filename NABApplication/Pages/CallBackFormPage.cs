using AutomationFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace NABApplication.Pages
{
    public class CallBackFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;

        #region Element Locators
        private By _header = By.XPath("//h1[text()='NAB Contact Centre Call Back Form']");
        private By _existingCustomer = By.XPath("//div[@id='field-page-Page1-isExisting']/label/span");
        private By _nabId = By.Id("field-page-Page1-nabID");
        private By _firstName = By.XPath("//input[@label='First name']");
        private By _lastName = By.XPath("//input[@label='Last name']");
        private By _phoneNumber = By.XPath("//input[@label='Phone number']");
        private By _selectState = By.XPath(
                "//span[text()='State you live in']/parent::label/following-sibling::div/descendant::div[contains(@class,'indicators')]");
        private By _email = By.XPath("//input[@label='Email']");
        private By _submit = By.XPath("//span[text()='Submit']");
        
        #endregion

        #region Constructor
        public CallBackFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion

        #region Methods
        public void MoveToNewWindow()
        {
            _elementUtil.SwitchWindow();
        }
        public String GetHeaderValue()
        {
            if (_elementUtil.DoCheckIsElementDisplayed(_header))
            {
                return _elementUtil.GetTextOf(_header);
            }
            return null;
        }
        public void SelectExistingCustomer(String value, String NABID)
        {
            Thread.Sleep(3000);
            IList<IWebElement> existingCustomerList = _elementUtil.GetElements(_existingCustomer);
            Console.WriteLine("Existing customer options : " + existingCustomerList.Count);

            foreach (IWebElement e in existingCustomerList)
            {
                if (e.Text.Equals(value))
                {
                    e.Click();
                    if (value.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _elementUtil.DoCheckIsElementDisplayed(_nabId);
                        _elementUtil.DoSendKeys(_nabId, NABID);
                    }
                    break;
                }
            }
        }
        public void EnterFirstName(String firstNameValue)
        {
            _elementUtil.DoSendKeys(_firstName, firstNameValue);
        }
        public void EnterLastName(String lastNameValue)
        {
            _elementUtil.DoSendKeys(_lastName, lastNameValue);
        }
        public void SelectState(String state)
        {           
            _javascriptUtil.ScrollIntoView(_selectState);        
            _elementUtil.DoClick(_selectState);  
            _elementUtil.DoClick(By.XPath("//div[text()='" + state + "']"));
        }
        public void EnterPhoneNumber(String phone)
        {   
            _elementUtil.DoSendKeys(_phoneNumber, phone);
        }
        public void EnterEmailAddress(String emailAddress)
        {
            _elementUtil.DoSendKeys(_email, emailAddress);
            Thread.Sleep(2000);
        }
        public void ClickOnSubmit()
        {
            _elementUtil.DoClick(_submit);
        }
        #endregion
    }
}
