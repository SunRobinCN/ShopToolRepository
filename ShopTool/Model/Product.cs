using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ShopTool.Comm;

namespace ShopTool.Model
{
    public class Product
    {
        public string Username { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime UploaDateTime { get; set; }
        public string UploadResult { get; set; }
        public string UploadFailedReson { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        [System.ComponentModel.Browsable(false)]
        public ConnectedComboInfo Category { get; set; }
        public ConnectedComboInfo CategoryDetailInfo { get; set; }
        public Info Status { get; set; }
        public Info LogisticLiao { get; set; }
        public List<Info> LogisticWay { get; set; }
        public Info Area { get; set; }
        public Info LogisticDay { get; set; }
        public List<Image> Pictures { get; set; }
        public List<string> PictureUrls { get; set; }
        public List<string> ImagePaths { get; set; }
        public string Id { get; set; }

        public Product()
        {
            this.Pictures = new List<Image>();
            this.PictureUrls = new List<string>();
            this.ImagePaths = new List<string>();
            Id = Guid.NewGuid().ToString();
        }

        public string FinalLogisticWay
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Info info in LogisticWay ?? new List<Info>())
                {
                    builder.Append(info.Name + ", ");
                }
                if (builder.Length > 2)
                {
                    builder.Remove(builder.Length - 1, 1);
                    builder.Remove(builder.Length - 1, 1);
                }
                return builder.ToString();
            }
        }
    }
}