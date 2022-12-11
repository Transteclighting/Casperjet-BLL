namespace CJ.Win
{
    partial class frmCustomerMappings
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
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtERPCode = new System.Windows.Forms.TextBox();
            this.lblERPCode = new System.Windows.Forms.Label();
            this.lvwCustomerMapping = new System.Windows.Forms.ListView();
            this.colCustomerERPCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.lvwCustomerNonMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.lblTotalMapping = new System.Windows.Forms.Label();
            this.txtCustomerCodeU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerNameU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(140, 36);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(124, 20);
            this.txtCustomerCode.TabIndex = 192;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Customer Code";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(779, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(140, 58);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerName.TabIndex = 184;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 185;
            this.label1.Text = "Customer Name";
            // 
            // txtERPCode
            // 
            this.txtERPCode.Location = new System.Drawing.Point(140, 13);
            this.txtERPCode.Name = "txtERPCode";
            this.txtERPCode.Size = new System.Drawing.Size(124, 20);
            this.txtERPCode.TabIndex = 182;
            this.txtERPCode.TextChanged += new System.EventHandler(this.txtERPCode_TextChanged);
            // 
            // lblERPCode
            // 
            this.lblERPCode.AutoSize = true;
            this.lblERPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblERPCode.Location = new System.Drawing.Point(17, 16);
            this.lblERPCode.Name = "lblERPCode";
            this.lblERPCode.Size = new System.Drawing.Size(121, 13);
            this.lblERPCode.TabIndex = 183;
            this.lblERPCode.Text = "Customer ERP Code";
            // 
            // lvwCustomerMapping
            // 
            this.lvwCustomerMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomerMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerERPCode,
            this.colCustomerCode,
            this.colCustomerName});
            this.lvwCustomerMapping.FullRowSelect = true;
            this.lvwCustomerMapping.GridLines = true;
            this.lvwCustomerMapping.Location = new System.Drawing.Point(438, 111);
            this.lvwCustomerMapping.MultiSelect = false;
            this.lvwCustomerMapping.Name = "lvwCustomerMapping";
            this.lvwCustomerMapping.Size = new System.Drawing.Size(428, 349);
            this.lvwCustomerMapping.TabIndex = 181;
            this.lvwCustomerMapping.UseCompatibleStateImageBehavior = false;
            this.lvwCustomerMapping.View = System.Windows.Forms.View.Details;
            this.lvwCustomerMapping.DoubleClick += new System.EventHandler(this.lvwCustomerMappings_DoubleClick);
            // 
            // colCustomerERPCode
            // 
            this.colCustomerERPCode.Text = "Customer ERP Code";
            this.colCustomerERPCode.Width = 123;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 113;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 253;
            // 
            // lvwCustomerNonMapping
            // 
            this.lvwCustomerNonMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwCustomerNonMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwCustomerNonMapping.FullRowSelect = true;
            this.lvwCustomerNonMapping.GridLines = true;
            this.lvwCustomerNonMapping.Location = new System.Drawing.Point(8, 111);
            this.lvwCustomerNonMapping.MultiSelect = false;
            this.lvwCustomerNonMapping.Name = "lvwCustomerNonMapping";
            this.lvwCustomerNonMapping.Size = new System.Drawing.Size(357, 349);
            this.lvwCustomerNonMapping.TabIndex = 194;
            this.lvwCustomerNonMapping.UseCompatibleStateImageBehavior = false;
            this.lvwCustomerNonMapping.View = System.Windows.Forms.View.Details;
            this.lvwCustomerNonMapping.DoubleClick += new System.EventHandler(this.lvwCustomerNonMappings_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Customer Code";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Customer Name";
            this.columnHeader2.Width = 234;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(376, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 27);
            this.button1.TabIndex = 196;
            this.button1.Text = "<=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(377, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 27);
            this.btnAdd.TabIndex = 195;
            this.btnAdd.Text = "=>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Location = new System.Drawing.Point(64, 475);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAll.TabIndex = 198;
            this.lblTotalAll.Text = "?";
            // 
            // lblTotalMapping
            // 
            this.lblTotalMapping.AutoSize = true;
            this.lblTotalMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMapping.Location = new System.Drawing.Point(481, 475);
            this.lblTotalMapping.Name = "lblTotalMapping";
            this.lblTotalMapping.Size = new System.Drawing.Size(19, 20);
            this.lblTotalMapping.TabIndex = 197;
            this.lblTotalMapping.Text = "?";
            // 
            // txtCustomerCodeU
            // 
            this.txtCustomerCodeU.Location = new System.Drawing.Point(103, 35);
            this.txtCustomerCodeU.Name = "txtCustomerCodeU";
            this.txtCustomerCodeU.Size = new System.Drawing.Size(124, 20);
            this.txtCustomerCodeU.TabIndex = 201;
            this.txtCustomerCodeU.TextChanged += new System.EventHandler(this.txtCustomerCodeU_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Customer Code";
            // 
            // txtCustomerNameU
            // 
            this.txtCustomerNameU.Location = new System.Drawing.Point(103, 57);
            this.txtCustomerNameU.Name = "txtCustomerNameU";
            this.txtCustomerNameU.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerNameU.TabIndex = 199;
            this.txtCustomerNameU.TextChanged += new System.EventHandler(this.txtCustomerNameU_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Customer Name";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 204;
            this.label10.Text = "Entry Date >=";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(111, 19);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(124, 20);
            this.dtFromDate.TabIndex = 203;
            this.dtFromDate.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(113, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 205;
            this.label5.Text = "Un Map List";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(585, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 211;
            this.label6.Text = "Mapped List";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtERPCode);
            this.groupBox1.Controls.Add(this.lblERPCode);
            this.groupBox1.Location = new System.Drawing.Point(438, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 82);
            this.groupBox1.TabIndex = 212;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search (Mapped List)";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCustomerCodeU);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCustomerNameU);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 80);
            this.groupBox3.TabIndex = 213;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search (Un Map List)";
            // 
            // frmCustomerMappings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalMapping);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwCustomerNonMapping);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwCustomerMapping);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Mappings";
            this.Load += new System.EventHandler(this.frmCustomerMappings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtERPCode;
        private System.Windows.Forms.Label lblERPCode;
        private System.Windows.Forms.ListView lvwCustomerMapping;
        private System.Windows.Forms.ColumnHeader colCustomerERPCode;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ListView lvwCustomerNonMapping;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.Label lblTotalMapping;
        private System.Windows.Forms.TextBox txtCustomerCodeU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerNameU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}