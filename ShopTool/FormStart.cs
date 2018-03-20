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

        public string NewUsername { get; set; }
        public string NewPasswrod { get; set; }
        public List<Product> SelectedProducts { get; set; }

        public FrmStart()
        {
            InitializeComponent();
            SelectedProducts = new List<Product>();
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

        private void RefreshDataGrid()
        {
            List<Product> allProducts = TextUtil.GetProducts();
            //foreach (Product product in allProducts)
            //{
            //    product.Description.Replace(@"\n", "");
            //}
            this.dataGridView.DataSource = allProducts;
            this.dataGridView.ClearSelection();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnUploadExistedProduct_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count == 0 || this.dataGridView.SelectedRows.Count > 1)
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
            string id = row.Cells["Id"].Value.ToString();
            return GetSelectedProduct(id);
        }

        private Product GetSelectedProduct(string id)
        {
            List<Product> allProducts = TextUtil.GetProducts();
            foreach (Product product in allProducts)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            if (CheckMutipleUploadParameters() == false)
            {
                return;
            }
            NewUsername = this.txtUsername.Text.Trim();
            NewPasswrod = this.txtPassword.Text.Trim();

            SelectedProducts.Clear(); 
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                Product p = dataGridView.SelectedRows[i].DataBoundItem as Product;
                if (p == null)
                {
                    throw new Exception("Product config error!");
                }
                p.Id = Guid.NewGuid().ToString();
                p.Username = NewUsername;
                p.Password = NewPasswrod;
                p.UploadDateTime = DateTime.Now;
                p.UploadFailedReson = "";
                p.UploadResult = "";
                p.Pictures = new List<Image>();
                foreach (string imagePath in p.ImagePaths)
                {
                    p.Pictures.Add(Image.FromFile(imagePath));
                }
                p.ImagePaths.Clear();
                SelectedProducts.Add(p);
            }

            FormConfirm frmConfirm = new FormConfirm();
            frmConfirm.Products = SelectedProducts;
            frmConfirm.Show();
            this.Hide();
        }

        private bool CheckMutipleUploadParameters()
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个或多个已有产品");
                return false;
            }
            if (this.txtUsername.Text.Trim() == "" || this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名与密码");
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个或多个已有产品");
                return;
            }
            List<Product> toBeDeleted = new List<Product>();
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                Product p = dataGridView.SelectedRows[i].DataBoundItem as Product;
                if (p == null)
                {
                    throw new Exception("Product config error!");
                }
                toBeDeleted.Add(p);
            }
            DeleteSelectedProducts(toBeDeleted);
            RefreshDataGrid();
        }

        private void DeleteSelectedProducts(List<Product> toBeDeletedList)
        {
            List<Product> allProducts = TextUtil.GetProducts();
            List<Product> newList = new List<Product>();
            foreach (var product in allProducts)
            {
                if (CheckWetherInList(product, toBeDeletedList) == false)
                {
                    newList.Add(product);
                }
            }
            TextUtil.RefreshProducts(newList);
        }

        private bool CheckWetherInList(Product p, List<Product> list)
        {
            foreach (var product in list)
            {
                if (product.Id == p.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
