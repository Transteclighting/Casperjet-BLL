namespace CJ.Win
{
    partial class frmSpareLoans
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
            this.lvwSpareLoan = new System.Windows.Forms.ListView();
            this.colSpareLoanID = new System.Windows.Forms.ColumnHeader();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colRaiseDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwSpareLoan
            // 
            this.lvwSpareLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSpareLoan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSpareLoanID,
            this.colJobNo,
            this.colCustomerName,
            this.colRaiseDate,
            this.colStatus,
            this.colRemarks});
            this.lvwSpareLoan.FullRowSelect = true;
            this.lvwSpareLoan.GridLines = true;
            this.lvwSpareLoan.Location = new System.Drawing.Point(-2, 92);
            this.lvwSpareLoan.Name = "lvwSpareLoan";
            this.lvwSpareLoan.Size = new System.Drawing.Size(727, 301);
            this.lvwSpareLoan.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwSpareLoan.TabIndex = 1;
            this.lvwSpareLoan.UseCompatibleStateImageBehavior = false;
            this.lvwSpareLoan.View = System.Windows.Forms.View.Details;
            // 
            // colSpareLoanID
            // 
            this.colSpareLoanID.Text = "SpareLoan ID";
            this.colSpareLoanID.Width = 92;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job Number";
            this.colJobNo.Width = 94;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 160;
            // 
            // colRaiseDate
            // 
            this.colRaiseDate.Text = "Raise Date";
            this.colRaiseDate.Width = 132;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 111;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 128;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(745, 393);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 145;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(745, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 25);
            this.button1.TabIndex = 146;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSpareLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwSpareLoan);
            this.Name = "frmSpareLoans";
            this.Text = "Spare Loan";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSpareLoans_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwSpareLoan;
        private System.Windows.Forms.ColumnHeader colSpareLoanID;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colRaiseDate;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.Button button1;
    }
}