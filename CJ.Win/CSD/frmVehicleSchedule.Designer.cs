namespace CJ.Win
{
    partial class frmVehicleSchedule
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
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.rdoServiceWarranty = new System.Windows.Forms.RadioButton();
            this.rdoFullWarranty = new System.Windows.Forms.RadioButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.dtExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.rdoDrop = new System.Windows.Forms.RadioButton();
            this.rdoPickUp = new System.Windows.Forms.RadioButton();
            this.rdoPaid = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblJobType = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblRequisitionType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.chkContactCustomer = new System.Windows.Forms.CheckBox();
            this.chkJobNoAvailable = new System.Windows.Forms.CheckBox();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.grpJobNo = new System.Windows.Forms.GroupBox();
            this.grpCustomerDetail = new System.Windows.Forms.GroupBox();
            this.dtForm = new System.Windows.Forms.DateTimePicker();
            this.grpEDD = new System.Windows.Forms.GroupBox();
            this.ctlProduct2 = new CJ.Win.ctlProduct();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpJobNo.SuspendLayout();
            this.grpCustomerDetail.SuspendLayout();
            this.grpEDD.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(106, 65);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(170, 20);
            this.txtContactNo.TabIndex = 3;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(33, 68);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(71, 13);
            this.lblContactNo.TabIndex = 8;
            this.lblContactNo.Text = "Contact No";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(106, 14);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(300, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(8, 17);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // rdoServiceWarranty
            // 
            this.rdoServiceWarranty.AutoSize = true;
            this.rdoServiceWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoServiceWarranty.Location = new System.Drawing.Point(125, 12);
            this.rdoServiceWarranty.Name = "rdoServiceWarranty";
            this.rdoServiceWarranty.Size = new System.Drawing.Size(123, 17);
            this.rdoServiceWarranty.TabIndex = 5;
            this.rdoServiceWarranty.TabStop = true;
            this.rdoServiceWarranty.Text = "Service Warranty";
            this.rdoServiceWarranty.UseVisualStyleBackColor = true;
            // 
            // rdoFullWarranty
            // 
            this.rdoFullWarranty.AutoSize = true;
            this.rdoFullWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFullWarranty.Location = new System.Drawing.Point(8, 12);
            this.rdoFullWarranty.Name = "rdoFullWarranty";
            this.rdoFullWarranty.Size = new System.Drawing.Size(100, 17);
            this.rdoFullWarranty.TabIndex = 4;
            this.rdoFullWarranty.TabStop = true;
            this.rdoFullWarranty.Text = "Full Warranty";
            this.rdoFullWarranty.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(113, 370);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(473, 34);
            this.txtRemarks.TabIndex = 15;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(53, 371);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 104;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(409, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 27);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(506, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedDate.Location = new System.Drawing.Point(9, 15);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(91, 13);
            this.lblExpectedDate.TabIndex = 105;
            this.lblExpectedDate.Text = "Expected Date";
            // 
            // dtExpectedDate
            // 
            this.dtExpectedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpectedDate.Location = new System.Drawing.Point(106, 13);
            this.dtExpectedDate.Name = "dtExpectedDate";
            this.dtExpectedDate.Size = new System.Drawing.Size(108, 20);
            this.dtExpectedDate.TabIndex = 11;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(106, 40);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(51, 43);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 13);
            this.lblAddress.TabIndex = 110;
            this.lblAddress.Text = "Address";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(113, 236);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(350, 20);
            this.txtLocation.TabIndex = 8;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(78, 239);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(33, 13);
            this.lblLocation.TabIndex = 112;
            this.lblLocation.Text = "Area";
            // 
            // rdoDrop
            // 
            this.rdoDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDrop.Location = new System.Drawing.Point(132, 11);
            this.rdoDrop.Name = "rdoDrop";
            this.rdoDrop.Size = new System.Drawing.Size(81, 17);
            this.rdoDrop.TabIndex = 10;
            this.rdoDrop.TabStop = true;
            this.rdoDrop.Text = "Drop";
            this.rdoDrop.UseVisualStyleBackColor = true;
            // 
            // rdoPickUp
            // 
            this.rdoPickUp.AutoSize = true;
            this.rdoPickUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPickUp.Location = new System.Drawing.Point(14, 11);
            this.rdoPickUp.Name = "rdoPickUp";
            this.rdoPickUp.Size = new System.Drawing.Size(70, 17);
            this.rdoPickUp.TabIndex = 9;
            this.rdoPickUp.TabStop = true;
            this.rdoPickUp.Text = "Pick-Up";
            this.rdoPickUp.UseVisualStyleBackColor = true;
            // 
            // rdoPaid
            // 
            this.rdoPaid.AutoSize = true;
            this.rdoPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPaid.Location = new System.Drawing.Point(265, 12);
            this.rdoPaid.Name = "rdoPaid";
            this.rdoPaid.Size = new System.Drawing.Size(50, 17);
            this.rdoPaid.TabIndex = 6;
            this.rdoPaid.TabStop = true;
            this.rdoPaid.Text = "Paid";
            this.rdoPaid.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPaid);
            this.groupBox1.Controls.Add(this.rdoServiceWarranty);
            this.groupBox1.Controls.Add(this.rdoFullWarranty);
            this.groupBox1.Location = new System.Drawing.Point(106, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 36);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            // 
            // lblJobType
            // 
            this.lblJobType.AutoSize = true;
            this.lblJobType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobType.Location = new System.Drawing.Point(43, 95);
            this.lblJobType.Name = "lblJobType";
            this.lblJobType.Size = new System.Drawing.Size(59, 13);
            this.lblJobType.TabIndex = 117;
            this.lblJobType.Text = "Job Type";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(51, 130);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(51, 13);
            this.lblProduct.TabIndex = 119;
            this.lblProduct.Text = "Product";
            // 
            // lblRequisitionType
            // 
            this.lblRequisitionType.AutoSize = true;
            this.lblRequisitionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionType.Location = new System.Drawing.Point(6, 273);
            this.lblRequisitionType.Name = "lblRequisitionType";
            this.lblRequisitionType.Size = new System.Drawing.Size(102, 13);
            this.lblRequisitionType.TabIndex = 120;
            this.lblRequisitionType.Text = "Requisition Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDrop);
            this.groupBox2.Controls.Add(this.rdoPickUp);
            this.groupBox2.Location = new System.Drawing.Point(112, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 34);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(232, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 122;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(352, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 124;
            this.lblTo.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "hh:mm tt";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(377, 13);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(81, 20);
            this.dtTo.TabIndex = 13;
            // 
            // chkContactCustomer
            // 
            this.chkContactCustomer.AutoSize = true;
            this.chkContactCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContactCustomer.Location = new System.Drawing.Point(116, 344);
            this.chkContactCustomer.Name = "chkContactCustomer";
            this.chkContactCustomer.Size = new System.Drawing.Size(203, 17);
            this.chkContactCustomer.TabIndex = 14;
            this.chkContactCustomer.Text = "Contact Customer for Date-time";
            this.chkContactCustomer.UseVisualStyleBackColor = true;
            this.chkContactCustomer.CheckedChanged += new System.EventHandler(this.chkContactCustomer_CheckedChanged);
            // 
            // chkJobNoAvailable
            // 
            this.chkJobNoAvailable.AutoSize = true;
            this.chkJobNoAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJobNoAvailable.Location = new System.Drawing.Point(116, 58);
            this.chkJobNoAvailable.Name = "chkJobNoAvailable";
            this.chkJobNoAvailable.Size = new System.Drawing.Size(113, 17);
            this.chkJobNoAvailable.TabIndex = 127;
            this.chkJobNoAvailable.Text = "No Job Number";
            this.chkJobNoAvailable.UseVisualStyleBackColor = true;
            this.chkJobNoAvailable.CheckedChanged += new System.EventHandler(this.chkJobNoAvailable_CheckedChanged);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(57, 17);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 129;
            this.lblJobNo.Text = "Job No";
            // 
            // grpJobNo
            // 
            this.grpJobNo.Controls.Add(this.lblJobNo);
            this.grpJobNo.Controls.Add(this.ctlCSDJob1);
            this.grpJobNo.Location = new System.Drawing.Point(9, 2);
            this.grpJobNo.Name = "grpJobNo";
            this.grpJobNo.Size = new System.Drawing.Size(602, 46);
            this.grpJobNo.TabIndex = 132;
            this.grpJobNo.TabStop = false;
            // 
            // grpCustomerDetail
            // 
            this.grpCustomerDetail.Controls.Add(this.ctlProduct2);
            this.grpCustomerDetail.Controls.Add(this.lblProduct);
            this.grpCustomerDetail.Controls.Add(this.lblJobType);
            this.grpCustomerDetail.Controls.Add(this.groupBox1);
            this.grpCustomerDetail.Controls.Add(this.txtAddress);
            this.grpCustomerDetail.Controls.Add(this.lblAddress);
            this.grpCustomerDetail.Controls.Add(this.txtContactNo);
            this.grpCustomerDetail.Controls.Add(this.lblContactNo);
            this.grpCustomerDetail.Controls.Add(this.txtCustomerName);
            this.grpCustomerDetail.Controls.Add(this.lblCustomerName);
            this.grpCustomerDetail.Location = new System.Drawing.Point(9, 72);
            this.grpCustomerDetail.Name = "grpCustomerDetail";
            this.grpCustomerDetail.Size = new System.Drawing.Size(602, 155);
            this.grpCustomerDetail.TabIndex = 133;
            this.grpCustomerDetail.TabStop = false;
            // 
            // dtForm
            // 
            this.dtForm.CustomFormat = "hh:mm tt";
            this.dtForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtForm.Location = new System.Drawing.Point(265, 13);
            this.dtForm.Name = "dtForm";
            this.dtForm.Size = new System.Drawing.Size(81, 20);
            this.dtForm.TabIndex = 12;
            // 
            // grpEDD
            // 
            this.grpEDD.Controls.Add(this.dtForm);
            this.grpEDD.Controls.Add(this.lblTo);
            this.grpEDD.Controls.Add(this.dtTo);
            this.grpEDD.Controls.Add(this.lblFrom);
            this.grpEDD.Controls.Add(this.lblExpectedDate);
            this.grpEDD.Controls.Add(this.dtExpectedDate);
            this.grpEDD.Location = new System.Drawing.Point(9, 297);
            this.grpEDD.Name = "grpEDD";
            this.grpEDD.Size = new System.Drawing.Size(602, 40);
            this.grpEDD.TabIndex = 135;
            this.grpEDD.TabStop = false;
            // 
            // ctlProduct2
            // 
            this.ctlProduct2.Location = new System.Drawing.Point(101, 124);
            this.ctlProduct2.Name = "ctlProduct2";
            this.ctlProduct2.Size = new System.Drawing.Size(436, 29);
            this.ctlProduct2.TabIndex = 7;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(107, 14);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(489, 20);
            this.ctlCSDJob1.TabIndex = 136;
            // 
            // frmVehicleSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 502);
            this.Controls.Add(this.grpEDD);
            this.Controls.Add(this.grpCustomerDetail);
            this.Controls.Add(this.grpJobNo);
            this.Controls.Add(this.chkJobNoAvailable);
            this.Controls.Add(this.chkContactCustomer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblRequisitionType);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVehicleSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Requisition";
            this.Load += new System.EventHandler(this.frmVehicleSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpJobNo.ResumeLayout(false);
            this.grpJobNo.PerformLayout();
            this.grpCustomerDetail.ResumeLayout(false);
            this.grpCustomerDetail.PerformLayout();
            this.grpEDD.ResumeLayout(false);
            this.grpEDD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.RadioButton rdoServiceWarranty;
        private System.Windows.Forms.RadioButton rdoFullWarranty;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.DateTimePicker dtExpectedDate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.RadioButton rdoDrop;
        private System.Windows.Forms.RadioButton rdoPickUp;
        private System.Windows.Forms.RadioButton rdoPaid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblJobType;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblRequisitionType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.CheckBox chkContactCustomer;
        private System.Windows.Forms.CheckBox chkJobNoAvailable;
        private ctlJobAll ctlJobAll1;
        private System.Windows.Forms.Label lblJobNo;
        private ctlProduct ctlProduct2;
        private System.Windows.Forms.GroupBox grpJobNo;
        private System.Windows.Forms.GroupBox grpCustomerDetail;
        private System.Windows.Forms.DateTimePicker dtForm;
        private System.Windows.Forms.GroupBox grpEDD;
        private ctlCSDJob ctlCSDJob1;
    }
}