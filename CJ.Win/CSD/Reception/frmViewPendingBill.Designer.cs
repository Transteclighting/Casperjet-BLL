namespace CJ.Win.CSD.Reception
{
    partial class frmViewPendingBill
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
            this.lvwPendingJobs = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalBill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceivedAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrentPayable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBillPay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.txtCustomernName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwPendingJobs
            // 
            this.lvwPendingJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPendingJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colCustomerName,
            this.colMobile,
            this.colName,
            this.colTotalBill,
            this.colReceivedAmount,
            this.colCurrentPayable,
            this.colRemarks});
            this.lvwPendingJobs.FullRowSelect = true;
            this.lvwPendingJobs.GridLines = true;
            this.lvwPendingJobs.Location = new System.Drawing.Point(11, 67);
            this.lvwPendingJobs.MultiSelect = false;
            this.lvwPendingJobs.Name = "lvwPendingJobs";
            this.lvwPendingJobs.Size = new System.Drawing.Size(852, 318);
            this.lvwPendingJobs.TabIndex = 7;
            this.lvwPendingJobs.UseCompatibleStateImageBehavior = false;
            this.lvwPendingJobs.View = System.Windows.Forms.View.Details;
            this.lvwPendingJobs.DoubleClick += new System.EventHandler(this.lvwPendingJobs_DoubleClick);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 102;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 269;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Mobile";
            this.colMobile.Width = 122;
            // 
            // colTotalBill
            // 
            this.colTotalBill.Text = "Total Bill";
            this.colTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalBill.Width = 92;
            // 
            // colReceivedAmount
            // 
            this.colReceivedAmount.Text = "Received Amount";
            this.colReceivedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReceivedAmount.Width = 101;
            // 
            // colCurrentPayable
            // 
            this.colCurrentPayable.Text = "Current Payable";
            this.colCurrentPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCurrentPayable.Width = 91;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 130;
            // 
            // btnBillPay
            // 
            this.btnBillPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillPay.Location = new System.Drawing.Point(869, 67);
            this.btnBillPay.Name = "btnBillPay";
            this.btnBillPay.Size = new System.Drawing.Size(83, 26);
            this.btnBillPay.TabIndex = 8;
            this.btnBillPay.Text = "&Bill Pay";
            this.btnBillPay.UseVisualStyleBackColor = true;
            this.btnBillPay.Click += new System.EventHandler(this.btnBillPay_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(869, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(99, 11);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(131, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(289, 11);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(131, 20);
            this.txtMobileNo.TabIndex = 3;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(233, 14);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(55, 13);
            this.lblMobileNo.TabIndex = 2;
            this.lblMobileNo.Text = "Mobile No";
            // 
            // txtCustomernName
            // 
            this.txtCustomernName.Location = new System.Drawing.Point(99, 37);
            this.txtCustomernName.Name = "txtCustomernName";
            this.txtCustomernName.Size = new System.Drawing.Size(321, 20);
            this.txtCustomernName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer Name";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(730, 35);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(83, 26);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // colName
            // 
            this.colName.Text = "Technician Name";
            this.colName.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Technician Name";
            // 
            // txtTechName
            // 
            this.txtTechName.Location = new System.Drawing.Point(523, 38);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(201, 20);
            this.txtTechName.TabIndex = 11;
            // 
            // frmViewPendingBill
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 397);
            this.Controls.Add(this.txtTechName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtCustomernName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBillPay);
            this.Controls.Add(this.lvwPendingJobs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewPendingBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Pending Job";
            this.Load += new System.EventHandler(this.frmViewPendingJob_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPendingJobs;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colTotalBill;
        private System.Windows.Forms.ColumnHeader colReceivedAmount;
        private System.Windows.Forms.ColumnHeader colCurrentPayable;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnBillPay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.TextBox txtCustomernName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTechName;
    }
}