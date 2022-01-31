using AutomationFramework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
    public class HomePage
    {
		private IWebDriver _driver;
		private ElementUtil _elementUtil;
        private JavascriptUtil _javascriptUtil;

        #region Element Locators
       	private By _personalLink = By.XPath("//a[text()='Personal' and @class='menu-trigger']");
		private By _homeLoanMenu = By.XPath("//a[@class='menu-trigger']/span[text()='Home loans']");
		private By _homeLoanLink = By.XPath("//div[@class='nav-container']//span[text()='Home loans']");
        #endregion

        #region Constructor
        public HomePage(IWebDriver driver)
		{
			this._driver = driver;
			_elementUtil = new ElementUtil(this._driver);
            _javascriptUtil = new JavascriptUtil(this._driver);
		}
        #endregion

        #region Methods
        public String GetHomePageTitle()
		{
            Console.WriteLine("Getting the home page title");
			return _elementUtil.WaitForPageTitle("NAB personal banking | Loans, accounts, credit cards, insurance - NAB", 5);
		}	
		public HomeLoansPage MoveToHomeLoans()
		{
            _elementUtil.ClickWhenReady(_personalLink, 30);
            _javascriptUtil.ClickElementByJS(_homeLoanMenu);
            _javascriptUtil.ClickElementByJS(_homeLoanLink);            
            return new HomeLoansPage(_driver);
		}
        #endregion
    }
}
