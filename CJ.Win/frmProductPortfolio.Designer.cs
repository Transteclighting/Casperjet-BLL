namespace CJ.Win
{
    partial class frmProductPortfolio
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
            this.lvwOutlet = new System.Windows.Forms.ListView();
            this.colOutlet = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.btnSave = new System.Windows.Forms.Button();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvwOutlet
            // 
            this.lvwOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwOutlet.CheckBoxes = true;
            this.lvwOutlet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOutlet});
            this.lvwOutlet.FullRowSelect = true;
            this.lvwOutlet.GridLines = true;
            this.lvwOutlet.Location = new System.Drawing.Point(12, 80);
            this.lvwOutlet.MultiSelect = false;
            this.lvwOutlet.Name = "lvwOutlet";
            this.lvwOutlet.Size = new System.Drawing.Size(522, 367);
            this.lvwOutlet.TabIndex = 218;
            this.lvwOutlet.UseCompatibleStateImageBehavior = false;
            this.lvwOutlet.View = System.Windows.Forms.View.Details;
            // 
            // colOutlet
            // 
            this.colOutlet.Text = "Outlet";
            this.colOutlet.Width = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 219;
            this.label1.Text = "Product";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(70, 24);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(462, 25);
            this.ctlProduct1.TabIndex = 220;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(459, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 221;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(12, 55);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(83, 17);
            this.ckbSelect.TabIndex = 222;
            this.ckbSelect.Text = "Checked All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // frmProductPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 482);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwOutlet);
            this.Name = "frmProductPortfolio";
            this.Text = "frmProductPortfolios";
            this.Load += new System.EventHandler(this.frmProductPortfolio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwOutlet;
        private System.Windows.Forms.ColumnHeader colOutlet;
        private System.Windows.Forms.Label label1;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckbSelect;
    }
}