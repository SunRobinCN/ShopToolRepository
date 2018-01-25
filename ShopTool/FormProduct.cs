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
    public partial class FormProduct : Form
    {

        private List<Product> _products = new List<Product>();

        public FormProduct()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (DialogResult.OK == d.ShowDialog())
            {
                pictureBox2.Image = Image.FromFile(d.FileName);
            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            InitializeComboboxes();
        }

        private void InitializeComboboxes()
        {
            List<User> users = TextUtil.GetUsers();
            this.cmbUsername.ValueMember = "Password";
            this.cmbUsername.DisplayMember = "Username";
            this.cmbUsername.DataSource = users;

            this.cmbProductSatus.ValueMember = "Id";
            this.cmbProductSatus.DisplayMember = "Name";
            this.cmbProductSatus.DataSource = ComboUtil.GetDatatSourceForStatus();
            this.cmbProductSatus.SelectedIndex = 2;

            this.cmbLogisticWay.ValueMember = "Id";
            this.cmbLogisticWay.DisplayMember = "Name";

            this.cmbLogisticLiao.ValueMember = "Id";
            this.cmbLogisticLiao.DisplayMember = "Name";
            this.cmbLogisticLiao.DataSource = ComboUtil.GetDatatSourceForLoggisticLiao();
            this.cmbLogisticLiao.SelectedIndex = 0;

            this.cmbProductArea.ValueMember = "Id";
            this.cmbProductArea.DisplayMember = "Name";
            this.cmbProductArea.DataSource = ComboUtil.GetDatatSourceForArea();
            this.cmbProductArea.SelectedIndex = 0;

            this.cmbLogisticDay.ValueMember = "Id";
            this.cmbLogisticDay.DisplayMember = "Name";
            this.cmbLogisticDay.DataSource = ComboUtil.GetDatatSourceForDelierDate();
            this.cmbLogisticDay.SelectedIndex = 0;

            InitailizeComboCatogery();
        }

        private void InitailizeComboCatogery()
        {
            List<ConnectedComboInfo> list = ComboUtil.GetDatatSourceForCategory();
            this.cmbCategory1.ValueMember = "Id";
            this.cmbCategory1.DisplayMember = "Name";
            this.cmbCategory1.DataSource = list;
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectedComboInfo result = this.cmbCategory1.SelectedItem as ConnectedComboInfo;
            this.cmbCategory2.ValueMember = "Id";
            this.cmbCategory2.DisplayMember = "Name";
            this.cmbCategory2.DataSource = result.Children;

            this.cmbCategory3.DataSource = null;
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectedComboInfo result = this.cmbCategory2.SelectedItem as ConnectedComboInfo;
            this.cmbCategory3.ValueMember = "Id";
            this.cmbCategory3.DisplayMember = "Name";
            this.cmbCategory3.DataSource = result.Children;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (DialogResult.OK == d.ShowDialog())
            {
                pictureBox1.Image = Image.FromFile(d.FileName);
            }
        }

        private void btnNextProduct_Click(object sender, EventArgs e)
        {
            SaveProduct();
            SaveUser();
            ClearAll();
        }

        private void SaveProduct()
        {
            Product product = new Product
            {
                Username = this.cmbUsername.SelectedText,
                Password = this.txtPassword.Text,
                Name = this.txtProductName.Text,
                Description = this.txtProductDesc.Text,
                Price = this.txtProductPrice.Text,
                Category = GetProductCategory(),
                Status = cmbProductSatus.SelectedItem as Info,
                LogisticWay = cmbLogisticWay.SelectedItem as Info,
                LogisticLiao = cmbLogisticLiao.SelectedItem as Info,
                LogisticDay = cmbLogisticDay.SelectedItem as Info
            };
            product.Pictures.Add(this.pictureBox1.Image);
            product.Pictures.Add(this.pictureBox2.Image);
            product.Pictures.Add(this.pictureBox3.Image);
            product.Pictures.Add(this.pictureBox4.Image);
            _products.Add(product);
        }

        private ConnectedComboInfo GetProductCategory()
        {
            ConnectedComboInfo result = null;
            ConnectedComboInfo infoLevel3 = this.cmbCategory3.SelectedItem as ConnectedComboInfo;
            if (infoLevel3 != null && infoLevel3.Name != "")
            {
                result = infoLevel3;
            }
            else
            {
                ConnectedComboInfo infoLevel2 = this.cmbCategory2.SelectedItem as ConnectedComboInfo;
                result = infoLevel2;
            }
            return result;
        }

        private void SaveUser()
        {
            string username = this.cmbUsername.Text;
            string password = this.txtPassword.Text;
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

        private void ClearAll()
        {
            this.txtProductName.Text = "";
            this.txtProductDesc.Text = "";
            this.txtProductPrice.Text = "";
            InitializeComboboxes();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveProduct();
            List<OneUserBatch> batches = AssebleBatches();
            FormConfirm frmConfirm = new FormConfirm();
            frmConfirm.Batches = batches;
            frmConfirm.Show();
        }

        private List<OneUserBatch> AssebleBatches()
        {
            List<OneUserBatch> batches = new List<OneUserBatch>();
            foreach (Product product in _products)
            {
                OneUserBatch batch = GetBatchByUsername(product.Username, batches);
                if (batch == null)
                {
                    OneUserBatch newBatch = new OneUserBatch();
                    newBatch.Products.Add(product);
                    batches.Add(newBatch);
                }
                else
                {
                    batch.Products.Add(product);
                    batches.Add(batch);
                }
            }
            return batches;
        }

        private OneUserBatch GetBatchByUsername(string username, List<OneUserBatch> batches)
        {
            OneUserBatch batch = null;
            foreach (OneUserBatch oneUserBatch in batches ?? new List<OneUserBatch>())
            {
                if (oneUserBatch.Username == username)
                {
                    batch = oneUserBatch;
                }
            }
            return batch;
        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = TextUtil.GetUsers();
            User user = this.cmbUsername.SelectedItem as User;
            this.txtPassword.Text = user.Password;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (DialogResult.OK == d.ShowDialog())
            {
                pictureBox3.Image = Image.FromFile(d.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (DialogResult.OK == d.ShowDialog())
            {
                pictureBox4.Image = Image.FromFile(d.FileName);
            }
        }

        private void cmbLogisticLiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogisticLiaoInfo info = this.cmbLogisticLiao.SelectedItem as LogisticLiaoInfo;
            this.cmbLogisticWay.DataSource = info.ChildrenLogisticWay;
        }
    }
}
