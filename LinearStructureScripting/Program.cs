using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearStructureScripting
{
    public abstract class Program
    {
        public IWebDriver driver;
        [SetUp]
        public void InitilizeTest()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
