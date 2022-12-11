namespace CJ.Win.HR
{
    partial class frmHRPayrollOtherBenefitPaymentTypes
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
            this.lvwHRPayrollOtherBenefitPaymentTypes.Location = new System.Drawing.Point(12, 20);
            this.lvwHRPayrollOtherBenefitPaymentTypes.MultiSelect = false;
            this.lvwHRPayrollOtherBenefitPaymentTypes.Name = "lvwHRPayrollOtherBenefitPaymentTypes";
            this.lvwHRPayrollOtherBenefitPaymentTypes.Size = new System.Drawing.Size(454, 323);
            this.lvwHRPayrollOtherBenefitPaymentTypes.TabIndex = 186;
            this.lvwHRPayrollOtherBenefitPaymentTypes.UseCompatibleStateImageBehavior = false;
            this.lvwHRPayrollOtherBenefitPaymentTypes.View = System.Windows.Forms.View.Details;
            // 
            // colTypeName
            // 
            this.colTypeName.Text = "PaymentType";
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
            this.btnClose.Location = new System.Drawing.Point(472, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 193;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(472, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 27);
            this.btnAdd.TabIndex = 191;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(472, 53);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 27);
            this.btnEdit.TabIndex = 192;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmHRPayrollOtherBenefitPaymentTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 355);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lvwHRPayrollOtherBenefitPaymentTypes);
            this.Name = "frmHRPayrollOtherBenefitPaymentTypes";
            this.Text = "HR Payrol Other Benefit Payment Types";
            this.Load += new System.EventHandler(this.frmHRPayrollOtherBenefitPaymentTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwHRPayrollOtherBenefitPaymentTypes;
        private System.Windows.Forms.ColumnHeader colTypeName;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader colCreateBy;
    }
}