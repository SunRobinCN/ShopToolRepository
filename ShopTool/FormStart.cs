using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ShopTool.Comm;
using ShopTool.Model;
using Timer = System.Timers.Timer;

namespace ShopTool
{
    public partial class FrmStart : Form
    {
        public string NewUsername { get; set; }
        public string NewPasswrod { get; set; }
        public List<Product> SelectedProducts { get; set; }

        public FrmStart()
        {
            InitializeComponent();
            SelectedProducts = new List<Product>();

            InitializeUser();
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
            int count = 1;
            foreach (Product product in allProducts)
            {
                product.Index = count++;
            }
            this.dataGridView.DataSource = allProducts;
            this.dataGridView.ClearSelection();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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

        private void BatchUpload()
        {
            if (CheckMutipleUploadParameters() == false)
            {
                return;
            }
            NewUsername = this.cmbUsername.Text.Trim();
            NewPasswrod = this.txtBatchPassword.Text.Trim();
            SaveUser();

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

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            BatchUpload();
        }

        private bool CheckMutipleUploadParameters()
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个或多个已有产品");
                return false;
            }
            if (this.cmbUsername.Text.Trim() == "" || this.txtBatchPassword.Text.Trim() == "")
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

        private void btnUploadTimer_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show(@"请选择大于当前系统时间的时间段！");
                return;
            }
            if (CheckMutipleUploadParameters() == false)
            {
                return;
            }
            this.txtSetTime.Text = this.dateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(ExecuteWarpper);
            timer.Interval = 1000;
            timer.Start();
        }

        private void ExecuteWarpper(object source, ElapsedEventArgs args)
        {
            if (args.SignalTime.ToString("yyyy-MM-dd HH:mm:ss") == this.txtSetTime.Text)
            {
                Timer timer = source as Timer;
                timer?.Stop();

                MethodInvoker mi = new MethodInvoker(this.BatchUpload);
                this.BeginInvoke(mi);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = this.cmbUsername.Text;
            List<User> oldList = TextUtil.GetUsers();
            List<User> newList = new List<User>();
            foreach (User user in oldList)
            {
                if (user.Username != username)
                {
                    newList.Add(user);
                }
            }
            TextUtil.ArchiveUsers(newList);
            InitializeUser();
        }

        private void InitializeUser()
        {
            List<User> users = TextUtil.GetUsers();
            this.cmbUsername.ValueMember = "Password";
            this.cmbUsername.DisplayMember = "Username";
            this.cmbUsername.DataSource = users;
            this.cmbUsername.SelectedIndex = -1;
            this.txtBatchPassword.Text = "";
        }

        private void SaveUser()
        {
            string username = this.cmbUsername.Text;
            string password = this.txtBatchPassword.Text;
            if (username != "" && password != "")
            {
                List<User> users = TextUtil.GetUsers();
                bool existed = false;
                foreach (User user in users)
                {
                    if (user.Username == username)
                    {
                        user.Password = password;
                        existed = true;
                    }
                }
                if (existed == false)
                {
                    User newUser = new User()
                    {
                        Username = username,
                        Password = password
                    };
                    users.Add(newUser);
                }
                TextUtil.ArchiveUsers(users);
            }
        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUsername.SelectedIndex >= 0)
            {
                User user = this.cmbUsername.SelectedItem as User;
                this.txtBatchPassword.Text = user.Password;
            }
            else
            {
                this.txtBatchPassword.Text = "";
            }
        }
    }
}
