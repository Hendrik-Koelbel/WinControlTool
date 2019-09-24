using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControlTool
{
    public static class ServiceHelper
    {
        /// <summary>
        /// Verify if a service exists
        /// </summary>
        /// <param name="ServiceName">Service name</param>
        /// <returns></returns>
        public static bool serviceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }

        /// <summary>
        /// Start a service by it's name
        /// </summary>
        /// <param name="ServiceName"></param>
        public static void startService(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;


            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                // Start the service if the current status is stopped.
                try
                {
                    // Start the service, and wait until its status is "Running".
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);

                    // Display the current service status.
                }
                catch (InvalidOperationException)
                {
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// Stop a service that is active
        /// </summary>
        /// <param name="ServiceName"></param>
        public static void stopService(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status == ServiceControllerStatus.Running)
            {
                // Start the service if the current status is stopped.
                try
                {
                    // Start the service, and wait until its status is "Running".
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);

                    // Display the current service status.
                }
                catch (InvalidOperationException)
                {
                }
            }
            else
            {
            }
        }

        /// <summary>
        ///  Verify if a service is running.
        /// </summary>
        /// <param name="ServiceName"></param>
        public static bool serviceIsRunning(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status == ServiceControllerStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Reboots a service
        /// </summary>
        /// <param name="ServiceName"></param>
        public static void rebootService(string ServiceName)
        {
            if (serviceExists(ServiceName))
            {
                if (serviceIsRunning(ServiceName))
                {
                    stopService(ServiceName);
                }
                else
                {
                    startService(ServiceName);
                }
            }
            else
            {
            }
        }
    }
}
