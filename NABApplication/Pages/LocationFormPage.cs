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
    public class LocationFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public LocationFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _enterSuburbTextBox = By.CssSelector("#location");
        private By _suburbTextBoxAutosuggest1 = By.CssSelector("#autosuggest-listbox-location-0");
        private By _locationFormNEXTButton = By.CssSelector("#location-form > p.Styledp-iPxeNv.dVTyqH > button");
        public void EnterSuburborPostcode()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_enterSuburbTextBox).SendKeys("3084");
            Thread.Sleep(1000);
            shadowRoot.FindElement(_suburbTextBoxAutosuggest1).Click();
            Thread.Sleep(1000);
            shadowRoot.FindElement(_locationFormNEXTButton).Click();
        }
    }
}
