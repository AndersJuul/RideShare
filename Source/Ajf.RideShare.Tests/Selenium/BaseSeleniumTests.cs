using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Ajf.RideShare.Tests.Selenium
{
    public class BaseSeleniumTests
    {
        protected RemoteWebDriver ChromeDriver { get; set; }

        private Uri BaseUri { get; set; }


        protected void RunTest(Action a)
        {
            try
            {
                a();
            }
            catch (Exception e)
            {
                ChromeDriver.GetScreenshot().SaveAsFile(@"c:\temp\"+DateTime.Now.ToString("yyyyMMddHHmmss")+".bmp",ScreenshotImageFormat.Bmp);
                Console.WriteLine(e);
                throw;
            }
        }

        [SetUp]
        public void SetUp()
        {
            BaseUri = new Uri(ConfigurationManager.AppSettings["UrlRideShareWeb"]);

            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            ChromeDriver.Navigate().GoToUrl(BaseUri);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver?.Dispose();
        }

        protected void LoginKevin()
        {
            var emailTextBox = ChromeDriver.FindElementById("username");
            emailTextBox.Clear();
            emailTextBox.SendKeys("Kevin");

            var passwordTextBox = ChromeDriver.FindElementById("password");
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("secret");

            var logInElement = ChromeDriver.FindElementByClassName("btn-primary");
            logInElement.Click();
        }
    }
}