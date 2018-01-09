using NUnit.Framework;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    [TestFixture]
    [Category("Database")]
    public class IntegrationTestBaseImpl : IntegrationTestBase
    {
        [Test]
        public void ThatDatabaseCanBeCreatedAndDeleted()
        {
        }
    }
}