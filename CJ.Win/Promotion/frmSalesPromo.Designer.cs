namespace CJ.Win.Promotion
{
    partial class frmSalesPromo
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
            this.lvwOutlet = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvwChannel = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lvwProductGroup = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.cmbProductGroupType = new System.Windows.Forms.ComboBox();
            this.chkProductGroup = new System.Windows.Forms.CheckBox();
            this.chkOutlet = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPromotionNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoAmount = new System.Windows.Forms.RadioButton();
            this.rdoPercente = new System.Windows.Forms.RadioButton();
            this.lblPercent = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkPromoTypeAll = new System.Windows.Forms.CheckBox();
            this.lvwPromotionType = new System.Windows.Forms.ListView();
            this.colPromotionType = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwOutlet
            // 
            this.lvwOutlet.CheckBoxes = true;
            this.lvwOutlet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwOutlet.FullRowSelect = true;
            this.lvwOutlet.GridLines = true;
            this.lvwOutlet.Location = new System.Drawing.Point(12, 141);
            this.lvwOutlet.Name = "lvwOutlet";
            this.lvwOutlet.Size = new System.Drawing.Size(293, 171);
            this.lvwOutlet.TabIndex = 3;
            this.lvwOutlet.UseCompatibleStateImageBehavior = false;
            this.lvwOutlet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Outlet Name";
            this.columnHeader2.Width = 214;
            // 
            // lvwChannel
            // 
            this.lvwChannel.CheckBoxes = true;
            this.lvwChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvwChannel.FullRowSelect = true;
            this.lvwChannel.GridLines = true;
            this.lvwChannel.Location = new System.Drawing.Point(3, 16);
            this.lvwChannel.Name = "lvwChannel";
            this.lvwChannel.Size = new System.Drawing.Size(293, 123);
            this.lvwChannel.TabIndex = 0;
            this.lvwChannel.UseCompatibleStateImageBehavior = false;
            this.lvwChannel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Code";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Channel Name";
            this.columnHeader4.Width = 214;
            // 
            // lvwProductGroup
            // 
            this.lvwProductGroup.CheckBoxes = true;
            this.lvwProductGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvwProductGroup.FullRowSelect = true;
            this.lvwProductGroup.GridLines = true;
            this.lvwProductGroup.Location = new System.Drawing.Point(7, 45);
            this.lvwProductGroup.Name = "lvwProductGroup";
            this.lvwProductGroup.Size = new System.Drawing.Size(311, 169);
            this.lvwProductGroup.TabIndex = 2;
            this.lvwProductGroup.UseCompatibleStateImageBehavior = false;
            this.lvwProductGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Code";
            this.columnHeader5.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Product Group Name";
            this.columnHeader6.Width = 214;
            // 
            // cmbProductGroupType
            // 
            this.cmbProductGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductGroupType.FormattingEnabled = true;
            this.cmbProductGroupType.Location = new System.Drawing.Point(76, 20);
            this.cmbProductGroupType.Name = "cmbProductGroupType";
            this.cmbProductGroupType.Size = new System.Drawing.Size(150, 21);
            this.cmbProductGroupType.TabIndex = 1;
            this.cmbProductGroupType.SelectedIndexChanged += new System.EventHandler(this.cmbProductGroupType_SelectedIndexChanged);
            // 
            // chkProductGroup
            // 
            this.chkProductGroup.AutoSize = true;
            this.chkProductGroup.Location = new System.Drawing.Point(547, 120);
            this.chkProductGroup.Name = "chkProductGroup";
            this.chkProductGroup.Size = new System.Drawing.Size(71, 17);
            this.chkProductGroup.TabIndex = 6;
            this.chkProductGroup.Text = "Check All";
            this.chkProductGroup.UseVisualStyleBackColor = true;
            this.chkProductGroup.CheckedChanged += new System.EventHandler(this.chkProductGroup_CheckedChanged);
            // 
            // chkOutlet
            // 
            this.chkOutlet.AutoSize = true;
            this.chkOutlet.Location = new System.Drawing.Point(4, 21);
            this.chkOutlet.Name = "chkOutlet";
            this.chkOutlet.Size = new System.Drawing.Size(71, 17);
            this.chkOutlet.TabIndex = 0;
            this.chkOutlet.Text = "Check All";
            this.chkOutlet.UseVisualStyleBackColor = true;
            this.chkOutlet.CheckedChanged += new System.EventHandler(this.chkOutlet_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(480, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(561, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description:";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(478, 10);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(138, 20);
            this.dtEndDate.TabIndex = 5;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(307, 10);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(138, 20);
            this.dtStartDate.TabIndex = 3;
            // 
            // txtPromotionNo
            // 
            this.txtPromotionNo.Enabled = false;
            this.txtPromotionNo.Location = new System.Drawing.Point(111, 10);
            this.txtPromotionNo.Name = "txtPromotionNo";
            this.txtPromotionNo.Size = new System.Drawing.Size(113, 20);
            this.txtPromotionNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Effect From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promotion No:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 34);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(505, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(268, 58);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(84, 20);
            this.txtDiscount.TabIndex = 8;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Discount Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Group Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbProductGroupType);
            this.groupBox1.Controls.Add(this.lvwProductGroup);
            this.groupBox1.Location = new System.Drawing.Point(314, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 221);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Group";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOutlet);
            this.groupBox2.Location = new System.Drawing.Point(8, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 220);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outlet";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwChannel);
            this.groupBox3.Location = new System.Drawing.Point(8, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 145);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoAmount);
            this.groupBox4.Controls.Add(this.rdoPercente);
            this.groupBox4.Controls.Add(this.lblPercent);
            this.groupBox4.Controls.Add(this.txtDiscount);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dtEndDate);
            this.groupBox4.Controls.Add(this.dtStartDate);
            this.groupBox4.Controls.Add(this.txtPromotionNo);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(628, 83);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.Location = new System.Drawing.Point(177, 61);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(61, 17);
            this.rdoAmount.TabIndex = 192;
            this.rdoAmount.TabStop = true;
            this.rdoAmount.Text = "Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoAmount_CheckedChanged);
            // 
            // rdoPercente
            // 
            this.rdoPercente.AutoSize = true;
            this.rdoPercente.Location = new System.Drawing.Point(112, 60);
            this.rdoPercente.Name = "rdoPercente";
            this.rdoPercente.Size = new System.Drawing.Size(33, 17);
            this.rdoPercente.TabIndex = 191;
            this.rdoPercente.TabStop = true;
            this.rdoPercente.Text = "%";
            this.rdoPercente.UseVisualStyleBackColor = true;
            this.rdoPercente.CheckedChanged += new System.EventHandler(this.rdoPercente_CheckedChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(358, 62);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 190;
            this.lblPercent.Text = "%";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkPromoTypeAll);
            this.groupBox6.Controls.Add(this.lvwPromotionType);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox6.Location = new System.Drawing.Point(314, 320);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(322, 145);
            this.groupBox6.TabIndex = 189;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Promotion Type";
            // 
            // chkPromoTypeAll
            // 
            this.chkPromoTypeAll.AutoSize = true;
            this.chkPromoTypeAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPromoTypeAll.Location = new System.Drawing.Point(238, 10);
            this.chkPromoTypeAll.Name = "chkPromoTypeAll";
            this.chkPromoTypeAll.Size = new System.Drawing.Size(70, 17);
            this.chkPromoTypeAll.TabIndex = 187;
            this.chkPromoTypeAll.Text = "Select All";
            this.chkPromoTypeAll.UseVisualStyleBackColor = true;
            this.chkPromoTypeAll.CheckedChanged += new System.EventHandler(this.chkPromoTypeAll_CheckedChanged);
            // 
            // lvwPromotionType
            // 
            this.lvwPromotionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPromotionType.CheckBoxes = true;
            this.lvwPromotionType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPromotionType});
            this.lvwPromotionType.FullRowSelect = true;
            this.lvwPromotionType.GridLines = true;
            this.lvwPromotionType.HideSelection = false;
            this.lvwPromotionType.Location = new System.Drawing.Point(6, 29);
            this.lvwPromotionType.Name = "lvwPromotionType";
            this.lvwPromotionType.Size = new System.Drawing.Size(308, 109);
            this.lvwPromotionType.TabIndex = 187;
            this.lvwPromotionType.UseCompatibleStateImageBehavior = false;
            this.lvwPromotionType.View = System.Windows.Forms.View.Details;
            // 
            // colPromotionType
            // 
            this.colPromotionType.Text = "Promotion Type";
            this.colPromotionType.Width = 250;
            // 
            // frmSalesPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 501);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkProductGroup);
            this.Controls.Add(this.lvwOutlet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmSalesPromo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Promotion for TD Corporate";
            this.Load += new System.EventHandler(this.frmSalesPromo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwOutlet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwChannel;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvwProductGroup;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox cmbProductGroupType;
        private System.Windows.Forms.CheckBox chkProductGroup;
        private System.Windows.Forms.CheckBox chkOutlet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtPromotionNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkPromoTypeAll;
        private System.Windows.Forms.ListView lvwPromotionType;
        private System.Windows.Forms.ColumnHeader colPromotionType;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.RadioButton rdoAmount;
        private System.Windows.Forms.RadioButton rdoPercente;

    }
}