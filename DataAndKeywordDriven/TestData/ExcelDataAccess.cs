using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Dapper;

namespace DataDriven.TestData
{
    class ExcelDataAccess
    {
        public static string assemblyDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string projectDir = Path.GetDirectoryName(Path.GetDirectoryName(assemblyDir));
        public static string Path_TestData = Path.Combine(projectDir, "TestData\\TestData.xlsx");

        public static string TestDataFileConnection()
        {
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", Path_TestData);
            return con;
        }

        public static UserData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
