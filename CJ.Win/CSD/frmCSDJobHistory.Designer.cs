namespace CJ.Win.CSD
{
    partial class frmCSDJobHistory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lvwJoHistory = new System.Windows.Forms.ListView();
            this.colTranDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colSubStatus = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtJobNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtModelNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(497, 13);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.ReadOnly = true;
            this.txtJobNumber.Size = new System.Drawing.Size(141, 20);
            this.txtJobNumber.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Job Number";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(497, 39);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.ReadOnly = true;
            this.txtModelNo.Size = new System.Drawing.Size(141, 20);
            this.txtModelNo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mobile No";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 13);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(370, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(56, 38);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(370, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Product";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Customer";
            // 
            // lvwJoHistory
            // 
            this.lvwJoHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranDate,
            this.colStatus,
            this.colSubStatus,
            this.colCreatedBy,
            this.colRemarks});
            this.lvwJoHistory.FullRowSelect = true;
            this.lvwJoHistory.GridLines = true;
            this.lvwJoHistory.Location = new System.Drawing.Point(6, 79);
            this.lvwJoHistory.Name = "lvwJoHistory";
            this.lvwJoHistory.Size = new System.Drawing.Size(646, 230);
            this.lvwJoHistory.TabIndex = 1;
            this.lvwJoHistory.UseCompatibleStateImageBehavior = false;
            this.lvwJoHistory.View = System.Windows.Forms.View.Details;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Tran Date";
            this.colTranDate.Width = 121;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 152;
            // 
            // colSubStatus
            // 
            this.colSubStatus.Text = "Sub Status";
            this.colSubStatus.Width = 154;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 100;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 120;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(571, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCSDJobHistory
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 355);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwJoHistory);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCSDJobHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD Job History";
            this.Load += new System.EventHandler(this.frmCSDJobHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvwJoHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colSubStatus;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label1;

    }
}