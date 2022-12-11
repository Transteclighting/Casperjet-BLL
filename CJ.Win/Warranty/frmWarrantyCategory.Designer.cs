namespace CJ.Win.Warranty
{
    partial class frmWarrantyCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtService = new System.Windows.Forms.TextBox();
            this.txtSpare = new System.Windows.Forms.TextBox();
            this.txtSpecial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(334, 20);
            this.txtName.TabIndex = 1;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.ColProductId});
            this.dgvLineItem.Location = new System.Drawing.Point(8, 169);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(432, 217);
            this.dgvLineItem.TabIndex = 12;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged_1);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick_1);
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
            this.txtProductDescription.HeaderText = "Product Name";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 250;
            // 
            // ColProductId
            // 
            this.ColProductId.HeaderText = "ProductId";
            this.ColProductId.Name = "ColProductId";
            this.ColProductId.ReadOnly = true;
            this.ColProductId.Visible = false;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(144, 390);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSpecial);
            this.groupBox1.Controls.Add(this.txtSpare);
            this.groupBox1.Controls.Add(this.txtService);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 131);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warranty Category Parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Service Validity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Spare Validity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Special Part Validity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Effective From";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(188, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(138, 20);
            this.dtFromDate.TabIndex = 33;
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(188, 51);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(100, 20);
            this.txtService.TabIndex = 34;
            // 
            // txtSpare
            // 
            this.txtSpare.Location = new System.Drawing.Point(188, 77);
            this.txtSpare.Name = "txtSpare";
            this.txtSpare.Size = new System.Drawing.Size(100, 20);
            this.txtSpare.TabIndex = 35;
            // 
            // txtSpecial
            // 
            this.txtSpecial.Location = new System.Drawing.Point(188, 102);
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.Size = new System.Drawing.Size(100, 20);
            this.txtSpecial.TabIndex = 36;
            // 
            // frmWarrantyCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmWarrantyCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warranty Category";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductId;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpecial;
        private System.Windows.Forms.TextBox txtSpare;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.DateTimePicker dtFromDate;
    }
}