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
                //LoginKevin();

                //Assert.AreEqual("RideShare", ChromeDriver.Title);

                ChromeDriver.FindElement(By.Id("addEvent")).Click();

                Assert.AreEqual("RideShare", ChromeDriver.Title);
            });
        }
    }
}