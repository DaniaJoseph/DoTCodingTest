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
   public class AppointmentDetailsPage
    {
        private IWebDriver _driver;
        private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;
        #region Constructor
        public AppointmentDetailsPage(IWebDriver driver)
        {
            this._driver = driver;
            _elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
        }
        #endregion
        private By _shadowRoot = By.XPath("//*[@id='wrapper']//self-serve-appointment-booking");
        private By _appointmentDetailsText = By.CssSelector("div > div > div > div > div.sc-gtsrHT.Rowstyle__StyledRow-mjf486-0.iHXuUE.cwoAMR.StyledRow-bfNfbx.jlSDJf > div.sc-dlnjwi.Colstyle__StyledCol-sc-1evc4kf-0.ldCTSc.duEYaW.LeftContentCol-fOupiG.ReviewConfirmationCol-bhndEV.fKiecM.ewikFm > h2:nth-child(3)");

        public void VerifyIfAppointmentDetailsIsDisplayed()
        {
            Thread.Sleep(3000);
            IWebElement shadowRoot = _javascriptUtil.ExpandRootElement(_elementUtil.GetElement(_shadowRoot));
            Thread.Sleep(1000);
            Assert.IsTrue(shadowRoot.FindElement(_appointmentDetailsText).Displayed);
            Console.WriteLine("Appointments details are displayed correctly");
        }
    }
}
