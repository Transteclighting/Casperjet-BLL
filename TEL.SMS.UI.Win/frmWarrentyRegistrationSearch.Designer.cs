namespace TEL.SMS.UI.Win
{
    partial class frmWarrentyRegistrationSearch
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvwWarrantyRegister = new System.Windows.Forms.ListView();
            this.colSerialNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colCustomerAddress = new System.Windows.Forms.ColumnHeader();
            this.colProduct = new System.Windows.Forms.ColumnHeader();
            this.colPurchaseDate = new System.Windows.Forms.ColumnHeader();
            this.colEntryDate = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.rdoPurchaseDate = new System.Windows.Forms.RadioButton();
            this.rdoEntryDate = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.PurGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PDateto = new System.Windows.Forms.DateTimePicker();
            this.PDateFrom = new System.Windows.Forms.DateTimePicker();
            this.EntryGrp = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EDateTo = new System.Windows.Forms.DateTimePicker();
            this.EDateFrom = new System.Windows.Forms.DateTimePicker();
            this.PurGroup.SuspendLayout();
            this.EntryGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(622, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvwWarrantyRegister
            // 
            this.lvwWarrantyRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWarrantyRegister.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSerialNo,
            this.colCustomerCode,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colProduct,
            this.colPurchaseDate,
            this.colEntryDate,
            this.colUserName});
            this.lvwWarrantyRegister.FullRowSelect = true;
            this.lvwWarrantyRegister.GridLines = true;
            this.lvwWarrantyRegister.HideSelection = false;
            this.lvwWarrantyRegister.Location = new System.Drawing.Point(3, 150);
            this.lvwWarrantyRegister.MultiSelect = false;
            this.lvwWarrantyRegister.Name = "lvwWarrantyRegister";
            this.lvwWarrantyRegister.Size = new System.Drawing.Size(923, 360);
            this.lvwWarrantyRegister.TabIndex = 54;
            this.lvwWarrantyRegister.UseCompatibleStateImageBehavior = false;
            this.lvwWarrantyRegister.View = System.Windows.Forms.View.Details;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "Serial No";
            this.colSerialNo.Width = 82;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 88;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer  Name";
            this.colCustomerName.Width = 200;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Text = "Address";
            this.colCustomerAddress.Width = 200;
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product";
            this.colProduct.Width = 120;
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.Text = "Purchase Date";
            this.colPurchaseDate.Width = 100;
            // 
            // colEntryDate
            // 
            this.colEntryDate.Text = "Entry Date";
            this.colEntryDate.Width = 100;
            // 
            // colUserName
            // 
            this.colUserName.Text = "UserName";
            this.colUserName.Width = 120;
            // 
            // rdoPurchaseDate
            // 
            this.rdoPurchaseDate.AutoSize = true;
            this.rdoPurchaseDate.Location = new System.Drawing.Point(12, 12);
            this.rdoPurchaseDate.Name = "rdoPurchaseDate";
            this.rdoPurchaseDate.Size = new System.Drawing.Size(96, 17);
            this.rdoPurchaseDate.TabIndex = 56;
            this.rdoPurchaseDate.Text = "Purchase Date";
            this.rdoPurchaseDate.UseVisualStyleBackColor = true;
            this.rdoPurchaseDate.Click += new System.EventHandler(this.rdoPurchaseDate_Click);
            this.rdoPurchaseDate.CheckedChanged += new System.EventHandler(this.rdoPurchaseDate_CheckedChanged);
            // 
            // rdoEntryDate
            // 
            this.rdoEntryDate.AutoSize = true;
            this.rdoEntryDate.Location = new System.Drawing.Point(12, 50);
            this.rdoEntryDate.Name = "rdoEntryDate";
            this.rdoEntryDate.Size = new System.Drawing.Size(75, 17);
            this.rdoEntryDate.TabIndex = 57;
            this.rdoEntryDate.Text = "Entry Date";
            this.rdoEntryDate.UseVisualStyleBackColor = true;
            this.rdoEntryDate.Click += new System.EventHandler(this.rdoEntryDate_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(12, 87);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 58;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.rdoAll_Click);
            // 
            // PurGroup
            // 
            this.PurGroup.Controls.Add(this.label2);
            this.PurGroup.Controls.Add(this.label1);
            this.PurGroup.Controls.Add(this.PDateto);
            this.PurGroup.Controls.Add(this.PDateFrom);
            this.PurGroup.Location = new System.Drawing.Point(123, 2);
            this.PurGroup.Name = "PurGroup";
            this.PurGroup.Size = new System.Drawing.Size(574, 33);
            this.PurGroup.TabIndex = 59;
            this.PurGroup.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // PDateto
            // 
            this.PDateto.Location = new System.Drawing.Point(368, 10);
            this.PDateto.Name = "PDateto";
            this.PDateto.Size = new System.Drawing.Size(200, 20);
            this.PDateto.TabIndex = 61;
            this.PDateto.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // PDateFrom
            // 
            this.PDateFrom.Location = new System.Drawing.Point(68, 8);
            this.PDateFrom.Name = "PDateFrom";
            this.PDateFrom.Size = new System.Drawing.Size(200, 20);
            this.PDateFrom.TabIndex = 0;
            // 
            // EntryGrp
            // 
            this.EntryGrp.Controls.Add(this.label3);
            this.EntryGrp.Controls.Add(this.label4);
            this.EntryGrp.Controls.Add(this.EDateTo);
            this.EntryGrp.Controls.Add(this.EDateFrom);
            this.EntryGrp.Location = new System.Drawing.Point(123, 42);
            this.EntryGrp.Name = "EntryGrp";
            this.EntryGrp.Size = new System.Drawing.Size(574, 33);
            this.EntryGrp.TabIndex = 60;
            this.EntryGrp.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "To Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "From Date";
            // 
            // EDateTo
            // 
            this.EDateTo.Location = new System.Drawing.Point(368, 7);
            this.EDateTo.Name = "EDateTo";
            this.EDateTo.Size = new System.Drawing.Size(200, 20);
            this.EDateTo.TabIndex = 65;
            // 
            // EDateFrom
            // 
            this.EDateFrom.Location = new System.Drawing.Point(68, 7);
            this.EDateFrom.Name = "EDateFrom";
            this.EDateFrom.Size = new System.Drawing.Size(200, 20);
            this.EDateFrom.TabIndex = 63;
            // 
            // frmWarrentyRegistrationSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 522);
            this.Controls.Add(this.EntryGrp);
            this.Controls.Add(this.PurGroup);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoEntryDate);
            this.Controls.Add(this.rdoPurchaseDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvwWarrantyRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmWarrentyRegistrationSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warrenty Registration Search";
            this.Load += new System.EventHandler(this.frmWarrentyRegistrationSearch_Load);
            this.PurGroup.ResumeLayout(false);
            this.PurGroup.PerformLayout();
            this.EntryGrp.ResumeLayout(false);
            this.EntryGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvwWarrantyRegister;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCustomerAddress;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colPurchaseDate;
        private System.Windows.Forms.ColumnHeader colEntryDate;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.RadioButton rdoPurchaseDate;
        private System.Windows.Forms.RadioButton rdoEntryDate;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.GroupBox PurGroup;
        private System.Windows.Forms.GroupBox EntryGrp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker PDateto;
        private System.Windows.Forms.DateTimePicker PDateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker EDateTo;
        private System.Windows.Forms.DateTimePicker EDateFrom;
    }
}