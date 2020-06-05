using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace TestSerilog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Write Logs to Sql Server 

            //var connectionString = "Server=localhost;Initial Catalog = CommanderDB;User ID =CommanderApi;Password=CommanderApi;";
            //var logger = new LoggerConfiguration()
            //                .MinimumLevel.Verbose()
            //                .WriteTo.MSSqlServer(
            //                  connectionString: connectionString,
            //                  sinkOptions: new SinkOptions { TableName = "Log" })
            //                .CreateLogger();

            //logger.Information("Starting writing logs to Sql Server"); 


            // Write Logs to Oracle Server
            var connectionString =
              "user id=system;password=Adiva@2020;data source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA=(SERVICE_NAME = xe)))";

            var logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .WriteTo.Oracle(cfg => cfg.WithSettings(connectionString, "Log")
                            .UseBurstBatch()
                            .CreateSink())
                            .CreateLogger();
            logger.Information("Start writing logs to Oracle Server");

        }
    }
}
