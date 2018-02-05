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
            List<Product> products = TextUtil.GetProducts();
            this.dataGridView.DataSource = products.Where(p => (DateTime.Now - p.UploaDateTime).Days < HisotryInterval).ToList();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
