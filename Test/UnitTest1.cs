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
            Product product = new Product();
            product.Username = "myname";
            product.Password = "mypassword";
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

            product.UploaDateTime = DateTime.Now;

            TextUtil.ArchiveProduct(product);
            for (int i = 0; i < 105; i++)
            {
                TextUtil.ArchiveProduct(product);
            }
            List<Product> list = TextUtil.GetProducts();
        }
    }
}
