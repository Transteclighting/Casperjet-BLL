namespace CJ.Win.EPS
{
    partial class frmEPSOrders
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
            this.colOrderNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lvwOrderList = new System.Windows.Forms.ListView();
            this.colOrderDate = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btnOrderConfirm = new System.Windows.Forms.Button();
            this.btInvoice = new System.Windows.Forms.Button();
            this.All = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSalesOrderNo = new System.Windows.Forms.TextBox();
            this.lblSalesOrderNo = new System.Windows.Forms.Label();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRePrintInvoice = new System.Windows.Forms.Button();
            this.btnRePrintEMI = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.SuspendLayout();
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Sales Order No.";
            this.colOrderNo.Width = 106;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 172;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company Name";
            this.colCompany.Width = 163;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(704, 96);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 27);
            this.btnAdd.TabIndex = 74;
            this.btnAdd.Text = "Add Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 121;
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.Location = new System.Drawing.Point(704, 126);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(131, 27);
            this.btnEditOrder.TabIndex = 75;
            this.btnEditOrder.Tag = "M1.15";
            this.btnEditOrder.Text = "Edit Order";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(704, 156);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(131, 27);
            this.btndelete.TabIndex = 76;
            this.btndelete.Tag = "M1.17";
            this.btndelete.Text = "Delete Order";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(618, 65);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 26);
            this.btnShow.TabIndex = 73;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lvwOrderList
            // 
            this.lvwOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderNo,
            this.colOrderDate,
            this.colCompany,
            this.colCustomerName,
            this.colStatus});
            this.lvwOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderList.FullRowSelect = true;
            this.lvwOrderList.GridLines = true;
            this.lvwOrderList.HideSelection = false;
            this.lvwOrderList.Location = new System.Drawing.Point(5, 96);
            this.lvwOrderList.MultiSelect = false;
            this.lvwOrderList.Name = "lvwOrderList";
            this.lvwOrderList.Size = new System.Drawing.Size(696, 366);
            this.lvwOrderList.TabIndex = 77;
            this.lvwOrderList.UseCompatibleStateImageBehavior = false;
            this.lvwOrderList.View = System.Windows.Forms.View.Details;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Text = "Order Date";
            this.colOrderDate.Width = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Company";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(704, 435);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(131, 27);
            this.btClose.TabIndex = 80;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderConfirm.Location = new System.Drawing.Point(704, 96);
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.Size = new System.Drawing.Size(131, 27);
            this.btnOrderConfirm.TabIndex = 81;
            this.btnOrderConfirm.Text = "Order Confirm";
            this.btnOrderConfirm.UseVisualStyleBackColor = true;
            this.btnOrderConfirm.Click += new System.EventHandler(this.btnOrderConfirm_Click);
            // 
            // btInvoice
            // 
            this.btInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInvoice.Location = new System.Drawing.Point(704, 126);
            this.btInvoice.Name = "btInvoice";
            this.btInvoice.Size = new System.Drawing.Size(131, 27);
            this.btInvoice.TabIndex = 82;
            this.btInvoice.Tag = "M1.15";
            this.btInvoice.Text = "Send to Invoice";
            this.btInvoice.UseVisualStyleBackColor = true;
            this.btInvoice.Click += new System.EventHandler(this.btInvoice_Click);
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(336, 40);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 169;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 170;
            this.label10.Text = "Order Date";
            // 
            // txtSalesOrderNo
            // 
            this.txtSalesOrderNo.Location = new System.Drawing.Point(108, 62);
            this.txtSalesOrderNo.Name = "txtSalesOrderNo";
            this.txtSalesOrderNo.Size = new System.Drawing.Size(143, 20);
            this.txtSalesOrderNo.TabIndex = 168;
            // 
            // lblSalesOrderNo
            // 
            this.lblSalesOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderNo.Location = new System.Drawing.Point(14, 65);
            this.lblSalesOrderNo.Name = "lblSalesOrderNo";
            this.lblSalesOrderNo.Size = new System.Drawing.Size(93, 13);
            this.lblSalesOrderNo.TabIndex = 167;
            this.lblSalesOrderNo.Text = "Sales Order No";
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(382, 39);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(43, 13);
            this.lblComplainStatus.TabIndex = 166;
            this.lblComplainStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(426, 35);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(171, 21);
            this.cmbStatus.TabIndex = 165;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(210, 39);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 164;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(233, 36);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 163;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(108, 36);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 162;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(373, 62);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(224, 20);
            this.txtCustomerName.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "Customer Name";
            // 
            // btnRePrintInvoice
            // 
            this.btnRePrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRePrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRePrintInvoice.Location = new System.Drawing.Point(704, 186);
            this.btnRePrintInvoice.Name = "btnRePrintInvoice";
            this.btnRePrintInvoice.Size = new System.Drawing.Size(131, 27);
            this.btnRePrintInvoice.TabIndex = 173;
            this.btnRePrintInvoice.Tag = "M1.17";
            this.btnRePrintInvoice.Text = "Re-Print Invoice";
            this.btnRePrintInvoice.UseVisualStyleBackColor = true;
            this.btnRePrintInvoice.Click += new System.EventHandler(this.btnRePrintInvoice_Click);
            // 
            // btnRePrintEMI
            // 
            this.btnRePrintEMI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRePrintEMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRePrintEMI.Location = new System.Drawing.Point(704, 215);
            this.btnRePrintEMI.Name = "btnRePrintEMI";
            this.btnRePrintEMI.Size = new System.Drawing.Size(131, 27);
            this.btnRePrintEMI.TabIndex = 174;
            this.btnRePrintEMI.Tag = "M1.17";
            this.btnRePrintEMI.Text = "Re-Print EMI";
            this.btnRePrintEMI.UseVisualStyleBackColor = true;
            this.btnRePrintEMI.Click += new System.EventHandler(this.btnRePrintEMI_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(108, 8);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(495, 25);
            this.ctlCustomer1.TabIndex = 79;
            // 
            // frmEPSOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 465);
            this.Controls.Add(this.btnRePrintEMI);
            this.Controls.Add(this.btnRePrintInvoice);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.All);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSalesOrderNo);
            this.Controls.Add(this.lblSalesOrderNo);
            this.Controls.Add(this.lblComplainStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnOrderConfirm);
            this.Controls.Add(this.btInvoice);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lvwOrderList);
            this.Name = "frmEPSOrders";
            this.Text = "frmEPSOrders";
            this.Load += new System.EventHandler(this.frmEPSOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListView lvwOrderList;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btnOrderConfirm;
        private System.Windows.Forms.Button btInvoice;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSalesOrderNo;
        private System.Windows.Forms.Label lblSalesOrderNo;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colOrderDate;
        private System.Windows.Forms.Button btnRePrintInvoice;
        private System.Windows.Forms.Button btnRePrintEMI;
    }
}