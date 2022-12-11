namespace CJ.Win.Distribution
{
    partial class frmCACInvoiceWiseCapacity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACInvoiceWiseCapacity));
            this.dtInvDate = new System.Windows.Forms.DateTimePicker();
            this.btnGo = new System.Windows.Forms.Button();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIndoorCapacity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutdoorCapacity = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtInvDate
            // 
            this.dtInvDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInvDate.Enabled = false;
            this.dtInvDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvDate.Location = new System.Drawing.Point(332, 6);
            this.dtInvDate.Name = "dtInvDate";
            this.dtInvDate.Size = new System.Drawing.Size(118, 23);
            this.dtInvDate.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGo.Location = new System.Drawing.Point(458, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(64, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Get";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lbldate.Location = new System.Drawing.Point(282, 10);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(37, 15);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Date:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblNumber.Location = new System.Drawing.Point(57, 10);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(61, 15);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Invoice #:";
            // 
            // txtInvNo
            // 
            this.txtInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvNo.Location = new System.Drawing.Point(139, 6);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(142, 23);
            this.txtInvNo.TabIndex = 1;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(139, 151);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(383, 23);
            this.txtRemarks.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(75, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Remarks:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(451, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 28);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(33, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Indoor Capacity:";
            // 
            // txtIndoorCapacity
            // 
            this.txtIndoorCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndoorCapacity.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtIndoorCapacity.Location = new System.Drawing.Point(139, 93);
            this.txtIndoorCapacity.Name = "txtIndoorCapacity";
            this.txtIndoorCapacity.Size = new System.Drawing.Size(142, 23);
            this.txtIndoorCapacity.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(22, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Outdoor Capacity:";
            // 
            // txtOutdoorCapacity
            // 
            this.txtOutdoorCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutdoorCapacity.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtOutdoorCapacity.Location = new System.Drawing.Point(139, 122);
            this.txtOutdoorCapacity.Name = "txtOutdoorCapacity";
            this.txtOutdoorCapacity.Size = new System.Drawing.Size(142, 23);
            this.txtOutdoorCapacity.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(374, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 28);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(34, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Customer Name:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtCustomer.Location = new System.Drawing.Point(139, 35);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(311, 23);
            this.txtCustomer.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(78, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtAmount.Location = new System.Drawing.Point(139, 64);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(142, 23);
            this.txtAmount.TabIndex = 8;
            // 
            // frmCACInvoiceWiseCapacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 225);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutdoorCapacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIndoorCapacity);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtInvDate);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtInvNo);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACInvoiceWiseCapacity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Invoice Wise Capacity";
            this.Load += new System.EventHandler(this.frmCACInvoiceWiseCapacity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInvDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIndoorCapacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutdoorCapacity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmount;
    }
}