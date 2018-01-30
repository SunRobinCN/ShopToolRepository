using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            //string r = GetContent();
            ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            if (browser.IsBrowserInitialized)
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

                var mngr = Cef.GetGlobalCookieManager();
                Cookie Ac = new Cookie();
                Ac.Name = "ss";
                Ac.Value = "xxxxxxxxxxx";
                Task<bool>  a =mngr.SetCookieAsync("https://shoppies.jp", Ac);
                Task.WaitAll(a);
                browser.ShowDevTools();
                //browser.LoadHtml(r, "https://shoppies.jp/");
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
            //browser.ShowDevTools();
            //the url parameter does not have to be an existing address.
            //browser.LoadHtml(r, "https://shoppies.jp/");
            browser.IsBrowserInitializedChanged += new EventHandler<IsBrowserInitializedChangedEventArgs>(OnIsBrowserInitializedChanged);
            browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(OnLoadEnd);
            browser.RequestHandler = new MyRequestHandler();
        }

        private string GetContent()
        {
            OneUserBatch batch = new OneUserBatch()
            {
                Username = "outam1984@yahoo.co.jp",
                Password = "X8u813"
            };
            Product product = new Product();
            batch.Products.Add(product);

            product.Name = "test12";
            product.Description = "test1 desc";
            product.Price = "3333";
            product.Area = new Info()
            {
                Name = "秋田県"
            };
            product.Category = new ConnectedComboInfo()
            {
                ID = "9105",
                Name = "ゲーム"
            };
            product.Status = new Info()
            {
                ID = "6",
                Name = ""
            };
            product.LogisticLiao = new Info()
            {
                ID = "1",
                Name = ""
            };
            product.LogisticDay = new Info()
            {
                ID = "0",
                Name = ""
            };

            System.Drawing.Image image = Image.FromFile(@"C:\Users\Administrator\Desktop\t.jpg");
            product.Pictures.Add(image);
            product.Pictures.Add(image.Clone() as Image);
            product.Pictures.Add(image.Clone() as Image);
            product.Pictures.Add(image.Clone() as Image);
            string r = "";
            HttpUtil.LoginToShopWebsite(batch.Username, batch.Password);
            foreach (Product p in batch.Products)
            {
                List<string> uploadPicturesResult = HttpUtil.UploadPictureToWebsite(p.Pictures);
                product.PictureUrls = uploadPicturesResult;
                r = HttpUtil.ConfirmInformationWithWebsite(p);
            }
            return r;
        }
    }
}
