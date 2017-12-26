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
                // -------------------
                // Main page
                // -------------------
                Assert.AreEqual("RideShare - Hovedside", ChromeDriver.Title);

                LoginKevin();

                ChromeDriver.FindElement(By.Id("addEvent")).Click();

                // -------------------
                // Create new event page
                // -------------------
                Assert.AreEqual("RideShare - Opret en samkørsel", ChromeDriver.Title);

                var txtDate = ChromeDriver.FindElement(By.Id("txtDate"));
                txtDate.Clear();
                txtDate.SendKeys(DateTime.Now.AddDays(3).ToString("yyyy-MM-dd HH:mm"));

                var txtDescription = ChromeDriver.FindElement(By.Id("txtDescription"));
                txtDescription.Clear();
                txtDescription.SendKeys("Selenium test Description "+  new Random().Next());

                ChromeDriver.FindElement(By.Id("btnSubmit")).Click();

                // -------------------
                // Main page
                // -------------------
                Assert.AreEqual("RideShare - Hovedside", ChromeDriver.Title);

                ChromeDriver.FindElementsById("btnEventDetails").First().Click();

                // -------------------
                // Event details page
                // -------------------
                Assert.AreEqual("RideShare - Vis en samkørsel", ChromeDriver.Title);
            });
        }
    }
}