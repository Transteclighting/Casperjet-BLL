namespace CJ.Win.Promotion
{
    partial class frmDiscountASGBrandEMI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountASGBrandEMI));
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTenure = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvwAG = new System.Windows.Forms.ListView();
            this.colAGID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 331);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 28);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(93, 340);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(69, 19);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 316);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(81, 15);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Effective Date";
            // 
            // dtEffectiveDate
            // 
            this.dtEffectiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtEffectiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEffectiveDate.Location = new System.Drawing.Point(93, 313);
            this.dtEffectiveDate.Name = "dtEffectiveDate";
            this.dtEffectiveDate.Size = new System.Drawing.Size(200, 21);
            this.dtEffectiveDate.TabIndex = 13;
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(90, 71);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(200, 23);
            this.cmbASG.TabIndex = 5;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "ASG Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(93, 283);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(200, 23);
            this.cmbBrand.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Brand Desc";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTenure
            // 
            this.cmbTenure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenure.FormattingEnabled = true;
            this.cmbTenure.Location = new System.Drawing.Point(93, 254);
            this.cmbTenure.Name = "cmbTenure";
            this.cmbTenure.Size = new System.Drawing.Size(200, 23);
            this.cmbTenure.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "EMI(Month)";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(383, 331);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 28);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(90, 11);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(200, 23);
            this.cmbPG.TabIndex = 1;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "PG Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(90, 41);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(200, 23);
            this.cmbMAG.TabIndex = 3;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "MAG Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lvwAG
            // 
            this.lvwAG.CheckBoxes = true;
            this.lvwAG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAGID,
            this.colAGName});
            this.lvwAG.FullRowSelect = true;
            this.lvwAG.GridLines = true;
            this.lvwAG.HideSelection = false;
            this.lvwAG.Location = new System.Drawing.Point(16, 128);
            this.lvwAG.Name = "lvwAG";
            this.lvwAG.Size = new System.Drawing.Size(445, 115);
            this.lvwAG.TabIndex = 7;
            this.lvwAG.UseCompatibleStateImageBehavior = false;
            this.lvwAG.View = System.Windows.Forms.View.Details;
            // 
            // colAGID
            // 
            this.colAGID.Text = "AG ID";
            this.colAGID.Width = 116;
            // 
            // colAGName
            // 
            this.colAGName.Text = "AG Name";
            this.colAGName.Width = 320;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(16, 105);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(63, 20);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "Check All ";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // frmDiscountASGBrandEMI
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 364);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lvwAG);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtEffectiveDate);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTenure);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiscountASGBrandEMI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASG Brand Free EMI";
            this.Load += new System.EventHandler(this.frmDiscountASGBrandEMI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtEffectiveDate;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTenure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvwAG;
        private System.Windows.Forms.ColumnHeader colAGID;
        private System.Windows.Forms.ColumnHeader colAGName;
        private System.Windows.Forms.Button btnSelectAll;
    }
}