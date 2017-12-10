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

                //ChromeDriver.FindElement(By.Id("addEvent")).Click();

                //Assert.AreEqual("RideShare - Tilføj en samkørsel", ChromeDriver.Title);
            });
        }
    }
}