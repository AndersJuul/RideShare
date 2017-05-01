using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace Ajf.RideShare.Web.Migrations
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["DatabaseConnection"];
            //var connectionString = @"Server=ANDERS2014\SQLEXPRESS;Database=RideShare-localdev;Trusted_Connection=True;";

            var upgradeEngine = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            Debug.WriteLine(upgradeEngine);

            var result = upgradeEngine.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return 1;
            }

            return 0;
        }
    }
}
