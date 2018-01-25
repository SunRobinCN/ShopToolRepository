using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopTool
{
    public partial class FormDone : Form
    {
        public string UploadResultMessage { get; set; }

        public FormDone()
        {
            InitializeComponent();
        }

        private void FormDone_Load(object sender, EventArgs e)
        {
            this.label2.Text = UploadResultMessage;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
