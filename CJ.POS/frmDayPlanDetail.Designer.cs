namespace CJ.POS
{
    partial class frmDayPlanDetail
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
            this.cmbVisitPlanType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbDayPlanPurpose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.dtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTimeTo = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbVisitPlanType
            // 
            this.cmbVisitPlanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitPlanType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitPlanType.FormattingEnabled = true;
            this.cmbVisitPlanType.Location = new System.Drawing.Point(90, 17);
            this.cmbVisitPlanType.Name = "cmbVisitPlanType";
            this.cmbVisitPlanType.Size = new System.Drawing.Size(196, 23);
            this.cmbVisitPlanType.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(420, 251);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 30);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbDayPlanPurpose
            // 
            this.cmbDayPlanPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayPlanPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDayPlanPurpose.FormattingEnabled = true;
            this.cmbDayPlanPurpose.Location = new System.Drawing.Point(90, 46);
            this.cmbDayPlanPurpose.Name = "cmbDayPlanPurpose";
            this.cmbDayPlanPurpose.Size = new System.Drawing.Size(196, 23);
            this.cmbDayPlanPurpose.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Visit Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Plan Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Time From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Time To";
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPlanDate.Location = new System.Drawing.Point(90, 79);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(100, 20);
            this.dtPlanDate.TabIndex = 25;
            // 
            // dtTimeFrom
            // 
            this.dtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeFrom.Location = new System.Drawing.Point(90, 105);
            this.dtTimeFrom.Name = "dtTimeFrom";
            this.dtTimeFrom.ShowUpDown = true;
            this.dtTimeFrom.Size = new System.Drawing.Size(83, 20);
            this.dtTimeFrom.TabIndex = 26;
            // 
            // dtTimeTo
            // 
            this.dtTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeTo.Location = new System.Drawing.Point(90, 131);
            this.dtTimeTo.Name = "dtTimeTo";
            this.dtTimeTo.ShowUpDown = true;
            this.dtTimeTo.Size = new System.Drawing.Size(83, 20);
            this.dtTimeTo.TabIndex = 27;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(90, 199);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(418, 20);
            this.txtAddress.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(90, 225);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(418, 20);
            this.txtRemarks.TabIndex = 30;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(90, 158);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(418, 21);
            this.ctlCustomer1.TabIndex = 32;
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Customer";
            // 
            // frmDayPlanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 293);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.dtTimeTo);
            this.Controls.Add(this.dtTimeFrom);
            this.Controls.Add(this.dtPlanDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDayPlanPurpose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbVisitPlanType);
            this.Name = "frmDayPlanDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDayPlanDetail";
            this.Load += new System.EventHandler(this.frmDayPlanDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVisitPlanType;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbDayPlanPurpose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPlanDate;
        private System.Windows.Forms.DateTimePicker dtTimeFrom;
        private System.Windows.Forms.DateTimePicker dtTimeTo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label8;
    }
}