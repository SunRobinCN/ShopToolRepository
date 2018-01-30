using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ShopTool.Comm;
using ShopTool.Model;

namespace ShopTool
{
    public partial class FormExecute : Form
    {
        public static string Url = "https://shoppies.jp/write-item_sp";

        public Product product { get; set; }

        public FormExecute()
        {
            InitializeComponent();
        }



        void OnLoadEnd(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            string jscript = "";
            CefSharp.FrameLoadEndEventArgs p = e as CefSharp.FrameLoadEndEventArgs;
            if (p != null)
            {
                if ((p.Url == "https://shoppies.jp/write-item_sp"))
                {
                    jscript = "$('#changeLogin').click();" +
                              "$(\"input[name=\'loginid\']\").val(\'outam1984@yahoo.co.jp\');" +
                              "$(\"input[name=\'password\']\").val(\'X8u813\');";
                    browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    Thread.Sleep(10000);
                    jscript = "$(\"input[name=\'loginbtn\']\").click();";
                    browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                }
                if (p.Url == "https://shoppies.jp/?jb=write-item_sp")
                {
                    jscript = $"$(\'#picUrl0\').val(\'{product.PictureUrls[0]}\');" +
                              $"$(\'#picUrl1\').val(\'{product.PictureUrls[1]}\');" +
                              $"$(\'#picUrl2\').val(\'{product.PictureUrls[2]}\');" +
                              $"$(\'#picUrl3\').val(\'{product.PictureUrls[3]}\');";
                    browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    jscript = $"$(\'#inputPrice\').val(\'{product.Price}\');" +
                              $"$(\'#titleInput\').val(\'{product.Name}\');" +
                              $"$(\'#explanation\').val(\'{product.Description}\');";
                    browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                }
            }
            
            
        }

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (sender is ChromiumWebBrowser browser && browser.IsBrowserInitialized)
            {
                browser.Load(Url);
                browser.ShowDevTools();
            }
        }

        private void FormExecute_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings();
            CefSharp.Cef.Initialize(settings);
            ChromiumWebBrowser browser = new ChromiumWebBrowser("")
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill
            };
            this.Controls.Add(browser);
            browser.IsBrowserInitializedChanged += new EventHandler<IsBrowserInitializedChangedEventArgs>(OnIsBrowserInitializedChanged);
            browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(OnLoadEnd);
            browser.RequestHandler = new MyRequestHandler();
        }

        private void FormExecute_Shown(object sender, EventArgs e)
        {
        }
    }
}
