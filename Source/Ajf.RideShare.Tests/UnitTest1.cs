using Ajf.RideShare.Web.Services;
using NUnit.Framework;

namespace Ajf.RideShare.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        //[Category("Selenium")]
        public void TestMethod2()
        {
            var eventService = new EventService(null);
            Assert.Pass("This is good");
        }
    }
}