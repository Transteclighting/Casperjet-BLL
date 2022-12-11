namespace CJ.Win.Promotion
{
    partial class frmPromoCPFlatDiscount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromoCPFlatDiscount));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvwSalesType = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvwShowroom = new System.Windows.Forms.TreeView();
            this.chkbAll = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkPromoTypeAll = new System.Windows.Forms.CheckBox();
            this.lvwPromotionType = new System.Windows.Forms.ListView();
            this.colPromotionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbContributor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContribution = new System.Windows.Forms.TextBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFreeEMITenure = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoDiscountPercent = new System.Windows.Forms.RadioButton();
            this.rdoFlatAmt = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteCtrlVToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 26);
            // 
            // pasteCtrlVToolStripMenuItem
            // 
            this.pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            this.pasteCtrlVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pasteCtrlVToolStripMenuItem.Text = "Paste";
            this.pasteCtrlVToolStripMenuItem.Click += new System.EventHandler(this.pasteCtrlVToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tvwSalesType);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 198);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "For Sales Type";
            // 
            // tvwSalesType
            // 
            this.tvwSalesType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwSalesType.CheckBoxes = true;
            this.tvwSalesType.Location = new System.Drawing.Point(7, 23);
            this.tvwSalesType.Name = "tvwSalesType";
            this.tvwSalesType.Size = new System.Drawing.Size(234, 167);
            this.tvwSalesType.TabIndex = 0;
            this.tvwSalesType.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSalesType_AfterCheck);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvwShowroom);
            this.groupBox3.Controls.Add(this.chkbAll);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 384);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 183);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For Showroom";
            // 
            // tvwShowroom
            // 
            this.tvwShowroom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwShowroom.CheckBoxes = true;
            this.tvwShowroom.Location = new System.Drawing.Point(8, 34);
            this.tvwShowroom.Name = "tvwShowroom";
            this.tvwShowroom.Size = new System.Drawing.Size(516, 137);
            this.tvwShowroom.TabIndex = 0;
            this.tvwShowroom.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwShowroom_AfterCheck);
            // 
            // chkbAll
            // 
            this.chkbAll.AutoSize = true;
            this.chkbAll.Location = new System.Drawing.Point(446, 13);
            this.chkbAll.Name = "chkbAll";
            this.chkbAll.Size = new System.Drawing.Size(73, 18);
            this.chkbAll.TabIndex = 1;
            this.chkbAll.Text = "Select All";
            this.chkbAll.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 40);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(434, 22);
            this.txtDescription.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Promotion Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Effect Date:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkPromoTypeAll);
            this.groupBox6.Controls.Add(this.lvwPromotionType);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(267, 180);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(277, 198);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Promotion Type";
            // 
            // chkPromoTypeAll
            // 
            this.chkPromoTypeAll.AutoSize = true;
            this.chkPromoTypeAll.Location = new System.Drawing.Point(191, 14);
            this.chkPromoTypeAll.Name = "chkPromoTypeAll";
            this.chkPromoTypeAll.Size = new System.Drawing.Size(73, 19);
            this.chkPromoTypeAll.TabIndex = 0;
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
            this.lvwPromotionType.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPromotionType.FullRowSelect = true;
            this.lvwPromotionType.GridLines = true;
            this.lvwPromotionType.HideSelection = false;
            this.lvwPromotionType.Location = new System.Drawing.Point(9, 38);
            this.lvwPromotionType.Name = "lvwPromotionType";
            this.lvwPromotionType.Size = new System.Drawing.Size(259, 148);
            this.lvwPromotionType.TabIndex = 1;
            this.lvwPromotionType.UseCompatibleStateImageBehavior = false;
            this.lvwPromotionType.View = System.Windows.Forms.View.Details;
            // 
            // colPromotionType
            // 
            this.colPromotionType.Text = "Promotion Type";
            this.colPromotionType.Width = 360;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contribution";
            // 
            // cmbContributor
            // 
            this.cmbContributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContributor.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContributor.FormattingEnabled = true;
            this.cmbContributor.Location = new System.Drawing.Point(85, 151);
            this.cmbContributor.Name = "cmbContributor";
            this.cmbContributor.Size = new System.Drawing.Size(258, 23);
            this.cmbContributor.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.label7.Location = new System.Drawing.Point(14, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Contributor";
            // 
            // txtContribution
            // 
            this.txtContribution.Location = new System.Drawing.Point(429, 152);
            this.txtContribution.Name = "txtContribution";
            this.txtContribution.Size = new System.Drawing.Size(112, 22);
            this.txtContribution.TabIndex = 13;
            this.txtContribution.Text = "0";
            this.txtContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContribution.TextChanged += new System.EventHandler(this.txtContribution_TextChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(110, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(130, 22);
            this.dtFromDate.TabIndex = 1;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(276, 12);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(130, 22);
            this.dtTodate.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(70, 569);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(507, 21);
            this.txtRemarks.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(10, 570);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSave.Location = new System.Drawing.Point(583, 567);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(664, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.label9.Location = new System.Drawing.Point(29, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Free EMI";
            // 
            // cmbFreeEMITenure
            // 
            this.cmbFreeEMITenure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreeEMITenure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFreeEMITenure.FormattingEnabled = true;
            this.cmbFreeEMITenure.Location = new System.Drawing.Point(85, 124);
            this.cmbFreeEMITenure.Name = "cmbFreeEMITenure";
            this.cmbFreeEMITenure.Size = new System.Drawing.Size(155, 21);
            this.cmbFreeEMITenure.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoDiscountPercent);
            this.groupBox5.Controls.Add(this.rdoFlatAmt);
            this.groupBox5.Controls.Add(this.rdoNone);
            this.groupBox5.Controls.Add(this.lblDiscountType);
            this.groupBox5.Controls.Add(this.txtDiscount);
            this.groupBox5.Controls.Add(this.lblDiscount);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(12, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(532, 50);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Discount";
            // 
            // rdoDiscountPercent
            // 
            this.rdoDiscountPercent.AutoSize = true;
            this.rdoDiscountPercent.Location = new System.Drawing.Point(206, 18);
            this.rdoDiscountPercent.Name = "rdoDiscountPercent";
            this.rdoDiscountPercent.Size = new System.Drawing.Size(113, 19);
            this.rdoDiscountPercent.TabIndex = 2;
            this.rdoDiscountPercent.TabStop = true;
            this.rdoDiscountPercent.Text = "Discount Percent";
            this.rdoDiscountPercent.UseVisualStyleBackColor = true;
            this.rdoDiscountPercent.CheckedChanged += new System.EventHandler(this.rdoDiscountPercent_CheckedChanged);
            // 
            // rdoFlatAmt
            // 
            this.rdoFlatAmt.AutoSize = true;
            this.rdoFlatAmt.Location = new System.Drawing.Point(91, 19);
            this.rdoFlatAmt.Name = "rdoFlatAmt";
            this.rdoFlatAmt.Size = new System.Drawing.Size(90, 19);
            this.rdoFlatAmt.TabIndex = 1;
            this.rdoFlatAmt.TabStop = true;
            this.rdoFlatAmt.Text = "Flat Amount";
            this.rdoFlatAmt.UseVisualStyleBackColor = true;
            this.rdoFlatAmt.CheckedChanged += new System.EventHandler(this.rdoFlatAmt_CheckedChanged);
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Location = new System.Drawing.Point(8, 18);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(54, 19);
            this.rdoNone.TabIndex = 0;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "None";
            this.rdoNone.UseVisualStyleBackColor = true;
            this.rdoNone.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Location = new System.Drawing.Point(495, 21);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(12, 15);
            this.lblDiscountType.TabIndex = 5;
            this.lblDiscountType.Text = "?";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(406, 17);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(85, 22);
            this.txtDiscount.TabIndex = 4;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged_1);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(330, 20);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(71, 15);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "|     Discount";
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.ContextMenuStrip = this.contextMenuStrip1;
            this.dgData.Location = new System.Drawing.Point(550, 12);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.Size = new System.Drawing.Size(189, 549);
            this.dgData.TabIndex = 4;
            // 
            // frmPromoCPFlatDiscount
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 603);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbFreeEMITenure);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtTodate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.txtContribution);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbContributor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgData);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPromoCPFlatDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promo CP Flat Discount";
            this.Load += new System.EventHandler(this.frmPromoCPFlatDiscount_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView tvwSalesType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvwShowroom;
        private System.Windows.Forms.CheckBox chkbAll;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkPromoTypeAll;
        private System.Windows.Forms.ListView lvwPromotionType;
        private System.Windows.Forms.ColumnHeader colPromotionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbContributor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContribution;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFreeEMITenure;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdoDiscountPercent;
        private System.Windows.Forms.RadioButton rdoFlatAmt;
        private System.Windows.Forms.RadioButton rdoNone;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteCtrlVToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgData;
    }
}