namespace CJ.Win.EPS
{
    partial class frmEPSAdjustment
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
            this.lvwInvoiceList = new System.Windows.Forms.ListView();
            this.colOrderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.colCustName = new System.Windows.Forms.ColumnHeader();
            this.colOrderDate = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceAmount = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnEarlyClosing = new System.Windows.Forms.Button();
            this.btnReverseInvoice = new System.Windows.Forms.Button();
            this.btPayment = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.All = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvwInvoiceList
            // 
            this.lvwInvoiceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoiceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderID,
            this.columnHeader3,
            this.colCustomer,
            this.colCustName,
            this.colOrderDate,
            this.colInvoiceAmount,
            this.columnHeader2});
            this.lvwInvoiceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwInvoiceList.FullRowSelect = true;
            this.lvwInvoiceList.GridLines = true;
            this.lvwInvoiceList.HideSelection = false;
            this.lvwInvoiceList.Location = new System.Drawing.Point(2, 68);
            this.lvwInvoiceList.MultiSelect = false;
            this.lvwInvoiceList.Name = "lvwInvoiceList";
            this.lvwInvoiceList.Size = new System.Drawing.Size(742, 439);
            this.lvwInvoiceList.TabIndex = 75;
            this.lvwInvoiceList.UseCompatibleStateImageBehavior = false;
            this.lvwInvoiceList.View = System.Windows.Forms.View.Details;
            // 
            // colOrderID
            // 
            this.colOrderID.Text = "Invoice No";
            this.colOrderID.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sales Order No.";
            this.columnHeader3.Width = 120;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer Code";
            this.colCustomer.Width = 100;
            // 
            // colCustName
            // 
            this.colCustName.Text = "Customer Name";
            this.colCustName.Width = 186;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Text = "Invoice Date";
            this.colOrderDate.Width = 90;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Invoice Amount";
            this.colInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInvoiceAmount.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Invoice Status";
            this.columnHeader2.Width = 120;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(87, 38);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(247, 20);
            this.txtInvoiceNo.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 132;
            this.label5.Text = "Invoice No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Invoice Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(233, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToDate.TabIndex = 129;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(88, 13);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(115, 20);
            this.dtFromDate.TabIndex = 128;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(360, 32);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(72, 28);
            this.btnShow.TabIndex = 134;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnEarlyClosing
            // 
            this.btnEarlyClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEarlyClosing.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEarlyClosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEarlyClosing.Location = new System.Drawing.Point(747, 69);
            this.btnEarlyClosing.Name = "btnEarlyClosing";
            this.btnEarlyClosing.Size = new System.Drawing.Size(109, 39);
            this.btnEarlyClosing.TabIndex = 136;
            this.btnEarlyClosing.Text = "Early Closing";
            this.btnEarlyClosing.UseVisualStyleBackColor = true;
            this.btnEarlyClosing.Click += new System.EventHandler(this.btnEarlyClosing_Click);
            // 
            // btnReverseInvoice
            // 
            this.btnReverseInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReverseInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReverseInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverseInvoice.Location = new System.Drawing.Point(747, 67);
            this.btnReverseInvoice.Name = "btnReverseInvoice";
            this.btnReverseInvoice.Size = new System.Drawing.Size(109, 41);
            this.btnReverseInvoice.TabIndex = 137;
            this.btnReverseInvoice.Text = "Reverse Invoice";
            this.btnReverseInvoice.UseVisualStyleBackColor = true;
            this.btnReverseInvoice.Click += new System.EventHandler(this.btnInvoiceReverse_Click);
            // 
            // btPayment
            // 
            this.btPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPayment.Location = new System.Drawing.Point(747, 68);
            this.btPayment.Name = "btPayment";
            this.btPayment.Size = new System.Drawing.Size(109, 39);
            this.btPayment.TabIndex = 138;
            this.btPayment.Text = "Advance Payment";
            this.btPayment.UseVisualStyleBackColor = true;
            this.btPayment.Click += new System.EventHandler(this.btnAdvancePayment_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(747, 480);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(109, 27);
            this.btClose.TabIndex = 139;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(336, 17);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 170;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // frmEPSAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 510);
            this.Controls.Add(this.All);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btPayment);
            this.Controls.Add(this.btnReverseInvoice);
            this.Controls.Add(this.btnEarlyClosing);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwInvoiceList);
            this.Name = "frmEPSAdjustment";
            this.Load += new System.EventHandler(this.frmEPSInvoiceDelivery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwInvoiceList;
        private System.Windows.Forms.ColumnHeader colOrderID;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colCustName;
        private System.Windows.Forms.ColumnHeader colOrderDate;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnEarlyClosing;
        private System.Windows.Forms.Button btnReverseInvoice;
        private System.Windows.Forms.Button btPayment;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.CheckBox All;

    }
}