using APIFramework.Base;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace APIAutomation.StepDefinitions
{
    [Binding]
    public class DisruptionsAPISteps
    {
        private TestInitializeHooks _testInitializeHooks;
        public DisruptionsAPISteps(TestInitializeHooks testInitializeHooks)
        {
            this._testInitializeHooks = testInitializeHooks;
        }

        [Given(@"I call (.*) with (.*) http request")]
        public void GivenICallWithHttpRequest(string resourceUrl,string httpRequestType)
        {
            _testInitializeHooks.Request = new RestRequest(resourceUrl, Method.GET);
        }
        
        [When(@"I pass the query parameter (.*)")]
        public void WhenIPassTheQueryParameter(string value)
        {
            _testInitializeHooks.Request.AddQueryParameter("current", value);
        }
        
        [Then(@"I get the response")]
        public void ThenIGetTheResponse()
        {
            _testInitializeHooks.Response = _testInitializeHooks.RestClient.Execute(_testInitializeHooks.Request);
        }
        
        [Then(@"the API call is successful with status code (.*)")]
        public void ThenTheAPICallIsSuccessfulWithStatusCode(string status)
        {
            Assert.That(_testInitializeHooks.Response.StatusCode.ToString(), Is.EqualTo(status), "Status code is not matching");
        }
        
        [Then(@"get the count of the events based on (.*)")]
        public void ThenGetTheCountOfTheEventsBasedOn(string disruptionStatus)
        {
            if(_testInitializeHooks.Response.IsSuccessful)
            {
                int count = 0;
                JArray jArray = JArray.Parse(_testInitializeHooks.Response.Content);
                foreach(var a in jArray.Children<JObject>())
                {
                    if(a.Property("disruption_status").Value.ToString().Equals(disruptionStatus))
                    {
                        count ++;
                    }
                }
                Console.WriteLine("Count of events with disruption status C is : ===> " + count);
            }
        }
    }
}
