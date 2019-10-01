using System;
using LinearStructureScripting.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

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

            driver.Url = "http://www.store.demoqa.com";

            var homePage = new HomePage(driver);
            homePage.ClickOnMyAccount();

            var loginPage = new LoginPage(driver);
            loginPage.LoginToApplication();
        }
    }
}
