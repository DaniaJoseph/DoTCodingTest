using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AutomationFramework.Base
{
   [Binding]
   public class TestInitializeHooks
    {
        public static IWebDriver InitializeDriver(string browserName)
        {
            switch (browserName.ToUpperInvariant())
            {
                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(),VersionResolveStrategy.MatchingBrowser);
                    DriverFactory.Driver = new FirefoxDriver();
                    break;
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    DriverFactory.Driver = new ChromeDriver();
                    break;
                default:
                    Console.WriteLine("Please pass the correct browser..." + browserName);
                    throw new ArgumentException($"Browser not yet implemented: {browserName}");

            }
            DriverFactory.Driver.Manage().Window.Maximize();
            DriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
            DriverFactory.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);
            return DriverFactory.Driver;
        }
    }
}
