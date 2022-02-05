using AutomationFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
    public class TimeSlotPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public TimeSlotPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _7thDateOption = By.CssSelector("#date-20220206");
        private By _firstTimeOption = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.SelectTimeSlotCol-kxmyod.fKiecM.dUxGgZ > form > div:nth-child(4) > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > button");
        private By _timeSlotFormNextButton = By.CssSelector("button[form='timeslot-form']");

        private By _nextWeek = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.SelectTimeSlotCol-kxmyod.fKiecM.dUxGgZ > form > div.StyledDateSelect-bxlUXz.diABTs > div.StyledButtonContainer-ejwjTU.iveIqB > div.RightIconContainer-liEPPi.insFil > button > div");
        public void SelectAppointDateAndTime()
        {
            Thread.Sleep(3000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(8000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(80000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(shadowRoot.FindElement(_7thDateOption)));
          
            new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            IJavaScriptExecutor ex = (IJavaScriptExecutor)_driver;
            ex.ExecuteScript("arguments[0].click();", shadowRoot.FindElement(_7thDateOption));

            Thread.Sleep(3000);
            shadowRoot.FindElement(_firstTimeOption).Click();
            Thread.Sleep(1000);
            shadowRoot.FindElement(_timeSlotFormNextButton).Click();
        }
    }
}
