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
using Log;
using ShopTool.Comm;
using ShopTool.Model;

namespace ShopTool
{
    public partial class FormExecute : Form
    {
        public const int INTERVAL = 500;

        public Product Product { get; set; }
        public bool Failed { get; set; }

        public FormExecute()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //this.myTransparentPanel.Hide();
        }

        private void FormExecute_Load(object sender, EventArgs e)
        {
            if (Cef.IsInitialized == false)
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
            browser.RequestHandler = new MyRequestHandler();
            browser.JsDialogHandler = new JsDialogHandler();
        }

        void OnFrameLoadEnd(object sender, EventArgs e)
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
                        //这里根据是否登录了，执行两种情况
                        Task<CefSharp.JavascriptResponse> task = browser.EvaluateScriptAsync("$(\"#changeLogin\").length;");
                        Task.WaitAll(task);
                        if (task.Result.Result != null && Convert.ToInt32(task.Result.Result) > 0)
                        {
                            jscript = "$('#changeLogin').click();" +
                                      "$(\"input[name=\'loginid\']\").val(\'outam1984@yahoo.co.jp\');" +
                                      "$(\"input[name=\'password\']\").val(\'X8u813\');";
                            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                            Thread.Sleep(INTERVAL);
                            jscript = "$(\"input[name=\'loginbtn\']\").click();";
                            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        }
                        else
                        {
                            Execute(browser);
                        }
                    }
                    if (p.Url == "https://shoppies.jp/?jb=write-item_sp")
                    {
                        Execute(browser);
                    }
                    if (p.Url == "https://shoppies.jp/write-item_conf")
                    {
                        Thread.Sleep(INTERVAL * 5);
                        jscript = "$(\'.gbl-submitBtnMini\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                    }
                    if (p.Url.EndsWith("b=write-item_end"))
                    {
                        Product.UploadResult = "Success!";
                        Product.UploaDateTime = DateTime.Now;
                        TextUtil.ArchiveProduct(Product);
                        Thread.Sleep(INTERVAL * 6);
                        jscript = "$(\"#prof_header > a\").last().click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL * 16);
                        browser?.Dispose();
                        this.Close();
                        this.Dispose();
                    }
                }
            });
        }

        private void Execute(ChromiumWebBrowser browser)
        {
            string jscript;
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

            jscript = "$(\'.writeItemCategory .tempArrowLink\').click();";
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
            jscript = "$(\"#mCSB_1_container .tempArrowLink\").eq(0).click();";
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
            jscript = string.Format(
                "$(\"#mCSB_2_container .tempLinkWrap.subCategory >  .tempArrowLink.cateLinks.categoryInput2.noArrow\").eq({0}).click();",
                Product.CategoryDetailInfo.LevelTwoID);
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
            jscript = string.Format("$(\"nav [alt = \'{0}\']\").click();",
                Product.CategoryDetailInfo.LevelThreeID);
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
            Thread.Sleep(INTERVAL);


            jscript = string.Format("$(\'.writeItemStatus .tempArrowLink\').click();");
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
            Thread.Sleep(INTERVAL);
            jscript = string.Format("$(\'#{0}\').click();", Product.Status.ID);
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
            Thread.Sleep(INTERVAL * 3);
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
            Thread.Sleep(INTERVAL * 5);


            jscript = "$(\'#tes\').click();";
            browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
        }

        void OnFrameLoadEnd2(object sender, EventArgs e)
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

                        Task<CefSharp.JavascriptResponse> task = browser.EvaluateScriptAsync("$(\"#changeLogin\").length;");
                        // 等待js 方法执行完后，获取返回值
                        Task.WaitAll(task);
                        // t.Result 是 CefSharp.JavascriptResponse 对象
                        // t.Result.Result 是一个 object 对象，来自js的 callTest2() 方法的返回值
                        if (task.Result.Result != null)
                        {
                            int i = Convert.ToInt32(task.Result.Result);
                            MessageBox.Show(task.Result.Result.ToString());
                        }


                    }
                }
            });
        }

        void OnLoadError(object sender, LoadErrorEventArgs e)
        {
            FileLog.Error("OnLoadError", new Exception(e.ErrorText), LogType.Error);
        }

        void OnConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            if (e.Message.Contains("Uncaught") && (e.Message.Contains("modori") == false)
                && (e.Message.Contains("setPostLink") == false))
            {
                Product.UploadResult = "Failed";
                Product.UploadFailedReson = e.Message;
                Product.UploaDateTime = DateTime.Now;
                TextUtil.ArchiveProduct(Product);
                FileLog.Error("OnConsoleMessage", new Exception(e.Message + "\r\n" + e.Source), LogType.Error);
                ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
                browser?.Dispose();
                this.Dispose();
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

        private void myTransparentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
