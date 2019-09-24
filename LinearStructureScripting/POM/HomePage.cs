using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LinearStructureScripting.POM
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "account")]
        [CacheLookup]
        public IWebElement MyAccount { get; set; }

    }
}
