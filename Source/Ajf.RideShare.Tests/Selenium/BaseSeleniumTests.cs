using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Ajf.RideShare.Tests.Selenium
{
    public class BaseSeleniumTests
    {
        public RemoteWebDriver ChromeDriver { get; set; }

        public Uri BaseUri { get; set; }

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