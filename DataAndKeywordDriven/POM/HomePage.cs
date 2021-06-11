using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DataDriven.POM
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "BtnAdd")]
        [CacheLookup]
        private IWebElement AddUserBtn { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnAddBtn()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(AddUserBtn));
            AddUserBtn.Click();
        }
    }
}
