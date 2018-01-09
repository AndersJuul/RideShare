using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using Ajf.RideShare.Models;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class TestInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        //protected override void Seed(TestContext context)
        //{
        //    //context.Customers.AddOrUpdate(
        //    //    c => c.Id,
        //    //    new Customer { Name = "Customer 1" },
        //    //    new Customer { Name = "Customer 2" });

        //    base.Seed(context);
        //}
    }
    [TestFixture]
    public abstract class IntegrationTestBase
    {
        [SetUp]
        public void Setup()
        {
            Database.SetInitializer(new TestInitializer());

            DbName = "RideShare.Test." + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss");
            ConnectionString = $"Server=JuulServer2017;Database={DbName};User Id=rideshare;Password=rideshare";
            DbContext = new ApplicationDbContext(){Database = { Connection = { ConnectionString = ConnectionString } } };
            DbContext.Database.Initialize(true);

            //DbName = "RideShare.Test." + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss");

            //Debug.WriteLine("Creating test db: " + DbName);

            //ConnectionString = $"Server=JuulServer2017;Database={DbName};User Id=rideshare;Password=rideshare";

            //var settings = new Configuration();
            //var migrator = new DbMigrator(settings);
            //settings.TargetDatabase=new DbConnectionInfo(ConnectionString,"System.Data.SqlClient");
            //var migrateDatabaseToLatestVersion = new MigrateDatabaseToLatestVersion<ApplicationDbContext,Configuration>();
            //var applicationDbContext = new ApplicationDbContext();
            //migrateDatabaseToLatestVersion.InitializeDatabase(applicationDbContext);
            //migrator.Update();
        }

        public ApplicationDbContext DbContext { get; set; }

        [TearDown]
        public void TearDown()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                con.ChangeDatabase("master");
                new SqlCommand(@"ALTER DATABASE [" + DbName + @"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
                    con)
                    .ExecuteNonQuery();
                new SqlCommand(@"DROP DATABASE [" + DbName + "]",
                    con)
                    .ExecuteNonQuery();
            }
            Debug.WriteLine("Creating test db: " + DbName);
        }

        protected string ConnectionString;
        protected string DbName;
    }
}