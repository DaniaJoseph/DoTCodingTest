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
        public static BookAnAppoinmentPage BookAnAppoinmentPage;
        public static ApplicantFormPage ApplicantFormPage;
        public static IncomeFormPage IncomeFormPage;
        public static DepositFormPage DepositFormPage;
        public static LocationFormPage LocationFormPage;
        public static AppointmentKindPage AppointmentKindPage;
        public static TimeSlotPage TimeSlotPage;
        public static ContactFormPage ContactFormPage;
        public static AppointmentDetailsPage AppointmentDetailsPage;

        public static void InitializeAllPages()
        {
            homePage = new HomePage(DriverFactory.Driver);
            homeLoansPage = new HomeLoansPage(DriverFactory.Driver);
            customerAssistancePage = new CustomerAssistancePage(DriverFactory.Driver);
            callBackFormPage = new CallBackFormPage(DriverFactory.Driver);
            BookAnAppoinmentPage=new BookAnAppoinmentPage(DriverFactory.Driver);
            ApplicantFormPage=new ApplicantFormPage(DriverFactory.Driver);
            IncomeFormPage=new IncomeFormPage(DriverFactory.Driver);
            DepositFormPage=new DepositFormPage(DriverFactory.Driver);
            LocationFormPage=new LocationFormPage(DriverFactory.Driver);
            AppointmentKindPage=new AppointmentKindPage(DriverFactory.Driver);
            TimeSlotPage= new TimeSlotPage(DriverFactory.Driver);
            ContactFormPage=new ContactFormPage(DriverFactory.Driver);
            AppointmentDetailsPage=new AppointmentDetailsPage(DriverFactory.Driver);
        }


    }
}
