using APIFramework.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APIAutomation.Hooks
{
    [Binding]
    public class HooksInitialize
    {
        private TestInitializeHooks _testInitializeHooks;
        public HooksInitialize(TestInitializeHooks testInitializeHooks)
        {
            this._testInitializeHooks = testInitializeHooks;
        }

        #region Before Scenario
        [BeforeScenario]
        public void Initialize()
        {
            _testInitializeHooks.BaseUrl = new Uri(ConfigurationManager.AppSettings.Get("baseURL"));
            _testInitializeHooks.RestClient.BaseUrl = _testInitializeHooks.BaseUrl;
        }
        #endregion
    }
}
