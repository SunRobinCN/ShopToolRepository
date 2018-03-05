using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProcesses
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    FileLog.Info(p.ProcessName, LogType.Info);
                }
            }
            catch (Exception ex)
            {
                FileLog.Error("KillBrowserProcess", ex, LogType.Error);
            }
        }
    }
}
