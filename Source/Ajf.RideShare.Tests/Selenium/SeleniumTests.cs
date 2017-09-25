using NUnit.Framework;

namespace Ajf.RideShare.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatFrankCanLogin()
        {
            LoginFrank();

            Assert.AreEqual("Hovedside - Samkørsel", ChromeDriver.Title);
        }
    }
}