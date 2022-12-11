namespace CJ.Win
{
    partial class frmReplaceIssue
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
            this.lblIssueRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIssueRemarks = new System.Windows.Forms.TextBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.dtIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssueProduct = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.txtBarcodeSL = new System.Windows.Forms.TextBox();
            this.lblBarcodeSL = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReplaceID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIssueRemarks
            // 
            this.lblIssueRemarks.AutoSize = true;
            this.lblIssueRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueRemarks.Location = new System.Drawing.Point(13, 148);
            this.lblIssueRemarks.Name = "lblIssueRemarks";
            this.lblIssueRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblIssueRemarks.TabIndex = 125;
            this.lblIssueRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(369, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 27);
            this.btnSave.TabIndex = 124;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIssueRemarks
            // 
            this.txtIssueRemarks.Location = new System.Drawing.Point(16, 169);
            this.txtIssueRemarks.Multiline = true;
            this.txtIssueRemarks.Name = "txtIssueRemarks";
            this.txtIssueRemarks.Size = new System.Drawing.Size(509, 56);
            this.txtIssueRemarks.TabIndex = 123;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(27, 126);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(68, 13);
            this.lblIssueDate.TabIndex = 126;
            this.lblIssueDate.Text = "Issue Date";
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.CustomFormat = "dd-MMM-yyyy";
            this.dtIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIssueDate.Location = new System.Drawing.Point(98, 123);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.Size = new System.Drawing.Size(130, 20);
            this.dtIssueDate.TabIndex = 127;
            // 
            // lblIssueProduct
            // 
            this.lblIssueProduct.AutoSize = true;
            this.lblIssueProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueProduct.Location = new System.Drawing.Point(16, 95);
            this.lblIssueProduct.Name = "lblIssueProduct";
            this.lblIssueProduct.Size = new System.Drawing.Size(85, 13);
            this.lblIssueProduct.TabIndex = 131;
            this.lblIssueProduct.Text = "Issue Product";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(101, 91);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(429, 22);
            this.ctlProduct1.TabIndex = 132;
            // 
            // txtBarcodeSL
            // 
            this.txtBarcodeSL.Location = new System.Drawing.Point(377, 125);
            this.txtBarcodeSL.Name = "txtBarcodeSL";
            this.txtBarcodeSL.Size = new System.Drawing.Size(147, 20);
            this.txtBarcodeSL.TabIndex = 133;
            // 
            // lblBarcodeSL
            // 
            this.lblBarcodeSL.AutoSize = true;
            this.lblBarcodeSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcodeSL.Location = new System.Drawing.Point(301, 128);
            this.lblBarcodeSL.Name = "lblBarcodeSL";
            this.lblBarcodeSL.Size = new System.Drawing.Size(73, 13);
            this.lblBarcodeSL.TabIndex = 134;
            this.lblBarcodeSL.Text = "Barcode SL";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblContactNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblReplaceID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblCustomerName);
            this.groupBox3.Controls.Add(this.lblJobNo);
            this.groupBox3.Location = new System.Drawing.Point(20, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 68);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 152;
            this.label3.Text = "Contact No";
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContactNo.Location = new System.Drawing.Point(312, 40);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(172, 20);
            this.lblContactNo.TabIndex = 151;
            this.lblContactNo.Text = "ContactNo";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 150;
            this.label5.Text = "Replace ID";
            // 
            // lblReplaceID
            // 
            this.lblReplaceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReplaceID.Location = new System.Drawing.Point(90, 15);
            this.lblReplaceID.Name = "lblReplaceID";
            this.lblReplaceID.Size = new System.Drawing.Size(105, 19);
            this.lblReplaceID.TabIndex = 149;
            this.lblReplaceID.Text = "ReplaceID";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Job No";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Location = new System.Drawing.Point(312, 14);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(172, 20);
            this.lblCustomerName.TabIndex = 146;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblJobNo
            // 
            this.lblJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobNo.Location = new System.Drawing.Point(91, 41);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(104, 19);
            this.lblJobNo.TabIndex = 145;
            this.lblJobNo.Text = "JobNo";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(445, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 27);
            this.btnCancel.TabIndex = 155;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReplaceIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(544, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtBarcodeSL);
            this.Controls.Add(this.lblBarcodeSL);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.lblIssueProduct);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.dtIssueDate);
            this.Controls.Add(this.lblIssueRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIssueRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Issue";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIssueRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIssueRemarks;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.DateTimePicker dtIssueDate;
        private System.Windows.Forms.Label lblIssueProduct;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.TextBox txtBarcodeSL;
        private System.Windows.Forms.Label lblBarcodeSL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReplaceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Button btnCancel;
    }
}