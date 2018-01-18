using Highway.Data;
using Ploeh.AutoFixture;

namespace Ajf.RideShare.Tests.UnitTests.Contexts
{
    public abstract class ServiceContext
    {
        protected ServiceContext(Fixture fixture, IRepository repository)
        {
            Fixture = fixture;
            Repository = repository;
        }

        public IRepository Repository { get; }
        public Fixture Fixture { get;  }
    }
}