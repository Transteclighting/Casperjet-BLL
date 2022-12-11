namespace CJ.Win.IT
{
    partial class frmITEquipments
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwITAssetList = new System.Windows.Forms.ListView();
            this.colAssetNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModelNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBarnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCuser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCSotre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAsset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btHistory = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.colPurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(788, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 27);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btndelete.Location = new System.Drawing.Point(788, 172);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(89, 27);
            this.btndelete.TabIndex = 77;
            this.btndelete.Tag = "M1.20";
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(788, 134);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 27);
            this.btnEdit.TabIndex = 76;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(788, 101);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 27);
            this.btnAdd.TabIndex = 75;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwITAssetList
            // 
            this.lvwITAssetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwITAssetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssetNo,
            this.colSerialNo,
            this.colModelNo,
            this.colBarnd,
            this.colProductNo,
            this.colPurchaseDate,
            this.colCuser,
            this.colCSotre});
            this.lvwITAssetList.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwITAssetList.FullRowSelect = true;
            this.lvwITAssetList.GridLines = true;
            this.lvwITAssetList.HideSelection = false;
            this.lvwITAssetList.Location = new System.Drawing.Point(12, 101);
            this.lvwITAssetList.MultiSelect = false;
            this.lvwITAssetList.Name = "lvwITAssetList";
            this.lvwITAssetList.Size = new System.Drawing.Size(770, 340);
            this.lvwITAssetList.TabIndex = 74;
            this.lvwITAssetList.UseCompatibleStateImageBehavior = false;
            this.lvwITAssetList.View = System.Windows.Forms.View.Details;
            this.lvwITAssetList.DoubleClick += new System.EventHandler(this.lvwITAssetList_DoubleClick);
            // 
            // colAssetNo
            // 
            this.colAssetNo.Text = "Asset Number";
            this.colAssetNo.Width = 150;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "Serial No";
            this.colSerialNo.Width = 150;
            // 
            // colModelNo
            // 
            this.colModelNo.Text = "Model Number";
            this.colModelNo.Width = 150;
            // 
            // colBarnd
            // 
            this.colBarnd.Text = "Brand";
            this.colBarnd.Width = 150;
            // 
            // colProductNo
            // 
            this.colProductNo.Text = "Product Number";
            this.colProductNo.Width = 150;
            // 
            // colCuser
            // 
            this.colCuser.Text = "Current User";
            this.colCuser.Width = 150;
            // 
            // colCSotre
            // 
            this.colCSotre.Text = "Current Stock";
            this.colCSotre.Width = 120;
            // 
            // txtAsset
            // 
            this.txtAsset.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtAsset.Location = new System.Drawing.Point(106, 8);
            this.txtAsset.Name = "txtAsset";
            this.txtAsset.Size = new System.Drawing.Size(162, 23);
            this.txtAsset.TabIndex = 80;
            this.txtAsset.TextChanged += new System.EventHandler(this.txtAsset_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 79;
            this.label1.Text = "Asset Number";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtSerial.Location = new System.Drawing.Point(106, 37);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(162, 23);
            this.txtSerial.TabIndex = 82;
            this.txtSerial.TextChanged += new System.EventHandler(this.txtAsset_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 81;
            this.label2.Text = "Serial Number";
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtBrand.Location = new System.Drawing.Point(379, 37);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(174, 23);
            this.txtBrand.TabIndex = 86;
            this.txtBrand.TextChanged += new System.EventHandler(this.txtAsset_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(336, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 85;
            this.label3.Text = "Brand";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtModelNo.Location = new System.Drawing.Point(379, 8);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(174, 23);
            this.txtModelNo.TabIndex = 84;
            this.txtModelNo.TextChanged += new System.EventHandler(this.txtAsset_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(281, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 83;
            this.label4.Text = "Model Number";
            // 
            // btHistory
            // 
            this.btHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHistory.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btHistory.Location = new System.Drawing.Point(788, 205);
            this.btHistory.Name = "btHistory";
            this.btHistory.Size = new System.Drawing.Size(89, 27);
            this.btHistory.TabIndex = 87;
            this.btHistory.Tag = "M1.20";
            this.btHistory.Text = "Show History";
            this.btHistory.UseVisualStyleBackColor = true;
            this.btHistory.Click += new System.EventHandler(this.btHistory_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label15.Location = new System.Drawing.Point(559, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 15);
            this.label15.TabIndex = 88;
            this.label15.Text = "Type Name";
            // 
            // cbTypeName
            // 
            this.cbTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Location = new System.Drawing.Point(638, 8);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(137, 23);
            this.cbTypeName.TabIndex = 89;
            this.cbTypeName.SelectedIndexChanged += new System.EventHandler(this.cbTypeName_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGo.Location = new System.Drawing.Point(693, 68);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(89, 27);
            this.btnGo.TabIndex = 90;
            this.btnGo.Text = "Search";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(36, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 92;
            this.label10.Text = "Employee";
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.Text = "Purchase Date";
            this.colPurchaseDate.Width = 120;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.ctlEmployee1.Location = new System.Drawing.Point(106, 68);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(453, 25);
            this.ctlEmployee1.TabIndex = 91;
            // 
            // frmITEquipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 453);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbTypeName);
            this.Controls.Add(this.btHistory);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAsset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwITAssetList);
            this.Name = "frmITEquipments";
            this.Text = "frmITEquipments";
            this.Load += new System.EventHandler(this.frmITEquipments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwITAssetList;
        private System.Windows.Forms.ColumnHeader colAssetNo;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.TextBox txtAsset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colModelNo;
        private System.Windows.Forms.ColumnHeader colBarnd;
        private System.Windows.Forms.ColumnHeader colProductNo;
        private System.Windows.Forms.ColumnHeader colCuser;
        private System.Windows.Forms.ColumnHeader colCSotre;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btHistory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label10;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.ColumnHeader colPurchaseDate;
    }
}