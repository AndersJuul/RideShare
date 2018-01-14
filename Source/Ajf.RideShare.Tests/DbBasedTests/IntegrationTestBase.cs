using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using Ajf.RideShare.Api;
using Ajf.RideShare.Models;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    [TestFixture]
    public abstract class IntegrationTestBase
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Database.SetInitializer(new TestInitializer());

            DbName = "RideShare.Test."+Environment.MachineName + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss");
            ConnectionString = $"Server=JuulServer2017;Database={DbName};User Id=rideshare;Password=rideshare";
            DbContext = new ApplicationDbContext {Database = { Connection = { ConnectionString = ConnectionString } } };
            DbContext.Database.Initialize(true);


            AutoMapperInitializor.Init();
        }

        public ApplicationDbContext DbContext { get; set; }

        [OneTimeTearDown]
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
            Debug.WriteLine("Tore down test db: " + DbName);
        }

        protected string ConnectionString;
        protected string DbName;
    }
}