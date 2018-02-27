using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log;
using ShopTool.Comm;
using ShopTool.Model;


namespace ShopTool
{
    public partial class FormConfirm : Form
    {
        public List<Product> Products { get; set; }
        public FormDone FormDoneInfo { get; set; }

        public FormConfirm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            FormDoneInfo = new FormDone();
            this.Closed += CloseApplicaiton;
        }

        private void btnUploadProduct_Click(object sender, EventArgs e)
        {
            this.btnUpload.Text = "正在上传中...";
            this.btnUpload.Enabled = false;
            //foreach (Product product in Products)
            //{
            //    this.ShowExecute(product);
            //}

            foreach (Product product in Products)
            {
                FormExecute formExecute = new FormExecute { Product = product };
                formExecute.ShowDialog();
                Thread.Sleep(1000*1);
            }

            Task.Factory.StartNew(() =>
            {
                bool singal = true;
                while (singal)
                {
                    if (CheckWhetherAllProductsUploaded() == true)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (Product product in Products)
                        {
                            builder.AppendLine("Username: " + product.Username + ", Product: " + product.Name +
                                               ", Result: " +
                                               product.UploadResult + "\r\n");
                        }
                        FormDoneInfo.UploadResultMessage = builder.ToString();

                        MethodInvoker mi = new MethodInvoker(this.ShowResult);
                        this.BeginInvoke(mi);
                        singal = false;
                        //this.Hide();
                    }
                    else
                    {
                        Thread.Sleep(1000 * 10);
                    }
                }
            });
        }

        private void ShowResult()
        {
            FormDoneInfo.ShowDialog();
        }

        private void ShowExecute(Product product)
        {
            FormExecute formExecute = new FormExecute { Product = product };
            formExecute.Show();
        }

        private bool CheckWhetherAllProductsUploaded()
        {
            bool result = true;
            foreach (Product product in Products)
            {
                if (string.IsNullOrEmpty(product.UploadResult))
                {
                    result = false;
                }
            }
            return result;
        }

        private void InitializeBatchesInfo()
        {
            foreach (Product product in Products)
            {
                foreach (Image image in product.Pictures)
                {
                    AddImage(image);
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(product.Username + ":");
                this.rtxtConfirmInfo.AppendText("\r\n");
                this.rtxtConfirmInfo.AppendText("用户名：" + product.Username + "\r\n");
                this.rtxtConfirmInfo.AppendText("商品名：" + product.Name + "\r\n");
                this.rtxtConfirmInfo.AppendText("商品説明：\r\n" + product.Description + "\r\n");
                this.rtxtConfirmInfo.AppendText("カテゴリ：" + (product).CategoryDetailInfo.ToString() + "\r\n");
                this.rtxtConfirmInfo.AppendText("状態：" + product.Status.Name + "\r\n");
                this.rtxtConfirmInfo.AppendText("配送料：" + product.LogisticLiao.Name + "\r\n");
                this.rtxtConfirmInfo.AppendText("配送方法：" + product.FinalLogisticWay + "\r\n");
                this.rtxtConfirmInfo.AppendText("出品地域：" + product.Area.Name + "\r\n");
                this.rtxtConfirmInfo.AppendText("発送日の目安：" + product.LogisticDay.Name + "\r\n");
                this.rtxtConfirmInfo.AppendText("\r\n\r\n");
            }
            this.rtxtConfirmInfo.ReadOnly = true;
            rtxtConfirmInfo.Select(0, 0);
        }

        private void AddImage(Image picture)
        {
            Bitmap bmp = new Bitmap(picture);
            double resizeTimes = bmp.Height / 110d;
            Bitmap resizedBmp = GetResizeImage(bmp, resizeTimes);
            //var obj = Clipboard.GetDataObject();
            //Clipboard.SetDataObject(resizedBmp);
            DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            rtxtConfirmInfo.InsertImage(resizedBmp);
            if (rtxtConfirmInfo.CanPaste(format))
            {
            }
            //Clipboard.SetDataObject(obj);
        }

        private Bitmap GetResizeImage(Bitmap bm, double times)
        {
            Bitmap newbm = null;
            try
            {
                int nowWidth = (int)(bm.Width / times);
                int nowHeight = (int)(bm.Height / times);
                newbm = new Bitmap(nowWidth, nowHeight);
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
            }

            return newbm;
        }

        private void FormConfirm_Load(object sender, EventArgs e)
        {
            InitializeBatchesInfo();
        }

        private void FormConfirm_Shown(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    foreach (Product product in Products)
                    {
                        HttpUtil.LoginToShopWebsite(product.Username, product.Password);
                        List<string> uploadPicturesResult = HttpUtil.UploadPictureToWebsite(product.Pictures);
                        product.PictureUrls = uploadPicturesResult;
                        MyHttpClient.Dispose();
                    }
                    this.btnUpload.Text = "确认无误并且上传";
                    this.btnUpload.Enabled = true;
                }
                catch (Exception exception)
                {
                    FileLog.Error("FormConfirm_Shown", exception, LogType.Error);
                    MessageBox.Show(exception.Message);
                    MessageBox.Show("上传图片时出现问题，请查看网络连接情况！如还有其他问题，联系开发者.");
                }
            });
        }

        private void rtxtConfirmInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseApplicaiton(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
