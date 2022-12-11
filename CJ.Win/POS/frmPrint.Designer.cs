namespace CJ.Win.POS
{
    partial class frmPrint
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lvwItemList = new System.Windows.Forms.ListView();
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutlet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnDefectiveReceive = new System.Windows.Forms.Button();
            this.btnReturnReceive = new System.Windows.Forms.Button();
            this.btnStockTransfer = new System.Windows.Forms.Button();
            this.btnAction_ISGM = new System.Windows.Forms.Button();
            this.btnWarranty = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btGetData = new System.Windows.Forms.Button();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDealerWarranty = new System.Windows.Forms.Button();
            this.txtShowroomCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVAT11Ka = new System.Windows.Forms.Button();
            this.btVATPrint = new System.Windows.Forms.Button();
            this.btnThermalPrint = new System.Windows.Forms.Button();
            this.btnDirectPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(234, 26);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(104, 20);
            this.dtToDate.TabIndex = 64;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(85, 26);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(105, 20);
            this.dtFromDate.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Location = new System.Drawing.Point(44, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 51);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 40;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lvwItemList
            // 
            this.lvwItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colDate,
            this.colInvoiceAmount,
            this.colOutlet,
            this.colConsumerName,
            this.colMobileNo,
            this.colAddress,
            this.colStatus,
            this.colRemarks});
            this.lvwItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItemList.FullRowSelect = true;
            this.lvwItemList.GridLines = true;
            this.lvwItemList.HideSelection = false;
            this.lvwItemList.Location = new System.Drawing.Point(12, 145);
            this.lvwItemList.MultiSelect = false;
            this.lvwItemList.Name = "lvwItemList";
            this.lvwItemList.Size = new System.Drawing.Size(698, 295);
            this.lvwItemList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwItemList.TabIndex = 66;
            this.lvwItemList.UseCompatibleStateImageBehavior = false;
            this.lvwItemList.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Invoice Date";
            this.colDate.Width = 100;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Invoice Amount";
            this.colInvoiceAmount.Width = 110;
            // 
            // colOutlet
            // 
            this.colOutlet.Text = "Outlet";
            this.colOutlet.Width = 55;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 150;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 110;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 170;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 110;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Create Remarks";
            this.colRemarks.Width = 180;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoice.Location = new System.Drawing.Point(715, 145);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(93, 26);
            this.btnInvoice.TabIndex = 76;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnDefectiveReceive
            // 
            this.btnDefectiveReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefectiveReceive.Location = new System.Drawing.Point(716, 144);
            this.btnDefectiveReceive.Name = "btnDefectiveReceive";
            this.btnDefectiveReceive.Size = new System.Drawing.Size(93, 28);
            this.btnDefectiveReceive.TabIndex = 75;
            this.btnDefectiveReceive.Text = "Receive";
            this.btnDefectiveReceive.UseVisualStyleBackColor = true;
            // 
            // btnReturnReceive
            // 
            this.btnReturnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnReceive.Location = new System.Drawing.Point(716, 144);
            this.btnReturnReceive.Name = "btnReturnReceive";
            this.btnReturnReceive.Size = new System.Drawing.Size(93, 28);
            this.btnReturnReceive.TabIndex = 74;
            this.btnReturnReceive.Text = "Receive";
            this.btnReturnReceive.UseVisualStyleBackColor = true;
            // 
            // btnStockTransfer
            // 
            this.btnStockTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStockTransfer.Location = new System.Drawing.Point(716, 145);
            this.btnStockTransfer.Name = "btnStockTransfer";
            this.btnStockTransfer.Size = new System.Drawing.Size(93, 26);
            this.btnStockTransfer.TabIndex = 73;
            this.btnStockTransfer.Text = "Stock Transfer";
            this.btnStockTransfer.UseVisualStyleBackColor = true;
            // 
            // btnAction_ISGM
            // 
            this.btnAction_ISGM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction_ISGM.Location = new System.Drawing.Point(716, 145);
            this.btnAction_ISGM.Name = "btnAction_ISGM";
            this.btnAction_ISGM.Size = new System.Drawing.Size(93, 26);
            this.btnAction_ISGM.TabIndex = 72;
            this.btnAction_ISGM.Text = "Action";
            this.btnAction_ISGM.UseVisualStyleBackColor = true;
            // 
            // btnWarranty
            // 
            this.btnWarranty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarranty.Location = new System.Drawing.Point(715, 180);
            this.btnWarranty.Name = "btnWarranty";
            this.btnWarranty.Size = new System.Drawing.Size(93, 26);
            this.btnWarranty.TabIndex = 70;
            this.btnWarranty.Text = "Warranty Card";
            this.btnWarranty.UseVisualStyleBackColor = true;
            this.btnWarranty.Click += new System.EventHandler(this.btnWarranty_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(715, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 26);
            this.btnAdd.TabIndex = 69;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(718, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(716, 145);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(93, 26);
            this.btnAction.TabIndex = 67;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(635, 110);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(75, 25);
            this.btGetData.TabIndex = 78;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(88, 63);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(214, 20);
            this.txtInvoiceNo.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Invoice No:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(88, 115);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(533, 20);
            this.txtBarcode.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Barcode SL:";
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Location = new System.Drawing.Point(411, 88);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(210, 20);
            this.txtConsumerName.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Consumer Name:";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(88, 89);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(214, 20);
            this.txtMobileNo.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Mobile No:";
            // 
            // btnDealerWarranty
            // 
            this.btnDealerWarranty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDealerWarranty.Location = new System.Drawing.Point(716, 216);
            this.btnDealerWarranty.Name = "btnDealerWarranty";
            this.btnDealerWarranty.Size = new System.Drawing.Size(93, 35);
            this.btnDealerWarranty.TabIndex = 87;
            this.btnDealerWarranty.Text = "Warranty Card For Dealer";
            this.btnDealerWarranty.UseVisualStyleBackColor = true;
            this.btnDealerWarranty.Visible = false;
            this.btnDealerWarranty.Click += new System.EventHandler(this.btnDealerWarranty_Click);
            // 
            // txtShowroomCode
            // 
            this.txtShowroomCode.Location = new System.Drawing.Point(411, 59);
            this.txtShowroomCode.Name = "txtShowroomCode";
            this.txtShowroomCode.Size = new System.Drawing.Size(210, 20);
            this.txtShowroomCode.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "SowroomCode:";
            // 
            // btnVAT11Ka
            // 
            this.btnVAT11Ka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVAT11Ka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVAT11Ka.Location = new System.Drawing.Point(715, 297);
            this.btnVAT11Ka.Name = "btnVAT11Ka";
            this.btnVAT11Ka.Size = new System.Drawing.Size(96, 34);
            this.btnVAT11Ka.TabIndex = 160;
            this.btnVAT11Ka.Text = " VAT Print Mushak-11 (Ka)";
            this.btnVAT11Ka.UseVisualStyleBackColor = true;
            this.btnVAT11Ka.Click += new System.EventHandler(this.btnVAT11Ka_Click);
            // 
            // btVATPrint
            // 
            this.btVATPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVATPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVATPrint.Location = new System.Drawing.Point(715, 257);
            this.btVATPrint.Name = "btVATPrint";
            this.btVATPrint.Size = new System.Drawing.Size(96, 34);
            this.btVATPrint.TabIndex = 159;
            this.btVATPrint.Text = " VAT Print Mushak-11";
            this.btVATPrint.UseVisualStyleBackColor = true;
            this.btVATPrint.Click += new System.EventHandler(this.btVATPrint_Click);
            // 
            // btnThermalPrint
            // 
            this.btnThermalPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThermalPrint.Location = new System.Drawing.Point(715, 337);
            this.btnThermalPrint.Name = "btnThermalPrint";
            this.btnThermalPrint.Size = new System.Drawing.Size(93, 26);
            this.btnThermalPrint.TabIndex = 161;
            this.btnThermalPrint.Text = "Thermal Print";
            this.btnThermalPrint.UseVisualStyleBackColor = true;
           // this.btnThermalPrint.Click += new System.EventHandler(this.btnThermalPrint_Click);
            // 
            // btnDirectPrint
            // 
            this.btnDirectPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectPrint.Location = new System.Drawing.Point(716, 369);
            this.btnDirectPrint.Name = "btnDirectPrint";
            this.btnDirectPrint.Size = new System.Drawing.Size(93, 39);
            this.btnDirectPrint.TabIndex = 162;
            this.btnDirectPrint.Text = "Direct Thermal Print";
            this.btnDirectPrint.UseVisualStyleBackColor = true;
          //  this.btnDirectPrint.Click += new System.EventHandler(this.btnDirectPrint_Click);
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 451);
            this.Controls.Add(this.btnDirectPrint);
            this.Controls.Add(this.btnThermalPrint);
            this.Controls.Add(this.btnVAT11Ka);
            this.Controls.Add(this.btVATPrint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtShowroomCode);
            this.Controls.Add(this.btnDealerWarranty);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnDefectiveReceive);
            this.Controls.Add(this.btnReturnReceive);
            this.Controls.Add(this.btnStockTransfer);
            this.Controls.Add(this.btnAction_ISGM);
            this.Controls.Add(this.btnWarranty);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lvwItemList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrint";
            this.Text = "Print";
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ListView lvwItemList;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colOutlet;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnDefectiveReceive;
        private System.Windows.Forms.Button btnReturnReceive;
        private System.Windows.Forms.Button btnStockTransfer;
        private System.Windows.Forms.Button btnAction_ISGM;
        private System.Windows.Forms.Button btnWarranty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.Button btnDealerWarranty;
        private System.Windows.Forms.TextBox txtShowroomCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVAT11Ka;
        private System.Windows.Forms.Button btVATPrint;
        private System.Windows.Forms.Button btnThermalPrint;
        private System.Windows.Forms.Button btnDirectPrint;
    }
}