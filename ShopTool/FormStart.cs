using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopTool.Comm;
using ShopTool.Model;

namespace ShopTool
{
    public partial class FrmStart : Form
    {
        private const int HisotryInterval = 3;
        readonly List<Product> _products = TextUtil.GetProducts();

        public FrmStart()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);  
        }

        private void btnUploadNew_Click(object sender, EventArgs e)
        {
            FormProduct product = new FormProduct();
            product.Show();
            this.Hide();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            foreach (Product product in _products)
            {
                product.Description.Replace(@"\n", "");
            }
            this.dataGridView.DataSource = _products.Where(p => (DateTime.Now - p.UploaDateTime).Days < HisotryInterval).ToList();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnUploadExistedProduct_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个已有的产品！");
                return;
            }

            Product p = GetSelectedProduct();
            FormProduct formProduct = new FormProduct();
            formProduct.ExistedProduct = p;
            formProduct.Show();
            this.Hide();
        }

        private Product GetSelectedProduct()
        {
            DataGridViewRow row = this.dataGridView.SelectedRows[0];
            string id = row.Cells["Id"].ToString();
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
