using System;
using LinearStructureScripting.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System.Threading;
using LinearStructureScripting.Properties;

namespace LinearStructureScripting.Tests
{
    [TestFixture]
    public sealed class StructureScripting : Program
    {
        [Test]
        public void TestCase1()
        {
            //This test method use Page object model(POM) to organize elements and event methods.
            //so you can use POM in other test methods
            //Note you can mange waiting by implicit or explict waiting methods.

            driver.Url = Settings.Default.URL;

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToApplication();

            Thread.Sleep(10000);

            HomePage homePage = new HomePage(driver);
            homePage.ClickOnAddBtn();

            Thread.Sleep(5000);

            driver.Navigate().Back();
            Thread.Sleep(5000);

        }
    }
}
