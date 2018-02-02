using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ShopTool.Comm;
using ShopTool.Model;

namespace ShopTool
{
    public partial class FormExecute : Form
    {
        public const int INTERVAL = 5000;

        public Product Product { get; set; }
        public bool Failed { get; set; }

        public FormExecute()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            this.myTransparentPanel.BackColor = Color.FromArgb(25, Color.Black);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        }

        private void FormExecute_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings();
            CefSharp.Cef.Initialize(settings);
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
            browser.RequestHandler = new MyRequestHandler();
            browser.JsDialogHandler = new JsDialogHandler();
        }

        void OnFrameLoadEnd2(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
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
                        Thread.Sleep(INTERVAL);
                        jscript = "$(\"input[name=\'loginbtn\']\").click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    }
                    if (p.Url == "https://shoppies.jp/?jb=write-item_sp")
                    {
                        jscript = $"$(\'#picUrl0\').val(\'{Product.PictureUrls[0]}\');" +
                                  $"$(\'#picUrl1\').val(\'{Product.PictureUrls[1]}\');" +
                                  $"$(\'#picUrl2\').val(\'{Product.PictureUrls[2]}\');" +
                                  $"$(\'#picUrl3\').val(\'{Product.PictureUrls[3]}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);

                        jscript = $"$(\'#inputPrice\').val(\'{Product.Price}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = $"$(\'#titleInput\').val(\'{Product.Name}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = $"$(\'#explanation\').val(\'{Product.Description}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = "$(\'.writeItemCategory .tempArrowLink\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = "$(\"#mCSB_1_container .tempArrowLink\").eq(0).click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format(
                            "$(\"#mCSB_2_container .tempLinkWrap.subCategory >  .tempArrowLink.cateLinks.categoryInput2.noArrow\").eq({0}).click();",
                            Product.CategoryDetailInfo.LevelTwo);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\"nav [alt = \'{0}\']\").click();",
                            Product.CategoryDetailInfo.LevelThree);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'.writeItemStatus .tempArrowLink\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\'#{0}\').click();",Product.Status.ID);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'.writeItemCarry .tempArrowLink\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = $"$(\'#{Product.LogisticLiao.ID}\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        StringBuilder builder = new StringBuilder();
                        builder.Append("$(\'.writeItemSendMethod .tempArrowLink\').click();");
                        foreach (Info info in Product.LogisticWay)
                        {
                            string s = string.Format("$(\'#{0}\').click();", info.ID);
                            builder.Append(s);
                        }
                        jscript = builder.ToString();
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL*3);
                        jscript = "$(\'#sendMethodFin\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'#areaChoice\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\'#{0}\').click();", Product.Area.ID);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'#sendDateChoice\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\'#{0}\').click();", Product.LogisticDay.ID);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL*5);


                        jscript = "$(\'#tes\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    }
                    if (p.Url == "https://shoppies.jp/write-item_conf")
                    {
                        Thread.Sleep(INTERVAL * 5);
                        jscript = "$(\'.gbl-submitBtnMini\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    }
                    if (p.Url.EndsWith("b=write-item_end"))
                    {
                        Thread.Sleep(INTERVAL * 6);
                        browser?.Dispose();
                        this.Close();
                        this.Dispose();
                    }
                }
            });
        }

        void OnFrameLoadEnd(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
                string jscript = "";
                if (e is FrameLoadEndEventArgs p)
                {
                    if ((p.Url == "https://shoppies.jp/write-item_sp"))
                    {
                        jscript = "";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    }
                }
            });
        }

        void OnLoadError(object sender, EventArgs e)
        {
            
        }

        void OnConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Debug.WriteLine(e.Message);
            if (e.Message.Contains("Uncaught"))
            {
                //Product.UploadResult = "Failed";
                //Product.UploadFailedReson = e.Message;
                ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
                browser?.Dispose();
            }
        }

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (sender is ChromiumWebBrowser browser && browser.IsBrowserInitialized)
            {
                browser.Load("https://shoppies.jp/write-item_sp");
                browser.ShowDevTools();
            }
        }

    }
}
