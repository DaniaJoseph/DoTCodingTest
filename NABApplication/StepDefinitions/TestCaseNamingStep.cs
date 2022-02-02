using AutomationFramework;
using AutomationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NABApplication.StepDefinitions
{
    [Binding]
    public class TestCaseNamingStep
    {

        DataTableCollection exceltablecollection;
        DataTable exceldatatable;
       
        string fileName = System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + @"\TestInput\TestInput.xlsx";
        
        string sheetname;
        [Given(@"I am Running test  (.*)")]
        public void GivenIAmRunningTest(string TestCaseNo)
        {
            TempFile.TestCaseNo = TestCaseNo;
            string fileName1 = System.AppDomain.CurrentDomain.BaseDirectory;
        }


        [Given(@"I collect the required data to fill the contact details page")]
        public void GivenICollectTheRequiredDataToFillTheContactDetailsPage()
        {
            sheetname = "ContactDeatils";
            ExcelReaderHelpers.PopulateInCollection(fileName, sheetname);
        }

    }
}