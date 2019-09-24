using System;
using System.Drawing;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace NUnitAndSelenium
{
    [TestFixture]
    [Parallelizable]
    class NUnitTestSuite1
    {
        IWebDriver driver;
        [SetUp]
        public void InitilizeTest()
        {
            // method run before each Test method
            driver = new ChromeDriver();

        }

        [Test]
        [Category("My Tasks")]
        [Author("Tester1")]
        public void TestCase1()
        {
            // Test method steps

            //Go to URL
            ////////////You can add your website and locators//////////////

            driver.Navigate().GoToUrl("http://www.toolsqcc.com");

            //navigate to the previous page 
            driver.Navigate().Back();

            //navigate to the next page 
            driver.Navigate().Forward();

            //refreshes the page 
            driver.Navigate().Refresh();

            //clear the value
            driver.FindElement(By.Id("UserName")).Clear();

            //input value
            driver.FindElement(By.Id("UserName")).SendKeys("ToolsQC");

            //Click web element
            driver.FindElement(By.LinkText("ToolsQA")).Click();

            //Check if an element is currently being displayed or not
            bool status1 = driver.FindElement(By.Id("UserName")).Displayed;

            //Check if the element currently is Enabled or not
            IWebElement element = driver.FindElement(By.Id("UserName"));
            bool status2 = element.Enabled;

            if (status2)
            {
                element.SendKeys("ToolsQA");
            }

            //Check if element is selected or not
            IWebElement element1 = driver.FindElement(By.Id("Sex-Male"));
            bool status = element1.Selected;
            //Or can be written as
            bool staus = driver.FindElement(By.Id("Sex-Male")).Selected;

            //This method works well/better than the Click() if the current element is a form
            IWebElement element2 = driver.FindElement(By.Id("SubmitButton"));
            element2.Submit();
            //Or can be written as
            driver.FindElement(By.Id("SubmitButton")).Submit();

            //This returns an innerText of the element
            IWebElement element3 = driver.FindElement(By.XPath("anyLink"));
            String linkText = element3.Text;

            //gets the tag name of this element. 
            String tagName = driver.FindElement(By.Name("anyname")).TagName;

            //Fetch CSS property value 
            IWebElement element4 = driver.FindElement(By.Id("SubmitButton"));
            String attValue = element4.GetCssValue("background-color");

            //fetch the width and height of the rendered element
            //IWebElement element5 = driver.FindElement(By.Id("SubmitButton"));
            //Dimension dimensions = element5.Size();
            //Console.WriteLine("Height:" + dimensions.Height + "Width: " + dimensions.Width);

            //fetch the width and height of the rendered element
            IWebElement element6 = driver.FindElement(By.Id("SubmitButton"));
            Point point = element6.Location;
            Console.WriteLine("X cordinate : " + point.X + "Y cordinate: " + point.Y);

            //Click on Link text
            driver.FindElement(By.LinkText("Name of the Link")).Click();

        }

        [Test]
        [TestCase(40, 50.5, 100)]
        [Category("Task distribution")]
        public void TestCase2(int target1, double target2, int target3)
        {
            // Test method steps

            //Implicit Wait
            driver.Navigate().GoToUrl("http://www.bravo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element1 = driver.FindElement(By.Id("target"));

            //Page Load Timeout
            driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(500);
            driver.Navigate().GoToUrl("http://www.bravo.com/");
            IWebElement element2 = driver.FindElement(By.Id("target"));

            //Thread
            Thread.Sleep(6000);

            //Explicit wait 
            //WebDriver wait
            driver.Navigate().GoToUrl("https://www.bravo.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Console.WriteLine(Web.FindElement(By.Id("target")).GetAttribute("innerHTML"));
                return true;
            });
            wait.Until(waitForElement);

            //Explicit wait 
            //Default wait
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement element3 = driver.FindElement(By.Id("colorVar"));
            DefaultWait<IWebElement> wait2 = new DefaultWait<IWebElement>(element3);
            wait2.Timeout = TimeSpan.FromMinutes(2);
            wait2.PollingInterval = TimeSpan.FromMilliseconds(250);
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = element3.GetAttribute("style");
                if (styleAttrib.Contains("red"))
                { return true; }
                Console.WriteLine("Color is still " + styleAttrib);
                return false;
            });
            wait2.Until(waiter);
        }

        [TearDown]
        public void EndTest()
        {
            // method run after each Test method
            driver.Close();

        }
    }
}
