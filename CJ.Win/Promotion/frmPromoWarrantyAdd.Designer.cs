namespace CJ.Win.Promotion
{
    partial class frmPromoWarrantyAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromoWarrantyAdd));
            this.label3 = new System.Windows.Forms.Label();
            this.txtExchangeWarranty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimefrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectProducts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(30, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 150;
            this.label3.Text = "Extended Warranty";
            // 
            // txtExchangeWarranty
            // 
            this.txtExchangeWarranty.Location = new System.Drawing.Point(183, 94);
            this.txtExchangeWarranty.Margin = new System.Windows.Forms.Padding(4);
            this.txtExchangeWarranty.Name = "txtExchangeWarranty";
            this.txtExchangeWarranty.Size = new System.Drawing.Size(631, 22);
            this.txtExchangeWarranty.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(80, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 148;
            this.label4.Text = "Description";
            // 
            // tDescription
            // 
            this.tDescription.Location = new System.Drawing.Point(183, 64);
            this.tDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(427, 22);
            this.tDescription.TabIndex = 147;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(563, 604);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 35);
            this.btnSave.TabIndex = 152;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(385, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 141;
            this.label1.Text = "To";
            // 
            // dateTimefrom
            // 
            this.dateTimefrom.CustomFormat = "dd-MMM-yyyy";
            this.dateTimefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimefrom.Location = new System.Drawing.Point(183, 32);
            this.dateTimefrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimefrom.Name = "dateTimefrom";
            this.dateTimefrom.Size = new System.Drawing.Size(191, 24);
            this.dateTimefrom.TabIndex = 140;
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.CustomFormat = "dd-MMM-yyyy";
            this.dateTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTo.Location = new System.Drawing.Point(419, 32);
            this.dateTimeTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(191, 24);
            this.dateTimeTo.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(84, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 139;
            this.label2.Text = "Start From";
            // 
            // SelectProducts
            // 
            this.SelectProducts.Location = new System.Drawing.Point(33, 135);
            this.SelectProducts.Margin = new System.Windows.Forms.Padding(4);
            this.SelectProducts.Name = "SelectProducts";
            this.SelectProducts.Size = new System.Drawing.Size(130, 29);
            this.SelectProducts.TabIndex = 154;
            this.SelectProducts.Text = "Get Product List";
            this.SelectProducts.UseVisualStyleBackColor = true;
            this.SelectProducts.Click += new System.EventHandler(this.SelectProducts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 604);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 35);
            this.button1.TabIndex = 155;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSKU,
            this.btnGet,
            this.ProductName,
            this.colProductID,
            this.colProductDescription});
            this.dgvProducts.Location = new System.Drawing.Point(33, 171);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(781, 426);
            this.dgvProducts.TabIndex = 5;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // colSKU
            // 
            this.colSKU.HeaderText = "Product Code";
            this.colSKU.Name = "colSKU";
            this.colSKU.Width = 150;
            // 
            // btnGet
            // 
            this.btnGet.HeaderText = "?";
            this.btnGet.Name = "btnGet";
            this.btnGet.Text = "...";
            this.btnGet.Width = 35;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 350;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colProductDescription
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.colProductDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.colProductDescription.HeaderText = "Description";
            this.colProductDescription.Name = "colProductDescription";
            this.colProductDescription.ReadOnly = true;
            this.colProductDescription.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Product ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 350;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // frmPromoWarrantyAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 652);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimefrom);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.dateTimeTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExchangeWarranty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelectProducts);
            this.Controls.Add(this.tDescription);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPromoWarrantyAdd";
            this.Text = "Add Promo Warranty";
            this.Load += new System.EventHandler(this.frmPromoWarrantyAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimefrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExchangeWarranty;
        private System.Windows.Forms.Button SelectProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewButtonColumn btnGet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductDescription;
    }
}