namespace CJ.Win
{
    partial class frmISVPartsRequisitionSend
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbCourierName = new System.Windows.Forms.ComboBox();
            this.txtConsignmentNo = new System.Windows.Forms.TextBox();
            this.lblConsignmentNo = new System.Windows.Forms.Label();
            this.lblCourier = new System.Windows.Forms.Label();
            this.txtReceivedby = new System.Windows.Forms.TextBox();
            this.lblReceiveBy = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbHand2Hand = new System.Windows.Forms.RadioButton();
            this.rdbByCourier = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRequisitionID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInterService = new System.Windows.Forms.Label();
            this.lblReportNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(443, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 27);
            this.btnCancel.TabIndex = 166;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbCourierName
            // 
            this.cmbCourierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourierName.FormattingEnabled = true;
            this.cmbCourierName.Location = new System.Drawing.Point(117, 134);
            this.cmbCourierName.Name = "cmbCourierName";
            this.cmbCourierName.Size = new System.Drawing.Size(187, 21);
            this.cmbCourierName.TabIndex = 165;
            // 
            // txtConsignmentNo
            // 
            this.txtConsignmentNo.Location = new System.Drawing.Point(415, 133);
            this.txtConsignmentNo.Name = "txtConsignmentNo";
            this.txtConsignmentNo.Size = new System.Drawing.Size(112, 20);
            this.txtConsignmentNo.TabIndex = 163;
            // 
            // lblConsignmentNo
            // 
            this.lblConsignmentNo.AutoSize = true;
            this.lblConsignmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignmentNo.Location = new System.Drawing.Point(322, 137);
            this.lblConsignmentNo.Name = "lblConsignmentNo";
            this.lblConsignmentNo.Size = new System.Drawing.Size(91, 13);
            this.lblConsignmentNo.TabIndex = 164;
            this.lblConsignmentNo.Text = "Consignment #";
            // 
            // lblCourier
            // 
            this.lblCourier.AutoSize = true;
            this.lblCourier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourier.Location = new System.Drawing.Point(33, 137);
            this.lblCourier.Name = "lblCourier";
            this.lblCourier.Size = new System.Drawing.Size(83, 13);
            this.lblCourier.TabIndex = 162;
            this.lblCourier.Text = "Courier Name";
            // 
            // txtReceivedby
            // 
            this.txtReceivedby.Location = new System.Drawing.Point(117, 162);
            this.txtReceivedby.Name = "txtReceivedby";
            this.txtReceivedby.Size = new System.Drawing.Size(187, 20);
            this.txtReceivedby.TabIndex = 160;
            // 
            // lblReceiveBy
            // 
            this.lblReceiveBy.AutoSize = true;
            this.lblReceiveBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveBy.Location = new System.Drawing.Point(38, 164);
            this.lblReceiveBy.Name = "lblReceiveBy";
            this.lblReceiveBy.Size = new System.Drawing.Size(72, 13);
            this.lblReceiveBy.TabIndex = 161;
            this.lblReceiveBy.Text = "Receive By";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(32, 193);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 159;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(328, 162);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(84, 13);
            this.lblDeliveryDate.TabIndex = 158;
            this.lblDeliveryDate.Text = "Delivery Date";
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeliveryDate.Location = new System.Drawing.Point(415, 159);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(112, 20);
            this.dtDeliveryDate.TabIndex = 157;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(350, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 156;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.AcceptsReturn = true;
            this.txtRemarks.Location = new System.Drawing.Point(35, 209);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(492, 54);
            this.txtRemarks.TabIndex = 155;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbHand2Hand);
            this.groupBox1.Controls.Add(this.rdbByCourier);
            this.groupBox1.Location = new System.Drawing.Point(32, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 37);
            this.groupBox1.TabIndex = 167;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode of Delivery";
            // 
            // rdbHand2Hand
            // 
            this.rdbHand2Hand.AutoSize = true;
            this.rdbHand2Hand.Location = new System.Drawing.Point(379, 13);
            this.rdbHand2Hand.Name = "rdbHand2Hand";
            this.rdbHand2Hand.Size = new System.Drawing.Size(90, 17);
            this.rdbHand2Hand.TabIndex = 116;
            this.rdbHand2Hand.Text = "Hand-to-hand";
            this.rdbHand2Hand.UseVisualStyleBackColor = true;
            this.rdbHand2Hand.CheckedChanged += new System.EventHandler(this.rdbHand2Hand_CheckedChanged);
            // 
            // rdbByCourier
            // 
            this.rdbByCourier.AutoSize = true;
            this.rdbByCourier.Location = new System.Drawing.Point(21, 13);
            this.rdbByCourier.Name = "rdbByCourier";
            this.rdbByCourier.Size = new System.Drawing.Size(73, 17);
            this.rdbByCourier.TabIndex = 115;
            this.rdbByCourier.Text = "By Courier";
            this.rdbByCourier.UseVisualStyleBackColor = true;
            this.rdbByCourier.CheckedChanged += new System.EventHandler(this.rdbByCourier_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblSerialNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblRequisitionID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblInterService);
            this.groupBox3.Controls.Add(this.lblReportNo);
            this.groupBox3.Location = new System.Drawing.Point(32, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 68);
            this.groupBox3.TabIndex = 168;
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
            this.label3.Text = "Serial No";
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSerialNo.Location = new System.Drawing.Point(312, 40);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(172, 20);
            this.lblSerialNo.TabIndex = 151;
            this.lblSerialNo.Text = "?";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 150;
            this.label5.Text = "Requisition ID";
            // 
            // lblRequisitionID
            // 
            this.lblRequisitionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRequisitionID.Location = new System.Drawing.Point(104, 15);
            this.lblRequisitionID.Name = "lblRequisitionID";
            this.lblRequisitionID.Size = new System.Drawing.Size(92, 19);
            this.lblRequisitionID.TabIndex = 149;
            this.lblRequisitionID.Text = "?";
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
            this.label2.Text = "Inter Service";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Report No";
            // 
            // lblInterService
            // 
            this.lblInterService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInterService.Location = new System.Drawing.Point(312, 14);
            this.lblInterService.Name = "lblInterService";
            this.lblInterService.Size = new System.Drawing.Size(172, 20);
            this.lblInterService.TabIndex = 146;
            this.lblInterService.Text = "?";
            // 
            // lblReportNo
            // 
            this.lblReportNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReportNo.Location = new System.Drawing.Point(105, 41);
            this.lblReportNo.Name = "lblReportNo";
            this.lblReportNo.Size = new System.Drawing.Size(91, 19);
            this.lblReportNo.TabIndex = 145;
            this.lblReportNo.Text = "?";
            // 
            // frmISVPartsRequisitionSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 312);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbCourierName);
            this.Controls.Add(this.txtConsignmentNo);
            this.Controls.Add(this.lblConsignmentNo);
            this.Controls.Add(this.lblCourier);
            this.Controls.Add(this.txtReceivedby);
            this.Controls.Add(this.lblReceiveBy);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtDeliveryDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISVPartsRequisitionSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISV Parts Delivery";
            this.Load += new System.EventHandler(this.frmISVPartsRequisitionSend_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbCourierName;
        private System.Windows.Forms.TextBox txtConsignmentNo;
        private System.Windows.Forms.Label lblConsignmentNo;
        private System.Windows.Forms.Label lblCourier;
        private System.Windows.Forms.TextBox txtReceivedby;
        private System.Windows.Forms.Label lblReceiveBy;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbHand2Hand;
        private System.Windows.Forms.RadioButton rdbByCourier;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRequisitionID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInterService;
        private System.Windows.Forms.Label lblReportNo;
    }
}