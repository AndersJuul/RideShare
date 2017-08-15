using System.Data.Entity.Migrations;
using Ajf.RideShare.Models.Migrations;

namespace Ajf.RideShare.Migrate
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Configuration(){};
            var migrator = new DbMigrator(settings);
            migrator.Update();
        }
    }
}
