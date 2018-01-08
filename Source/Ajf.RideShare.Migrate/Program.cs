using System;
using System.Data.Entity.Migrations;
using Ajf.Nuget.Logging;
using Serilog;

namespace Ajf.RideShare.Migrate
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = StandardLoggerConfigurator.GetEnrichedLogger();
            Log.Logger.Information("Starting migration...");

            try
            {
                var settings = new Configuration();
                var migrator = new DbMigrator(settings);

                foreach (var pendingMigration in migrator.GetPendingMigrations())
                {
                    Log.Logger.Debug("Pending migration: " + pendingMigration);
                }

                migrator.Update();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e,"Error during migration");
                throw;
            }
            Log.Logger.Information("Migration done without problems...");
        }
    }
}
