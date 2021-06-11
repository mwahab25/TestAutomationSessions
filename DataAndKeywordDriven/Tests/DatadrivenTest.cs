using DataDriven.POM;
using DataDriven.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataDriven.Tests
{
    [TestFixture]
    public class DatadrivenTest : Program
    {
        [Test]
        public void TestCase1()
        {
            driver.Url = Settings.Default.URL;

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToApplication("Login_001");

            Thread.Sleep(10000);

            HomePage homePage = new HomePage(driver);
            homePage.ClickOnAddBtn();

            Thread.Sleep(5000);

            driver.Navigate().Back();
            Thread.Sleep(5000);
        }
    }
}
