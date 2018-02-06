using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log;

namespace ShopTool
{
    public partial class FormDone : Form
    {
        private string browserProcessName = "CefSharp.BrowserSubprocess";
        private string thisProcessName = "ShopTool";

        public string UploadResultMessage { get; set; }

        public FormDone()
        {
            InitializeComponent();
        }

        private void FormDone_Load(object sender, EventArgs e)
        {
            this.label2.Text = UploadResultMessage;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            KillBrowserProcess(browserProcessName);
            KillBrowserProcess(thisProcessName);
            this.Close();
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void KillBrowserProcess(string name)
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
    }
}
