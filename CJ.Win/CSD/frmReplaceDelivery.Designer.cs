namespace CJ.Win
{
    partial class frmReplaceDelivery
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
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDeliveryRemarks = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbShowroom = new System.Windows.Forms.RadioButton();
            this.rdbCentralWH = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbWHVehicle = new System.Windows.Forms.RadioButton();
            this.rdbByCourier = new System.Windows.Forms.RadioButton();
            this.rdbHomeDelivery = new System.Windows.Forms.RadioButton();
            this.rdbWalkIn = new System.Windows.Forms.RadioButton();
            this.txtDeliveredby = new System.Windows.Forms.TextBox();
            this.lblDeliveredby = new System.Windows.Forms.Label();
            this.txtConsignmentNo = new System.Windows.Forms.TextBox();
            this.lblConsignmentNo = new System.Windows.Forms.Label();
            this.lblCourier = new System.Windows.Forms.Label();
            this.cmbCourierName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReplaceID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(318, 211);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(84, 13);
            this.lblDeliveryDate.TabIndex = 95;
            this.lblDeliveryDate.Text = "Delivery Date";
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeliveryDate.Location = new System.Drawing.Point(405, 208);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(112, 20);
            this.dtDeliveryDate.TabIndex = 94;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(319, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 93;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDeliveryRemarks
            // 
            this.txtDeliveryRemarks.AcceptsReturn = true;
            this.txtDeliveryRemarks.Location = new System.Drawing.Point(25, 253);
            this.txtDeliveryRemarks.Multiline = true;
            this.txtDeliveryRemarks.Name = "txtDeliveryRemarks";
            this.txtDeliveryRemarks.Size = new System.Drawing.Size(492, 54);
            this.txtDeliveryRemarks.TabIndex = 92;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(22, 237);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(64, 13);
            this.lblComments.TabIndex = 96;
            this.lblComments.Text = "Comments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbShowroom);
            this.groupBox1.Controls.Add(this.rdbCentralWH);
            this.groupBox1.Location = new System.Drawing.Point(22, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 37);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery From WH";
            // 
            // rdbShowroom
            // 
            this.rdbShowroom.AutoSize = true;
            this.rdbShowroom.Location = new System.Drawing.Point(379, 13);
            this.rdbShowroom.Name = "rdbShowroom";
            this.rdbShowroom.Size = new System.Drawing.Size(75, 17);
            this.rdbShowroom.TabIndex = 116;
            this.rdbShowroom.Text = "Showroom";
            this.rdbShowroom.UseVisualStyleBackColor = true;
            // 
            // rdbCentralWH
            // 
            this.rdbCentralWH.AutoSize = true;
            this.rdbCentralWH.Location = new System.Drawing.Point(21, 13);
            this.rdbCentralWH.Name = "rdbCentralWH";
            this.rdbCentralWH.Size = new System.Drawing.Size(80, 17);
            this.rdbCentralWH.TabIndex = 115;
            this.rdbCentralWH.Text = "Central WH";
            this.rdbCentralWH.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbWHVehicle);
            this.groupBox2.Controls.Add(this.rdbByCourier);
            this.groupBox2.Controls.Add(this.rdbHomeDelivery);
            this.groupBox2.Controls.Add(this.rdbWalkIn);
            this.groupBox2.Location = new System.Drawing.Point(21, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 37);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode of Delivery";
            // 
            // rdbWHVehicle
            // 
            this.rdbWHVehicle.AutoSize = true;
            this.rdbWHVehicle.Location = new System.Drawing.Point(381, 13);
            this.rdbWHVehicle.Name = "rdbWHVehicle";
            this.rdbWHVehicle.Size = new System.Drawing.Size(82, 17);
            this.rdbWHVehicle.TabIndex = 118;
            this.rdbWHVehicle.Text = "WH Vehicle";
            this.rdbWHVehicle.UseVisualStyleBackColor = true;
            this.rdbWHVehicle.CheckedChanged += new System.EventHandler(this.rdbWHVehicle_CheckedChanged);
            // 
            // rdbByCourier
            // 
            this.rdbByCourier.AutoSize = true;
            this.rdbByCourier.Location = new System.Drawing.Point(261, 13);
            this.rdbByCourier.Name = "rdbByCourier";
            this.rdbByCourier.Size = new System.Drawing.Size(73, 17);
            this.rdbByCourier.TabIndex = 117;
            this.rdbByCourier.Text = "By Courier";
            this.rdbByCourier.UseVisualStyleBackColor = true;
            this.rdbByCourier.CheckedChanged += new System.EventHandler(this.rdbByCourier_CheckedChanged);
            // 
            // rdbHomeDelivery
            // 
            this.rdbHomeDelivery.AutoSize = true;
            this.rdbHomeDelivery.Location = new System.Drawing.Point(133, 13);
            this.rdbHomeDelivery.Name = "rdbHomeDelivery";
            this.rdbHomeDelivery.Size = new System.Drawing.Size(94, 17);
            this.rdbHomeDelivery.TabIndex = 116;
            this.rdbHomeDelivery.Text = "Home Delivery";
            this.rdbHomeDelivery.UseVisualStyleBackColor = true;
            this.rdbHomeDelivery.CheckedChanged += new System.EventHandler(this.rdbHomeDelivery_CheckedChanged);
            // 
            // rdbWalkIn
            // 
            this.rdbWalkIn.AutoSize = true;
            this.rdbWalkIn.Location = new System.Drawing.Point(24, 13);
            this.rdbWalkIn.Name = "rdbWalkIn";
            this.rdbWalkIn.Size = new System.Drawing.Size(62, 17);
            this.rdbWalkIn.TabIndex = 115;
            this.rdbWalkIn.Text = "Walk In";
            this.rdbWalkIn.UseVisualStyleBackColor = true;
            this.rdbWalkIn.CheckedChanged += new System.EventHandler(this.rdbWalkIn_CheckedChanged);
            // 
            // txtDeliveredby
            // 
            this.txtDeliveredby.Location = new System.Drawing.Point(107, 211);
            this.txtDeliveredby.Name = "txtDeliveredby";
            this.txtDeliveredby.Size = new System.Drawing.Size(187, 20);
            this.txtDeliveredby.TabIndex = 127;
            // 
            // lblDeliveredby
            // 
            this.lblDeliveredby.AutoSize = true;
            this.lblDeliveredby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveredby.Location = new System.Drawing.Point(28, 213);
            this.lblDeliveredby.Name = "lblDeliveredby";
            this.lblDeliveredby.Size = new System.Drawing.Size(78, 13);
            this.lblDeliveredby.TabIndex = 128;
            this.lblDeliveredby.Text = "Delivered by";
            // 
            // txtConsignmentNo
            // 
            this.txtConsignmentNo.Location = new System.Drawing.Point(405, 182);
            this.txtConsignmentNo.Name = "txtConsignmentNo";
            this.txtConsignmentNo.Size = new System.Drawing.Size(112, 20);
            this.txtConsignmentNo.TabIndex = 131;
            // 
            // lblConsignmentNo
            // 
            this.lblConsignmentNo.AutoSize = true;
            this.lblConsignmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignmentNo.Location = new System.Drawing.Point(312, 186);
            this.lblConsignmentNo.Name = "lblConsignmentNo";
            this.lblConsignmentNo.Size = new System.Drawing.Size(91, 13);
            this.lblConsignmentNo.TabIndex = 132;
            this.lblConsignmentNo.Text = "Consignment #";
            // 
            // lblCourier
            // 
            this.lblCourier.AutoSize = true;
            this.lblCourier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourier.Location = new System.Drawing.Point(23, 186);
            this.lblCourier.Name = "lblCourier";
            this.lblCourier.Size = new System.Drawing.Size(83, 13);
            this.lblCourier.TabIndex = 130;
            this.lblCourier.Text = "Courier Name";
            // 
            // cmbCourierName
            // 
            this.cmbCourierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourierName.FormattingEnabled = true;
            this.cmbCourierName.Location = new System.Drawing.Point(107, 183);
            this.cmbCourierName.Name = "cmbCourierName";
            this.cmbCourierName.Size = new System.Drawing.Size(187, 21);
            this.cmbCourierName.TabIndex = 133;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblContactNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblReplaceID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblCustomerName);
            this.groupBox3.Controls.Add(this.lblJobNo);
            this.groupBox3.Location = new System.Drawing.Point(23, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 68);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(412, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 27);
            this.btnCancel.TabIndex = 154;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReplaceDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 352);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmbCourierName);
            this.Controls.Add(this.txtConsignmentNo);
            this.Controls.Add(this.lblConsignmentNo);
            this.Controls.Add(this.lblCourier);
            this.Controls.Add(this.txtDeliveredby);
            this.Controls.Add(this.lblDeliveredby);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtDeliveryDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDeliveryRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Delivery";
            this.Load += new System.EventHandler(this.frmReplaceDelivery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDeliveryRemarks;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbShowroom;
        private System.Windows.Forms.RadioButton rdbCentralWH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbHomeDelivery;
        private System.Windows.Forms.RadioButton rdbWalkIn;
        private System.Windows.Forms.TextBox txtDeliveredby;
        private System.Windows.Forms.Label lblDeliveredby;
        private System.Windows.Forms.RadioButton rdbWHVehicle;
        private System.Windows.Forms.RadioButton rdbByCourier;
        private System.Windows.Forms.TextBox txtConsignmentNo;
        private System.Windows.Forms.Label lblConsignmentNo;
        private System.Windows.Forms.Label lblCourier;
        private System.Windows.Forms.ComboBox cmbCourierName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReplaceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
    }
}