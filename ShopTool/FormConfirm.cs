using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ShopTool.Comm;
using ShopTool.Model;


namespace ShopTool
{
    public partial class FormConfirm : Form
    {
        public List<OneUserBatch> Batches { get; set; }

        public FormConfirm()
        {
            InitializeComponent();
        }

        private void btnUploadProduct_Click(object sender, EventArgs e)
        {
            
        }

        private void InitializeBatchesInfo()
        {
            foreach (OneUserBatch oneUserBatch in Batches)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(oneUserBatch.Username + ":");
                foreach (Product product in oneUserBatch.Products)
                {
                    this.rtxtConfirmInfo.AppendText("产品名称：" + product.Name);
                    Bitmap bmp = new Bitmap(product.Pictures[0]);
                    var obj = Clipboard.GetDataObject();
                    Clipboard.SetDataObject(bmp);
                    DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (rtxtConfirmInfo.CanPaste(format))
                        rtxtConfirmInfo.Paste();
                    Clipboard.SetDataObject(obj);
                }
                
            }
        }

        private void FormConfirm_Load(object sender, EventArgs e)
        {
            InitializeBatchesInfo();
        }

        private string test()
        {
            List<OneUserBatch> batches = new List<OneUserBatch>();
            OneUserBatch batch = new OneUserBatch()
            {
                Username = "outam1984@yahoo.co.jp",
                Password = "X8u813"
            };
            Product product = new Product();
            batches.Add(batch);
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
            product.LogisticWay = new Info()
            {
                ID = "1",
                Name = ""
            };
            product.LogisticDay = new Info()
            {
                ID = "0",
                Name = ""
            };

            System.Drawing.Image image = Image.FromFile(@"C:\Users\robin.sun\Desktop\t.jpg");
            product.Pictures.Add(image);
            product.Pictures.Add(image.Clone() as Image);
            product.Pictures.Add(image.Clone() as Image);
            product.Pictures.Add(image.Clone() as Image);
            return HttpUtil.UploadBatchesToWebsite(batches);
        }
    }
}
