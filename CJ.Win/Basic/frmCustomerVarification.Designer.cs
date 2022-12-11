namespace CJ.Win.Basic
{
    partial class frmCustomerVarification
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbNatureofBusiness = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoOfEmp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblParentCustomerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCompanyType = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.cmbCompanyCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtExpSales = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbVerifiedThrough = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVerifiedBy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(389, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Varified";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbNatureofBusiness
            // 
            this.cmbNatureofBusiness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNatureofBusiness.FormattingEnabled = true;
            this.cmbNatureofBusiness.Location = new System.Drawing.Point(106, 112);
            this.cmbNatureofBusiness.Name = "cmbNatureofBusiness";
            this.cmbNatureofBusiness.Size = new System.Drawing.Size(166, 21);
            this.cmbNatureofBusiness.TabIndex = 0;
            this.cmbNatureofBusiness.SelectedIndexChanged += new System.EventHandler(this.cmbNatureofBusiness_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer Code:";
            // 
            // txtNoOfEmp
            // 
            this.txtNoOfEmp.Location = new System.Drawing.Point(355, 175);
            this.txtNoOfEmp.Name = "txtNoOfEmp";
            this.txtNoOfEmp.Size = new System.Drawing.Size(190, 20);
            this.txtNoOfEmp.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parent CustomerName:";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomerCode.Location = new System.Drawing.Point(103, 9);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(13, 13);
            this.lblCustomerCode.TabIndex = 6;
            this.lblCustomerCode.Text = "?";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomerName.Location = new System.Drawing.Point(398, 9);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(13, 13);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "?";
            // 
            // lblParentCustomerName
            // 
            this.lblParentCustomerName.AutoSize = true;
            this.lblParentCustomerName.ForeColor = System.Drawing.Color.Blue;
            this.lblParentCustomerName.Location = new System.Drawing.Point(398, 79);
            this.lblParentCustomerName.Name = "lblParentCustomerName";
            this.lblParentCustomerName.Size = new System.Drawing.Size(13, 13);
            this.lblParentCustomerName.TabIndex = 8;
            this.lblParentCustomerName.Text = "?";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.Color.Blue;
            this.lblAddress.Location = new System.Drawing.Point(103, 32);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(13, 13);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Customer Address:";
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.ForeColor = System.Drawing.Color.Blue;
            this.lblContactNo.Location = new System.Drawing.Point(103, 79);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(13, 13);
            this.lblContactNo.TabIndex = 12;
            this.lblContactNo.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Contact No:";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.ForeColor = System.Drawing.Color.Blue;
            this.lblContactPerson.Location = new System.Drawing.Point(103, 56);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(13, 13);
            this.lblContactPerson.TabIndex = 14;
            this.lblContactPerson.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Contact Person:";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.ForeColor = System.Drawing.Color.Blue;
            this.lblDesignation.Location = new System.Drawing.Point(400, 56);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(13, 13);
            this.lblDesignation.TabIndex = 16;
            this.lblDesignation.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Contact Designation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nature of Business:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(355, 112);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(190, 21);
            this.cmbType.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Company Type:";
            // 
            // cmbCompanyType
            // 
            this.cmbCompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanyType.FormattingEnabled = true;
            this.cmbCompanyType.Location = new System.Drawing.Point(106, 142);
            this.cmbCompanyType.Name = "cmbCompanyType";
            this.cmbCompanyType.Size = new System.Drawing.Size(166, 21);
            this.cmbCompanyType.TabIndex = 2;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(300, 148);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(52, 13);
            this.lbl.TabIndex = 23;
            this.lbl.Text = "Category:";
            // 
            // cmbCompanyCategory
            // 
            this.cmbCompanyCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanyCategory.FormattingEnabled = true;
            this.cmbCompanyCategory.Location = new System.Drawing.Point(355, 145);
            this.cmbCompanyCategory.Name = "cmbCompanyCategory";
            this.cmbCompanyCategory.Size = new System.Drawing.Size(190, 21);
            this.cmbCompanyCategory.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(286, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "No. of Emp:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Exp. Sales (Yearly):";
            // 
            // txtExpSales
            // 
            this.txtExpSales.Location = new System.Drawing.Point(106, 175);
            this.txtExpSales.Name = "txtExpSales";
            this.txtExpSales.Size = new System.Drawing.Size(166, 20);
            this.txtExpSales.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Verified Through:";
            // 
            // cmbVerifiedThrough
            // 
            this.cmbVerifiedThrough.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerifiedThrough.FormattingEnabled = true;
            this.cmbVerifiedThrough.Location = new System.Drawing.Point(106, 204);
            this.cmbVerifiedThrough.Name = "cmbVerifiedThrough";
            this.cmbVerifiedThrough.Size = new System.Drawing.Size(166, 21);
            this.cmbVerifiedThrough.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 270);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Remarks: ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(106, 267);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(439, 20);
            this.txtRemarks.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(470, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(281, 207);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Verified Date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(356, 203);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Verified By:";
            // 
            // txtVerifiedBy
            // 
            this.txtVerifiedBy.Location = new System.Drawing.Point(106, 237);
            this.txtVerifiedBy.Name = "txtVerifiedBy";
            this.txtVerifiedBy.Size = new System.Drawing.Size(254, 20);
            this.txtVerifiedBy.TabIndex = 8;
            // 
            // frmCustomerVarification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 340);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtVerifiedBy);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbVerifiedThrough);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtExpSales);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.cmbCompanyCategory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbCompanyType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblParentCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoOfEmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNatureofBusiness);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "frmCustomerVarification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Varification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbNatureofBusiness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoOfEmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblParentCustomerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCompanyType;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cmbCompanyCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtExpSales;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbVerifiedThrough;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtVerifiedBy;
    }
}