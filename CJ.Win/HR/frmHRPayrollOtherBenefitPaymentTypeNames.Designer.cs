namespace CJ.Win.HR
{
    partial class frmHRPayrollOtherBenefitPaymentTypeNames
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
            this.lvwHRPayrollOtherBenefitPaymentTypes = new System.Windows.Forms.ListView();
            this.colTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwHRPayrollOtherBenefitPaymentTypes
            // 
            this.lvwHRPayrollOtherBenefitPaymentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwHRPayrollOtherBenefitPaymentTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeName,
            this.colCreateDate,
            this.colCreateBy});
            this.lvwHRPayrollOtherBenefitPaymentTypes.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwHRPayrollOtherBenefitPaymentTypes.FullRowSelect = true;
            this.lvwHRPayrollOtherBenefitPaymentTypes.GridLines = true;
            this.lvwHRPayrollOtherBenefitPaymentTypes.HideSelection = false;
            this.lvwHRPayrollOtherBenefitPaymentTypes.Location = new System.Drawing.Point(12, 12);
            this.lvwHRPayrollOtherBenefitPaymentTypes.MultiSelect = false;
            this.lvwHRPayrollOtherBenefitPaymentTypes.Name = "lvwHRPayrollOtherBenefitPaymentTypes";
            this.lvwHRPayrollOtherBenefitPaymentTypes.Size = new System.Drawing.Size(537, 355);
            this.lvwHRPayrollOtherBenefitPaymentTypes.TabIndex = 194;
            this.lvwHRPayrollOtherBenefitPaymentTypes.UseCompatibleStateImageBehavior = false;
            this.lvwHRPayrollOtherBenefitPaymentTypes.View = System.Windows.Forms.View.Details;
            // 
            // colTypeName
            // 
            this.colTypeName.Text = "PaymentType Name";
            this.colTypeName.Width = 150;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 120;
            // 
            // colCreateBy
            // 
            this.colCreateBy.Text = "Create By";
            this.colCreateBy.Width = 120;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(555, 340);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 197;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(555, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 27);
            this.btnAdd.TabIndex = 195;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(555, 45);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 27);
            this.btnEdit.TabIndex = 196;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmHRPayrollOtherBenefitPaymentTypeNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 379);
            this.Controls.Add(this.lvwHRPayrollOtherBenefitPaymentTypes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Name = "frmHRPayrollOtherBenefitPaymentTypeNames";
            this.Text = "HR Payroll Other Benefit PaymentType Names";
            this.Load += new System.EventHandler(this.frmHRPayrollOtherBenefitPaymentTypeName_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwHRPayrollOtherBenefitPaymentTypes;
        private System.Windows.Forms.ColumnHeader colTypeName;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colCreateBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
    }
}