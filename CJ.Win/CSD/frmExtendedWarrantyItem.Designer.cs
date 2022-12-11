namespace CJ.Win.CSD
{
    partial class frmExtendedWarrantyItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtendedWarrantyItem));
            this.lvwProductPrice = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbTenure = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNetPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label59 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.SuspendLayout();
            // 
            // lvwProductPrice
            // 
            this.lvwProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.columnHeader2,
            this.columnHeader1});
            this.lvwProductPrice.FullRowSelect = true;
            this.lvwProductPrice.GridLines = true;
            this.lvwProductPrice.Location = new System.Drawing.Point(275, 49);
            this.lvwProductPrice.Name = "lvwProductPrice";
            this.lvwProductPrice.Size = new System.Drawing.Size(331, 200);
            this.lvwProductPrice.TabIndex = 62;
            this.lvwProductPrice.UseCompatibleStateImageBehavior = false;
            this.lvwProductPrice.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Net Price";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 84;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Commission";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 85;
            // 
            // cmbTenure
            // 
            this.cmbTenure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenure.FormattingEnabled = true;
            this.cmbTenure.Items.AddRange(new object[] {
            "<Select Smart Warranty Tenure >",
            "12",
            "24"});
            this.cmbTenure.Location = new System.Drawing.Point(111, 49);
            this.cmbTenure.Name = "cmbTenure";
            this.cmbTenure.Size = new System.Drawing.Size(158, 23);
            this.cmbTenure.TabIndex = 51;
            this.cmbTenure.SelectedIndexChanged += new System.EventHandler(this.cmbTenure_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(426, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 61;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "CarePack Tenure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "Net Price";
            // 
            // txtNetPrice
            // 
            this.txtNetPrice.Location = new System.Drawing.Point(111, 128);
            this.txtNetPrice.Name = "txtNetPrice";
            this.txtNetPrice.Size = new System.Drawing.Size(158, 23);
            this.txtNetPrice.TabIndex = 55;
            this.txtNetPrice.Text = "0.00";
            this.txtNetPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 58;
            this.label7.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(111, 255);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(495, 23);
            this.txtRemarks.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 56;
            this.label6.Text = "Commission";
            // 
            // txtCommission
            // 
            this.txtCommission.Location = new System.Drawing.Point(111, 171);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(158, 23);
            this.txtCommission.TabIndex = 57;
            this.txtCommission.Text = "0.00";
            this.txtCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(111, 88);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(158, 23);
            this.dtpEffectiveDate.TabIndex = 53;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(23, 90);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(85, 15);
            this.label59.TabIndex = 52;
            this.label59.Text = "Effective Date";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(55, 19);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(51, 15);
            this.lblCode.TabIndex = 49;
            this.lblCode.Text = "Product";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(111, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(425, 25);
            this.ctlProduct1.TabIndex = 63;
            // 
            // frmExtendedWarrantyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 318);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.lvwProductPrice);
            this.Controls.Add(this.cmbTenure);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNetPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCommission);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.lblCode);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtendedWarrantyItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExtendedWarrantyItem";
            this.Load += new System.EventHandler(this.frmExtendedWarrantyItem_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductPrice;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox cmbTenure;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNetPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label lblCode;
        private CJ.Control.ctlProduct ctlProduct1;
    }
}