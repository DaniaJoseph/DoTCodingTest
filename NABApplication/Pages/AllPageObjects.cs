using AutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NABApplication.Pages
{
    public static class AllPageObjects
    {
        public static HomePage homePage;
        public static HomeLoansPage homeLoansPage;
        public static CustomerAssistancePage customerAssistancePage;
        public static CallBackFormPage callBackFormPage;

        public static void InitializeAllPages()
        {
            homePage = new HomePage(DriverFactory.Driver);
            homeLoansPage = new HomeLoansPage(DriverFactory.Driver);
            customerAssistancePage = new CustomerAssistancePage(DriverFactory.Driver);
            callBackFormPage = new CallBackFormPage(DriverFactory.Driver);
        }
    }
}
