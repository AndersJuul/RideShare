using Ajf.RideShare.Api.DependencyResolution;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.UnitTests
{
    [TestFixture]
    public class IocTest
    {
        [Test]
        public void ThatConfigurationIsValid()
        {
            var container = IoC.Initialize();
            container.AssertConfigurationIsValid();
        }
    }
}