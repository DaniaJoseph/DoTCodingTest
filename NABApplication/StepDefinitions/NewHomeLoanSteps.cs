using AutomationFramework.Base;
using NABApplication.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace NABApplication.StepDefinitions
{
    [Binding]
    public class NewHomeLoanSteps
    {
        [Given(@"the user navigates to nab homepage")]
        public void GivenTheUserNavigatesToNabHomepage()
        {
            DriverFactory.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);           
        }

        [Then(@"verify the title of the page")]
        public void ThenVerifyTheTitleOfThePage()
        {
            string title = AllPageObjects.homePage.GetHomePageTitle();
            Console.WriteLine("Page title is : " + title);
            Assert.AreEqual("NAB personal banking | Loans, accounts, credit cards, insurance - NAB", title, "Title is not matching");
        }

        [Given(@"the user navigates to home loans")]
        public void GivenTheUserNavigatesToHomeLoans()
        {
            AllPageObjects.homePage.MoveToHomeLoans();
        }

        [When(@"the user clicks on Book an appointment")]
        public void WhenTheUserClicksOnBookAnAppointment()
        {
            AllPageObjects.homeLoansPage.ClickOnBookAnAppointment();
        }

        //[When(@"selects Buying a property")]
        //public void WhenSelectsBuyingAProperty()
        //{
        //    AllPageObjects.BookAnAppoinmentPage.ClickBuyingAproperty(
        //}



        [When(@"the user clicks on request to call back service")]
        public void WhenTheUserClicksOnRequestToCallBackService()
        {
            AllPageObjects.homeLoansPage.GoToCustomerAssistance();
        }

        [When(@"selects the new home loans service")]
        public void WhenSelectsTheNewHomeLoansService()
        {
            AllPageObjects.customerAssistancePage.SelectLoanType();
        }

        [When(@"select the loan topic as (.*)")]
        public void WhenSelectTheLoanTopicAs(string loanTopic)
        {
            AllPageObjects.customerAssistancePage.GoToCallBackForm();
        }

        [When(@"the user fills the form with (.*),(.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void WhenTheUserFillsTheFormWith(String existingCustomer, String nabId, String firstName, String lastName,
            String state, String phoneNumber, String emailId)
        {
            AllPageObjects.callBackFormPage.MoveToNewWindow();
            AllPageObjects.callBackFormPage.SelectExistingCustomer(existingCustomer, nabId);
            AllPageObjects.callBackFormPage.EnterFirstName(firstName);
            AllPageObjects.callBackFormPage.EnterLastName(lastName);
            AllPageObjects.callBackFormPage.SelectState(state);
            AllPageObjects.callBackFormPage.EnterPhoneNumber(phoneNumber);
            AllPageObjects.callBackFormPage.EnterEmailAddress(emailId);
        }

        [When(@"submits the application")]
        public void WhenSubmitsTheApplication()
        {
            //AllPageObjects.callBackFormPage.ClickOnSubmit();
        }

        [Then(@"the application is submitted successfully")]
        public void ThenTheApplicationIsSubmittedSuccessfully()
        {
            
        }
    }
}
