namespace CJ.Win.HR
{
    partial class frmHRPayrollUnmapEmpl
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
            this.lvwList = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colNoOfEmpl = new System.Windows.Forms.ColumnHeader();
            this.colGrossSalary = new System.Windows.Forms.ColumnHeader();
            this.colDeductAmount = new System.Windows.Forms.ColumnHeader();
            this.colNetSalary = new System.Windows.Forms.ColumnHeader();
            this.colExpense = new System.Windows.Forms.ColumnHeader();
            this.colSubsidy = new System.Windows.Forms.ColumnHeader();
            this.colTotalSalary = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colVerifiedBy = new System.Windows.Forms.ColumnHeader();
            this.colVerifiedDate = new System.Windows.Forms.ColumnHeader();
            this.colApprovedBy = new System.Windows.Forms.ColumnHeader();
            this.colApprovedDate = new System.Windows.Forms.ColumnHeader();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colEmployeeName,
            this.colDesignation,
            this.colDepartment});
            this.lvwList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(12, 33);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(452, 153);
            this.lvwList.TabIndex = 19;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 70;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 160;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 100;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 100;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 70;
            // 
            // colNoOfEmpl
            // 
            this.colNoOfEmpl.Text = "#OfEmpl";
            // 
            // colGrossSalary
            // 
            this.colGrossSalary.Text = "Gross Amount";
            this.colGrossSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGrossSalary.Width = 80;
            // 
            // colDeductAmount
            // 
            this.colDeductAmount.Text = "Deduct Amount";
            this.colDeductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDeductAmount.Width = 80;
            // 
            // colNetSalary
            // 
            this.colNetSalary.Text = "Net Salary";
            this.colNetSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNetSalary.Width = 80;
            // 
            // colExpense
            // 
            this.colExpense.Text = "Expense";
            this.colExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colExpense.Width = 80;
            // 
            // colSubsidy
            // 
            this.colSubsidy.Text = "Subsidy";
            this.colSubsidy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSubsidy.Width = 80;
            // 
            // colTotalSalary
            // 
            this.colTotalSalary.Text = "Total Salary";
            this.colTotalSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalSalary.Width = 80;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 70;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 70;
            // 
            // colVerifiedBy
            // 
            this.colVerifiedBy.Text = "Verified By";
            this.colVerifiedBy.Width = 70;
            // 
            // colVerifiedDate
            // 
            this.colVerifiedDate.Text = "Verified Date";
            this.colVerifiedDate.Width = 70;
            // 
            // colApprovedBy
            // 
            this.colApprovedBy.Text = "Approved By";
            this.colApprovedBy.Width = 70;
            // 
            // colApprovedDate
            // 
            this.colApprovedDate.Text = "Approved Date";
            this.colApprovedDate.Width = 70;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(389, 194);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblComment
            // 
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.ForeColor = System.Drawing.Color.Red;
            this.lblComment.Location = new System.Drawing.Point(12, 9);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(451, 19);
            this.lblComment.TabIndex = 21;
            this.lblComment.Text = "?";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmHRPayrollUnmapEmpl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 228);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvwList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHRPayrollUnmapEmpl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unmap Employee with Accpac";
            this.Load += new System.EventHandler(this.frmHRPayrollUnmapEmpl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colNoOfEmpl;
        private System.Windows.Forms.ColumnHeader colGrossSalary;
        private System.Windows.Forms.ColumnHeader colDeductAmount;
        private System.Windows.Forms.ColumnHeader colNetSalary;
        private System.Windows.Forms.ColumnHeader colExpense;
        private System.Windows.Forms.ColumnHeader colSubsidy;
        private System.Windows.Forms.ColumnHeader colTotalSalary;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colVerifiedBy;
        private System.Windows.Forms.ColumnHeader colVerifiedDate;
        private System.Windows.Forms.ColumnHeader colApprovedBy;
        private System.Windows.Forms.ColumnHeader colApprovedDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblComment;
    }
}