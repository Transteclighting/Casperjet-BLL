namespace CJ.Win.Promotion
{
    partial class frmSalesPromotion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPromotionNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvwChannel = new System.Windows.Forms.ListView();
            this.colChannelCode = new System.Windows.Forms.ColumnHeader();
            this.colChannelName = new System.Windows.Forms.ColumnHeader();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.llbEdit = new System.Windows.Forms.LinkLabel();
            this.lvwSlab = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.llbDeleteSlab = new System.Windows.Forms.LinkLabel();
            this.llbAddSlab = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.chkbAll = new System.Windows.Forms.CheckBox();
            this.lvwWarehouse = new System.Windows.Forms.ListView();
            this.colShowroomCode = new System.Windows.Forms.ColumnHeader();
            this.colShowroomtName = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvwPromotionType = new System.Windows.Forms.ListView();
            this.colPromotionType = new System.Windows.Forms.ColumnHeader();
            this.chkPromoTypeAll = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.txtPromotionNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(628, 20);
            this.txtDescription.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Description";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(571, 12);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(138, 20);
            this.dtEndDate.TabIndex = 32;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(345, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(138, 20);
            this.dtStartDate.TabIndex = 31;
            // 
            // txtPromotionNo
            // 
            this.txtPromotionNo.Enabled = false;
            this.txtPromotionNo.Location = new System.Drawing.Point(81, 12);
            this.txtPromotionNo.Name = "txtPromotionNo";
            this.txtPromotionNo.Size = new System.Drawing.Size(113, 20);
            this.txtPromotionNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Effect Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promotion No";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLineItem);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(335, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Promotional Product";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(7, 19);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(368, 133);
            this.dgvLineItem.TabIndex = 6;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 190;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvwChannel);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(335, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 142);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "For Channel";
            // 
            // lvwChannel
            // 
            this.lvwChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwChannel.CheckBoxes = true;
            this.lvwChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChannelCode,
            this.colChannelName});
            this.lvwChannel.FullRowSelect = true;
            this.lvwChannel.GridLines = true;
            this.lvwChannel.HideSelection = false;
            this.lvwChannel.Location = new System.Drawing.Point(7, 16);
            this.lvwChannel.Name = "lvwChannel";
            this.lvwChannel.Size = new System.Drawing.Size(371, 120);
            this.lvwChannel.TabIndex = 186;
            this.lvwChannel.UseCompatibleStateImageBehavior = false;
            this.lvwChannel.View = System.Windows.Forms.View.Details;
            // 
            // colChannelCode
            // 
            this.colChannelCode.Text = " Code";
            this.colChannelCode.Width = 82;
            // 
            // colChannelName
            // 
            this.colChannelName.Text = "Channel Name";
            this.colChannelName.Width = 250;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.llbEdit);
            this.groupBox5.Controls.Add(this.lvwSlab);
            this.groupBox5.Controls.Add(this.llbDeleteSlab);
            this.groupBox5.Controls.Add(this.llbAddSlab);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(4, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(325, 305);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Promotional Slab";
            // 
            // llbEdit
            // 
            this.llbEdit.AutoSize = true;
            this.llbEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbEdit.LinkColor = System.Drawing.Color.Black;
            this.llbEdit.Location = new System.Drawing.Point(184, 13);
            this.llbEdit.Name = "llbEdit";
            this.llbEdit.Size = new System.Drawing.Size(58, 13);
            this.llbEdit.TabIndex = 186;
            this.llbEdit.TabStop = true;
            this.llbEdit.Text = "Edit Slab";
            this.llbEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbEdit_LinkClicked);
            // 
            // lvwSlab
            // 
            this.lvwSlab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSlab.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwSlab.FullRowSelect = true;
            this.lvwSlab.GridLines = true;
            this.lvwSlab.HideSelection = false;
            this.lvwSlab.Location = new System.Drawing.Point(5, 34);
            this.lvwSlab.Name = "lvwSlab";
            this.lvwSlab.Size = new System.Drawing.Size(312, 265);
            this.lvwSlab.TabIndex = 185;
            this.lvwSlab.UseCompatibleStateImageBehavior = false;
            this.lvwSlab.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Slab No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Slab Name";
            this.columnHeader2.Width = 244;
            // 
            // llbDeleteSlab
            // 
            this.llbDeleteSlab.AutoSize = true;
            this.llbDeleteSlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbDeleteSlab.LinkColor = System.Drawing.Color.Black;
            this.llbDeleteSlab.Location = new System.Drawing.Point(244, 13);
            this.llbDeleteSlab.Name = "llbDeleteSlab";
            this.llbDeleteSlab.Size = new System.Drawing.Size(73, 13);
            this.llbDeleteSlab.TabIndex = 1;
            this.llbDeleteSlab.TabStop = true;
            this.llbDeleteSlab.Text = "Delete Slab";
            this.llbDeleteSlab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDeleteSlab_LinkClicked);
            // 
            // llbAddSlab
            // 
            this.llbAddSlab.AutoSize = true;
            this.llbAddSlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbAddSlab.LinkColor = System.Drawing.Color.Black;
            this.llbAddSlab.Location = new System.Drawing.Point(122, 13);
            this.llbAddSlab.Name = "llbAddSlab";
            this.llbAddSlab.Size = new System.Drawing.Size(58, 13);
            this.llbAddSlab.TabIndex = 0;
            this.llbAddSlab.TabStop = true;
            this.llbAddSlab.Text = "Add Slab";
            this.llbAddSlab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAddSlab_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbTotal);
            this.groupBox3.Controls.Add(this.chkbAll);
            this.groupBox3.Controls.Add(this.lvwWarehouse);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(335, 373);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 152);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For Showroom";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(80, 15);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(0, 13);
            this.lbTotal.TabIndex = 186;
            // 
            // chkbAll
            // 
            this.chkbAll.AutoSize = true;
            this.chkbAll.Location = new System.Drawing.Point(305, 11);
            this.chkbAll.Name = "chkbAll";
            this.chkbAll.Size = new System.Drawing.Size(70, 17);
            this.chkbAll.TabIndex = 185;
            this.chkbAll.Text = "Select All";
            this.chkbAll.UseVisualStyleBackColor = true;
            this.chkbAll.CheckedChanged += new System.EventHandler(this.chkbAll_CheckedChanged);
            // 
            // lvwWarehouse
            // 
            this.lvwWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWarehouse.CheckBoxes = true;
            this.lvwWarehouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowroomCode,
            this.colShowroomtName});
            this.lvwWarehouse.FullRowSelect = true;
            this.lvwWarehouse.GridLines = true;
            this.lvwWarehouse.HideSelection = false;
            this.lvwWarehouse.Location = new System.Drawing.Point(7, 29);
            this.lvwWarehouse.Name = "lvwWarehouse";
            this.lvwWarehouse.Size = new System.Drawing.Size(371, 114);
            this.lvwWarehouse.TabIndex = 184;
            this.lvwWarehouse.UseCompatibleStateImageBehavior = false;
            this.lvwWarehouse.View = System.Windows.Forms.View.Details;
            // 
            // colShowroomCode
            // 
            this.colShowroomCode.Text = " Code";
            this.colShowroomCode.Width = 82;
            // 
            // colShowroomtName
            // 
            this.colShowroomtName.Text = "Showroom Name";
            this.colShowroomtName.Width = 250;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(638, 529);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(557, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvwPromotionType
            // 
            this.lvwPromotionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPromotionType.CheckBoxes = true;
            this.lvwPromotionType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPromotionType});
            this.lvwPromotionType.FullRowSelect = true;
            this.lvwPromotionType.GridLines = true;
            this.lvwPromotionType.HideSelection = false;
            this.lvwPromotionType.Location = new System.Drawing.Point(6, 29);
            this.lvwPromotionType.Name = "lvwPromotionType";
            this.lvwPromotionType.Size = new System.Drawing.Size(311, 114);
            this.lvwPromotionType.TabIndex = 187;
            this.lvwPromotionType.UseCompatibleStateImageBehavior = false;
            this.lvwPromotionType.View = System.Windows.Forms.View.Details;
            // 
            // colPromotionType
            // 
            this.colPromotionType.Text = "Promotion Type";
            this.colPromotionType.Width = 250;
            // 
            // chkPromoTypeAll
            // 
            this.chkPromoTypeAll.AutoSize = true;
            this.chkPromoTypeAll.Location = new System.Drawing.Point(244, 10);
            this.chkPromoTypeAll.Name = "chkPromoTypeAll";
            this.chkPromoTypeAll.Size = new System.Drawing.Size(70, 17);
            this.chkPromoTypeAll.TabIndex = 187;
            this.chkPromoTypeAll.Text = "Select All";
            this.chkPromoTypeAll.UseVisualStyleBackColor = true;
            this.chkPromoTypeAll.CheckedChanged += new System.EventHandler(this.chkPromoTypeAll_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkPromoTypeAll);
            this.groupBox6.Controls.Add(this.lvwPromotionType);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(5, 373);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(325, 152);
            this.groupBox6.TabIndex = 188;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Promotion Type";
            // 
            // frmSalesPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 554);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSalesPromotion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Promotion";
            this.Load += new System.EventHandler(this.frmSalesPromotion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPromotionNo;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel llbDeleteSlab;
        private System.Windows.Forms.LinkLabel llbAddSlab;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkbAll;
        private System.Windows.Forms.ListView lvwWarehouse;
        private System.Windows.Forms.ColumnHeader colShowroomCode;
        private System.Windows.Forms.ColumnHeader colShowroomtName;
        private System.Windows.Forms.ListView lvwChannel;
        private System.Windows.Forms.ColumnHeader colChannelCode;
        private System.Windows.Forms.ColumnHeader colChannelName;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvwSlab;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.LinkLabel llbEdit;
        private System.Windows.Forms.ListView lvwPromotionType;
        private System.Windows.Forms.ColumnHeader colPromotionType;
        private System.Windows.Forms.CheckBox chkPromoTypeAll;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}