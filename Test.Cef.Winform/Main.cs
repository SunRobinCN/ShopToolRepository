using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Test.Cef.Winform
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (CefSharp.Cef.IsInitialized == false)
            {
                var settings = new CefSettings();
                CefSharp.Cef.Initialize(settings);
            }
            ChromiumWebBrowser browser = new ChromiumWebBrowser("")
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(browser);
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.FrameLoadEnd += OnFrameLoadEnd;
            browser.LoadError += OnLoadError;
            browser.ConsoleMessage += OnConsoleMessage;
            //browser.RequestHandler = new MyRequestHandler();
            //browser.JsDialogHandler = new JsDialogHandler();
        }

        void OnFrameLoadEnd(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            //    string jscript = "";
            //    if (e is FrameLoadEndEventArgs p)
            //    {
            //        if ((p.Url == "https://shoppies.jp/write-item_sp"))
            //        {
            //            jscript = "";
            //            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);

            //            Task<CefSharp.JavascriptResponse> task = browser.EvaluateScriptAsync("$(\"#changeLogin\").length;");
            //            // 等待js 方法执行完后，获取返回值
            //            Task.WaitAll(task);
            //            // t.Result 是 CefSharp.JavascriptResponse 对象
            //            // t.Result.Result 是一个 object 对象，来自js的 callTest2() 方法的返回值
            //            if (task.Result.Result != null)
            //            {
            //                int i = Convert.ToInt32(task.Result.Result);
            //                MessageBox.Show(task.Result.Result.ToString());
            //            }
            //        }
            //    }
            //});
        }

        void OnLoadError(object sender, LoadErrorEventArgs e)
        {
            MessageBox.Show("OnLoadError!");
        }

        void OnConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
        }

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (sender is ChromiumWebBrowser browser && browser.IsBrowserInitialized)
            {
                browser.Load("https://www.baidu.com");
                //browser.ShowDevTools();
            }
        }
    }
}
