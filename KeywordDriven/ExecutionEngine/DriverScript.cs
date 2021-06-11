using System;
using System.Reflection;
using KeywordDriven.Config;
using NUnit.Framework;
using KeywordDriven.Utility;

namespace KeywordDriven.ExecutionEngine
{
    [TestFixture]
    public class DriverScript
    {
        //This is a class object, declared as 'public static'
        //So that it can be used outside the scope of this class method
        public static ActionKeywords actionKeywords;
        public static String sActionKeyword;
        public static String sPageObject;
        //This is reflection class object, declared as 'public static'
        public static MethodInfo methodInfo;

        public static int iTestStep;
        public static int iTestLastStep;
        public static String sTestCaseID;
        public static String sRunMode;
        public static String sData;
        public static bool bResult;

        [SetUp]
        public void TestSetUp()
        {
        }

        [Test]
        public void TestMain()
        {
            ////Here we are instantiating a new object of class 'ActionKeywords'
            actionKeywords = new ActionKeywords();

            //Declaring the path of the Excel file with the name of the Excel file
            String sPath = Constants.Path_TestData;

            //Here we are passing the Excel path and SheetName to connect with the Excel file
            //This method was created in the last chapter of 'Set up Data Engine' 		
            ExcelUtils.SetExcelFile(sPath);

            // now start our test cases
            execute_TestCase();
        }

        private void execute_TestCase()
        {
            // Lets get the total number of test cases mentioned in the Test cases sheet
            int iTotalTestCases = ExcelUtils.GetRowCount(Constants.Sheet_TestCases);
            // This loop will execute the number of times equal to total number of test cases
            for (int iTestCase = 1; iTestCase < iTotalTestCases; iTestCase++)
            {
                // set to true at start execution of each test case
                bResult = true;
                // This is to get the test case name from the test cases sheet
                sTestCaseID = ExcelUtils.GetCellData(iTestCase, Constants.Col_TestCaseID, Constants.Sheet_TestCases);
                // This is to get the value of the Run Mode column for the current test case
                sRunMode = ExcelUtils.GetCellData(iTestCase, Constants.Col_RunMode, Constants.Sheet_TestCases);
                // This is the condition statement on RunMode value
                if (sRunMode != null && sRunMode.Equals("Yes"))
                {
                    // Only execute this part of code if the value of Run Mode is 'Yes'
                    iTestStep = ExcelUtils.GetRowContains(sTestCaseID, Constants.Col_TestCaseID, Constants.Sheet_TestSteps);
                    iTestLastStep = ExcelUtils.GetTestStepsCount(Constants.Sheet_TestSteps, sTestCaseID, iTestStep);
                    Console.WriteLine(sTestCaseID);
                    // This loop will execute number of times equal to Total number of test steps
                    // This is the loop for reading the values of the column (Action Keyword) row by row
                    // It means this loop will execute all the steps mentioned for the test case in Test Steps sheet
                    // set to true at start execution of each test step
                    bResult = true;
                    for (; iTestStep < iTestLastStep; iTestStep++)
                    {
                        //This to get the value of column Action Keyword from the excel
                        sActionKeyword = ExcelUtils.GetCellData(iTestStep, Constants.Col_ActionKeyword, Constants.Sheet_TestSteps);
                        //A new separate method as below is created with the name 'execute_Actions'
                        //So this statement is doing nothing but calling that piece of code to execute
                        sPageObject = ExcelUtils.GetCellData(iTestStep, Constants.Col_PageObject, Constants.Sheet_TestSteps);
                        sData = ExcelUtils.GetCellData(iTestStep, Constants.Col_DataSet, Constants.Sheet_TestSteps);
                        execute_Actions();
                        //check if result fails
                        if (!bResult)
                        {
                            // if 'false' then write test result as FAIL
                            ExcelUtils.SetCellData(Constants.KEYWORD_FAIL, iTestCase, Constants.Col_CaseResult, Constants.Sheet_TestCases);
                            break;
                        }
                    }
                    //This will only execute after the last step of the test case
                    if (bResult)
                    {
                        // if 'true' then write test case result as PASS
                        ExcelUtils.SetCellData(Constants.KEYWORD_PASS, iTestCase, Constants.Col_CaseResult, Constants.Sheet_TestCases);
                    }
                    Console.WriteLine(sTestCaseID);
                }
            }
        }

        //This method contains the code to perform some action (test step)
        //As it is completely different set of logic, which revolves around the action only,
        //It makes sense to keep it separate from the main driver script
        private static void execute_Actions()
        {
            // a sActionKeyword = null value signals the end of all test cases             
            String sResult;
            if (sActionKeyword != null)
            {
                // the reflection class can help to invoke methods based on variable method string
                MethodInfo mi = actionKeywords.GetType().GetMethod(sActionKeyword);

                // Passing 'Page Object' name and 'Action Keyword' as Arguments to this class instance
                // This code will pass string array as parameters to every invoked method
                string[] args = { sPageObject, sData };
                mi.Invoke(sActionKeyword, args);

                sResult = bResult ? Constants.KEYWORD_PASS : Constants.KEYWORD_FAIL;
                // Set PASS or FAIL to test steps result cell
                ExcelUtils.SetCellData(sResult, iTestStep, Constants.Col_TestStepResult, Constants.Sheet_TestSteps);
                if (!bResult)
                {
                    ActionKeywords.closeBrowser("", "");
                }
            }
        }

        /**
         * http://stackoverflow.com/questions/17777545/closing-excel-application-process-in-c-sharp-after-data-access
         * */
        [TearDown]
        public void TestCloseApp()
        {
            ExcelUtils.ExcelWBook.Save();
            ExcelUtils.ExcelWBook.Close(0);
            ExcelUtils.ExcelApp.Quit();
        }       
    }
}
