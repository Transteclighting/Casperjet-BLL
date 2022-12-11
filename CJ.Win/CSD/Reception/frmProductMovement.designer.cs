namespace CJ.Win.CSD.Reception
{
    partial class frmProductMovement
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
            this.lvwUnMapJob = new System.Windows.Forms.ListView();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colProduct = new System.Windows.Forms.ColumnHeader();
            this.colASG = new System.Windows.Forms.ColumnHeader();
            this.lvwMapJob = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnUnmap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChallanNo = new System.Windows.Forms.Label();
            this.CheckedAll = new System.Windows.Forms.CheckBox();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalUnmap = new System.Windows.Forms.Label();
            this.lblTotalMap = new System.Windows.Forms.Label();
            this.CheckedMapAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwUnMapJob
            // 
            this.lvwUnMapJob.CheckBoxes = true;
            this.lvwUnMapJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colProduct,
            this.colASG});
            this.lvwUnMapJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwUnMapJob.GridLines = true;
            this.lvwUnMapJob.HideSelection = false;
            this.lvwUnMapJob.Location = new System.Drawing.Point(8, 91);
            this.lvwUnMapJob.MultiSelect = false;
            this.lvwUnMapJob.Name = "lvwUnMapJob";
            this.lvwUnMapJob.Size = new System.Drawing.Size(422, 291);
            this.lvwUnMapJob.TabIndex = 6;
            this.lvwUnMapJob.UseCompatibleStateImageBehavior = false;
            this.lvwUnMapJob.View = System.Windows.Forms.View.Details;
            this.lvwUnMapJob.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwUnMapJob_ColumnClick);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "     Job No";
            this.colJobNo.Width = 102;
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product";
            this.colProduct.Width = 210;
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            this.colASG.Width = 98;
            // 
            // lvwMapJob
            // 
            this.lvwMapJob.CheckBoxes = true;
            this.lvwMapJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwMapJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMapJob.FullRowSelect = true;
            this.lvwMapJob.GridLines = true;
            this.lvwMapJob.HideSelection = false;
            this.lvwMapJob.Location = new System.Drawing.Point(482, 91);
            this.lvwMapJob.MultiSelect = false;
            this.lvwMapJob.Name = "lvwMapJob";
            this.lvwMapJob.Size = new System.Drawing.Size(425, 291);
            this.lvwMapJob.TabIndex = 12;
            this.lvwMapJob.UseCompatibleStateImageBehavior = false;
            this.lvwMapJob.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "     Job No";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product";
            this.columnHeader2.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ASG";
            this.columnHeader3.Width = 104;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(236, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(113, 20);
            this.dtToDate.TabIndex = 4;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(83, 16);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(114, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Create Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "ASG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(244, 62);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(113, 21);
            this.cmbASG.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Job No";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(362, 61);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 24);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(840, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMap
            // 
            this.btnMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMap.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnMap.Location = new System.Drawing.Point(435, 160);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(41, 24);
            this.btnMap.TabIndex = 10;
            this.btnMap.Text = ">>";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnUnmap
            // 
            this.btnUnmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnmap.ForeColor = System.Drawing.Color.Red;
            this.btnUnmap.Location = new System.Drawing.Point(436, 224);
            this.btnUnmap.Name = "btnUnmap";
            this.btnUnmap.Size = new System.Drawing.Size(41, 24);
            this.btnUnmap.TabIndex = 11;
            this.btnUnmap.Text = "<<";
            this.btnUnmap.UseVisualStyleBackColor = true;
            this.btnUnmap.Click += new System.EventHandler(this.btnUnmap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(591, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Challan No:";
            // 
            // lblChallanNo
            // 
            this.lblChallanNo.AutoSize = true;
            this.lblChallanNo.Location = new System.Drawing.Point(655, 14);
            this.lblChallanNo.Name = "lblChallanNo";
            this.lblChallanNo.Size = new System.Drawing.Size(13, 13);
            this.lblChallanNo.TabIndex = 9;
            this.lblChallanNo.Text = "?";
            // 
            // CheckedAll
            // 
            this.CheckedAll.AutoSize = true;
            this.CheckedAll.Location = new System.Drawing.Point(16, 95);
            this.CheckedAll.Name = "CheckedAll";
            this.CheckedAll.Size = new System.Drawing.Size(15, 14);
            this.CheckedAll.TabIndex = 7;
            this.CheckedAll.UseVisualStyleBackColor = true;
            this.CheckedAll.CheckedChanged += new System.EventHandler(this.CheckedAll_CheckedChanged);
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(91, 62);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(114, 20);
            this.txtJobNo.TabIndex = 2;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(74, 409);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(715, 20);
            this.txtRemarks.TabIndex = 15;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Remarks";
            // 
            // lblTotalUnmap
            // 
            this.lblTotalUnmap.AutoSize = true;
            this.lblTotalUnmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUnmap.Location = new System.Drawing.Point(78, 387);
            this.lblTotalUnmap.Name = "lblTotalUnmap";
            this.lblTotalUnmap.Size = new System.Drawing.Size(14, 13);
            this.lblTotalUnmap.TabIndex = 17;
            this.lblTotalUnmap.Text = "?";
            // 
            // lblTotalMap
            // 
            this.lblTotalMap.AutoSize = true;
            this.lblTotalMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMap.Location = new System.Drawing.Point(560, 385);
            this.lblTotalMap.Name = "lblTotalMap";
            this.lblTotalMap.Size = new System.Drawing.Size(14, 13);
            this.lblTotalMap.TabIndex = 18;
            this.lblTotalMap.Text = "?";
            // 
            // CheckedMapAll
            // 
            this.CheckedMapAll.AutoSize = true;
            this.CheckedMapAll.Location = new System.Drawing.Point(490, 95);
            this.CheckedMapAll.Name = "CheckedMapAll";
            this.CheckedMapAll.Size = new System.Drawing.Size(15, 14);
            this.CheckedMapAll.TabIndex = 13;
            this.CheckedMapAll.UseVisualStyleBackColor = true;
            this.CheckedMapAll.CheckedChanged += new System.EventHandler(this.CheckedMapAll_CheckedChanged);
            // 
            // frmProductMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 436);
            this.Controls.Add(this.CheckedMapAll);
            this.Controls.Add(this.lblTotalMap);
            this.Controls.Add(this.lblTotalUnmap);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.CheckedAll);
            this.Controls.Add(this.lblChallanNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnmap);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwMapJob);
            this.Controls.Add(this.lvwUnMapJob);
            this.Name = "frmProductMovement";
            this.Text = "frmProductMovement";
            this.Load += new System.EventHandler(this.frmProductMovement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwUnMapJob;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ListView lvwMapJob;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnUnmap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChallanNo;
        private System.Windows.Forms.CheckBox CheckedAll;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalUnmap;
        private System.Windows.Forms.Label lblTotalMap;
        private System.Windows.Forms.CheckBox CheckedMapAll;
    }
}