namespace CJ.Win.CSD.Reception
{
    partial class frmStatusUpdateForcelyCreate
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
            this.lblProductLocation = new System.Windows.Forms.Label();
            this.cmbProductLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbJobStatus = new System.Windows.Forms.ComboBox();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProductPhysicalLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProductMovementStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblProductLocation
            // 
            this.lblProductLocation.AutoSize = true;
            this.lblProductLocation.Location = new System.Drawing.Point(4, 114);
            this.lblProductLocation.Name = "lblProductLocation";
            this.lblProductLocation.Size = new System.Drawing.Size(76, 13);
            this.lblProductLocation.TabIndex = 12;
            this.lblProductLocation.Text = "Prod. Location";
            // 
            // cmbProductLocation
            // 
            this.cmbProductLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductLocation.FormattingEnabled = true;
            this.cmbProductLocation.Location = new System.Drawing.Point(83, 110);
            this.cmbProductLocation.Name = "cmbProductLocation";
            this.cmbProductLocation.Size = new System.Drawing.Size(171, 21);
            this.cmbProductLocation.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Job Status";
            // 
            // cmbJobStatus
            // 
            this.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobStatus.FormattingEnabled = true;
            this.cmbJobStatus.Location = new System.Drawing.Point(83, 83);
            this.cmbJobStatus.Name = "cmbJobStatus";
            this.cmbJobStatus.Size = new System.Drawing.Size(171, 21);
            this.cmbJobStatus.TabIndex = 11;
            this.cmbJobStatus.SelectedIndexChanged += new System.EventHandler(this.cmbJobStatus_SelectedIndexChanged);
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(83, 8);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Size = new System.Drawing.Size(176, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job No";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(372, 164);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(78, 27);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(83, 137);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(448, 20);
            this.txtRemarks.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Remarks";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(83, 32);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(176, 20);
            this.txtCustomerName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cus. Name";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(339, 32);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.ReadOnly = true;
            this.txtMobileNo.Size = new System.Drawing.Size(192, 20);
            this.txtMobileNo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mobile No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Cus. Address";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(83, 56);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.ReadOnly = true;
            this.txtCustomerAddress.Size = new System.Drawing.Size(448, 20);
            this.txtCustomerAddress.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Prod. Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(339, 8);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(192, 20);
            this.txtProductName.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(452, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Prod. Phy. Location";
            // 
            // cmbProductPhysicalLocation
            // 
            this.cmbProductPhysicalLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductPhysicalLocation.FormattingEnabled = true;
            this.cmbProductPhysicalLocation.Location = new System.Drawing.Point(360, 110);
            this.cmbProductPhysicalLocation.Name = "cmbProductPhysicalLocation";
            this.cmbProductPhysicalLocation.Size = new System.Drawing.Size(171, 21);
            this.cmbProductPhysicalLocation.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Movement Status";
            // 
            // cmbProductMovementStatus
            // 
            this.cmbProductMovementStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductMovementStatus.FormattingEnabled = true;
            this.cmbProductMovementStatus.Location = new System.Drawing.Point(360, 84);
            this.cmbProductMovementStatus.Name = "cmbProductMovementStatus";
            this.cmbProductMovementStatus.Size = new System.Drawing.Size(171, 21);
            this.cmbProductMovementStatus.TabIndex = 21;
            // 
            // frmStatusUpdateForcelyCreate
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 200);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbProductMovementStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbProductPhysicalLocation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblProductLocation);
            this.Controls.Add(this.cmbProductLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbJobStatus);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStatusUpdateForcelyCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forcely Status Update";
            this.Load += new System.EventHandler(this.frmStatusUpdateForcelyCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductLocation;
        private System.Windows.Forms.ComboBox cmbProductLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJobStatus;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProductPhysicalLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProductMovementStatus;
    }
}