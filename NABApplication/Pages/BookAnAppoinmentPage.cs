using AutomationFramework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

       
    }
}
