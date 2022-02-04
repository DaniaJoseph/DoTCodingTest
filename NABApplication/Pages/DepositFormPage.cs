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
    public class DepositFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public DepositFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _moneySaved = By.CssSelector("#deposit-form > fieldset > div > div > div > label:nth-child(1) > span.Label-idxVLZ.iyyITP");
        private By _depositFormNEXTButton = By.CssSelector("#deposit-form > p.Styledp-iPxeNv.dVTyqH > button");
        public void SelectMoneySavedOption()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_moneySaved).Click();
            Thread.Sleep(1000);
            shadowRoot.FindElement(_depositFormNEXTButton).Click();
            Thread.Sleep(1000);
        }
    }
}
