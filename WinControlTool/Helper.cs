using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControlTool
{
    internal static class Helper
    {
        public static bool ExecuteAndReport(Action job)
        {
            try
            {
                job();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}