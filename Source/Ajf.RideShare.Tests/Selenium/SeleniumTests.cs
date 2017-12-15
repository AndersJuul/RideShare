using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Ajf.RideShare.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatKevinCanLogin()
        {
            RunTest(() =>
            {
                Assert.AreEqual("RideShare", ChromeDriver.Title);

                ChromeDriver.FindElement(By.Id("addEvent")).Click();
                
                Assert.AreEqual("Ajf Security Token Service", ChromeDriver.Title);

                LoginKevin();

                Assert.AreEqual("RideShare", ChromeDriver.Title);

                var txtDate = ChromeDriver.FindElement(By.Id("txtDate"));
                txtDate.Clear();
                txtDate.SendKeys(DateTime.Now.AddDays(3).ToString("yyyy-MM-dd HH:mm"));

                var txtDescription = ChromeDriver.FindElement(By.Id("txtDescription"));
                txtDescription.Clear();
                txtDescription.SendKeys("Selenium test Description "+  new Random().Next());

                ChromeDriver.FindElement(By.Id("btnSubmit")).Click();
            });
        }
    }
}