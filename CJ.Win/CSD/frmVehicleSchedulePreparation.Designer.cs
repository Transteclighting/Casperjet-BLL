namespace CJ.Win
{
    partial class frmVehicleSchedulePreparation
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblVRID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblScheduleRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtScheduleRemarks = new System.Windows.Forms.TextBox();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.chkContactCustomer = new System.Windows.Forms.CheckBox();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.dtForm = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpEDD = new System.Windows.Forms.GroupBox();
            this.dtScheduleTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtScheduleTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblScheduleDate = new System.Windows.Forms.Label();
            this.dtScheduleDate = new System.Windows.Forms.DateTimePicker();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.grpBasic.SuspendLayout();
            this.grpEDD.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 176;
            this.label3.Text = "Mobile";
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContactNo.Location = new System.Drawing.Point(413, 27);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(100, 20);
            this.lblContactNo.TabIndex = 175;
            this.lblContactNo.Text = "ContactNo";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(41, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(54, 20);
            this.lblID.TabIndex = 174;
            this.lblID.Text = "VR ID";
            // 
            // lblVRID
            // 
            this.lblVRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVRID.Location = new System.Drawing.Point(94, 27);
            this.lblVRID.Name = "lblVRID";
            this.lblVRID.Size = new System.Drawing.Size(61, 20);
            this.lblVRID.TabIndex = 173;
            this.lblVRID.Text = "VRID";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 172;
            this.label2.Text = "Customer";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 171;
            this.label1.Text = "Address";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Location = new System.Drawing.Point(218, 27);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(145, 20);
            this.lblCustomerName.TabIndex = 170;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.Location = new System.Drawing.Point(94, 50);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(419, 20);
            this.lblAddress.TabIndex = 169;
            this.lblAddress.Text = "Address";
            // 
            // lblScheduleRemarks
            // 
            this.lblScheduleRemarks.AutoSize = true;
            this.lblScheduleRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleRemarks.Location = new System.Drawing.Point(2, 54);
            this.lblScheduleRemarks.Name = "lblScheduleRemarks";
            this.lblScheduleRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblScheduleRemarks.TabIndex = 168;
            this.lblScheduleRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(306, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtScheduleRemarks
            // 
            this.txtScheduleRemarks.Location = new System.Drawing.Point(58, 54);
            this.txtScheduleRemarks.Multiline = true;
            this.txtScheduleRemarks.Name = "txtScheduleRemarks";
            this.txtScheduleRemarks.Size = new System.Drawing.Size(423, 42);
            this.txtScheduleRemarks.TabIndex = 3;
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.chkContactCustomer);
            this.grpBasic.Controls.Add(this.lblExpectedDate);
            this.grpBasic.Controls.Add(this.lblFrom);
            this.grpBasic.Controls.Add(this.dtExpectedDate);
            this.grpBasic.Controls.Add(this.dtForm);
            this.grpBasic.Controls.Add(this.dtTo);
            this.grpBasic.Controls.Add(this.lblTo);
            this.grpBasic.Location = new System.Drawing.Point(29, 10);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(496, 132);
            this.grpBasic.TabIndex = 177;
            this.grpBasic.TabStop = false;
            // 
            // chkContactCustomer
            // 
            this.chkContactCustomer.AutoSize = true;
            this.chkContactCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContactCustomer.Location = new System.Drawing.Point(14, 113);
            this.chkContactCustomer.Name = "chkContactCustomer";
            this.chkContactCustomer.Size = new System.Drawing.Size(203, 17);
            this.chkContactCustomer.TabIndex = 178;
            this.chkContactCustomer.TabStop = false;
            this.chkContactCustomer.Text = "Contact Customer for Date-time";
            this.chkContactCustomer.UseVisualStyleBackColor = true;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedDate.Location = new System.Drawing.Point(11, 92);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(91, 13);
            this.lblExpectedDate.TabIndex = 105;
            this.lblExpectedDate.Text = "Expected Date";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(249, 90);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 122;
            this.lblFrom.Text = "From";
            // 
            // dtExpectedDate
            // 
            this.dtExpectedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpectedDate.Location = new System.Drawing.Point(105, 88);
            this.dtExpectedDate.Name = "dtExpectedDate";
            this.dtExpectedDate.Size = new System.Drawing.Size(108, 20);
            this.dtExpectedDate.TabIndex = 106;
            this.dtExpectedDate.TabStop = false;
            // 
            // dtForm
            // 
            this.dtForm.CustomFormat = "hh:mm tt";
            this.dtForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtForm.Location = new System.Drawing.Point(289, 88);
            this.dtForm.Name = "dtForm";
            this.dtForm.Size = new System.Drawing.Size(81, 20);
            this.dtForm.TabIndex = 134;
            this.dtForm.TabStop = false;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "hh:mm tt";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(403, 88);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(81, 20);
            this.dtTo.TabIndex = 125;
            this.dtTo.TabStop = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(376, 90);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 124;
            this.lblTo.Text = "To";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(417, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpEDD
            // 
            this.grpEDD.Controls.Add(this.dtScheduleTimeFrom);
            this.grpEDD.Controls.Add(this.label4);
            this.grpEDD.Controls.Add(this.dtScheduleTimeTo);
            this.grpEDD.Controls.Add(this.label6);
            this.grpEDD.Controls.Add(this.lblScheduleDate);
            this.grpEDD.Controls.Add(this.dtScheduleDate);
            this.grpEDD.Controls.Add(this.txtScheduleRemarks);
            this.grpEDD.Controls.Add(this.lblScheduleRemarks);
            this.grpEDD.Location = new System.Drawing.Point(29, 148);
            this.grpEDD.Name = "grpEDD";
            this.grpEDD.Size = new System.Drawing.Size(496, 112);
            this.grpEDD.TabIndex = 179;
            this.grpEDD.TabStop = false;
            // 
            // dtScheduleTimeFrom
            // 
            this.dtScheduleTimeFrom.CustomFormat = "hh:mm tt";
            this.dtScheduleTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleTimeFrom.Location = new System.Drawing.Point(287, 21);
            this.dtScheduleTimeFrom.Name = "dtScheduleTimeFrom";
            this.dtScheduleTimeFrom.Size = new System.Drawing.Size(81, 20);
            this.dtScheduleTimeFrom.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "To";
            // 
            // dtScheduleTimeTo
            // 
            this.dtScheduleTimeTo.CustomFormat = "hh:mm tt";
            this.dtScheduleTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleTimeTo.Location = new System.Drawing.Point(399, 21);
            this.dtScheduleTimeTo.Name = "dtScheduleTimeTo";
            this.dtScheduleTimeTo.Size = new System.Drawing.Size(81, 20);
            this.dtScheduleTimeTo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(251, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 122;
            this.label6.Text = "From";
            // 
            // lblScheduleDate
            // 
            this.lblScheduleDate.AutoSize = true;
            this.lblScheduleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleDate.Location = new System.Drawing.Point(8, 23);
            this.lblScheduleDate.Name = "lblScheduleDate";
            this.lblScheduleDate.Size = new System.Drawing.Size(91, 13);
            this.lblScheduleDate.TabIndex = 105;
            this.lblScheduleDate.Text = "Schedule Date";
            // 
            // dtScheduleDate
            // 
            this.dtScheduleDate.CustomFormat = "dd-MMM-yyyy";
            this.dtScheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtScheduleDate.Location = new System.Drawing.Point(105, 21);
            this.dtScheduleDate.Name = "dtScheduleDate";
            this.dtScheduleDate.Size = new System.Drawing.Size(108, 20);
            this.dtScheduleDate.TabIndex = 0;
            // 
            // lblJob
            // 
            this.lblJob.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(41, 73);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(54, 20);
            this.lblJob.TabIndex = 181;
            this.lblJob.Text = "Job#";
            // 
            // lblJobNo
            // 
            this.lblJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobNo.Location = new System.Drawing.Point(94, 73);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(79, 20);
            this.lblJobNo.TabIndex = 180;
            this.lblJobNo.Text = "JobNo";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(175, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 183;
            this.label8.Text = "Remarks";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.Location = new System.Drawing.Point(241, 73);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(272, 20);
            this.lblRemarks.TabIndex = 182;
            this.lblRemarks.Text = "Remarks";
            // 
            // frmVehicleSchedulePreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 307);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.grpEDD);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblVRID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBasic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVehicleSchedulePreparation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Schedule Preparation";
            this.Load += new System.EventHandler(this.frmVehicleSchedulePreparation_Load);
            this.grpBasic.ResumeLayout(false);
            this.grpBasic.PerformLayout();
            this.grpEDD.ResumeLayout(false);
            this.grpEDD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblVRID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblScheduleRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtScheduleRemarks;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.DateTimePicker dtForm;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.DateTimePicker dtExpectedDate;
        private System.Windows.Forms.CheckBox chkContactCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpEDD;
        private System.Windows.Forms.DateTimePicker dtScheduleTimeFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtScheduleTimeTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblScheduleDate;
        private System.Windows.Forms.DateTimePicker dtScheduleDate;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemarks;
    }
}