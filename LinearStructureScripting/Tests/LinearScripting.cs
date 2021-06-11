using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinearStructureScripting.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

            //Navigate to URL
            driver.Url = "http://104.210.220.80:7200";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            //input username
            driver.FindElement(By.Name("username")).SendKeys("admin");
            //input password
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //click Login
            driver.FindElement(By.XPath("//button")).Click();

            Thread.Sleep(10000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("BtnAdd")));

            //click add new user button
            driver.FindElement(By.Id("BtnAdd")).Click();
            Thread.Sleep(5000);
            
            //go back
            driver.Navigate().Back();
            Thread.Sleep(5000);
            
            //close driver
            driver.Close();
        }
    }
}
