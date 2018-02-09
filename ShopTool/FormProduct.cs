using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopTool.Comm;
using ShopTool.Model;
using ShopTool.Properties;

namespace ShopTool
{
    public partial class FormProduct : Form
    {

        private List<Product> _products = new List<Product>();
        public ConnectedComboInfo CategoryDetailInfo { get; set; }

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

            this.cmbLogisticLiao.ValueMember = "Id";
            this.cmbLogisticLiao.DisplayMember = "Name";
            this.cmbLogisticLiao.DataSource = ComboUtil.GetDatatSourceForLoggisticLiao();
            this.cmbLogisticLiao.SelectedIndex = 0;

            this.cmbLogisticWay.ValueMember = "Id";
            this.cmbLogisticWay.DisplayMember = "Name";

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
            this.cmbCategory1.DataSource = null;
            this.cmbCategory2.DataSource = null;
            this.cmbCategory3.DataSource = null;
            List<ConnectedComboInfo> list = ComboUtil.GetDatatSourceForCategory();
            this.cmbCategory1.ValueMember = "Id";
            this.cmbCategory1.DisplayMember = "Name";
            this.cmbCategory1.DataSource = list;
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCategory2.DataSource = null;
            this.cmbCategory3.DataSource = null;
            ConnectedComboInfo result = this.cmbCategory1.SelectedItem as ConnectedComboInfo;
            this.cmbCategory2.ValueMember = "Id";
            this.cmbCategory2.DisplayMember = "Name";
            if (result != null) this.cmbCategory2.DataSource = (result.Children);
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCategory3.DataSource = null;
            ConnectedComboInfo result = this.cmbCategory2.SelectedItem as ConnectedComboInfo;
            this.cmbCategory3.ValueMember = "Id";
            this.cmbCategory3.DisplayMember = "Name";
            if (result != null) this.cmbCategory3.DataSource = (result.Children);
        }

