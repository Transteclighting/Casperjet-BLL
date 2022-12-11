namespace CJ.Win
{
    partial class frmBarcodePrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.lvwProductBarcode = new System.Windows.Forms.ListView();
            this.colBarcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrintCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btgetdata = new System.Windows.Forms.Button();
            this.lvwTranList = new System.Windows.Forms.ListView();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtrefno = new System.Windows.Forms.TextBox();
            this.cbbarcodetype = new System.Windows.Forms.ComboBox();
            this.dttodate = new System.Windows.Forms.DateTimePicker();
            this.dtformdate = new System.Windows.Forms.DateTimePicker();
            this.lbrefno = new System.Windows.Forms.Label();
            this.lbbarcodetype = new System.Windows.Forms.Label();
            this.lbtodate = new System.Windows.Forms.Label();
            this.lbformdate = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.btCLose = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picProductcode = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnumberofcopy = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductcode)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbSelect);
            this.groupBox1.Controls.Add(this.lvwProductBarcode);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(357, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Print";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(332, 14);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(181, 21);
            this.txtProductCode.TabIndex = 165;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 164;
            this.label2.Text = "Product Code";
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSelect.Location = new System.Drawing.Point(15, 22);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(76, 17);
            this.ckbSelect.TabIndex = 163;
            this.ckbSelect.Text = "Select All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // lvwProductBarcode
            // 
            this.lvwProductBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductBarcode.CheckBoxes = true;
            this.lvwProductBarcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBarcode,
            this.colProductCode,
            this.colProductName,
            this.colPrintCount});
            this.lvwProductBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwProductBarcode.GridLines = true;
            this.lvwProductBarcode.Location = new System.Drawing.Point(9, 41);
            this.lvwProductBarcode.Name = "lvwProductBarcode";
            this.lvwProductBarcode.Size = new System.Drawing.Size(504, 220);
            this.lvwProductBarcode.TabIndex = 2;
            this.lvwProductBarcode.UseCompatibleStateImageBehavior = false;
            this.lvwProductBarcode.View = System.Windows.Forms.View.Details;
            this.lvwProductBarcode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwProductBarcode_ItemCheck);
            this.lvwProductBarcode.Click += new System.EventHandler(this.lvwProductBarcode_Click);
            // 
            // colBarcode
            // 
            this.colBarcode.Text = "Barcode ";
            this.colBarcode.Width = 150;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 100;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 250;
            // 
            // colPrintCount
            // 
            this.colPrintCount.Text = "Print Count";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.btgetdata);
            this.groupBox2.Controls.Add(this.lvwTranList);
            this.groupBox2.Controls.Add(this.txtrefno);
            this.groupBox2.Controls.Add(this.cbbarcodetype);
            this.groupBox2.Controls.Add(this.dttodate);
            this.groupBox2.Controls.Add(this.dtformdate);
            this.groupBox2.Controls.Add(this.lbrefno);
            this.groupBox2.Controls.Add(this.lbbarcodetype);
            this.groupBox2.Controls.Add(this.lbtodate);
            this.groupBox2.Controls.Add(this.lbformdate);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 509);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Search";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(283, 36);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 10;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btgetdata
            // 
            this.btgetdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btgetdata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btgetdata.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btgetdata.Location = new System.Drawing.Point(260, 119);
            this.btgetdata.Name = "btgetdata";
            this.btgetdata.Size = new System.Drawing.Size(75, 48);
            this.btgetdata.TabIndex = 9;
            this.btgetdata.Text = "Get Data";
            this.btgetdata.UseVisualStyleBackColor = false;
            this.btgetdata.Click += new System.EventHandler(this.btgetdata_Click);
            // 
            // lvwTranList
            // 
            this.lvwTranList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.TranDate});
            this.lvwTranList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTranList.FullRowSelect = true;
            this.lvwTranList.GridLines = true;
            this.lvwTranList.Location = new System.Drawing.Point(5, 119);
            this.lvwTranList.Name = "lvwTranList";
            this.lvwTranList.Size = new System.Drawing.Size(251, 384);
            this.lvwTranList.TabIndex = 8;
            this.lvwTranList.UseCompatibleStateImageBehavior = false;
            this.lvwTranList.View = System.Windows.Forms.View.Details;
            this.lvwTranList.Click += new System.EventHandler(this.lvwTranList_Click);
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Transaction No";
            this.colTranNo.Width = 150;
            // 
            // TranDate
            // 
            this.TranDate.Text = " Date";
            this.TranDate.Width = 100;
            // 
            // txtrefno
            // 
            this.txtrefno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrefno.Location = new System.Drawing.Point(114, 92);
            this.txtrefno.Name = "txtrefno";
            this.txtrefno.Size = new System.Drawing.Size(181, 21);
            this.txtrefno.TabIndex = 7;
            this.txtrefno.TextChanged += new System.EventHandler(this.txtrefno_TextChanged);
            // 
            // cbbarcodetype
            // 
            this.cbbarcodetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbarcodetype.FormattingEnabled = true;
            this.cbbarcodetype.Items.AddRange(new object[] {
            "System",
            "Manual",
            "All"});
            this.cbbarcodetype.Location = new System.Drawing.Point(115, 60);
            this.cbbarcodetype.Name = "cbbarcodetype";
            this.cbbarcodetype.Size = new System.Drawing.Size(128, 23);
            this.cbbarcodetype.TabIndex = 6;
            this.cbbarcodetype.Text = "All";
            this.cbbarcodetype.SelectedIndexChanged += new System.EventHandler(this.cbbarcodetype_SelectedIndexChanged);
            // 
            // dttodate
            // 
            this.dttodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttodate.Location = new System.Drawing.Point(181, 31);
            this.dttodate.Name = "dttodate";
            this.dttodate.Size = new System.Drawing.Size(96, 21);
            this.dttodate.TabIndex = 5;
            this.dttodate.ValueChanged += new System.EventHandler(this.dttodate_ValueChanged);
            // 
            // dtformdate
            // 
            this.dtformdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtformdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtformdate.Location = new System.Drawing.Point(52, 31);
            this.dtformdate.Name = "dtformdate";
            this.dtformdate.Size = new System.Drawing.Size(96, 21);
            this.dtformdate.TabIndex = 4;
            this.dtformdate.ValueChanged += new System.EventHandler(this.dtformdate_ValueChanged);
            // 
            // lbrefno
            // 
            this.lbrefno.AutoSize = true;
            this.lbrefno.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrefno.Location = new System.Drawing.Point(9, 93);
            this.lbrefno.Name = "lbrefno";
            this.lbrefno.Size = new System.Drawing.Size(103, 19);
            this.lbrefno.TabIndex = 3;
            this.lbrefno.Text = "Reference No";
            // 
            // lbbarcodetype
            // 
            this.lbbarcodetype.AutoSize = true;
            this.lbbarcodetype.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbarcodetype.Location = new System.Drawing.Point(9, 60);
            this.lbbarcodetype.Name = "lbbarcodetype";
            this.lbbarcodetype.Size = new System.Drawing.Size(102, 19);
            this.lbbarcodetype.TabIndex = 2;
            this.lbbarcodetype.Text = "Barcode Type";
            // 
            // lbtodate
            // 
            this.lbtodate.AutoSize = true;
            this.lbtodate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtodate.Location = new System.Drawing.Point(151, 32);
            this.lbtodate.Name = "lbtodate";
            this.lbtodate.Size = new System.Drawing.Size(26, 19);
            this.lbtodate.TabIndex = 1;
            this.lbtodate.Text = "To";
            // 
            // lbformdate
            // 
            this.lbformdate.AutoSize = true;
            this.lbformdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbformdate.Location = new System.Drawing.Point(9, 31);
            this.lbformdate.Name = "lbformdate";
            this.lbformdate.Size = new System.Drawing.Size(42, 19);
            this.lbformdate.TabIndex = 0;
            this.lbformdate.Text = "Date";
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btPrint.Enabled = false;
            this.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(15, 15);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 28);
            this.btPrint.TabIndex = 4;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = false;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btCLose
            // 
            this.btCLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCLose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCLose.Location = new System.Drawing.Point(156, 15);
            this.btCLose.Name = "btCLose";
            this.btCLose.Size = new System.Drawing.Size(88, 28);
            this.btCLose.TabIndex = 5;
            this.btCLose.Text = "Close";
            this.btCLose.UseVisualStyleBackColor = false;
            this.btCLose.Click += new System.EventHandler(this.btCLose_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // picBarcode
            // 
            this.picBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBarcode.Location = new System.Drawing.Point(132, 19);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(245, 30);
            this.picBarcode.TabIndex = 6;
            this.picBarcode.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.picProductcode);
            this.groupBox3.Controls.Add(this.picBarcode);
            this.groupBox3.Location = new System.Drawing.Point(363, 354);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(516, 164);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // picProductcode
            // 
            this.picProductcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picProductcode.Location = new System.Drawing.Point(132, 49);
            this.picProductcode.Name = "picProductcode";
            this.picProductcode.Size = new System.Drawing.Size(245, 31);
            this.picProductcode.TabIndex = 7;
            this.picProductcode.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtnumberofcopy);
            this.groupBox4.Controls.Add(this.btCLose);
            this.groupBox4.Controls.Add(this.btPrint);
            this.groupBox4.Location = new System.Drawing.Point(357, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(525, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of Copy";
            // 
            // txtnumberofcopy
            // 
            this.txtnumberofcopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumberofcopy.Location = new System.Drawing.Point(433, 17);
            this.txtnumberofcopy.Name = "txtnumberofcopy";
            this.txtnumberofcopy.Size = new System.Drawing.Size(80, 26);
            this.txtnumberofcopy.TabIndex = 6;
            this.txtnumberofcopy.Text = "6";
            this.txtnumberofcopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtnumberofcopy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumberofcopy_KeyPress);
            // 
            // frmBarcodePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 548);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBarcodePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBarcodePrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProductcode)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwProductBarcode;
        private System.Windows.Forms.ColumnHeader colBarcode;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbtodate;
        private System.Windows.Forms.Label lbformdate;
        private System.Windows.Forms.Label lbrefno;
        private System.Windows.Forms.Label lbbarcodetype;
        private System.Windows.Forms.DateTimePicker dttodate;
        private System.Windows.Forms.DateTimePicker dtformdate;
        private System.Windows.Forms.TextBox txtrefno;
        private System.Windows.Forms.ComboBox cbbarcodetype;
        private System.Windows.Forms.ListView lvwTranList;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader TranDate;
        private System.Windows.Forms.Button btgetdata;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btCLose;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtnumberofcopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picProductcode;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colPrintCount;
    }
}