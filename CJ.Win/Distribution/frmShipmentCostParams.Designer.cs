namespace CJ.Win.Distribution
{
    partial class frmShipmentCostParams
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProductCodeU = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductNameU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyU = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.lblTotalMapping = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwShipmentUnMap = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwShipmentMapp = new System.Windows.Forms.ListView();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProductCodeU);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCompany);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtProductNameU);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(5, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 90);
            this.groupBox2.TabIndex = 234;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search (Un Map List)";
            // 
            // txtProductCodeU
            // 
            this.txtProductCodeU.Location = new System.Drawing.Point(91, 35);
            this.txtProductCodeU.Name = "txtProductCodeU";
            this.txtProductCodeU.Size = new System.Drawing.Size(124, 20);
            this.txtProductCodeU.TabIndex = 224;
            this.txtProductCodeU.TextChanged += new System.EventHandler(this.txtProductCodeU_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 223;
            this.label7.Text = "Product Code";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(91, 13);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(220, 20);
            this.txtCompany.TabIndex = 222;
            this.txtCompany.TextChanged += new System.EventHandler(this.txtCompany_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 221;
            this.label10.Text = "Company";
            // 
            // txtProductNameU
            // 
            this.txtProductNameU.Location = new System.Drawing.Point(91, 59);
            this.txtProductNameU.Name = "txtProductNameU";
            this.txtProductNameU.Size = new System.Drawing.Size(220, 20);
            this.txtProductNameU.TabIndex = 214;
            this.txtProductNameU.TextChanged += new System.EventHandler(this.txtProductNameU_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Product Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompanyU);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Location = new System.Drawing.Point(457, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 89);
            this.groupBox1.TabIndex = 233;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search (Mapped List)";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(94, 34);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(124, 20);
            this.txtProductCode.TabIndex = 179;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 180;
            this.label2.Text = "Product Code";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(94, 56);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(220, 20);
            this.txtProductName.TabIndex = 171;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "Product Name";
            // 
            // txtCompanyU
            // 
            this.txtCompanyU.Location = new System.Drawing.Point(94, 11);
            this.txtCompanyU.Name = "txtCompanyU";
            this.txtCompanyU.Size = new System.Drawing.Size(220, 20);
            this.txtCompanyU.TabIndex = 169;
            this.txtCompanyU.TextChanged += new System.EventHandler(this.txtCompanyU_TextChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(33, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(58, 13);
            this.lblCompany.TabIndex = 170;
            this.lblCompany.Text = "Company";
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Location = new System.Drawing.Point(178, 468);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAll.TabIndex = 232;
            this.lblTotalAll.Text = "?";
            // 
            // lblTotalMapping
            // 
            this.lblTotalMapping.AutoSize = true;
            this.lblTotalMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMapping.Location = new System.Drawing.Point(641, 468);
            this.lblTotalMapping.Name = "lblTotalMapping";
            this.lblTotalMapping.Size = new System.Drawing.Size(19, 20);
            this.lblTotalMapping.TabIndex = 231;
            this.lblTotalMapping.Text = "?";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(627, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 230;
            this.label6.Text = "Mapped List";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 229;
            this.label5.Text = "Un Map List";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(412, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 27);
            this.btnDelete.TabIndex = 228;
            this.btnDelete.Text = "<=";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(411, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 27);
            this.btnAdd.TabIndex = 227;
            this.btnAdd.Text = "=>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwShipmentUnMap
            // 
            this.lvwShipmentUnMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwShipmentUnMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwShipmentUnMap.FullRowSelect = true;
            this.lvwShipmentUnMap.GridLines = true;
            this.lvwShipmentUnMap.Location = new System.Drawing.Point(2, 121);
            this.lvwShipmentUnMap.MultiSelect = false;
            this.lvwShipmentUnMap.Name = "lvwShipmentUnMap";
            this.lvwShipmentUnMap.Size = new System.Drawing.Size(409, 329);
            this.lvwShipmentUnMap.TabIndex = 226;
            this.lvwShipmentUnMap.UseCompatibleStateImageBehavior = false;
            this.lvwShipmentUnMap.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Company";
            this.columnHeader1.Width = 57;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product Code";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 169;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(790, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 225;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwShipmentMapp
            // 
            this.lvwShipmentMapp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwShipmentMapp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colProductName,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwShipmentMapp.FullRowSelect = true;
            this.lvwShipmentMapp.GridLines = true;
            this.lvwShipmentMapp.Location = new System.Drawing.Point(459, 122);
            this.lvwShipmentMapp.MultiSelect = false;
            this.lvwShipmentMapp.Name = "lvwShipmentMapp";
            this.lvwShipmentMapp.Size = new System.Drawing.Size(426, 329);
            this.lvwShipmentMapp.TabIndex = 224;
            this.lvwShipmentMapp.UseCompatibleStateImageBehavior = false;
            this.lvwShipmentMapp.View = System.Windows.Forms.View.Details;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 63;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Code";
            this.colProductName.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 191;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cost";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "IC";
            this.columnHeader6.Width = 33;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IA";
            this.columnHeader7.Width = 28;
            // 
            // frmShipmentCostParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 492);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalMapping);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwShipmentUnMap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwShipmentMapp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShipmentCostParams";
            this.Text = "Shipment Cost";
            this.Load += new System.EventHandler(this.frmShipmentCostParams_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductNameU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyU;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.Label lblTotalMapping;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwShipmentUnMap;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwShipmentMapp;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtProductCodeU;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;

    }
}