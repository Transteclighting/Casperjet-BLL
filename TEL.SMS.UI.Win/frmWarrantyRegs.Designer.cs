namespace TEL.SMS.UI.Win
{
    partial class frmWarrantyRegs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarrantyRegs));
            this.lvwWarrantyRegister = new System.Windows.Forms.ListView();
            this.colSerialNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colCustomerAddress = new System.Windows.Forms.ColumnHeader();
            this.colProduct = new System.Windows.Forms.ColumnHeader();
            this.colPurchaseDate = new System.Windows.Forms.ColumnHeader();
            this.colEntryDate = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewWarrantyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyWarrantyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWarrantyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSearchOn = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtFinal = new System.Windows.Forms.RadioButton();
            this.rbtSMS = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.lvwWarrantyRegister.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwWarrantyRegister.FullRowSelect = true;
            this.lvwWarrantyRegister.GridLines = true;
            this.lvwWarrantyRegister.HideSelection = false;
            this.lvwWarrantyRegister.Location = new System.Drawing.Point(12, 34);
            this.lvwWarrantyRegister.Name = "lvwWarrantyRegister";
            this.lvwWarrantyRegister.Size = new System.Drawing.Size(832, 423);
            this.lvwWarrantyRegister.TabIndex = 24;
            this.lvwWarrantyRegister.UseCompatibleStateImageBehavior = false;
            this.lvwWarrantyRegister.View = System.Windows.Forms.View.Details;
            this.lvwWarrantyRegister.DoubleClick += new System.EventHandler(this.lvwWarrantyRegister_DoubleClick);
            this.lvwWarrantyRegister.SelectedIndexChanged += new System.EventHandler(this.lvwWarrantyRegister_SelectedIndexChanged);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewWarrantyToolStripMenuItem,
            this.modifyWarrantyToolStripMenuItem,
            this.deleteWarrantyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 70);
            // 
            // addNewWarrantyToolStripMenuItem
            // 
            this.addNewWarrantyToolStripMenuItem.Name = "addNewWarrantyToolStripMenuItem";
            this.addNewWarrantyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addNewWarrantyToolStripMenuItem.Text = "Add New Warranty";
            this.addNewWarrantyToolStripMenuItem.Click += new System.EventHandler(this.addNewWarrantyRegisterToolStripMenuItem_Click);
            // 
            // modifyWarrantyToolStripMenuItem
            // 
            this.modifyWarrantyToolStripMenuItem.Name = "modifyWarrantyToolStripMenuItem";
            this.modifyWarrantyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.modifyWarrantyToolStripMenuItem.Text = "Modify Warranty";
            this.modifyWarrantyToolStripMenuItem.Click += new System.EventHandler(this.modifyWarrantyRegisterToolStripMenuItem_Click);
            // 
            // deleteWarrantyToolStripMenuItem
            // 
            this.deleteWarrantyToolStripMenuItem.Name = "deleteWarrantyToolStripMenuItem";
            this.deleteWarrantyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deleteWarrantyToolStripMenuItem.Text = "Delete Warranty";
            this.deleteWarrantyToolStripMenuItem.Click += new System.EventHandler(this.deleteWarrantyRegisterToolStripMenuItem_Click);
            // 
            // cboSearchOn
            // 
            this.cboSearchOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchOn.FormattingEnabled = true;
            this.cboSearchOn.Items.AddRange(new object[] {
            "SerialNo",
            "CustomerCode",
            "CustomerName",
            "RegMode"});
            this.cboSearchOn.Location = new System.Drawing.Point(42, 6);
            this.cboSearchOn.Name = "cboSearchOn";
            this.cboSearchOn.Size = new System.Drawing.Size(121, 21);
            this.cboSearchOn.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(439, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(169, 7);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(264, 20);
            this.txtFind.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Find";
            // 
            // rbtFinal
            // 
            this.rbtFinal.AutoSize = true;
            this.rbtFinal.Checked = true;
            this.rbtFinal.Location = new System.Drawing.Point(631, 8);
            this.rbtFinal.Name = "rbtFinal";
            this.rbtFinal.Size = new System.Drawing.Size(47, 17);
            this.rbtFinal.TabIndex = 55;
            this.rbtFinal.TabStop = true;
            this.rbtFinal.Text = "Final";
            this.rbtFinal.UseVisualStyleBackColor = true;
            // 
            // rbtSMS
            // 
            this.rbtSMS.AutoSize = true;
            this.rbtSMS.Location = new System.Drawing.Point(693, 9);
            this.rbtSMS.Name = "rbtSMS";
            this.rbtSMS.Size = new System.Drawing.Size(48, 17);
            this.rbtSMS.TabIndex = 56;
            this.rbtSMS.Text = "SMS";
            this.rbtSMS.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(531, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 22);
            this.btnPrint.TabIndex = 57;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmWarrantyRegs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 469);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rbtSMS);
            this.Controls.Add(this.rbtFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.cboSearchOn);
            this.Controls.Add(this.lvwWarrantyRegister);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWarrantyRegs";
            this.Text = "Warranty Register";
            this.Load += new System.EventHandler(this.frmWarrantyRegs_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwWarrantyRegister;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewWarrantyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyWarrantyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWarrantyToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colCustomerAddress;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colPurchaseDate;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colEntryDate;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ComboBox cboSearchOn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtFinal;
        private System.Windows.Forms.RadioButton rbtSMS;
        private System.Windows.Forms.Button btnPrint;
    }
}