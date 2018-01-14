﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using Ajf.RideShare.Api;
using Ajf.RideShare.Models;
using NUnit.Framework;

namespace Ajf.RideShare.Tests.DbBasedTests
{
    public class TestInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
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

            AutoMapperInitializor.Init();
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
            Debug.WriteLine("Tore down test db: " + DbName);
        }

        protected string ConnectionString;
        protected string DbName;
    }
}