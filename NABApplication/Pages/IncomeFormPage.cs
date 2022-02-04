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
    public class IncomeFormPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public IncomeFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _fullorPartTimeEmployment = By.CssSelector("#income-form > fieldset > div > div > div > label:nth-child(1) > span.Checkboxstyle__CustomCheckbox-tk9n2c-0.SSABCustomCheckbox-lolqDD.fABBwW.fMJtph");
        private By _incomeFormNextButton = By.CssSelector("#income-form > p.Styledp-iPxeNv.dVTyqH > button");

        public void SelectFullorParttimeEmployment()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_fullorPartTimeEmployment).Click();
            Thread.Sleep(1000);
            shadowRoot.FindElement(_incomeFormNextButton).Click();
        }
    }
}
