using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Ajf.RideShare.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatKevinCanLoginAndDoStuff()
        {
            RunTest(() =>
            {
                Assert.AreEqual("RideShare - Index", ChromeDriver.Title);

                LoginKevin();

                ChromeDriver.FindElement(By.Id("addEvent")).Click();

                Assert.AreEqual("RideShare - Opret en samkørsel", ChromeDriver.Title);

                var txtDate = ChromeDriver.FindElement(By.Id("txtDate"));
                txtDate.Clear();
                txtDate.SendKeys(DateTime.Now.AddDays(3).ToString("yyyy-MM-dd HH:mm"));

                var txtDescription = ChromeDriver.FindElement(By.Id("txtDescription"));
                txtDescription.Clear();
                txtDescription.SendKeys("Selenium test Description "+  new Random().Next());

                ChromeDriver.FindElement(By.Id("btnSubmit")).Click();

                Assert.AreEqual("RideShare - Index", ChromeDriver.Title);

                ChromeDriver.FindElementsById("btnEditEvent").First().Click();

                Assert.AreEqual("RideShare - Rediger en samkørsel", ChromeDriver.Title);
            });
        }
    }
}