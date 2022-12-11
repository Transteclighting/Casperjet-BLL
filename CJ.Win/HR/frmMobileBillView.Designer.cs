namespace CJ.Win.HR
{
    partial class frmMobileBillView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMobileBillView));
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwMobileBillView = new System.Windows.Forms.ListView();
            this.colEmployeeCode = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colUserType = new System.Windows.Forms.ColumnHeader();
            this.colCompanyCode = new System.Windows.Forms.ColumnHeader();
            this.colDepartmentName = new System.Windows.Forms.ColumnHeader();
            this.colCreditLimitType = new System.Windows.Forms.ColumnHeader();
            this.colCreditLimit = new System.Windows.Forms.ColumnHeader();
            this.colPackageAmount = new System.Windows.Forms.ColumnHeader();
            this.colPackageName = new System.Windows.Forms.ColumnHeader();
            this.colTMonth = new System.Windows.Forms.ColumnHeader();
            this.colTYear = new System.Windows.Forms.ColumnHeader();
            this.colTotalLimit = new System.Windows.Forms.ColumnHeader();
            this.colBillAmount = new System.Windows.Forms.ColumnHeader();
            this.colDeductFromSalary = new System.Windows.Forms.ColumnHeader();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(856, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwMobileBillView
            // 
            this.lvwMobileBillView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMobileBillView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployeeCode,
            this.colUserName,
            this.colUserType,
            this.colCompanyCode,
            this.colDepartmentName,
            this.colCreditLimitType,
            this.colCreditLimit,
            this.colPackageAmount,
            this.colPackageName,
            this.colTMonth,
            this.colTYear,
            this.colTotalLimit,
            this.colBillAmount,
            this.colDeductFromSalary});
            this.lvwMobileBillView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMobileBillView.FullRowSelect = true;
            this.lvwMobileBillView.GridLines = true;
            this.lvwMobileBillView.HideSelection = false;
            this.lvwMobileBillView.Location = new System.Drawing.Point(11, 51);
            this.lvwMobileBillView.MultiSelect = false;
            this.lvwMobileBillView.Name = "lvwMobileBillView";
            this.lvwMobileBillView.Size = new System.Drawing.Size(920, 275);
            this.lvwMobileBillView.TabIndex = 2;
            this.lvwMobileBillView.UseCompatibleStateImageBehavior = false;
            this.lvwMobileBillView.View = System.Windows.Forms.View.Details;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Text = "Emp. Code";
            this.colEmployeeCode.Width = 47;
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 120;
            // 
            // colUserType
            // 
            this.colUserType.Text = "User Type";
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Text = "Company";
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Text = "Department";
            this.colDepartmentName.Width = 87;
            // 
            // colCreditLimitType
            // 
            this.colCreditLimitType.Text = "Credit Limit";
            // 
            // colCreditLimit
            // 
            this.colCreditLimit.Text = "Credit Limit";
            // 
            // colPackageAmount
            // 
            this.colPackageAmount.Text = "PackageAmount";
            // 
            // colPackageName
            // 
            this.colPackageName.Text = "Package";
            // 
            // colTMonth
            // 
            this.colTMonth.Text = "Month";
            // 
            // colTYear
            // 
            this.colTYear.Text = "Year";
            // 
            // colTotalLimit
            // 
            this.colTotalLimit.Text = "Total Limit";
            // 
            // colBillAmount
            // 
            this.colBillAmount.Text = "Bill Amount";
            // 
            // colDeductFromSalary
            // 
            this.colDeductFromSalary.Text = "Deduct";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMobileNo.Location = new System.Drawing.Point(79, 22);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(91, 13);
            this.lblMobileNo.TabIndex = 1;
            this.lblMobileNo.Text = "Mobile Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobile No";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Location = new System.Drawing.Point(8, 339);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(13, 13);
            this.lblTotalBill.TabIndex = 3;
            this.lblTotalBill.Text = "?";
            // 
            // frmMobileBillView
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 369);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwMobileBillView);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileBillView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Bill View";
            this.Load += new System.EventHandler(this.frmMobileBillView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwMobileBillView;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.ColumnHeader colEmployeeCode;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colUserType;
        private System.Windows.Forms.ColumnHeader colCompanyCode;
        private System.Windows.Forms.ColumnHeader colCreditLimitType;
        private System.Windows.Forms.ColumnHeader colCreditLimit;
        private System.Windows.Forms.ColumnHeader colPackageAmount;
        private System.Windows.Forms.ColumnHeader colPackageName;
        private System.Windows.Forms.ColumnHeader colTMonth;
        private System.Windows.Forms.ColumnHeader colTYear;
        private System.Windows.Forms.ColumnHeader colTotalLimit;
        private System.Windows.Forms.ColumnHeader colBillAmount;
        private System.Windows.Forms.ColumnHeader colDeductFromSalary;
        private System.Windows.Forms.ColumnHeader colDepartmentName;
    }
}