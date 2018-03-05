namespace ShopTool
{
    partial class FormExecute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myTransparentPanel = new ShopTool.MyControlPannel();
            this.SuspendLayout();
            // 
            // myTransparentPanel
            // 
            this.myTransparentPanel.BackColor = System.Drawing.Color.Transparent;
            this.myTransparentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTransparentPanel.Location = new System.Drawing.Point(0, 0);
            this.myTransparentPanel.Name = "myTransparentPanel";
            this.myTransparentPanel.Size = new System.Drawing.Size(939, 567);
            this.myTransparentPanel.TabIndex = 1;
            this.myTransparentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.myTransparentPanel_Paint);
            // 
            // FormExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 567);
            this.Controls.Add(this.myTransparentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormExecute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormExecute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExecute_FormClosing);
            this.Load += new System.EventHandler(this.FormExecute_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyControlPannel myTransparentPanel;
    }
}