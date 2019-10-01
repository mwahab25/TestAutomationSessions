using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LinearStructureScripting.POM
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "log")]
        [CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToApplication()
        {
            UserName.SendKeys("TestUser_1");
            Password.SendKeys("[email protected]");
            Submit.Submit();
        }
    }
}
