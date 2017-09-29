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
            BaseUri = new Uri(ConfigurationManager.AppSettings["urlRideShareWeb"]);

            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Navigate().GoToUrl(BaseUri);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver?.Dispose();
        }

        protected void LoginFrank()
        {
            var emailTextBox = ChromeDriver.FindElementById("Email");
            emailTextBox.Clear();
            emailTextBox.SendKeys("frank@email.dk");

            var passwordTextBox = ChromeDriver.FindElementById("Password");
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("Frank1");

            var logInElement = ChromeDriver.FindElementById("LogIn");
            logInElement.Click();
        }
    }
}