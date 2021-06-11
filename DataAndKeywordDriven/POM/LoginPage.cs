using System;
using DataDriven.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DataDriven.POM
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button")]
        [CacheLookup]
        private IWebElement LoginBtn { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToApplication(string testName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(UserName));
            var userData = ExcelDataAccess.GetTestData(testName);
            UserName.SendKeys(userData.Username);
            Password.SendKeys(userData.Password);
            LoginBtn.Click();
        }
    }
}
