namespace CJ.Win.Basic
{
    partial class frmCustomerCreditLimits
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
            this.btnAssignCreditLimit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwCustCreditLimit = new System.Windows.Forms.ListView();
            this.colCustomerID = new System.Windows.Forms.ColumnHeader();
            this.colCustCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colLimitExpiryDate = new System.Windows.Forms.ColumnHeader();
            this.colMinCreditLimit = new System.Windows.Forms.ColumnHeader();
            this.colMaxCreditLimit = new System.Windows.Forms.ColumnHeader();
            this.colChannelDesc = new System.Windows.Forms.ColumnHeader();
            this.colCurrentbalance = new System.Windows.Forms.ColumnHeader();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAssignCreditLimit
            // 
            this.btnAssignCreditLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAssignCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignCreditLimit.Location = new System.Drawing.Point(878, 60);
            this.btnAssignCreditLimit.Name = "btnAssignCreditLimit";
            this.btnAssignCreditLimit.Size = new System.Drawing.Size(113, 37);
            this.btnAssignCreditLimit.TabIndex = 1;
            this.btnAssignCreditLimit.Text = "Assign Credit Limit";
            this.btnAssignCreditLimit.UseVisualStyleBackColor = true;
            this.btnAssignCreditLimit.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(878, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvwCustCreditLimit
            // 
            this.lvwCustCreditLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustCreditLimit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerID,
            this.colCustCode,
            this.colCustomerName,
            this.colCreateDate,
            this.colLimitExpiryDate,
            this.colMinCreditLimit,
            this.colMaxCreditLimit,
            this.colChannelDesc,
            this.colCurrentbalance});
            this.lvwCustCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCustCreditLimit.FullRowSelect = true;
            this.lvwCustCreditLimit.GridLines = true;
            this.lvwCustCreditLimit.HideSelection = false;
            this.lvwCustCreditLimit.Location = new System.Drawing.Point(12, 60);
            this.lvwCustCreditLimit.MultiSelect = false;
            this.lvwCustCreditLimit.Name = "lvwCustCreditLimit";
            this.lvwCustCreditLimit.Size = new System.Drawing.Size(860, 517);
            this.lvwCustCreditLimit.TabIndex = 5;
            this.lvwCustCreditLimit.UseCompatibleStateImageBehavior = false;
            this.lvwCustCreditLimit.View = System.Windows.Forms.View.Details;
            this.lvwCustCreditLimit.SelectedIndexChanged += new System.EventHandler(this.lvwCustCreditLimit_SelectedIndexChanged);
            // 
            // colCustomerID
            // 
            this.colCustomerID.Text = "CustomerID";
            this.colCustomerID.Width = 0;
            // 
            // colCustCode
            // 
            this.colCustCode.Text = "Cust. Code";
            this.colCustCode.Width = 80;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 180;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 90;
            // 
            // colLimitExpiryDate
            // 
            this.colLimitExpiryDate.Text = "Expiry Date";
            this.colLimitExpiryDate.Width = 90;
            // 
            // colMinCreditLimit
            // 
            this.colMinCreditLimit.Text = "Min Credit Limit";
            this.colMinCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMinCreditLimit.Width = 70;
            // 
            // colMaxCreditLimit
            // 
            this.colMaxCreditLimit.Text = "Max Credit Limit";
            this.colMaxCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMaxCreditLimit.Width = 70;
            // 
            // colChannelDesc
            // 
            this.colChannelDesc.Text = "Channel Desc";
            this.colChannelDesc.Width = 130;
            // 
            // colCurrentbalance
            // 
            this.colCurrentbalance.Text = "Balance";
            this.colCurrentbalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCurrentbalance.Width = 70;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(108, 12);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 29);
            this.ctlCustomer1.TabIndex = 6;
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(549, 14);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(67, 23);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Customer Code:";
            // 
            // frmCustomerCreditLimits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lvwCustCreditLimit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAssignCreditLimit);
            this.Name = "frmCustomerCreditLimits";
            this.Text = "frmCustomerCreditLimits";
            this.Load += new System.EventHandler(this.frmCustomerCreditLimits_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAssignCreditLimit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwCustCreditLimit;
        private System.Windows.Forms.ColumnHeader colCustCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colLimitExpiryDate;
        private System.Windows.Forms.ColumnHeader colMinCreditLimit;
        private System.Windows.Forms.ColumnHeader colMaxCreditLimit;
        private System.Windows.Forms.ColumnHeader colChannelDesc;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colCurrentbalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colCustomerID;
    }
}