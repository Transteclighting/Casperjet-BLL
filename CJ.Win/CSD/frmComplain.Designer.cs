namespace CJ.Win
{
    partial class frmComplain
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
            this.dtDateOccurred = new System.Windows.Forms.DateTimePicker();
            this.lblDateOccurred = new System.Windows.Forms.Label();
            this.lblComplainerName = new System.Windows.Forms.Label();
            this.txtComplainerName = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblComplainerType = new System.Windows.Forms.Label();
            this.cmbComplainType = new System.Windows.Forms.ComboBox();
            this.txtReferanceJobNo = new System.Windows.Forms.TextBox();
            this.lblReferanceJobNo = new System.Windows.Forms.Label();
            this.cmbComplainAgainst = new System.Windows.Forms.ComboBox();
            this.lblComplainAgainstWhom = new System.Windows.Forms.Label();
            this.txtComplainDetails = new System.Windows.Forms.TextBox();
            this.lblComplainDetails = new System.Windows.Forms.Label();
            this.rdoBeforeSale = new System.Windows.Forms.RadioButton();
            this.rdoAfterSale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwComCatDetail = new System.Windows.Forms.ListView();
            this.colCategoryDetail = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwComplainType = new System.Windows.Forms.ListView();
            this.colComplainType = new System.Windows.Forms.ColumnHeader();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.txtComplainAgainstWhom = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDateOccurred
            // 
            this.dtDateOccurred.CustomFormat = "dd-MMM-yyyy";
            this.dtDateOccurred.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOccurred.Location = new System.Drawing.Point(442, 409);
            this.dtDateOccurred.Name = "dtDateOccurred";
            this.dtDateOccurred.Size = new System.Drawing.Size(130, 20);
            this.dtDateOccurred.TabIndex = 12;
            // 
            // lblDateOccurred
            // 
            this.lblDateOccurred.AutoSize = true;
            this.lblDateOccurred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOccurred.Location = new System.Drawing.Point(345, 411);
            this.lblDateOccurred.Name = "lblDateOccurred";
            this.lblDateOccurred.Size = new System.Drawing.Size(90, 13);
            this.lblDateOccurred.TabIndex = 1;
            this.lblDateOccurred.Text = "Date Occurred";
            // 
            // lblComplainerName
            // 
            this.lblComplainerName.AutoSize = true;
            this.lblComplainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerName.Location = new System.Drawing.Point(38, 26);
            this.lblComplainerName.Name = "lblComplainerName";
            this.lblComplainerName.Size = new System.Drawing.Size(105, 13);
            this.lblComplainerName.TabIndex = 2;
            this.lblComplainerName.Text = "Complainer Name";
            // 
            // txtComplainerName
            // 
            this.txtComplainerName.Location = new System.Drawing.Point(153, 23);
            this.txtComplainerName.Name = "txtComplainerName";
            this.txtComplainerName.Size = new System.Drawing.Size(300, 20);
            this.txtComplainerName.TabIndex = 0;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(153, 49);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(170, 20);
            this.txtContactNo.TabIndex = 1;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(73, 52);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(71, 13);
            this.lblContactNo.TabIndex = 4;
            this.lblContactNo.Text = "Contact No";
            // 
            // lblComplainerType
            // 
            this.lblComplainerType.AutoSize = true;
            this.lblComplainerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerType.Location = new System.Drawing.Point(91, 75);
            this.lblComplainerType.Name = "lblComplainerType";
            this.lblComplainerType.Size = new System.Drawing.Size(47, 13);
            this.lblComplainerType.TabIndex = 83;
            this.lblComplainerType.Text = "Source";
            // 
            // cmbComplainType
            // 
            this.cmbComplainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplainType.FormattingEnabled = true;
            this.cmbComplainType.Location = new System.Drawing.Point(152, 75);
            this.cmbComplainType.Name = "cmbComplainType";
            this.cmbComplainType.Size = new System.Drawing.Size(171, 21);
            this.cmbComplainType.TabIndex = 2;
            // 
            // txtReferanceJobNo
            // 
            this.txtReferanceJobNo.Location = new System.Drawing.Point(154, 406);
            this.txtReferanceJobNo.Name = "txtReferanceJobNo";
            this.txtReferanceJobNo.Size = new System.Drawing.Size(171, 20);
            this.txtReferanceJobNo.TabIndex = 11;
            // 
            // lblReferanceJobNo
            // 
            this.lblReferanceJobNo.AutoSize = true;
            this.lblReferanceJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferanceJobNo.Location = new System.Drawing.Point(7, 409);
            this.lblReferanceJobNo.Name = "lblReferanceJobNo";
            this.lblReferanceJobNo.Size = new System.Drawing.Size(149, 13);
            this.lblReferanceJobNo.TabIndex = 94;
            this.lblReferanceJobNo.Text = "Referance JobNo (if any)";
            // 
            // cmbComplainAgainst
            // 
            this.cmbComplainAgainst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplainAgainst.FormattingEnabled = true;
            this.cmbComplainAgainst.Location = new System.Drawing.Point(154, 294);
            this.cmbComplainAgainst.Name = "cmbComplainAgainst";
            this.cmbComplainAgainst.Size = new System.Drawing.Size(171, 21);
            this.cmbComplainAgainst.TabIndex = 8;
            // 
            // lblComplainAgainstWhom
            // 
            this.lblComplainAgainstWhom.AutoSize = true;
            this.lblComplainAgainstWhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainAgainstWhom.Location = new System.Drawing.Point(8, 293);
            this.lblComplainAgainstWhom.Name = "lblComplainAgainstWhom";
            this.lblComplainAgainstWhom.Size = new System.Drawing.Size(143, 13);
            this.lblComplainAgainstWhom.TabIndex = 98;
            this.lblComplainAgainstWhom.Text = "Complain Against Whom";
            // 
            // txtComplainDetails
            // 
            this.txtComplainDetails.Location = new System.Drawing.Point(154, 329);
            this.txtComplainDetails.Multiline = true;
            this.txtComplainDetails.Name = "txtComplainDetails";
            this.txtComplainDetails.Size = new System.Drawing.Size(397, 54);
            this.txtComplainDetails.TabIndex = 10;
            // 
            // lblComplainDetails
            // 
            this.lblComplainDetails.AutoSize = true;
            this.lblComplainDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainDetails.Location = new System.Drawing.Point(46, 330);
            this.lblComplainDetails.Name = "lblComplainDetails";
            this.lblComplainDetails.Size = new System.Drawing.Size(101, 13);
            this.lblComplainDetails.TabIndex = 102;
            this.lblComplainDetails.Text = "Complain Details";
            // 
            // rdoBeforeSale
            // 
            this.rdoBeforeSale.AutoSize = true;
            this.rdoBeforeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBeforeSale.Location = new System.Drawing.Point(159, 125);
            this.rdoBeforeSale.Name = "rdoBeforeSale";
            this.rdoBeforeSale.Size = new System.Drawing.Size(91, 17);
            this.rdoBeforeSale.TabIndex = 4;
            this.rdoBeforeSale.Text = "Before Sale";
            this.rdoBeforeSale.UseVisualStyleBackColor = true;
            this.rdoBeforeSale.CheckedChanged += new System.EventHandler(this.rdoBeforeSale_CheckedChanged);
            // 
            // rdoAfterSale
            // 
            this.rdoAfterSale.AutoSize = true;
            this.rdoAfterSale.Checked = true;
            this.rdoAfterSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAfterSale.Location = new System.Drawing.Point(262, 125);
            this.rdoAfterSale.Name = "rdoAfterSale";
            this.rdoAfterSale.Size = new System.Drawing.Size(81, 17);
            this.rdoAfterSale.TabIndex = 5;
            this.rdoAfterSale.TabStop = true;
            this.rdoAfterSale.Text = "After Sale";
            this.rdoAfterSale.UseVisualStyleBackColor = true;
            this.rdoAfterSale.CheckedChanged += new System.EventHandler(this.rdoAfterSale_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwComCatDetail);
            this.groupBox1.Location = new System.Drawing.Point(145, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 171);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complain Category";
            // 
            // lvwComCatDetail
            // 
            this.lvwComCatDetail.CheckBoxes = true;
            this.lvwComCatDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategoryDetail});
            this.lvwComCatDetail.GridLines = true;
            this.lvwComCatDetail.HideSelection = false;
            this.lvwComCatDetail.Location = new System.Drawing.Point(8, 41);
            this.lvwComCatDetail.MultiSelect = false;
            this.lvwComCatDetail.Name = "lvwComCatDetail";
            this.lvwComCatDetail.Size = new System.Drawing.Size(194, 124);
            this.lvwComCatDetail.TabIndex = 6;
            this.lvwComCatDetail.UseCompatibleStateImageBehavior = false;
            this.lvwComCatDetail.View = System.Windows.Forms.View.Details;
            // 
            // colCategoryDetail
            // 
            this.colCategoryDetail.Text = "Category Detail";
            this.colCategoryDetail.Width = 183;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwComplainType);
            this.groupBox2.Location = new System.Drawing.Point(381, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 172);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Complain Type";
            // 
            // lvwComplainType
            // 
            this.lvwComplainType.CheckBoxes = true;
            this.lvwComplainType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComplainType});
            this.lvwComplainType.GridLines = true;
            this.lvwComplainType.HideSelection = false;
            this.lvwComplainType.Location = new System.Drawing.Point(6, 19);
            this.lvwComplainType.MultiSelect = false;
            this.lvwComplainType.Name = "lvwComplainType";
            this.lvwComplainType.Size = new System.Drawing.Size(178, 147);
            this.lvwComplainType.TabIndex = 7;
            this.lvwComplainType.UseCompatibleStateImageBehavior = false;
            this.lvwComplainType.View = System.Windows.Forms.View.Details;
            // 
            // colComplainType
            // 
            this.colComplainType.Text = "Complain Type";
            this.colComplainType.Width = 152;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(347, 75);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(35, 13);
            this.lblSource.TabIndex = 92;
            this.lblSource.Text = "Type";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(399, 72);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(171, 21);
            this.cmbSource.TabIndex = 3;
            // 
            // txtComplainAgainstWhom
            // 
            this.txtComplainAgainstWhom.Location = new System.Drawing.Point(338, 293);
            this.txtComplainAgainstWhom.Name = "txtComplainAgainstWhom";
            this.txtComplainAgainstWhom.Size = new System.Drawing.Size(213, 20);
            this.txtComplainAgainstWhom.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(442, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(326, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmComplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 494);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtComplainAgainstWhom);
            this.Controls.Add(this.rdoAfterSale);
            this.Controls.Add(this.rdoBeforeSale);
            this.Controls.Add(this.txtComplainDetails);
            this.Controls.Add(this.lblComplainDetails);
            this.Controls.Add(this.cmbComplainAgainst);
            this.Controls.Add(this.lblComplainAgainstWhom);
            this.Controls.Add(this.txtReferanceJobNo);
            this.Controls.Add(this.lblReferanceJobNo);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.cmbComplainType);
            this.Controls.Add(this.lblComplainerType);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.txtComplainerName);
            this.Controls.Add(this.lblComplainerName);
            this.Controls.Add(this.lblDateOccurred);
            this.Controls.Add(this.dtDateOccurred);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmComplain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Complain";
            this.Load += new System.EventHandler(this.frmComplain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDateOccurred;
        private System.Windows.Forms.Label lblDateOccurred;
        private System.Windows.Forms.Label lblComplainerName;
        private System.Windows.Forms.TextBox txtComplainerName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblComplainerType;
        private System.Windows.Forms.ComboBox cmbComplainType;
        private System.Windows.Forms.TextBox txtReferanceJobNo;
        private System.Windows.Forms.Label lblReferanceJobNo;
        private System.Windows.Forms.ComboBox cmbComplainAgainst;
        private System.Windows.Forms.Label lblComplainAgainstWhom;
        private System.Windows.Forms.TextBox txtComplainDetails;
        private System.Windows.Forms.Label lblComplainDetails;
        private System.Windows.Forms.RadioButton rdoBeforeSale;
        private System.Windows.Forms.RadioButton rdoAfterSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.TextBox txtComplainAgainstWhom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvwComCatDetail;
        private System.Windows.Forms.ColumnHeader colCategoryDetail;
        private System.Windows.Forms.ListView lvwComplainType;
        private System.Windows.Forms.ColumnHeader colComplainType;
    }
}