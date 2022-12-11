namespace CJ.Win.Inventory
{
    partial class frmStockTransfers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTransfers));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromWH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.colToWHID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.colTranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromWHID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwStockList = new System.Windows.Forms.ListView();
            this.colTranSide = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbToWH = new System.Windows.Forms.ComboBox();
            this.btnPrintTransaction = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btPrintVAT = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btProcessVAT = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnTransferSerial = new System.Windows.Forms.Button();
            this.btnAddAdjestment = new System.Windows.Forms.Button();
            this.lblTransSide = new System.Windows.Forms.Label();
            this.rdoStockOut = new System.Windows.Forms.RadioButton();
            this.rdoStockIn = new System.Windows.Forms.RadioButton();
            this.lblTransferType = new System.Windows.Forms.Label();
            this.cmbTransferType = new System.Windows.Forms.ComboBox();
            this.btnVATPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Transfer To:";
            // 
            // cmbFromWH
            // 
            this.cmbFromWH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromWH.FormattingEnabled = true;
            this.cmbFromWH.Location = new System.Drawing.Point(155, 62);
            this.cmbFromWH.Name = "cmbFromWH";
            this.cmbFromWH.Size = new System.Drawing.Size(296, 23);
            this.cmbFromWH.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Transfer From:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Transaction Ref No :";
            // 
            // txtTranNo
            // 
            this.txtTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranNo.Location = new System.Drawing.Point(155, 35);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(195, 21);
            this.txtTranNo.TabIndex = 5;
            // 
            // colToWHID
            // 
            this.colToWHID.Text = "To Warehouse";
            this.colToWHID.Width = 157;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(823, 85);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 29);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Search";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(351, 10);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(112, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(378, 6);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 21);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(155, 6);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(110, 21);
            this.dtFromDate.TabIndex = 1;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Transaction Date";
            this.colTranDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTranDate.Width = 137;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 250;
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Transaction No";
            this.colTranNo.Width = 111;
            // 
            // colFromWHID
            // 
            this.colFromWHID.Text = "From Warehouse";
            this.colFromWHID.Width = 158;
            // 
            // lvwStockList
            // 
            this.lvwStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwStockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.colTranDate,
            this.colFromWHID,
            this.colToWHID,
            this.colTranSide,
            this.colTranType,
            this.colRemarks});
            this.lvwStockList.FullRowSelect = true;
            this.lvwStockList.GridLines = true;
            this.lvwStockList.HideSelection = false;
            this.lvwStockList.Location = new System.Drawing.Point(12, 120);
            this.lvwStockList.MultiSelect = false;
            this.lvwStockList.Name = "lvwStockList";
            this.lvwStockList.Size = new System.Drawing.Size(905, 572);
            this.lvwStockList.TabIndex = 11;
            this.lvwStockList.UseCompatibleStateImageBehavior = false;
            this.lvwStockList.View = System.Windows.Forms.View.Details;
            // 
            // colTranSide
            // 
            this.colTranSide.Text = "Tran Side";
            this.colTranSide.Width = 97;
            // 
            // colTranType
            // 
            this.colTranType.Text = "Tran Type";
            this.colTranType.Width = 124;
            // 
            // cmbToWH
            // 
            this.cmbToWH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToWH.FormattingEnabled = true;
            this.cmbToWH.Location = new System.Drawing.Point(155, 91);
            this.cmbToWH.Name = "cmbToWH";
            this.cmbToWH.Size = new System.Drawing.Size(296, 23);
            this.cmbToWH.TabIndex = 9;
            // 
            // btnPrintTransaction
            // 
            this.btnPrintTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTransaction.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTransaction.Location = new System.Drawing.Point(923, 155);
            this.btnPrintTransaction.Name = "btnPrintTransaction";
            this.btnPrintTransaction.Size = new System.Drawing.Size(94, 29);
            this.btnPrintTransaction.TabIndex = 14;
            this.btnPrintTransaction.Text = "Print Transaction";
            this.btnPrintTransaction.UseVisualStyleBackColor = true;
            this.btnPrintTransaction.Click += new System.EventHandler(this.btnPrintTransaction_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Enabled = false;
            this.btndelete.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(923, 415);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(94, 29);
            this.btndelete.TabIndex = 13;
            this.btndelete.Tag = "M1.20";
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Visible = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(923, 120);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(94, 29);
            this.btAdd.TabIndex = 12;
            this.btAdd.Tag = "M1.18";
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btPrintVAT
            // 
            this.btPrintVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintVAT.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrintVAT.Location = new System.Drawing.Point(923, 275);
            this.btPrintVAT.Name = "btPrintVAT";
            this.btPrintVAT.Size = new System.Drawing.Size(94, 29);
            this.btPrintVAT.TabIndex = 15;
            this.btPrintVAT.Text = "Print VAT";
            this.btPrintVAT.UseVisualStyleBackColor = true;
            this.btPrintVAT.Visible = false;
            this.btPrintVAT.Click += new System.EventHandler(this.btPrintVAT_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(923, 664);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btProcessVAT
            // 
            this.btProcessVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProcessVAT.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcessVAT.Location = new System.Drawing.Point(923, 310);
            this.btProcessVAT.Name = "btProcessVAT";
            this.btProcessVAT.Size = new System.Drawing.Size(94, 29);
            this.btProcessVAT.TabIndex = 16;
            this.btProcessVAT.Text = "VAT Challan Process";
            this.btProcessVAT.UseVisualStyleBackColor = true;
            this.btProcessVAT.Visible = false;
            this.btProcessVAT.Click += new System.EventHandler(this.btProcessVAT_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarcode.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(923, 345);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(94, 29);
            this.btnBarcode.TabIndex = 17;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Visible = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnTransferSerial
            // 
            this.btnTransferSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransferSerial.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTransferSerial.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferSerial.Location = new System.Drawing.Point(923, 380);
            this.btnTransferSerial.Name = "btnTransferSerial";
            this.btnTransferSerial.Size = new System.Drawing.Size(94, 29);
            this.btnTransferSerial.TabIndex = 18;
            this.btnTransferSerial.Text = "Barcode";
            this.btnTransferSerial.UseVisualStyleBackColor = true;
            this.btnTransferSerial.Visible = false;
            this.btnTransferSerial.Click += new System.EventHandler(this.btnTransferSerial_Click);
            // 
            // btnAddAdjestment
            // 
            this.btnAddAdjestment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAdjestment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAdjestment.Location = new System.Drawing.Point(923, 120);
            this.btnAddAdjestment.Name = "btnAddAdjestment";
            this.btnAddAdjestment.Size = new System.Drawing.Size(94, 29);
            this.btnAddAdjestment.TabIndex = 20;
            this.btnAddAdjestment.Tag = "M1.18";
            this.btnAddAdjestment.Text = "Add";
            this.btnAddAdjestment.UseVisualStyleBackColor = true;
            this.btnAddAdjestment.Click += new System.EventHandler(this.btnAddAdjestment_Click);
            // 
            // lblTransSide
            // 
            this.lblTransSide.AutoSize = true;
            this.lblTransSide.Location = new System.Drawing.Point(454, 63);
            this.lblTransSide.Name = "lblTransSide";
            this.lblTransSide.Size = new System.Drawing.Size(100, 15);
            this.lblTransSide.TabIndex = 21;
            this.lblTransSide.Text = "Transaction Side";
            // 
            // rdoStockOut
            // 
            this.rdoStockOut.AutoSize = true;
            this.rdoStockOut.Location = new System.Drawing.Point(737, 62);
            this.rdoStockOut.Name = "rdoStockOut";
            this.rdoStockOut.Size = new System.Drawing.Size(80, 19);
            this.rdoStockOut.TabIndex = 23;
            this.rdoStockOut.Text = "Stock Out";
            this.rdoStockOut.UseVisualStyleBackColor = true;
            this.rdoStockOut.CheckedChanged += new System.EventHandler(this.rdoStockOut_CheckedChanged);
            // 
            // rdoStockIn
            // 
            this.rdoStockIn.AutoSize = true;
            this.rdoStockIn.Location = new System.Drawing.Point(560, 62);
            this.rdoStockIn.Name = "rdoStockIn";
            this.rdoStockIn.Size = new System.Drawing.Size(69, 19);
            this.rdoStockIn.TabIndex = 22;
            this.rdoStockIn.Text = "Stock In";
            this.rdoStockIn.UseVisualStyleBackColor = true;
            this.rdoStockIn.CheckedChanged += new System.EventHandler(this.rdoStockIn_CheckedChanged);
            // 
            // lblTransferType
            // 
            this.lblTransferType.AutoSize = true;
            this.lblTransferType.Location = new System.Drawing.Point(471, 91);
            this.lblTransferType.Name = "lblTransferType";
            this.lblTransferType.Size = new System.Drawing.Size(83, 15);
            this.lblTransferType.TabIndex = 24;
            this.lblTransferType.Text = "Transfer Type";
            // 
            // cmbTransferType
            // 
            this.cmbTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferType.FormattingEnabled = true;
            this.cmbTransferType.Location = new System.Drawing.Point(560, 89);
            this.cmbTransferType.Name = "cmbTransferType";
            this.cmbTransferType.Size = new System.Drawing.Size(257, 23);
            this.cmbTransferType.TabIndex = 25;
            // 
            // btnVATPrint
            // 
            this.btnVATPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVATPrint.Location = new System.Drawing.Point(923, 190);
            this.btnVATPrint.Name = "btnVATPrint";
            this.btnVATPrint.Size = new System.Drawing.Size(94, 29);
            this.btnVATPrint.TabIndex = 67;
            this.btnVATPrint.Text = "VAT Print (6.5)";
            this.btnVATPrint.UseVisualStyleBackColor = true;
            this.btnVATPrint.Click += new System.EventHandler(this.btnVATPrint_Click);
            // 
            // frmStockTransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 704);
            this.Controls.Add(this.btnVATPrint);
            this.Controls.Add(this.lblTransSide);
            this.Controls.Add(this.rdoStockOut);
            this.Controls.Add(this.rdoStockIn);
            this.Controls.Add(this.lblTransferType);
            this.Controls.Add(this.cmbTransferType);
            this.Controls.Add(this.btnAddAdjestment);
            this.Controls.Add(this.btnTransferSerial);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btProcessVAT);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btPrintVAT);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btnPrintTransaction);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.cmbToWH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFromWH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwStockList);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockTransfers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStockTransfers";
            this.Load += new System.EventHandler(this.frmStockTransfers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFromWH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.ColumnHeader colToWHID;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader colFromWHID;
        private System.Windows.Forms.ListView lvwStockList;
        private System.Windows.Forms.ComboBox cmbToWH;
        private System.Windows.Forms.Button btnPrintTransaction;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btPrintVAT;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btProcessVAT;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnTransferSerial;
        private System.Windows.Forms.Button btnAddAdjestment;
        private System.Windows.Forms.Label lblTransSide;
        private System.Windows.Forms.RadioButton rdoStockOut;
        private System.Windows.Forms.RadioButton rdoStockIn;
        private System.Windows.Forms.Label lblTransferType;
        private System.Windows.Forms.ComboBox cmbTransferType;
        private System.Windows.Forms.ColumnHeader colTranSide;
        private System.Windows.Forms.ColumnHeader colTranType;
        private System.Windows.Forms.Button btnVATPrint;
    }
}