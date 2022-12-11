namespace CJ.Win.Promotion
{
    partial class frmSalesPromotionCentral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtForQty = new System.Windows.Forms.TextBox();
            this.dgvPromoProduct = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvwChannel = new System.Windows.Forms.ListView();
            this.colChannelCode = new System.Windows.Forms.ColumnHeader();
            this.colChannelName = new System.Windows.Forms.ColumnHeader();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvwCustomerType = new System.Windows.Forms.ListView();
            this.colCustomerType = new System.Windows.Forms.ColumnHeader();
            this.colChannel = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvOfferProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoAmount = new System.Windows.Forms.RadioButton();
            this.rdoPercente = new System.Windows.Forms.RadioButton();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoProduct = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromoProduct)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferProduct)).BeginInit();
            this.groupBox5.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Info";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(611, 20);
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
            this.dtEndDate.Location = new System.Drawing.Point(578, 12);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(114, 20);
            this.dtEndDate.TabIndex = 32;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(441, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(108, 20);
            this.dtStartDate.TabIndex = 31;
            // 
            // txtPromotionNo
            // 
            this.txtPromotionNo.Enabled = false;
            this.txtPromotionNo.Location = new System.Drawing.Point(81, 12);
            this.txtPromotionNo.Name = "txtPromotionNo";
            this.txtPromotionNo.Size = new System.Drawing.Size(197, 20);
            this.txtPromotionNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 15);
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
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtForQty);
            this.groupBox2.Controls.Add(this.dgvPromoProduct);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(9, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 199;
            this.label6.Text = "For Qunaitity:";
            // 
            // txtForQty
            // 
            this.txtForQty.Location = new System.Drawing.Point(384, 231);
            this.txtForQty.Name = "txtForQty";
            this.txtForQty.Size = new System.Drawing.Size(57, 20);
            this.txtForQty.TabIndex = 199;
            // 
            // dgvPromoProduct
            // 
            this.dgvPromoProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromoProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.ProductID});
            this.dgvPromoProduct.Location = new System.Drawing.Point(9, 18);
            this.dgvPromoProduct.Name = "dgvPromoProduct";
            this.dgvPromoProduct.Size = new System.Drawing.Size(432, 207);
            this.dgvPromoProduct.TabIndex = 6;
            this.dgvPromoProduct.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromoProduct_CellValueChanged);
            this.dgvPromoProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromoProduct_CellContentClick);
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
            this.txtProductDescription.Width = 250;
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
            this.groupBox4.Location = new System.Drawing.Point(466, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 114);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Channel";
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
            this.lvwChannel.Size = new System.Drawing.Size(222, 92);
            this.lvwChannel.TabIndex = 186;
            this.lvwChannel.UseCompatibleStateImageBehavior = false;
            this.lvwChannel.View = System.Windows.Forms.View.Details;
            // 
            // colChannelCode
            // 
            this.colChannelCode.Text = " Code";
            this.colChannelCode.Width = 50;
            // 
            // colChannelName
            // 
            this.colChannelName.Text = "Channel Name";
            this.colChannelName.Width = 159;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvwCustomerType);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(466, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(235, 140);
            this.groupBox6.TabIndex = 189;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Customer Type";
            // 
            // lvwCustomerType
            // 
            this.lvwCustomerType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomerType.CheckBoxes = true;
            this.lvwCustomerType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerType,
            this.colChannel});
            this.lvwCustomerType.FullRowSelect = true;
            this.lvwCustomerType.GridLines = true;
            this.lvwCustomerType.HideSelection = false;
            this.lvwCustomerType.Location = new System.Drawing.Point(6, 17);
            this.lvwCustomerType.Name = "lvwCustomerType";
            this.lvwCustomerType.Size = new System.Drawing.Size(223, 117);
            this.lvwCustomerType.TabIndex = 187;
            this.lvwCustomerType.UseCompatibleStateImageBehavior = false;
            this.lvwCustomerType.View = System.Windows.Forms.View.Details;
            // 
            // colCustomerType
            // 
            this.colCustomerType.Text = "Customer Type";
            this.colCustomerType.Width = 140;
            // 
            // colChannel
            // 
            this.colChannel.Text = "Channel";
            this.colChannel.Width = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(9, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(707, 278);
            this.groupBox3.TabIndex = 190;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Promotion For";
            // 
            // dgvOfferProduct
            // 
            this.dgvOfferProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfferProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colQty,
            this.dataGridViewTextBoxColumn3});
            this.dgvOfferProduct.Location = new System.Drawing.Point(14, 38);
            this.dgvOfferProduct.Name = "dgvOfferProduct";
            this.dgvOfferProduct.Size = new System.Drawing.Size(679, 73);
            this.dgvOfferProduct.TabIndex = 8;
            this.dgvOfferProduct.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfferProduct_CellValueChanged);
            this.dgvOfferProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfferProduct_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewButtonColumn1.Frozen = true;
            this.dataGridViewButtonColumn1.HeaderText = "?";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "...";
            this.dataGridViewButtonColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // colQty
            // 
            this.colQty.Frozen = true;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.Location = new System.Drawing.Point(242, 14);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(87, 17);
            this.rdoAmount.TabIndex = 197;
            this.rdoAmount.TabStop = true;
            this.rdoAmount.Text = "Amount (Flat)";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.Visible = false;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoAmount_CheckedChanged);
            // 
            // rdoPercente
            // 
            this.rdoPercente.AutoSize = true;
            this.rdoPercente.Location = new System.Drawing.Point(160, 14);
            this.rdoPercente.Name = "rdoPercente";
            this.rdoPercente.Size = new System.Drawing.Size(79, 17);
            this.rdoPercente.TabIndex = 196;
            this.rdoPercente.TabStop = true;
            this.rdoPercente.Text = "Percent (%)";
            this.rdoPercente.UseVisualStyleBackColor = true;
            this.rdoPercente.Visible = false;
            this.rdoPercente.CheckedChanged += new System.EventHandler(this.rdoPercente_CheckedChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(330, 13);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(84, 20);
            this.txtDiscount.TabIndex = 194;
            this.txtDiscount.Visible = false;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(420, 17);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 195;
            this.lblPercent.Text = "%";
            this.lblPercent.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 193;
            this.label5.Text = "Offer Type:";
            // 
            // rdoProduct
            // 
            this.rdoProduct.AutoSize = true;
            this.rdoProduct.Location = new System.Drawing.Point(95, 14);
            this.rdoProduct.Name = "rdoProduct";
            this.rdoProduct.Size = new System.Drawing.Size(62, 17);
            this.rdoProduct.TabIndex = 198;
            this.rdoProduct.TabStop = true;
            this.rdoProduct.Text = "Product";
            this.rdoProduct.UseVisualStyleBackColor = true;
            this.rdoProduct.CheckedChanged += new System.EventHandler(this.rdoProduct_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoProduct);
            this.groupBox5.Controls.Add(this.rdoAmount);
            this.groupBox5.Controls.Add(this.rdoPercente);
            this.groupBox5.Controls.Add(this.txtDiscount);
            this.groupBox5.Controls.Add(this.lblPercent);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.dgvOfferProduct);
            this.groupBox5.Location = new System.Drawing.Point(9, 353);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(706, 116);
            this.groupBox5.TabIndex = 199;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Offer";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(564, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 201;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 200;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSalesPromotionCentral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 503);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSalesPromotionCentral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSalesPromotionCentral";
            this.Load += new System.EventHandler(this.frmSalesPromotionCentral_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromoProduct)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferProduct)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtPromotionNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPromoProduct;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lvwChannel;
        private System.Windows.Forms.ColumnHeader colChannelCode;
        private System.Windows.Forms.ColumnHeader colChannelName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvwCustomerType;
        private System.Windows.Forms.ColumnHeader colCustomerType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvOfferProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.RadioButton rdoAmount;
        private System.Windows.Forms.RadioButton rdoPercente;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoProduct;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colChannel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtForQty;
    }
}