using System;
using LinearStructureScripting.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace LinearStructureScripting.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.store.demoqa.com";

            var homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.MyAccount.Click();

            var loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("TestUser_1");
            loginPage.Password.SendKeys("[email protected]");
            loginPage.Submit.Submit();
        }
    }
}
