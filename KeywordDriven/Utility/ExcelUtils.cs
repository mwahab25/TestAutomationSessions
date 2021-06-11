using System;
using Excel = Microsoft.Office.Interop.Excel;
using KeywordDriven.Config;
using KeywordDriven.ExecutionEngine;

namespace KeywordDriven.Utility
{
    public class ExcelUtils
    {
        public static Excel.Application ExcelApp;
        public static Excel.Workbook ExcelWBook;
        private static Excel.Worksheet ExcelWSheet;

        //This method is to set the File path and to open the Excel file
        //Pass Excel Path and SheetName as Arguments to this method
        public static void SetExcelFile(String path)
        {
            try
            {
                ExcelApp = new Excel.Application();
                ExcelApp.Visible = false;
                ExcelWBook = ExcelApp.Workbooks.Open(Constants.Path_TestData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        //This method is to read the test data from the Excel cell
        //In this we are passing parameters/arguments as Row Num and Col Num & Sheet Name
        public static string GetCellData(int rowNum, int colNum, String sheetName)
        {           
            try
            {
                ExcelWSheet = ExcelWBook.Sheets[sheetName] as Excel.Worksheet;
                string cellValue = (ExcelWSheet.Cells[rowNum + 1, colNum + 1] as Excel.Range).Text as string;
                return cellValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
                return "";
            }
        }

        // This method is to get the row count used of the excel sheet
        public static int GetRowCount(String sheetName)
        {
            int number = 0;
            try
            {
                ExcelWSheet = ExcelWBook.Sheets[sheetName] as Excel.Worksheet;
                number = ExcelWSheet.UsedRange.Rows.Count+1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
            return number;
        }

        // This method is to get the Row number of the test case
        // This method takes three arguments (Test case name, Column Number & Sheet Name)
        public static int GetRowContains(String testCaseName, int colNum, String sheetName)
        {
            int rowNum = 0;
            try
            {
                ExcelWSheet = ExcelWBook.Sheets[sheetName] as Excel.Worksheet;
                int rowCount = GetRowCount(sheetName);

                for (; rowNum < rowCount; rowNum++)
                {
                    if (GetCellData(rowNum, colNum, sheetName).Equals(testCaseName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
            return rowNum;
        }

        // This method is to get the count of the test steps of test case
        // This method takes three arguments (Sheet name, Test Case Id & Test case row number)
        public static int GetTestStepsCount(String sheetName, String testCaseID, int testCaseStart)
        {
            try
            {
                for (int i = testCaseStart; i <= ExcelUtils.GetRowCount(sheetName); i++)
                {
                    if (!testCaseID.Equals(ExcelUtils.GetCellData(i, Constants.Col_TestCaseID, sheetName)))
                    {
                        int number = i;
                        return number;
                    }
                }
                ExcelWSheet = ExcelWBook.Sheets[sheetName] as Excel.Worksheet;
                int number1 = ExcelWSheet.UsedRange.Rows.Count + 1;
                return number1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
                return 0;
            }
        }

        // This method is used to write value in excel cell
        // Four arguments are accepted (Result, Row Number, Column Number & Sheet Name)
        public static void SetCellData(String Result, int rowNum, int colNum, String sheetName)
        {
            try
            {
                ExcelWSheet = ExcelWBook.Sheets[sheetName] as Excel.Worksheet;
                (ExcelWSheet.Cells[rowNum + 1, colNum + 1] as Excel.Range).Value = Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }
    }
}
