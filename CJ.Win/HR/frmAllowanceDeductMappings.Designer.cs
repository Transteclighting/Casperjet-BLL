namespace CJ.Win.HR
{
    partial class frmAllowanceDeductMappings
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colADName = new System.Windows.Forms.ColumnHeader();
            this.lblCode = new System.Windows.Forms.Label();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.lvwAllowanceDeductMapping = new System.Windows.Forms.ListView();
            this.colGradeName = new System.Windows.Forms.ColumnHeader();
            this.colCompanyName = new System.Windows.Forms.ColumnHeader();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(541, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 25);
            this.btnClose.TabIndex = 96;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(541, 106);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 25);
            this.btnEdit.TabIndex = 95;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(541, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 25);
            this.btnAdd.TabIndex = 94;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(405, 41);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(93, 25);
            this.btnGetData.TabIndex = 93;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Job Grade";
            // 
            // cmbGrade
            // 
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Location = new System.Drawing.Point(255, 12);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(144, 21);
            this.cmbGrade.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Type";
            // 
            // colADName
            // 
            this.colADName.Text = "ADName";
            this.colADName.Width = 139;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(4, 46);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(51, 13);
            this.lblCode.TabIndex = 85;
            this.lblCode.Text = "Company";
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "CreateDate";
            this.colCreateDate.Width = 78;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 90;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(61, 12);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(126, 21);
            this.cmbType.TabIndex = 87;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 98;
            // 
            // lvwAllowanceDeductMapping
            // 
            this.lvwAllowanceDeductMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAllowanceDeductMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGradeName,
            this.colCompanyName,
            this.colCreateDate,
            this.colADName,
            this.colType,
            this.colAmount});
            this.lvwAllowanceDeductMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwAllowanceDeductMapping.FullRowSelect = true;
            this.lvwAllowanceDeductMapping.GridLines = true;
            this.lvwAllowanceDeductMapping.HideSelection = false;
            this.lvwAllowanceDeductMapping.Location = new System.Drawing.Point(7, 75);
            this.lvwAllowanceDeductMapping.MultiSelect = false;
            this.lvwAllowanceDeductMapping.Name = "lvwAllowanceDeductMapping";
            this.lvwAllowanceDeductMapping.Size = new System.Drawing.Size(521, 256);
            this.lvwAllowanceDeductMapping.TabIndex = 84;
            this.lvwAllowanceDeductMapping.UseCompatibleStateImageBehavior = false;
            this.lvwAllowanceDeductMapping.View = System.Windows.Forms.View.Details;
            this.lvwAllowanceDeductMapping.DoubleClick += new System.EventHandler(this.lvwAllowanceDeductMapping_DoubleClick);
            // 
            // colGradeName
            // 
            this.colGradeName.Text = "GradeName";
            this.colGradeName.Width = 109;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Text = "CompanyName";
            this.colCompanyName.Width = 151;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(61, 43);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(338, 21);
            this.cmbCompany.TabIndex = 98;
            // 
            // frmAllowanceDeductMappings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 343);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGrade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lvwAllowanceDeductMapping);
            this.Name = "frmAllowanceDeductMappings";
            this.Text = "frmAllowanceDeductMappings";
            this.Load += new System.EventHandler(this.frmAllowanceDeductMappings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colADName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ListView lvwAllowanceDeductMapping;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ColumnHeader colGradeName;
        private System.Windows.Forms.ColumnHeader colCompanyName;
    }
}