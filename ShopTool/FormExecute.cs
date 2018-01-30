using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<OneUserBatch> Batches { get; set; }

        public FormExecute()
        {
            InitializeComponent();
        }



        void OnLoadEnd(object sender, EventArgs e)
        {
            //ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            ////string jscript = "$(\'#id_sams_login_login_accountName\').val(\'robin.sun\');";
            //string jscript = "$('#changeLogin').click()";
            //browser.GetMainFrame().ExecuteJavaScriptAsync(jscript);

        }

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs args)
        {
            if (sender is ChromiumWebBrowser browser && browser.IsBrowserInitialized)
            {
                browser.Load(Url);
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
            foreach (OneUserBatch oneUserBatch in this.Batches)
            {
                HttpUtil.LoginToShopWebsite(oneUserBatch.Username, oneUserBatch.Password);
                foreach (Product product in oneUserBatch.Products)
                {
                    List<string> uploadPicturesResult = HttpUtil.UploadPictureToWebsite(product.Pictures);
                    product.PictureUrls = uploadPicturesResult;
                }
            }
        }
    }
}
