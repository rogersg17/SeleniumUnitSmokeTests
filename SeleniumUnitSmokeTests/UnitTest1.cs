using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumUnitSmokeTests
{
    [TestClass]
    public class Login
    {
        private static IWebDriver driver;
        private static string vmname;
        private static string baseURL;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
           driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Get VMNAME from Jenkins
            vmname = Environment.GetEnvironmentVariable("Test1");
            baseURL = "http://" + "ia-w12-1243-qa" + "/Login.php";
        }

            [ClassCleanup]
            public static void CleanupClass()
            {
                driver.Close();
                driver.Dispose();
             }


            [TestMethod]
            public void LogIntoEslideManager()
            {
                driver.Navigate().GoToUrl("http://ia-w12-1243-qa/Login.php");
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys("administrator");
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys("scanscope");
                driver.FindElement(By.Name("submit")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='»'])[1]/preceding::input[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Educational'])[1]/following::img[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Administrator'])[1]/following::i[4]")).Click();
            }

                  
        }
    }
