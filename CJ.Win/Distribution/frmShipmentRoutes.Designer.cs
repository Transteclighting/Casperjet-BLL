namespace CJ.Win.Distribution
{
    partial class frmShipmentRoutes
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
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomerNameU = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerIdU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTTypeU = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRouteIdU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyU = new System.Windows.Forms.TextBox();
            this.lblERPCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalMapping = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvwRouteNonMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lvwRouteMapping = new System.Windows.Forms.ListView();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colRoute = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(117, 82);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerName.TabIndex = 199;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomerNameU);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCustomerIdU);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTTypeU);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtRouteIdU);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompanyU);
            this.groupBox1.Controls.Add(this.lblERPCode);
            this.groupBox1.Location = new System.Drawing.Point(461, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 130);
            this.groupBox1.TabIndex = 224;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search (Mapped List)";
            // 
            // txtCustomerNameU
            // 
            this.txtCustomerNameU.Location = new System.Drawing.Point(140, 102);
            this.txtCustomerNameU.Name = "txtCustomerNameU";
            this.txtCustomerNameU.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerNameU.TabIndex = 218;
            this.txtCustomerNameU.TextChanged += new System.EventHandler(this.txtCustomerNameU_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 219;
            this.label9.Text = "Customer Name";
            // 
            // txtCustomerIdU
            // 
            this.txtCustomerIdU.Location = new System.Drawing.Point(140, 79);
            this.txtCustomerIdU.Name = "txtCustomerIdU";
            this.txtCustomerIdU.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerIdU.TabIndex = 216;
            this.txtCustomerIdU.TextChanged += new System.EventHandler(this.txtCustomerIdU_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 217;
            this.label2.Text = "Customer Code";
            // 
            // txtTTypeU
            // 
            this.txtTTypeU.Location = new System.Drawing.Point(140, 57);
            this.txtTTypeU.Name = "txtTTypeU";
            this.txtTTypeU.Size = new System.Drawing.Size(220, 20);
            this.txtTTypeU.TabIndex = 214;
            this.txtTTypeU.TextChanged += new System.EventHandler(this.txtTTypeU_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 215;
            this.label8.Text = "Transaction Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-429, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 82);
            this.groupBox2.TabIndex = 213;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search (Mapped List)";
            // 
            // txtRouteIdU
            // 
            this.txtRouteIdU.Location = new System.Drawing.Point(140, 35);
            this.txtRouteIdU.Name = "txtRouteIdU";
            this.txtRouteIdU.Size = new System.Drawing.Size(124, 20);
            this.txtRouteIdU.TabIndex = 184;
            this.txtRouteIdU.TextChanged += new System.EventHandler(this.txtRouteIdU_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 185;
            this.label1.Text = "Route Id";
            // 
            // txtCompanyU
            // 
            this.txtCompanyU.Location = new System.Drawing.Point(140, 13);
            this.txtCompanyU.Name = "txtCompanyU";
            this.txtCompanyU.Size = new System.Drawing.Size(220, 20);
            this.txtCompanyU.TabIndex = 182;
            this.txtCompanyU.TextChanged += new System.EventHandler(this.txtCompanyU_TextChanged);
            // 
            // lblERPCode
            // 
            this.lblERPCode.AutoSize = true;
            this.lblERPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblERPCode.Location = new System.Drawing.Point(75, 16);
            this.lblERPCode.Name = "lblERPCode";
            this.lblERPCode.Size = new System.Drawing.Size(58, 13);
            this.lblERPCode.TabIndex = 183;
            this.lblERPCode.Text = "Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Transaction Type";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(586, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 223;
            this.label6.Text = "Mapped List";
            // 
            // txtTType
            // 
            this.txtTType.Location = new System.Drawing.Point(117, 35);
            this.txtTType.Name = "txtTType";
            this.txtTType.Size = new System.Drawing.Size(124, 20);
            this.txtTType.TabIndex = 201;
            this.txtTType.TextChanged += new System.EventHandler(this.txtTType_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 222;
            this.label5.Text = "Un Map List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Customer Name";
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Location = new System.Drawing.Point(141, 507);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAll.TabIndex = 220;
            this.lblTotalAll.Text = "?";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 204;
            this.label10.Text = "Company";
            // 
            // lblTotalMapping
            // 
            this.lblTotalMapping.AutoSize = true;
            this.lblTotalMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMapping.Location = new System.Drawing.Point(620, 506);
            this.lblTotalMapping.Name = "lblTotalMapping";
            this.lblTotalMapping.Size = new System.Drawing.Size(19, 20);
            this.lblTotalMapping.TabIndex = 219;
            this.lblTotalMapping.Text = "?";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(391, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 27);
            this.btnAdd.TabIndex = 217;
            this.btnAdd.Text = "=>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(807, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 215;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(390, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 27);
            this.btnDelete.TabIndex = 218;
            this.btnDelete.Text = "<=";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lvwRouteNonMapping
            // 
            this.lvwRouteNonMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwRouteNonMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwRouteNonMapping.FullRowSelect = true;
            this.lvwRouteNonMapping.GridLines = true;
            this.lvwRouteNonMapping.Location = new System.Drawing.Point(9, 151);
            this.lvwRouteNonMapping.MultiSelect = false;
            this.lvwRouteNonMapping.Name = "lvwRouteNonMapping";
            this.lvwRouteNonMapping.Size = new System.Drawing.Size(374, 349);
            this.lvwRouteNonMapping.TabIndex = 216;
            this.lvwRouteNonMapping.UseCompatibleStateImageBehavior = false;
            this.lvwRouteNonMapping.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Comapny";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Transaction Type";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Code";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 153;
            // 
            // lvwRouteMapping
            // 
            this.lvwRouteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRouteMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colCode,
            this.colName,
            this.colRoute,
            this.columnHeader2});
            this.lvwRouteMapping.FullRowSelect = true;
            this.lvwRouteMapping.GridLines = true;
            this.lvwRouteMapping.Location = new System.Drawing.Point(447, 156);
            this.lvwRouteMapping.MultiSelect = false;
            this.lvwRouteMapping.Name = "lvwRouteMapping";
            this.lvwRouteMapping.Size = new System.Drawing.Size(428, 349);
            this.lvwRouteMapping.TabIndex = 214;
            this.lvwRouteMapping.UseCompatibleStateImageBehavior = false;
            this.lvwRouteMapping.View = System.Windows.Forms.View.Details;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 80;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 129;
            // 
            // colRoute
            // 
            this.colRoute.Text = "TType";
            this.colRoute.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Route Id";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCustomerId);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCompany);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCustomerName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 117);
            this.groupBox3.TabIndex = 225;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search (Un Map List)";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(117, 58);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(124, 20);
            this.txtCustomerId.TabIndex = 206;
            this.txtCustomerId.TextChanged += new System.EventHandler(this.txtCustomerId_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Customer Code";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(117, 13);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(220, 20);
            this.txtCompany.TabIndex = 205;
            this.txtCompany.TextChanged += new System.EventHandler(this.txtCompany_TextChanged);
            // 
            // frmShipmentRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalMapping);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lvwRouteNonMapping);
            this.Controls.Add(this.lvwRouteMapping);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShipmentRoutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShipmentRoutes";
            this.Load += new System.EventHandler(this.frmShipmentRoutes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRouteIdU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyU;
        private System.Windows.Forms.Label lblERPCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalMapping;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvwRouteNonMapping;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvwRouteMapping;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTTypeU;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colRoute;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtCustomerNameU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerIdU;
        private System.Windows.Forms.Label label2;


    }
}