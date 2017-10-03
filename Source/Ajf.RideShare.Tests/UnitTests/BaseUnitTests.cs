using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests
{
    public class BaseUnitTests
    {
        protected Fixture _fixture;

        [SetUp]
        public virtual void SetUp()
        {
            _fixture = new Fixture();
        }
    }
}