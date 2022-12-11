namespace CJ.Win.HR
{
    partial class frmBEILDistributionSets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBEILDistributionSets));
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistSet = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwBEILdistributionSet = new System.Windows.Forms.ListView();
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAllowance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbAllowanceType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dst. Set:";
            // 
            // txtDistSet
            // 
            this.txtDistSet.Location = new System.Drawing.Point(348, 13);
            this.txtDistSet.Name = "txtDistSet";
            this.txtDistSet.Size = new System.Drawing.Size(157, 20);
            this.txtDistSet.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(507, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dist. Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(74, 39);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(160, 20);
            this.txtCode.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(767, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(767, 98);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 26);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(767, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 26);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwBEILdistributionSet
            // 
            this.lvwBEILdistributionSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBEILdistributionSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colSet,
            this.colDistCode,
            this.colDistDescription,
            this.colCode,
            this.colAllowance});
            this.lvwBEILdistributionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBEILdistributionSet.FullRowSelect = true;
            this.lvwBEILdistributionSet.GridLines = true;
            this.lvwBEILdistributionSet.HideSelection = false;
            this.lvwBEILdistributionSet.Location = new System.Drawing.Point(2, 65);
            this.lvwBEILdistributionSet.MultiSelect = false;
            this.lvwBEILdistributionSet.Name = "lvwBEILdistributionSet";
            this.lvwBEILdistributionSet.Size = new System.Drawing.Size(759, 340);
            this.lvwBEILdistributionSet.TabIndex = 7;
            this.lvwBEILdistributionSet.UseCompatibleStateImageBehavior = false;
            this.lvwBEILdistributionSet.View = System.Windows.Forms.View.Details;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 250;
            // 
            // colSet
            // 
            this.colSet.Text = "Dist. Set";
            this.colSet.Width = 150;
            // 
            // colDistCode
            // 
            this.colDistCode.Text = "Dist. Code";
            this.colDistCode.Width = 150;
            // 
            // colDistDescription
            // 
            this.colDistDescription.Text = "Dist. Description";
            this.colDistDescription.Width = 250;
            // 
            // colCode
            // 
            this.colCode.Text = "Dept. Code";
            this.colCode.Width = 150;
            // 
            // colAllowance
            // 
            this.colAllowance.Text = "Allowance Type";
            this.colAllowance.Width = 150;
            // 
            // cmbAllowanceType
            // 
            this.cmbAllowanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllowanceType.FormattingEnabled = true;
            this.cmbAllowanceType.Location = new System.Drawing.Point(74, 12);
            this.cmbAllowanceType.Name = "cmbAllowanceType";
            this.cmbAllowanceType.Size = new System.Drawing.Size(214, 21);
            this.cmbAllowanceType.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Allowanced";
            // 
            // frmBEILDistributionSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 417);
            this.Controls.Add(this.cmbAllowanceType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDistSet);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwBEILdistributionSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBEILDistributionSets";
            this.Text = "BEIL Distribution Sets";
            this.Load += new System.EventHandler(this.frmBEILDistributionSets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistSet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwBEILdistributionSet;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colSet;
        private System.Windows.Forms.ColumnHeader colDistDescription;
        private System.Windows.Forms.ColumnHeader colAllowance;
        private System.Windows.Forms.ColumnHeader colDistCode;
        private System.Windows.Forms.ComboBox cmbAllowanceType;
        private System.Windows.Forms.Label label7;
    }
}