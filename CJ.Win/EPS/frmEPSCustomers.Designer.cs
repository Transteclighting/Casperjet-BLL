namespace CJ.Win.EPS
{
    partial class frmEPSCustomers
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
            this.lvwEPSCustomers = new System.Windows.Forms.ListView();
            this.colEPSCustNo = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colPhoneNo = new System.Windows.Forms.ColumnHeader();
            this.colCompanyCode = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEPSCustomerCode = new System.Windows.Forms.TextBox();
            this.lblEPSCustomerCode = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwEPSCustomers
            // 
            this.lvwEPSCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEPSCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEPSCustNo,
            this.colEmployeeName,
            this.colPhoneNo,
            this.colCompanyCode,
            this.colCompany});
            this.lvwEPSCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEPSCustomers.FullRowSelect = true;
            this.lvwEPSCustomers.GridLines = true;
            this.lvwEPSCustomers.HideSelection = false;
            this.lvwEPSCustomers.Location = new System.Drawing.Point(-2, 69);
            this.lvwEPSCustomers.MultiSelect = false;
            this.lvwEPSCustomers.Name = "lvwEPSCustomers";
            this.lvwEPSCustomers.Size = new System.Drawing.Size(701, 366);
            this.lvwEPSCustomers.TabIndex = 78;
            this.lvwEPSCustomers.UseCompatibleStateImageBehavior = false;
            this.lvwEPSCustomers.View = System.Windows.Forms.View.Details;
            this.lvwEPSCustomers.DoubleClick += new System.EventHandler(this.lvwEPSCustomers_DoubleClick);
            // 
            // colEPSCustNo
            // 
            this.colEPSCustNo.Text = "Cust. Code";
            this.colEPSCustNo.Width = 79;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 159;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.Text = "Phone No";
            this.colPhoneNo.Width = 136;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Text = "Company Code";
            this.colCompanyCode.Width = 102;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company Name";
            this.colCompany.Width = 215;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(129, 12);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(465, 25);
            this.ctlCustomer1.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Company";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(344, 37);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(245, 20);
            this.txtEmployeeName.TabIndex = 176;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(246, 40);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(98, 13);
            this.lblEmployeeName.TabIndex = 175;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEPSCustomerCode
            // 
            this.txtEPSCustomerCode.Location = new System.Drawing.Point(129, 37);
            this.txtEPSCustomerCode.Name = "txtEPSCustomerCode";
            this.txtEPSCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtEPSCustomerCode.TabIndex = 174;
            // 
            // lblEPSCustomerCode
            // 
            this.lblEPSCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEPSCustomerCode.Location = new System.Drawing.Point(8, 40);
            this.lblEPSCustomerCode.Name = "lblEPSCustomerCode";
            this.lblEPSCustomerCode.Size = new System.Drawing.Size(120, 13);
            this.lblEPSCustomerCode.TabIndex = 173;
            this.lblEPSCustomerCode.Text = "EPS Customer Code";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(708, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 27);
            this.btnAdd.TabIndex = 182;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(598, 33);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 26);
            this.btnShow.TabIndex = 181;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(708, 101);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 27);
            this.btnEdit.TabIndex = 183;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(708, 134);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 27);
            this.btnDelete.TabIndex = 184;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(708, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 28);
            this.btnClose.TabIndex = 186;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmEPSCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 447);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.txtEPSCustomerCode);
            this.Controls.Add(this.lblEPSCustomerCode);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwEPSCustomers);
            this.Name = "frmEPSCustomers";
            this.Text = "EPS Customers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwEPSCustomers;
        private System.Windows.Forms.ColumnHeader colEPSCustNo;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colPhoneNo;
        private System.Windows.Forms.ColumnHeader colCompanyCode;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEPSCustomerCode;
        private System.Windows.Forms.Label lblEPSCustomerCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}