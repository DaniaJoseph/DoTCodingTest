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
    public class BookAnAppoinmentPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;


        #region Constructor
        public BookAnAppoinmentPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion

        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _buyingAproperty = By.CssSelector("div[aria-label='Buying a property']>div>div>p:nth-child(1)");

        public void SelectBuyingApropertyOption()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(2000);
            shadowRoot.FindElement(_buyingAproperty).Click();
        }

    }
}

