namespace TEL.SMS.UI.Win
{
    partial class frmWarrantyReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarrantyReg));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarcodeCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlCustomer1 = new TEL.UI.Win.ctlCustomer();
            this.rbtOutlet = new System.Windows.Forms.RadioButton();
            this.rbtDealer = new System.Windows.Forms.RadioButton();
            this.txtOutlet = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.ctlProductSearch1 = new TEL.UI.Win.ctlProductSearch();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(497, 486);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Location = new System.Drawing.Point(118, 46);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(549, 20);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(118, 18);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(168, 20);
            this.txtSerialNo.TabIndex = 0;
            //this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNo_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial No *";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Customer Name *";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(120, 189);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(168, 20);
            this.txtMobileNo.TabIndex = 6;
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mobile No";
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.Location = new System.Drawing.Point(120, 163);
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(168, 20);
            this.txtTelephoneNo.TabIndex = 5;
            this.txtTelephoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephoneNo_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telephone No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Customer Address *";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerAddress.Location = new System.Drawing.Point(120, 72);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(549, 85);
            this.txtCustomerAddress.TabIndex = 4;
            this.txtCustomerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerAddress_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 215);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Purchase Date *";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpPurchaseDate.CalendarTitleForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(120, 241);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(109, 20);
            this.dtpPurchaseDate.TabIndex = 8;
            this.dtpPurchaseDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpPurchaseDate_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Product *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 409);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Invoice/Challan No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(120, 409);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(155, 20);
            this.txtBillNo.TabIndex = 11;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(120, 435);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(547, 31);
            this.txtRemarks.TabIndex = 12;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 435);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Remarks";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "BarCode No.*";
            // 
            // txtBarcodeCode
            // 
            this.txtBarcodeCode.Location = new System.Drawing.Point(118, 267);
            this.txtBarcodeCode.Name = "txtBarcodeCode";
            this.txtBarcodeCode.Size = new System.Drawing.Size(168, 20);
            this.txtBarcodeCode.TabIndex = 2;
            this.txtBarcodeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcodeCode_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctlCustomer1);
            this.groupBox1.Controls.Add(this.rbtOutlet);
            this.groupBox1.Controls.Add(this.rbtDealer);
            this.groupBox1.Controls.Add(this.txtOutlet);
            this.groupBox1.Location = new System.Drawing.Point(12, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Point *";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(140, 14);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(497, 25);
            this.ctlCustomer1.TabIndex = 1;
            this.ctlCustomer1.TxtbalanceEnabled = true;
            this.ctlCustomer1.TxtBalanceValue = 0;
            this.ctlCustomer1.TxtbalanceVisible = false;
            // 
            // rbtOutlet
            // 
            this.rbtOutlet.AutoSize = true;
            this.rbtOutlet.Location = new System.Drawing.Point(13, 46);
            this.rbtOutlet.Name = "rbtOutlet";
            this.rbtOutlet.Size = new System.Drawing.Size(53, 17);
            this.rbtOutlet.TabIndex = 2;
            this.rbtOutlet.Text = "Outlet";
            this.rbtOutlet.UseVisualStyleBackColor = true;
            this.rbtOutlet.CheckedChanged += new System.EventHandler(this.rbtOutlet_CheckedChanged);
            // 
            // rbtDealer
            // 
            this.rbtDealer.AutoSize = true;
            this.rbtDealer.Checked = true;
            this.rbtDealer.Location = new System.Drawing.Point(13, 20);
            this.rbtDealer.Name = "rbtDealer";
            this.rbtDealer.Size = new System.Drawing.Size(111, 17);
            this.rbtDealer.TabIndex = 0;
            this.rbtDealer.TabStop = true;
            this.rbtDealer.Text = "Showroom/Dealer";
            this.rbtDealer.UseVisualStyleBackColor = true;
            this.rbtDealer.CheckedChanged += new System.EventHandler(this.rbtDealer_CheckedChanged);
            // 
            // txtOutlet
            // 
            this.txtOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutlet.Location = new System.Drawing.Point(140, 45);
            this.txtOutlet.Name = "txtOutlet";
            this.txtOutlet.Size = new System.Drawing.Size(497, 20);
            this.txtOutlet.TabIndex = 3;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(592, 486);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 14;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ctlProductSearch1
            // 
            this.ctlProductSearch1.Location = new System.Drawing.Point(118, 297);
            this.ctlProductSearch1.Name = "ctlProductSearch1";
            this.ctlProductSearch1.Size = new System.Drawing.Size(547, 25);
            this.ctlProductSearch1.TabIndex = 9;
            // 
            // frmWarrantyReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 522);
            this.Controls.Add(this.ctlProductSearch1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBarcodeCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelephoneNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWarrantyReg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warranty";
            this.Load += new System.EventHandler(this.frmWarrantyReg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelephoneNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarcodeCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOutlet;
        private System.Windows.Forms.RadioButton rbtDealer;
        private System.Windows.Forms.TextBox txtOutlet;
        private System.Windows.Forms.Button Cancel;
        private TEL.UI.Win.ctlCustomer ctlCustomer1;
        private TEL.UI.Win.ctlProductSearch ctlProductSearch1;
    }
}