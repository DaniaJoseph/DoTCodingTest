using AutomationFramework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
    public class ContactFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public ContactFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _firstNameTextBox = By.CssSelector("#firstName");
        private By _lastNameTextBox = By.CssSelector("#lastName");
        private By _emailTextBox = By.CssSelector("#email");
        private By _mobileTextBox = By.CssSelector("#mobile");
        private By _contactFormNextButton = By.CssSelector("button[form ='contact-form']");
        public void EnterContactDetails()
        {
            Thread.Sleep(3000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_firstNameTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "FirstName"));
            Thread.Sleep(1000);
            Console.WriteLine("Reading from Excel");
            Console.WriteLine(ExcelReaderHelpers.ReadData(1, "FirstName"));
            shadowRoot.FindElement(_lastNameTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "LastName"));
            Console.WriteLine(ExcelReaderHelpers.ReadData(1, "LastName"));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_emailTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "Email"));
            Console.WriteLine(ExcelReaderHelpers.ReadData(1, "Email"));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_mobileTextBox).SendKeys(ExcelReaderHelpers.ReadData(1, "Mobile"));
            Thread.Sleep(1000);
            Console.WriteLine(ExcelReaderHelpers.ReadData(1, "Mobile"));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_contactFormNextButton).Click();
        }
    }
}