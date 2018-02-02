using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopTool;
using ShopTool.Comm;
using ShopTool.Model;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod3()
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
        }
    }
}
