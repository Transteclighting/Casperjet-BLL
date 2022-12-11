namespace CJ.Win
{
    partial class frmProductMappings
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
            this.lvwProductMapping = new System.Windows.Forms.ListView();
            this.colProductERPCode = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colProductCategory = new System.Windows.Forms.ColumnHeader();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtERPCode = new System.Windows.Forms.TextBox();
            this.lblERPCode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwProductNonMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductCodeU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductNameU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.lblTotalMapping = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwProductMapping
            // 
            this.lvwProductMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductERPCode,
            this.colProductCode,
            this.colProductName,
            this.colProductCategory});
            this.lvwProductMapping.FullRowSelect = true;
            this.lvwProductMapping.GridLines = true;
            this.lvwProductMapping.Location = new System.Drawing.Point(396, 104);
            this.lvwProductMapping.MultiSelect = false;
            this.lvwProductMapping.Name = "lvwProductMapping";
            this.lvwProductMapping.Size = new System.Drawing.Size(471, 331);
            this.lvwProductMapping.TabIndex = 161;
            this.lvwProductMapping.UseCompatibleStateImageBehavior = false;
            this.lvwProductMapping.View = System.Windows.Forms.View.Details;
            this.lvwProductMapping.DoubleClick += new System.EventHandler(this.lvwProductMappings_DoubleClick);
            // 
            // colProductERPCode
            // 
            this.colProductERPCode.Text = "Product ERP Code";
            this.colProductERPCode.Width = 106;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 83;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 214;
            // 
            // colProductCategory
            // 
            this.colProductCategory.Text = "Prod Cat";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(149, 56);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(220, 20);
            this.txtProductName.TabIndex = 171;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "Product Name";
            // 
            // txtERPCode
            // 
            this.txtERPCode.Location = new System.Drawing.Point(149, 11);
            this.txtERPCode.Name = "txtERPCode";
            this.txtERPCode.Size = new System.Drawing.Size(124, 20);
            this.txtERPCode.TabIndex = 169;
            this.txtERPCode.TextChanged += new System.EventHandler(this.txtERPCode_TextChanged);
            // 
            // lblERPCode
            // 
            this.lblERPCode.AutoSize = true;
            this.lblERPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblERPCode.Location = new System.Drawing.Point(37, 14);
            this.lblERPCode.Name = "lblERPCode";
            this.lblERPCode.Size = new System.Drawing.Size(113, 13);
            this.lblERPCode.TabIndex = 170;
            this.lblERPCode.Text = "Product ERP Code";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(780, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 176;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(149, 34);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(124, 20);
            this.txtProductCode.TabIndex = 179;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 180;
            this.label2.Text = "Product Code";
            // 
            // lvwProductNonMapping
            // 
            this.lvwProductNonMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwProductNonMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwProductNonMapping.FullRowSelect = true;
            this.lvwProductNonMapping.GridLines = true;
            this.lvwProductNonMapping.Location = new System.Drawing.Point(4, 104);
            this.lvwProductNonMapping.MultiSelect = false;
            this.lvwProductNonMapping.Name = "lvwProductNonMapping";
            this.lvwProductNonMapping.Size = new System.Drawing.Size(335, 331);
            this.lvwProductNonMapping.TabIndex = 181;
            this.lvwProductNonMapping.UseCompatibleStateImageBehavior = false;
            this.lvwProductNonMapping.View = System.Windows.Forms.View.Details;
            this.lvwProductNonMapping.DoubleClick += new System.EventHandler(this.lvwProductNonMappings_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Code";
            this.columnHeader1.Width = 89;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Name";
            this.columnHeader2.Width = 235;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(345, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 27);
            this.button1.TabIndex = 198;
            this.button1.Text = "<=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(346, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 27);
            this.btnAdd.TabIndex = 197;
            this.btnAdd.Text = "=>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(598, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 213;
            this.label6.Text = "Mapped List";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 212;
            this.label5.Text = "Un Map List";
            // 
            // txtProductCodeU
            // 
            this.txtProductCodeU.Location = new System.Drawing.Point(91, 35);
            this.txtProductCodeU.Name = "txtProductCodeU";
            this.txtProductCodeU.Size = new System.Drawing.Size(124, 20);
            this.txtProductCodeU.TabIndex = 216;
            this.txtProductCodeU.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 217;
            this.label3.Text = "Product Code";
            // 
            // txtProductNameU
            // 
            this.txtProductNameU.Location = new System.Drawing.Point(91, 57);
            this.txtProductNameU.Name = "txtProductNameU";
            this.txtProductNameU.Size = new System.Drawing.Size(220, 20);
            this.txtProductNameU.TabIndex = 214;
            this.txtProductNameU.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Product Name";
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Location = new System.Drawing.Point(29, 444);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAll.TabIndex = 219;
            this.lblTotalAll.Text = "?";
            // 
            // lblTotalMapping
            // 
            this.lblTotalMapping.AutoSize = true;
            this.lblTotalMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMapping.Location = new System.Drawing.Point(446, 444);
            this.lblTotalMapping.Name = "lblTotalMapping";
            this.lblTotalMapping.Size = new System.Drawing.Size(19, 20);
            this.lblTotalMapping.TabIndex = 218;
            this.lblTotalMapping.Text = "?";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(91, 13);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(124, 20);
            this.dtFromDate.TabIndex = 220;
            this.dtFromDate.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 221;
            this.label10.Text = "Entry Date >=";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtERPCode);
            this.groupBox1.Controls.Add(this.lblERPCode);
            this.groupBox1.Location = new System.Drawing.Point(396, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 79);
            this.groupBox1.TabIndex = 222;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search (Mapped List)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtProductCodeU);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProductNameU);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 80);
            this.groupBox2.TabIndex = 223;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search (Un Map List)";
            // 
            // frmProductMappings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalMapping);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwProductNonMapping);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwProductMapping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Mappings";
            this.Load += new System.EventHandler(this.frmProductMappings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductMapping;
        private System.Windows.Forms.ColumnHeader colProductERPCode;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductCategory;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtERPCode;
        private System.Windows.Forms.Label lblERPCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwProductNonMapping;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductCodeU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductNameU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.Label lblTotalMapping;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}