using System.Data.Entity;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class TestInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
    }
}