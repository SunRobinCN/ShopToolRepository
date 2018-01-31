using System;
using System.Collections.Generic;
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

        public Product product { get; set; }

        public FormExecute()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }



        void OnLoadEnd(object sender, EventArgs e)
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
                        jscript = $"$(\'#picUrl0\').val(\'{product.PictureUrls[0]}\');" +
                                  $"$(\'#picUrl1\').val(\'{product.PictureUrls[1]}\');" +
                                  $"$(\'#picUrl2\').val(\'{product.PictureUrls[2]}\');" +
                                  $"$(\'#picUrl3\').val(\'{product.PictureUrls[3]}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);

                        jscript = $"$(\'#inputPrice\').val(\'{product.Price}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = $"$(\'#titleInput\').val(\'{product.Name}\');";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = $"$(\'#explanation\').val(\'{product.Description}\');";
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
                            product.CategoryDetailInfo.LevelTwo);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\"nav [alt = \'{0}\']\").click();",
                            product.CategoryDetailInfo.LevelThree);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'.writeItemStatus .tempArrowLink\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\'#{0}\').click();",product.Status.ID);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'.writeItemCarry .tempArrowLink\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = $"$(\'#{product.LogisticLiao.ID}\').click();";
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        StringBuilder builder = new StringBuilder();
                        builder.Append("$(\'.writeItemSendMethod .tempArrowLink\').click();");
                        foreach (Info info in product.LogisticWay)
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
                        jscript = string.Format("$(\'#{0}\').click();", product.Area.ID);
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);


                        jscript = string.Format("$(\'#sendDateChoice\').click();");
                        browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);
                        Thread.Sleep(INTERVAL);
                        jscript = string.Format("$(\'#{0}\').click();", product.LogisticDay.ID);
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

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (sender is ChromiumWebBrowser browser && browser.IsBrowserInitialized)
            {
                browser.Load("https://shoppies.jp/write-item_sp");
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
    }
}
