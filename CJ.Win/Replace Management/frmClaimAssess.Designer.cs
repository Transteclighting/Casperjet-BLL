namespace CJ.Win.Replace_Management
{
    partial class frmClaimAssess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaimAssess));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.txtSubClaimNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtValidationDate = new System.Windows.Forms.DateTimePicker();
            this.dgvClaimAssess = new System.Windows.Forms.DataGridView();
            this.txtClaimDate = new System.Windows.Forms.TextBox();
            this.txtClaimMonth = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaimAssess)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Claim Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Claim Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Claim No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Claim No:";
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtClaimNo.Enabled = false;
            this.txtClaimNo.Location = new System.Drawing.Point(94, 12);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(138, 20);
            this.txtClaimNo.TabIndex = 1;
            // 
            // txtSubClaimNo
            // 
            this.txtSubClaimNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtSubClaimNo.Enabled = false;
            this.txtSubClaimNo.Location = new System.Drawing.Point(94, 38);
            this.txtSubClaimNo.Name = "txtSubClaimNo";
            this.txtSubClaimNo.Size = new System.Drawing.Size(138, 20);
            this.txtSubClaimNo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ValidationDate:";
            // 
            // dtValidationDate
            // 
            this.dtValidationDate.CustomFormat = "dd-MMM-yyyy";
            this.dtValidationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtValidationDate.Location = new System.Drawing.Point(94, 90);
            this.dtValidationDate.Name = "dtValidationDate";
            this.dtValidationDate.Size = new System.Drawing.Size(138, 20);
            this.dtValidationDate.TabIndex = 11;
            this.dtValidationDate.Value = new System.DateTime(2017, 10, 16, 13, 54, 31, 0);
            // 
            // dgvClaimAssess
            // 
            this.dgvClaimAssess.AllowUserToAddRows = false;
            this.dgvClaimAssess.AllowUserToDeleteRows = false;
            this.dgvClaimAssess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClaimAssess.Location = new System.Drawing.Point(10, 116);
            this.dgvClaimAssess.Name = "dgvClaimAssess";
            this.dgvClaimAssess.Size = new System.Drawing.Size(667, 278);
            this.dgvClaimAssess.TabIndex = 12;
            // 
            // txtClaimDate
            // 
            this.txtClaimDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtClaimDate.Enabled = false;
            this.txtClaimDate.Location = new System.Drawing.Point(323, 38);
            this.txtClaimDate.Name = "txtClaimDate";
            this.txtClaimDate.Size = new System.Drawing.Size(138, 20);
            this.txtClaimDate.TabIndex = 7;
            // 
            // txtClaimMonth
            // 
            this.txtClaimMonth.BackColor = System.Drawing.SystemColors.Info;
            this.txtClaimMonth.Enabled = false;
            this.txtClaimMonth.Location = new System.Drawing.Point(323, 12);
            this.txtClaimMonth.Name = "txtClaimMonth";
            this.txtClaimMonth.Size = new System.Drawing.Size(138, 20);
            this.txtClaimMonth.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(602, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(521, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Customer Name:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(94, 64);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(367, 20);
            this.txtCustomer.TabIndex = 9;
            // 
            // frmClaimAssess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 426);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtClaimDate);
            this.Controls.Add(this.txtClaimMonth);
            this.Controls.Add(this.dgvClaimAssess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtValidationDate);
            this.Controls.Add(this.txtSubClaimNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClaimNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClaimAssess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClaimAssess";
            this.Load += new System.EventHandler(this.frmClaimAssess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaimAssess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.TextBox txtSubClaimNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtValidationDate;
        private System.Windows.Forms.DataGridView dgvClaimAssess;
        private System.Windows.Forms.TextBox txtClaimDate;
        private System.Windows.Forms.TextBox txtClaimMonth;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
    }
}