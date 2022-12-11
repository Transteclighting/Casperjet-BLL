namespace CJ.Win.POS
{
    partial class frmDataTransfer
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
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTransferType = new System.Windows.Forms.ComboBox();
            this.lvwDataList = new System.Windows.Forms.ListView();
            this.colDataID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataDes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lvwOutlet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutlet = new System.Windows.Forms.TextBox();
            this.chkOutlet = new System.Windows.Forms.CheckBox();
            this.chkData = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTableName
            // 
            this.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableName.FormattingEnabled = true;
            this.cmbTableName.Items.AddRange(new object[] {
            "<<  Select Table Name >>",
            "t_Brand",
            "t_ProductGroup",
            "v_productDetails",
            "v_EmployeeDetails",
            "t_Showroom",
            "t_SalesPromotion",
            "t_WarrantyParam",
            "t_FinishedGoodsPrice",
            "t_user"});
            this.cmbTableName.Location = new System.Drawing.Point(86, 14);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(202, 21);
            this.cmbTableName.TabIndex = 9;
            this.cmbTableName.SelectedIndexChanged += new System.EventHandler(this.cmbTableName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Transfer Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Table Name:";
            // 
            // cmbTransferType
            // 
            this.cmbTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferType.FormattingEnabled = true;
            this.cmbTransferType.Location = new System.Drawing.Point(412, 12);
            this.cmbTransferType.Name = "cmbTransferType";
            this.cmbTransferType.Size = new System.Drawing.Size(165, 21);
            this.cmbTransferType.TabIndex = 26;
            // 
            // lvwDataList
            // 
            this.lvwDataList.CheckBoxes = true;
            this.lvwDataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDataID,
            this.colDataDes});
            this.lvwDataList.FullRowSelect = true;
            this.lvwDataList.GridLines = true;
            this.lvwDataList.HideSelection = false;
            this.lvwDataList.Location = new System.Drawing.Point(7, 36);
            this.lvwDataList.MultiSelect = false;
            this.lvwDataList.Name = "lvwDataList";
            this.lvwDataList.Size = new System.Drawing.Size(311, 349);
            this.lvwDataList.TabIndex = 27;
            this.lvwDataList.UseCompatibleStateImageBehavior = false;
            this.lvwDataList.View = System.Windows.Forms.View.Details;
            // 
            // colDataID
            // 
            this.colDataID.Text = "Data ID";
            this.colDataID.Width = 72;
            // 
            // colDataDes
            // 
            this.colDataDes.Text = "Data Description";
            this.colDataDes.Width = 227;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(462, 448);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 29;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(543, 448);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 30;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lvwOutlet
            // 
            this.lvwOutlet.CheckBoxes = true;
            this.lvwOutlet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwOutlet.FullRowSelect = true;
            this.lvwOutlet.GridLines = true;
            this.lvwOutlet.HideSelection = false;
            this.lvwOutlet.Location = new System.Drawing.Point(8, 35);
            this.lvwOutlet.MultiSelect = false;
            this.lvwOutlet.Name = "lvwOutlet";
            this.lvwOutlet.Size = new System.Drawing.Size(296, 349);
            this.lvwOutlet.TabIndex = 31;
            this.lvwOutlet.UseCompatibleStateImageBehavior = false;
            this.lvwOutlet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Outlet ID";
            this.columnHeader1.Width = 59;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Outlet Name";
            this.columnHeader2.Width = 225;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutlet);
            this.groupBox1.Controls.Add(this.chkOutlet);
            this.groupBox1.Controls.Add(this.lvwOutlet);
            this.groupBox1.Location = new System.Drawing.Point(337, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 392);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outlet List";
            // 
            // txtOutlet
            // 
            this.txtOutlet.Location = new System.Drawing.Point(66, 9);
            this.txtOutlet.Name = "txtOutlet";
            this.txtOutlet.Size = new System.Drawing.Size(225, 20);
            this.txtOutlet.TabIndex = 35;
            this.txtOutlet.TextChanged += new System.EventHandler(this.txtOutlet_TextChanged);
            // 
            // chkOutlet
            // 
            this.chkOutlet.AutoSize = true;
            this.chkOutlet.Location = new System.Drawing.Point(10, 16);
            this.chkOutlet.Name = "chkOutlet";
            this.chkOutlet.Size = new System.Drawing.Size(15, 14);
            this.chkOutlet.TabIndex = 32;
            this.chkOutlet.UseVisualStyleBackColor = true;
            this.chkOutlet.CheckedChanged += new System.EventHandler(this.chkOutlet_CheckedChanged);
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.Location = new System.Drawing.Point(11, 17);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(15, 14);
            this.chkData.TabIndex = 33;
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.CheckedChanged += new System.EventHandler(this.chkData_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.chkData);
            this.groupBox2.Controls.Add(this.lvwDataList);
            this.groupBox2.Location = new System.Drawing.Point(6, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 392);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data List";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 10);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(225, 20);
            this.txtDescription.TabIndex = 34;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // frmDataTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.cmbTransferType);
            this.Controls.Add(this.cmbTableName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmDataTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Transfer";
            this.Load += new System.EventHandler(this.frmDataTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTransferType;
        private System.Windows.Forms.ListView lvwDataList;
        private System.Windows.Forms.ColumnHeader colDataID;
        private System.Windows.Forms.ColumnHeader colDataDes;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView lvwOutlet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOutlet;
        private System.Windows.Forms.CheckBox chkData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutlet;
        private System.Windows.Forms.TextBox txtDescription;

    }
}