using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;

namespace ShopTool.Comm
{
    public static class ShutDownUtil
    {
        public static void KillBrowserProcess(string name)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (p.ProcessName == name)
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                FileLog.Error("KillBrowserProcess", ex, LogType.Error);
            }
        }

        public static void ShutDown()
        {
            string browserProcessName = "CefSharp.BrowserSubprocess";
            string thisProcessName = "ShopTool";

            ShutDownUtil.KillBrowserProcess(browserProcessName);
            ShutDownUtil.KillBrowserProcess(thisProcessName);
            FileLog.Info("ShutDown done!", LogType.Info);
        }
    }
}
