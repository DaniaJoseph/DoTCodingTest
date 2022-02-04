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
   public  class AppointmentKindPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public AppointmentKindPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _phoneCallOption = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.AppointmentSelectCol-jlmUBP.fKiecM.dbHahP > a:nth-child(4) > div > div > div > p.ListItemstyle__StyledLabel-sc-1lp3zzc-0.hPcUMr.label");
        public void SelectPhoneCallOption()
        {
            Thread.Sleep(1000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            shadowRoot.FindElement(_phoneCallOption).Click();
            Thread.Sleep(1000);
        }
    }
}
