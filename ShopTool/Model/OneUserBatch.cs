using System.Collections.Generic;

namespace ShopTool.Model
{
    public class OneUserBatch
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Product> Products { get; set; }

        public OneUserBatch()
        {
            this.Products = new List<Product>();
        }
    }
}