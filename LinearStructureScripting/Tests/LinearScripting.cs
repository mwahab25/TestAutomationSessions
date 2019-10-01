using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearStructureScripting.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LinearStructureScripting.Tests
{
    [TestFixture]
    public class LinearScripting
    {
        public IWebDriver driver;

        [Test]
        public void TestCase1()
        {
            //initiate driver
            driver = new ChromeDriver();

            //display URL on browser
            driver.Url = Settings.Default.URL;
            //click on my account button
            driver.FindElement(By.Id("account")).Click();

            //input username
            driver.FindElement(By.Id("log")).SendKeys("TestUser_1");
            //input password
            driver.FindElement(By.Id("pwd")).SendKeys("[email protected]");
            //click submit button
            driver.FindElement(By.Id("login")).Click();

            //close driver
            driver.Close();
        }
    }
}
