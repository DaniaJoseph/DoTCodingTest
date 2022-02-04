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
   public  class ApplicantFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public ApplicantFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _1applicant = By.CssSelector("label[for='applicants-0']>span[class*='Radio']");
        private By _applicantFormNextButton = By.CssSelector("#applicatnts-form > p > button");
        public void ClickFirstApplicant()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_1applicant).Click();
            Thread.Sleep(1000);
            shadowRoot.FindElement(_applicantFormNextButton).Click();
        }
    }
}
