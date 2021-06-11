using System;
using System.IO;

namespace KeywordDriven.Config
{
    class Constants
    {
        public const string URL = "http://104.210.220.80:7200";
        public static string assemblyDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string projectDir = Path.GetDirectoryName(Path.GetDirectoryName(assemblyDir));
        public static string Path_TestData = Path.Combine(projectDir, "DataEngine\\DataEngine.xlsx");       

        //List of Data Sheet Column Numbers
        public const int Col_TestCaseID = 0;
        public const int Col_TestScenarioID = 1;
        public const int Col_PageObject = 4;
        public const int Col_ActionKeyword = 5;
        public const int Col_DataSet = 6;

        // New entry in Constant variable
        public const int Col_RunMode = 2;

        // Two new constants variables to mark Fail or Pass
        public const String KEYWORD_FAIL = "FAIL";
        public const String KEYWORD_PASS = "PASS";

        // Define two new result column
        public const int Col_CaseResult = 3;
        public const int Col_TestStepResult = 7;

        //List of Data Engine Excel sheets
        public const String Sheet_TestSteps = "Test Steps";
        // New entry in Constant variable
        public const String Sheet_TestCases = "Test cases";
    }
}
