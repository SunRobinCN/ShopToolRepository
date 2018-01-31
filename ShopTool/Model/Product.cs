using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ShopTool.Comm;

namespace ShopTool.Model
{
    public class Product
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public ConnectedComboInfo Category { get; set; }
        public ConnectedComboInfo CategoryDetailInfo { get; set; }
        public Info Status { get; set; }
        public Info LogisticLiao { get; set; }
        public List<Info> LogisticWay { get; set; }
        public Info Area { get; set; }
        public Info LogisticDay { get; set; }
        public List<Image> Pictures { get; set; }
        public List<string> PictureUrls { get; set; }

        public Product()
        {
            this.Pictures = new List<Image>();
            this.PictureUrls = new List<string>();
        }

        public string FinalLogisticWay
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Info info in LogisticWay)
                {
                    builder.Append(info.Name + ", ");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Remove(builder.Length - 1, 1);
                return builder.ToString();
            }
        }
    }
}