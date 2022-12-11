namespace CJ.Win.DMS
{
    partial class frmReplaceDeliveryClaims
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
            this.lvwReplaceClaims = new System.Windows.Forms.ListView();
            this.colReplaceClaimID = new System.Windows.Forms.ColumnHeader();
            this.colReplaceClaimNumber = new System.Windows.Forms.ColumnHeader();
            this.colSubReplaceClaimNumber = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colClaimMonth = new System.Windows.Forms.ColumnHeader();
            this.colDeliveryDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.btSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblCustCode = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.colChallanNo = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwReplaceClaims
            // 
            this.lvwReplaceClaims.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReplaceClaims.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReplaceClaimID,
            this.colChallanNo,
            this.colReplaceClaimNumber,
            this.colSubReplaceClaimNumber,
            this.colCustomerCode,
            this.colCustomerName,
            this.colClaimMonth,
            this.colDeliveryDate,
            this.colStatus});
            this.lvwReplaceClaims.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwReplaceClaims.FullRowSelect = true;
            this.lvwReplaceClaims.GridLines = true;
            this.lvwReplaceClaims.HideSelection = false;
            this.lvwReplaceClaims.Location = new System.Drawing.Point(3, 49);
            this.lvwReplaceClaims.MultiSelect = false;
            this.lvwReplaceClaims.Name = "lvwReplaceClaims";
            this.lvwReplaceClaims.Size = new System.Drawing.Size(874, 315);
            this.lvwReplaceClaims.TabIndex = 12;
            this.lvwReplaceClaims.UseCompatibleStateImageBehavior = false;
            this.lvwReplaceClaims.View = System.Windows.Forms.View.Details;
            // 
            // colReplaceClaimID
            // 
            this.colReplaceClaimID.Text = "Claim ID";
            this.colReplaceClaimID.Width = 0;
            // 
            // colReplaceClaimNumber
            // 
            this.colReplaceClaimNumber.Text = "Claim Number";
            this.colReplaceClaimNumber.Width = 100;
            // 
            // colSubReplaceClaimNumber
            // 
            this.colSubReplaceClaimNumber.Text = "Sub Claim No";
            this.colSubReplaceClaimNumber.Width = 100;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 200;
            // 
            // colClaimMonth
            // 
            this.colClaimMonth.Text = "Claim Month";
            this.colClaimMonth.Width = 100;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.Text = "Delivery Date";
            this.colDeliveryDate.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 87;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(883, 50);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(112, 25);
            this.btSave.TabIndex = 170;
            this.btSave.Text = "Add";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(883, 86);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 25);
            this.btnPrint.TabIndex = 171;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(883, 117);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(112, 25);
            this.btnVerify.TabIndex = 172;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(883, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 25);
            this.button1.TabIndex = 173;
            this.button1.Text = "Delivered";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(430, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 174;
            this.label10.Text = "From Date";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(599, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 176;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(629, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 177;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(499, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 175;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(751, 10);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(63, 23);
            this.btnGetData.TabIndex = 178;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustCode.Location = new System.Drawing.Point(12, 14);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(92, 13);
            this.lblCustCode.TabIndex = 179;
            this.lblCustCode.Text = "Customer Code";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(110, 13);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(383, 25);
            this.ctlCustomer1.TabIndex = 180;
            // 
            // colChallanNo
            // 
            this.colChallanNo.Text = "Challan No";
            this.colChallanNo.Width = 80;
            // 
            // frmReplaceDeliveryClaims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 393);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lblCustCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lvwReplaceClaims);
            this.Name = "frmReplaceDeliveryClaims";
            this.Text = "frmReplaceClaims";
            this.Load += new System.EventHandler(this.frmReplaceDeliveryClaims_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwReplaceClaims;
        private System.Windows.Forms.ColumnHeader colReplaceClaimID;
        private System.Windows.Forms.ColumnHeader colReplaceClaimNumber;
        private System.Windows.Forms.ColumnHeader colSubReplaceClaimNumber;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.ColumnHeader colDeliveryDate;
        private System.Windows.Forms.ColumnHeader colClaimMonth;
        private System.Windows.Forms.ColumnHeader colChallanNo;
    }
}