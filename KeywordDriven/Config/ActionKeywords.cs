using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using KeywordDriven.ExecutionEngine;
using KeywordDriven.Properties;

namespace KeywordDriven.Config
{
    public class ActionKeywords
    {
        public static IWebDriver driver;

        public static void openBrowser(String obj, String data)
        {
            try
            {
                if (data == "Mozilla")
                {
                    driver = new FirefoxDriver();
                }
                else if (data == "IE")
                {
                    driver = new InternetExplorerDriver();
                }
                else if (data == "Chrome")
                {
                    driver = new ChromeDriver();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static void navigate(String obj, String data)
        {
            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                driver.Navigate().GoToUrl(Constants.URL);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static void click(String obj, String data)
        {
            try
            {
                driver.FindElement(By.XPath(getKey(obj, ""))).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static string getKey(String obj, String data)
        {
            return Settings.Default.Properties[obj].DefaultValue as string;
        }

        public static void input(String obj, String data)
        {
            try
            {
                IWebElement we = driver.FindElement(By.Name(getKey(obj, "")));
                we.Clear();
                we.SendKeys(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static void waitFor(String obj, String data)
        {
            try
            {
                Thread.Sleep(10000);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static void waitUntil(String obj, String data)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(getKey(obj, ""))));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }

        public static void closeBrowser(String obj, String data)
        {
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DriverScript.bResult = false;
            }
        }
    }
}
