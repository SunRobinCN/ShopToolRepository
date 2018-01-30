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
            FormExecute formExecute = new FormExecute();
            formExecute.Batches = this.Batches;
            formExecute.Show();
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
                    this.rtxtConfirmInfo.AppendText("商品名：" + product.Name + "\r\n");
                    this.rtxtConfirmInfo.AppendText("商品説明：" + product.Description + "\r\n");
                    this.rtxtConfirmInfo.AppendText("カテゴリ：" + (product).Category.Name + "\r\n");
                    this.rtxtConfirmInfo.AppendText("状態：" + product.Status.Name + "\r\n");
                    this.rtxtConfirmInfo.AppendText("配送料：" + product.LogisticLiao.Name + "\r\n");
                    this.rtxtConfirmInfo.AppendText("配送方法：" + product.FinalLogisticWay + "\r\n");
                    this.rtxtConfirmInfo.AppendText("出品地域：" + product.Area.Name + "\r\n"); 
                    this.rtxtConfirmInfo.AppendText("発送日の目安：" + product.LogisticDay.Name + "\r\n");
                }
            }
            this.rtxtConfirmInfo.ReadOnly = true;
        }

        private void AddImage(Image picture)
        {
            Bitmap bmp = new Bitmap(picture);
            double resizeTimes = bmp.Height / 110d;
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
    }
}
