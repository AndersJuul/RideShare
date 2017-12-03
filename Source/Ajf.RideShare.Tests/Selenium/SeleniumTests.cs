using NUnit.Framework;

namespace Ajf.RideShare.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatKevinCanLogin()
        {
            LoginKevin();

            Assert.AreEqual("RideShare", ChromeDriver.Title);
        }
    }
}