        private void cmbCategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryDetailInfo = new ConnectedComboInfo();
            ConnectedComboInfo info1 = this.cmbCategory1.SelectedItem as ConnectedComboInfo;
            ConnectedComboInfo info2 = this.cmbCategory2.SelectedItem as ConnectedComboInfo;
            ConnectedComboInfo info3 = this.cmbCategory3.SelectedItem as ConnectedComboInfo;
            if (info1 != null)
            {
                CategoryDetailInfo.LevelOneID = info1.ID;
                CategoryDetailInfo.LevelOneName = info1.Name;
            }
            if (info2 != null)
            {
                CategoryDetailInfo.LevelTwoID = (Convert.ToInt32(info2.ID) - 1).ToString();
                CategoryDetailInfo.LevelTwoName = info2.Name;
            }
            if (info3 != null)
            {
                CategoryDetailInfo.LevelThreeID = info3.ID;
                CategoryDetailInfo.LevelThreeName = info3.Name;
            }
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
            if (CheckInput() == false)
            {
                return;
            }
            SaveProduct();
            SaveUser();
            ClearAll();
        }

        private void SaveProduct()
        {
            Product product = new Product
            {
                Username = this.cmbUsername.Text,
                Password = this.txtPassword.Text,
                Name = this.txtProductName.Text,
                Description = this.txtProductDesc.Text,
                Price = this.txtProductPrice.Text,
                Category = GetProductCategory(),
                Status = cmbProductSatus.SelectedItem as Info,
                Area = this.cmbProductArea.SelectedItem as Info,
                LogisticWay = GetLogisticWay(),
                LogisticLiao = cmbLogisticLiao.SelectedItem as Info,
                LogisticDay = cmbLogisticDay.SelectedItem as Info,
                CategoryDetailInfo = CategoryDetailInfo
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

        private List<Info> GetLogisticWay()
        {
            List<Info> list = new List<Info>();
            IEnumerator enumerator = cmbLogisticWay.CheckedItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Info item = (Info)(enumerator.Current);
                list.Add(item);
            }
            return list;
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

            this.pictureBox1.Image = global::ShopTool.Properties.Resources.embedbyrobin1;
            this.pictureBox2.Image = global::ShopTool.Properties.Resources.embedbyrobin2;
            this.pictureBox3.Image = global::ShopTool.Properties.Resources.embedbyrobin2;
            this.pictureBox4.Image = global::ShopTool.Properties.Resources.embedbyrobin2;


            InitializeComboboxes();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }
            SaveProduct();
            FormConfirm frmConfirm = new FormConfirm();
            frmConfirm.Products = _products;
            frmConfirm.Show();
            this.Hide();
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
            this.cmbLogisticWay.ValueMember = "Id";
            this.cmbLogisticWay.DisplayMember = "Name";
            this.cmbLogisticWay.DataSource = info.ChildrenLogisticWay;
            this.cmbLogisticWay.ValueMember = "Id";
            this.cmbLogisticWay.DisplayMember = "Name";
            foreach (int i in this.cmbLogisticWay.CheckedIndices)
            {
                this.cmbLogisticWay.SetItemChecked(i, false);
            }
        }

        private void cmbLogisticWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox cb = sender as CheckedListBox;
            if ((cb.SelectedItem as Info) != null)
            {
                if ((cb.SelectedItem as Info).Name == "未定")
                {
                    foreach (int i in cb.CheckedIndices)
                    {
                        if (i != 0)
                        {
                            cb.SetItemChecked(i, false);
                        }
                    }
                }
                else
                {
                    cb.SetItemChecked(0, false);
                }
            }
        }

        private bool CheckInput()
        {
            Image originalImage1 = Resources.embedbyrobin1;
            Image originalImage2 = Resources.embedbyrobin2;
            Image originalImage3 = Resources.embedbyrobin2;
            Image originalImage4 = Resources.embedbyrobin2;
            if (ImageEquals(originalImage1, this.pictureBox1.Image) ||
                ImageEquals(originalImage2, this.pictureBox2.Image) ||
                ImageEquals(originalImage3, this.pictureBox3.Image) ||
                ImageEquals(originalImage4, this.pictureBox4.Image))
            {
                MessageBox.Show("请输入4张图片！");
                return false;
            }
            if (this.cmbCategory3.SelectedItem == null)
            {
                MessageBox.Show("请输入カテゴリ！");
                return false;
            }
            if (this.cmbUsername.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名！");
                return false;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！");
                return false;
            }
            if (this.txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("请输入商品説明！");
                return false;
            }
            if (this.txtProductDesc.Text.Trim() == "")
            {
                MessageBox.Show("请输入商品説明！");
                return false;
            }
            if (this.txtProductPrice.Text.Trim() == "")
            {
                MessageBox.Show("请输入价格！");
                return false;
            }
            int price;
            if (int.TryParse(txtProductPrice.Text.Trim(), out price) == false)
            {
                MessageBox.Show("请输入价格为数字！");
                return false;
            }
            if (price < 300 || price > 50000)
            {
                MessageBox.Show("请输入价格在规定的区间内！");
                return false;
            }
            if ((this.cmbProductArea.SelectedItem as Info).Name == "選択してください")
            {
                MessageBox.Show("请选择出品地域！");
                return false;
            }
            if (this.cmbLogisticWay.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择配送方法!");
                return false;
            }
            return true;
        }

        private bool ImageEquals(Image img1, Image img2)
        {
            Bitmap bmp1 = new Bitmap(img1);
            Bitmap bmp2 = new Bitmap(img2);
            if (!bmp1.Size.Equals(bmp2.Size))
            {
                return false;
            }
            for (int x = 0; x < bmp1.Width; ++x)
            {
                for (int y = 0; y < bmp1.Height; ++y)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void FormProduct_Shown(object sender, EventArgs e)
        {
            //this.txtProductName.Text = new Random().Next(1, 6) + "rr";
            //this.txtProductDesc.Text = "aaaa";
            //this.txtProductPrice.Text = "5555";
            //this.cmbProductArea.SelectedIndex = 3;
            //this.cmbCategory1.SelectedIndex = 1;
        }

        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutDownUtil.ShutDown();
        }
    }
}
