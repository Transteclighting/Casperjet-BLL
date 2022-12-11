namespace CJ.Win
{
    partial class frmInquiry
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
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.rdbAfterSale = new System.Windows.Forms.RadioButton();
            this.rdbBeforeSale = new System.Windows.Forms.RadioButton();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtOutletName = new System.Windows.Forms.TextBox();
            this.lblOutletName = new System.Windows.Forms.Label();
            this.cmbInquiryType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.txtInqName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwInqCatDetail = new System.Windows.Forms.ListView();
            this.colCategoryDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvwSerponseType = new System.Windows.Forms.ListView();
            this.colResponse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwReferOutlet = new System.Windows.Forms.ListView();
            this.colReferOutlet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRecvRemarks = new System.Windows.Forms.TextBox();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.rdoInBoundCall = new System.Windows.Forms.RadioButton();
            this.rdoOutBoundCall = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtWEBTrackNo = new System.Windows.Forms.TextBox();
            this.lblWEBTrackNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(90, 417);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(193, 20);
            this.txtLocation.TabIndex = 120;
            // 
            // rdbAfterSale
            // 
            this.rdbAfterSale.AutoSize = true;
            this.rdbAfterSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAfterSale.Location = new System.Drawing.Point(195, 125);
            this.rdbAfterSale.Name = "rdbAfterSale";
            this.rdbAfterSale.Size = new System.Drawing.Size(81, 17);
            this.rdbAfterSale.TabIndex = 118;
            this.rdbAfterSale.Text = "After Sale";
            this.rdbAfterSale.UseVisualStyleBackColor = true;
            this.rdbAfterSale.CheckedChanged += new System.EventHandler(this.rdbAfterSale_CheckedChanged);
            // 
            // rdbBeforeSale
            // 
            this.rdbBeforeSale.AutoSize = true;
            this.rdbBeforeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBeforeSale.Location = new System.Drawing.Point(96, 125);
            this.rdbBeforeSale.Name = "rdbBeforeSale";
            this.rdbBeforeSale.Size = new System.Drawing.Size(91, 17);
            this.rdbBeforeSale.TabIndex = 117;
            this.rdbBeforeSale.Text = "Before Sale";
            this.rdbBeforeSale.UseVisualStyleBackColor = true;
            this.rdbBeforeSale.CheckedChanged += new System.EventHandler(this.rdbBeforeSale_CheckedChanged);
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(348, 417);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(153, 21);
            this.cmbDistrict.TabIndex = 119;
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(298, 421);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(47, 13);
            this.lblDistrict.TabIndex = 129;
            this.lblDistrict.Text = "District";
            // 
            // txtOutletName
            // 
            this.txtOutletName.Location = new System.Drawing.Point(329, 393);
            this.txtOutletName.Name = "txtOutletName";
            this.txtOutletName.Size = new System.Drawing.Size(171, 20);
            this.txtOutletName.TabIndex = 122;
            // 
            // lblOutletName
            // 
            this.lblOutletName.AutoSize = true;
            this.lblOutletName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutletName.Location = new System.Drawing.Point(10, 395);
            this.lblOutletName.Name = "lblOutletName";
            this.lblOutletName.Size = new System.Drawing.Size(77, 13);
            this.lblOutletName.TabIndex = 128;
            this.lblOutletName.Text = "Outlet Name";
            // 
            // cmbInquiryType
            // 
            this.cmbInquiryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInquiryType.FormattingEnabled = true;
            this.cmbInquiryType.Location = new System.Drawing.Point(88, 36);
            this.cmbInquiryType.Name = "cmbInquiryType";
            this.cmbInquiryType.Size = new System.Drawing.Size(171, 21);
            this.cmbInquiryType.TabIndex = 113;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.SystemColors.Control;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(50, 40);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 126;
            this.lblType.Text = "Type";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(89, 85);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(153, 20);
            this.txtContactNo.TabIndex = 112;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(15, 89);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(71, 13);
            this.lblContactNo.TabIndex = 116;
            this.lblContactNo.Text = "Contact No";
            // 
            // txtInqName
            // 
            this.txtInqName.Location = new System.Drawing.Point(89, 61);
            this.txtInqName.Name = "txtInqName";
            this.txtInqName.Size = new System.Drawing.Size(249, 20);
            this.txtInqName.TabIndex = 110;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(48, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 114;
            this.lblName.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwInqCatDetail);
            this.groupBox1.Location = new System.Drawing.Point(82, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 276);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inquiry Category";
            // 
            // lvwInqCatDetail
            // 
            this.lvwInqCatDetail.CheckBoxes = true;
            this.lvwInqCatDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategoryDetail});
            this.lvwInqCatDetail.GridLines = true;
            this.lvwInqCatDetail.HideSelection = false;
            this.lvwInqCatDetail.Location = new System.Drawing.Point(8, 37);
            this.lvwInqCatDetail.MultiSelect = false;
            this.lvwInqCatDetail.Name = "lvwInqCatDetail";
            this.lvwInqCatDetail.Size = new System.Drawing.Size(194, 233);
            this.lvwInqCatDetail.TabIndex = 6;
            this.lvwInqCatDetail.UseCompatibleStateImageBehavior = false;
            this.lvwInqCatDetail.View = System.Windows.Forms.View.Details;
            // 
            // colCategoryDetail
            // 
            this.colCategoryDetail.Text = "Category Detail";
            this.colCategoryDetail.Width = 183;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lvwSerponseType);
            this.groupBox2.Location = new System.Drawing.Point(308, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 87);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Response";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(1, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(126, 87);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ReferOutlet";
            // 
            // lvwSerponseType
            // 
            this.lvwSerponseType.CheckBoxes = true;
            this.lvwSerponseType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResponse});
            this.lvwSerponseType.GridLines = true;
            this.lvwSerponseType.HideSelection = false;
            this.lvwSerponseType.Location = new System.Drawing.Point(7, 20);
            this.lvwSerponseType.MultiSelect = false;
            this.lvwSerponseType.Name = "lvwSerponseType";
            this.lvwSerponseType.Size = new System.Drawing.Size(110, 59);
            this.lvwSerponseType.TabIndex = 7;
            this.lvwSerponseType.UseCompatibleStateImageBehavior = false;
            this.lvwSerponseType.View = System.Windows.Forms.View.Details;
            // 
            // colResponse
            // 
            this.colResponse.Text = "Response";
            this.colResponse.Width = 99;
            // 
            // lvwReferOutlet
            // 
            this.lvwReferOutlet.CheckBoxes = true;
            this.lvwReferOutlet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferOutlet});
            this.lvwReferOutlet.GridLines = true;
            this.lvwReferOutlet.HideSelection = false;
            this.lvwReferOutlet.Location = new System.Drawing.Point(10, 19);
            this.lvwReferOutlet.MultiSelect = false;
            this.lvwReferOutlet.Name = "lvwReferOutlet";
            this.lvwReferOutlet.Size = new System.Drawing.Size(112, 101);
            this.lvwReferOutlet.TabIndex = 133;
            this.lvwReferOutlet.UseCompatibleStateImageBehavior = false;
            this.lvwReferOutlet.View = System.Windows.Forms.View.Details;
            // 
            // colReferOutlet
            // 
            this.colReferOutlet.Text = "ReferOutlet";
            this.colReferOutlet.Width = 99;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvwReferOutlet);
            this.groupBox4.Location = new System.Drawing.Point(307, 220);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 126);
            this.groupBox4.TabIndex = 134;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Refer Outlet";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(31, 421);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(56, 13);
            this.lblLocation.TabIndex = 135;
            this.lblLocation.Text = "Location";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(329, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 136;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(421, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 27);
            this.btnClose.TabIndex = 137;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(28, 445);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 139;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRecvRemarks
            // 
            this.txtRecvRemarks.Location = new System.Drawing.Point(90, 442);
            this.txtRecvRemarks.Multiline = true;
            this.txtRecvRemarks.Name = "txtRecvRemarks";
            this.txtRecvRemarks.Size = new System.Drawing.Size(411, 21);
            this.txtRecvRemarks.TabIndex = 138;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(90, 392);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(213, 21);
            this.cmbOutlet.TabIndex = 145;
            // 
            // rdoInBoundCall
            // 
            this.rdoInBoundCall.AutoSize = true;
            this.rdoInBoundCall.Location = new System.Drawing.Point(47, 11);
            this.rdoInBoundCall.Name = "rdoInBoundCall";
            this.rdoInBoundCall.Size = new System.Drawing.Size(88, 17);
            this.rdoInBoundCall.TabIndex = 149;
            this.rdoInBoundCall.TabStop = true;
            this.rdoInBoundCall.Text = "In Bound Call";
            this.rdoInBoundCall.UseVisualStyleBackColor = true;
            // 
            // rdoOutBoundCall
            // 
            this.rdoOutBoundCall.AutoSize = true;
            this.rdoOutBoundCall.Location = new System.Drawing.Point(141, 11);
            this.rdoOutBoundCall.Name = "rdoOutBoundCall";
            this.rdoOutBoundCall.Size = new System.Drawing.Size(96, 17);
            this.rdoOutBoundCall.TabIndex = 150;
            this.rdoOutBoundCall.TabStop = true;
            this.rdoOutBoundCall.Text = "Out Bound Call";
            this.rdoOutBoundCall.UseVisualStyleBackColor = true;
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Location = new System.Drawing.Point(244, 11);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(51, 17);
            this.rdoNone.TabIndex = 151;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "None";
            this.rdoNone.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoNone);
            this.groupBox5.Controls.Add(this.rdoOutBoundCall);
            this.groupBox5.Controls.Add(this.rdoInBoundCall);
            this.groupBox5.Location = new System.Drawing.Point(88, 466);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(303, 34);
            this.groupBox5.TabIndex = 152;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Solve";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 153;
            this.label1.Text = "Is Web Query";
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNo.Location = new System.Drawing.Point(5, 10);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(41, 17);
            this.rdoNo.TabIndex = 154;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "No";
            this.rdoNo.UseVisualStyleBackColor = true;
            this.rdoNo.CheckedChanged += new System.EventHandler(this.rdoNo_CheckedChanged);
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoYes.Location = new System.Drawing.Point(76, 10);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(46, 17);
            this.rdoYes.TabIndex = 155;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Yes";
            this.rdoYes.UseVisualStyleBackColor = true;
            this.rdoYes.CheckedChanged += new System.EventHandler(this.rdoYes_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoYes);
            this.groupBox6.Controls.Add(this.rdoNo);
            this.groupBox6.Location = new System.Drawing.Point(87, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(142, 33);
            this.groupBox6.TabIndex = 156;
            this.groupBox6.TabStop = false;
            // 
            // txtWEBTrackNo
            // 
            this.txtWEBTrackNo.Location = new System.Drawing.Point(332, 10);
            this.txtWEBTrackNo.Name = "txtWEBTrackNo";
            this.txtWEBTrackNo.Size = new System.Drawing.Size(102, 20);
            this.txtWEBTrackNo.TabIndex = 157;
            // 
            // lblWEBTrackNo
            // 
            this.lblWEBTrackNo.AutoSize = true;
            this.lblWEBTrackNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWEBTrackNo.Location = new System.Drawing.Point(240, 11);
            this.lblWEBTrackNo.Name = "lblWEBTrackNo";
            this.lblWEBTrackNo.Size = new System.Drawing.Size(90, 13);
            this.lblWEBTrackNo.TabIndex = 158;
            this.lblWEBTrackNo.Text = "Web Track No";
            // 
            // frmInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 539);
            this.Controls.Add(this.lblWEBTrackNo);
            this.Controls.Add(this.txtWEBTrackNo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRecvRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.rdbAfterSale);
            this.Controls.Add(this.rdbBeforeSale);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.lblDistrict);
            this.Controls.Add(this.txtOutletName);
            this.Controls.Add(this.lblOutletName);
            this.Controls.Add(this.cmbInquiryType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.txtInqName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmInquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inquiry";
            this.Load += new System.EventHandler(this.frmInquiry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.RadioButton rdbAfterSale;
        private System.Windows.Forms.RadioButton rdbBeforeSale;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.TextBox txtOutletName;
        private System.Windows.Forms.Label lblOutletName;
        private System.Windows.Forms.ComboBox cmbInquiryType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.TextBox txtInqName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwInqCatDetail;
        private System.Windows.Forms.ColumnHeader colCategoryDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvwSerponseType;
        private System.Windows.Forms.ColumnHeader colResponse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvwReferOutlet;
        private System.Windows.Forms.ColumnHeader colReferOutlet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRecvRemarks;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.RadioButton rdoInBoundCall;
        private System.Windows.Forms.RadioButton rdoOutBoundCall;
        private System.Windows.Forms.RadioButton rdoNone;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtWEBTrackNo;
        private System.Windows.Forms.Label lblWEBTrackNo;
    }
}