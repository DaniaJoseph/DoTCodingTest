using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Utilities
{
    public class ExcelReaderHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        #region ExcelToDataTableCollection
        public static DataTableCollection ExcelToDataTableCollection(string fileName)

        {

            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    ////read as dataset and set the first row as column name
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all the Tables
                    DataTableCollection table = result.Tables;
                    return table;
                }
            }
        }
        #endregion

        #region PopulateInCollection
        public static void PopulateInCollection(string fileName, string sheetName)
        {
            DataTable table = ExcelToDataTable(fileName, sheetName);
            #region find the row corresponding to the test case name
            for (int i = 0; i < table.Rows.Count; ++i)
            {
                int j = 0;

                var _testCaseNo = table.Rows[i][j].ToString();
                if (_testCaseNo == TempFile.TestCaseNo)
                {
                    j++; //
                    TempFile.Row = i + 1;
                    break;

                }

            }
            #endregion

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCol.Add(dtTable);
                }
            }
        }
        #endregion

        #region ExcelToDataTable
        public static DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all the Tables
                    DataTableCollection table = result.Tables;
                    //Store it in DataTable
                    DataTable resultTable = table[sheetName];
                    //return
                    return resultTable;
                }
            }
        }
        #endregion

        #region ReadData
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).FirstOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }

    #region Customclass DataCollection
    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
    #endregion

}
