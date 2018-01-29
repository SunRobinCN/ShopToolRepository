using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
                    foreach (Image image in product.Pictures)
                    {
                        AddImage(image);
                    }
                    this.rtxtConfirmInfo.AppendText("\r\n");
                    this.rtxtConfirmInfo.AppendText("产品名称：" + product.Name);
                    
                }
            }
            this.rtxtConfirmInfo.ReadOnly = true;
        }

        private void AddImage(Image picture)
        {
            Bitmap bmp = new Bitmap(picture);
            double resizeTimes = bmp.Height / 130d;
            Bitmap resizedBmp = GetResizeImage(bmp, resizeTimes);
            var obj = Clipboard.GetDataObject();
            Clipboard.SetDataObject(resizedBmp);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            if (rtxtConfirmInfo.CanPaste(format))
                rtxtConfirmInfo.Paste();
            Clipboard.SetDataObject(obj);
        }

        private Bitmap GetResizeImage(Bitmap bm, double times)
        {
            Bitmap newbm = null;
            try
            {
                int nowWidth = (int)(bm.Width / times);
                int nowHeight = (int)(bm.Height / times);
                newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newbm);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(bm, new System.Drawing.Rectangle(0, 0, nowWidth, nowHeight), new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return newbm;
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

        private void rtxtConfirmInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
