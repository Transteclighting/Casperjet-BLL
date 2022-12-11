namespace CJ.Win
{
    partial class frmVehicleScheduleSuspend
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
            this.label8 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.grpEDD = new System.Windows.Forms.GroupBox();
            this.cmbSuspendReason = new System.Windows.Forms.ComboBox();
            this.lblSuspendReason = new System.Windows.Forms.Label();
            this.txtSuspendRemarks = new System.Windows.Forms.TextBox();
            this.lblSuspendRemarks = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblVRID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.grpEDD.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(158, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 231;
            this.label8.Text = "Remarks";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.Location = new System.Drawing.Point(224, 72);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(272, 20);
            this.lblRemarks.TabIndex = 230;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblJob
            // 
            this.lblJob.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(24, 72);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(54, 20);
            this.lblJob.TabIndex = 229;
            this.lblJob.Text = "Job#";
            // 
            // lblJobNo
            // 
            this.lblJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobNo.Location = new System.Drawing.Point(77, 72);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(79, 20);
            this.lblJobNo.TabIndex = 228;
            this.lblJobNo.Text = "JobNo";
            // 
            // grpEDD
            // 
            this.grpEDD.Controls.Add(this.cmbSuspendReason);
            this.grpEDD.Controls.Add(this.lblSuspendReason);
            this.grpEDD.Controls.Add(this.txtSuspendRemarks);
            this.grpEDD.Controls.Add(this.lblSuspendRemarks);
            this.grpEDD.Location = new System.Drawing.Point(12, 121);
            this.grpEDD.Name = "grpEDD";
            this.grpEDD.Size = new System.Drawing.Size(496, 123);
            this.grpEDD.TabIndex = 227;
            this.grpEDD.TabStop = false;
            // 
            // cmbSuspendReason
            // 
            this.cmbSuspendReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuspendReason.FormattingEnabled = true;
            this.cmbSuspendReason.ItemHeight = 13;
            this.cmbSuspendReason.Location = new System.Drawing.Point(113, 19);
            this.cmbSuspendReason.Name = "cmbSuspendReason";
            this.cmbSuspendReason.Size = new System.Drawing.Size(152, 21);
            this.cmbSuspendReason.TabIndex = 0;
            // 
            // lblSuspendReason
            // 
            this.lblSuspendReason.AutoSize = true;
            this.lblSuspendReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuspendReason.Location = new System.Drawing.Point(8, 22);
            this.lblSuspendReason.Name = "lblSuspendReason";
            this.lblSuspendReason.Size = new System.Drawing.Size(103, 13);
            this.lblSuspendReason.TabIndex = 174;
            this.lblSuspendReason.Text = "Suspend Reason";
            // 
            // txtSuspendRemarks
            // 
            this.txtSuspendRemarks.Location = new System.Drawing.Point(6, 69);
            this.txtSuspendRemarks.Multiline = true;
            this.txtSuspendRemarks.Name = "txtSuspendRemarks";
            this.txtSuspendRemarks.Size = new System.Drawing.Size(478, 42);
            this.txtSuspendRemarks.TabIndex = 1;
            // 
            // lblSuspendRemarks
            // 
            this.lblSuspendRemarks.AutoSize = true;
            this.lblSuspendRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuspendRemarks.Location = new System.Drawing.Point(6, 52);
            this.lblSuspendRemarks.Name = "lblSuspendRemarks";
            this.lblSuspendRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblSuspendRemarks.TabIndex = 168;
            this.lblSuspendRemarks.Text = "Remarks";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(403, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 224;
            this.label3.Text = "Mobile";
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContactNo.Location = new System.Drawing.Point(396, 26);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(100, 20);
            this.lblContactNo.TabIndex = 223;
            this.lblContactNo.Text = "ContactNo";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(24, 26);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(54, 20);
            this.lblID.TabIndex = 222;
            this.lblID.Text = "VR ID";
            // 
            // lblVRID
            // 
            this.lblVRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVRID.Location = new System.Drawing.Point(77, 26);
            this.lblVRID.Name = "lblVRID";
            this.lblVRID.Size = new System.Drawing.Size(61, 20);
            this.lblVRID.TabIndex = 221;
            this.lblVRID.Text = "VRID";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 220;
            this.label2.Text = "Customer";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 219;
            this.label1.Text = "Address";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Location = new System.Drawing.Point(201, 26);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(145, 20);
            this.lblCustomerName.TabIndex = 218;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.Location = new System.Drawing.Point(77, 49);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(419, 20);
            this.lblAddress.TabIndex = 217;
            this.lblAddress.Text = "Address";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(292, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpBasic
            // 
            this.grpBasic.Location = new System.Drawing.Point(12, 9);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(496, 96);
            this.grpBasic.TabIndex = 225;
            this.grpBasic.TabStop = false;
            // 
            // frmVehicleScheduleSuspend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 295);
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
            this.Name = "frmVehicleScheduleSuspend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Schedule Suspend";
            this.Load += new System.EventHandler(this.frmVehicleScheduleSuspend_Load);
            this.grpEDD.ResumeLayout(false);
            this.grpEDD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.GroupBox grpEDD;
        private System.Windows.Forms.TextBox txtSuspendRemarks;
        private System.Windows.Forms.Label lblSuspendRemarks;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblVRID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.ComboBox cmbSuspendReason;
        private System.Windows.Forms.Label lblSuspendReason;
    }
}