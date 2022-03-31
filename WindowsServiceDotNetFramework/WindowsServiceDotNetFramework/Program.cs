using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDotNetFramework
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            #if (DEBUG == true)
            var service = new LoggingService();
            service.BatchJob();

            #endif
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LoggingService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
