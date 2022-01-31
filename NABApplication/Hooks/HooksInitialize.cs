using AutomationFramework.Base;
using NABApplication.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NABApplication.Hooks
{
    [Binding]
    public class HooksInitialize
    {
        private static IWebDriver _driver;

        #region BeforeScenario
        [BeforeScenario]
        public void LaunchBrowser()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            _driver = TestInitializeHooks.InitializeDriver(browserName);
            AllPageObjects.InitializeAllPages();
        }
        #endregion

        #region AfterScenario
        [AfterScenario]
        public void TearDown()
        {
            if (DriverFactory.Driver != null)
            {
                DriverFactory.Driver.Close();
                DriverFactory.Driver.Quit();
                DriverFactory.Driver.Dispose();
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (process.ProcessName.ToLower().Contains("chromedriver"))
                    {
                        process.Kill();
                    }
                }
            }
        }
        #endregion
    }
}
