using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using Ajf.RideShare.Api;
using Ajf.RideShare.Models;
using Ajf.RideShare.Tests.DbBasedTests;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.Base
{
    [TestFixture]
    public abstract class IntegrationTestBase
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Database.SetInitializer(new TestInitializer());

            _dbName = "RideShare.Test." + Environment.MachineName + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss");

            ConnectionString = $"Server=JuulServer2017;Database={_dbName};User Id=rideshare;Password=rideshare";
            DbContext = new ApplicationDbContext {Database = {Connection = {ConnectionString = ConnectionString}}};
            DbContext.Database.Initialize(true);

            AutoMapperInitializor.Init();
        }

        public ApplicationDbContext DbContext { get; set; }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TearDownDatabase();
        }

        private void TearDownDatabase()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                con.ChangeDatabase("master");
                new SqlCommand(@"ALTER DATABASE [" + _dbName + @"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
                        con)
                    .ExecuteNonQuery();
                new SqlCommand(@"DROP DATABASE [" + _dbName + "]",
                        con)
                    .ExecuteNonQuery();
            }

            Debug.WriteLine("Tore down test db: " + _dbName);
        }

        protected string ConnectionString;
        private string _dbName;
    }
}