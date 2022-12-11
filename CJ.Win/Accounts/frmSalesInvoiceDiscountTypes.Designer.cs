namespace CJ.Win.Accounts
{
    partial class frmSalesInvoiceDiscountTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInvoiceDiscountTypes));
            this.lvwSalesInvoiceDiscountType = new System.Windows.Forms.ListView();
            this.colDiscountTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApplicableFor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSIDTAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDiscountTypeName = new System.Windows.Forms.TextBox();
            this.lblDistSet = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lvwSalesInvoiceDiscountType
            // 
            this.lvwSalesInvoiceDiscountType.AllowColumnReorder = true;
            this.lvwSalesInvoiceDiscountType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSalesInvoiceDiscountType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDiscountTypeName,
            this.colApplicableFor,
            this.colType,
            this.colIsActive,
            this.colIsSystem,
            this.colCreateDate,
            this.colCreateUser});
            this.lvwSalesInvoiceDiscountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwSalesInvoiceDiscountType.FullRowSelect = true;
            this.lvwSalesInvoiceDiscountType.GridLines = true;
            this.lvwSalesInvoiceDiscountType.HideSelection = false;
            this.lvwSalesInvoiceDiscountType.Location = new System.Drawing.Point(12, 73);
            this.lvwSalesInvoiceDiscountType.Name = "lvwSalesInvoiceDiscountType";
            this.lvwSalesInvoiceDiscountType.Size = new System.Drawing.Size(706, 218);
            this.lvwSalesInvoiceDiscountType.TabIndex = 3;
            this.lvwSalesInvoiceDiscountType.UseCompatibleStateImageBehavior = false;
            this.lvwSalesInvoiceDiscountType.View = System.Windows.Forms.View.Details;
            this.lvwSalesInvoiceDiscountType.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colDiscountTypeName
            // 
            this.colDiscountTypeName.Text = "Discount Type Name";
            this.colDiscountTypeName.Width = 167;
            // 
            // colApplicableFor
            // 
            this.colApplicableFor.Text = "Applicable For";
            this.colApplicableFor.Width = 122;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 77;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            this.colIsActive.Width = 74;
            // 
            // colIsSystem
            // 
            this.colIsSystem.Text = "IsSystem";
            this.colIsSystem.Width = 78;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 91;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 103;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(724, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(724, 111);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 28);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSIDTAdd
            // 
            this.btnSIDTAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSIDTAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSIDTAdd.Location = new System.Drawing.Point(724, 73);
            this.btnSIDTAdd.Name = "btnSIDTAdd";
            this.btnSIDTAdd.Size = new System.Drawing.Size(68, 28);
            this.btnSIDTAdd.TabIndex = 4;
            this.btnSIDTAdd.Text = "&Add";
            this.btnSIDTAdd.UseVisualStyleBackColor = true;
            this.btnSIDTAdd.Click += new System.EventHandler(this.btnSIDTAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(399, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDiscountTypeName
            // 
            this.txtDiscountTypeName.Location = new System.Drawing.Point(139, 10);
            this.txtDiscountTypeName.Name = "txtDiscountTypeName";
            this.txtDiscountTypeName.Size = new System.Drawing.Size(199, 20);
            this.txtDiscountTypeName.TabIndex = 1;
            // 
            // lblDistSet
            // 
            this.lblDistSet.AutoSize = true;
            this.lblDistSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistSet.Location = new System.Drawing.Point(12, 11);
            this.lblDistSet.Name = "lblDistSet";
            this.lblDistSet.Size = new System.Drawing.Size(121, 15);
            this.lblDistSet.TabIndex = 0;
            this.lblDistSet.Text = "Discount Type Name";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "Active";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.LightGray;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(57, 298);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 15);
            this.label20.TabIndex = 9;
            this.label20.Text = "Inactive";
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(139, 37);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(199, 23);
            this.cmbTypes.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(100, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(355, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Active";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(399, 8);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(199, 23);
            this.cmbIsActive.TabIndex = 14;
            // 
            // frmSalesInvoiceDiscountTypes
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 323);
            this.Controls.Add(this.cmbTypes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDiscountTypeName);
            this.Controls.Add(this.lblDistSet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSIDTAdd);
            this.Controls.Add(this.lvwSalesInvoiceDiscountType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesInvoiceDiscountTypes";
            this.Text = "Sales Invoice Discount Types";
            this.Load += new System.EventHandler(this.frmSalesInvoiceDiscountTypes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSalesInvoiceDiscountType;
        private System.Windows.Forms.ColumnHeader colDiscountTypeName;
        private System.Windows.Forms.ColumnHeader colIsSystem;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSIDTAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtDiscountTypeName;
        private System.Windows.Forms.Label lblDistSet;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colApplicableFor;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbIsActive;
    }
}