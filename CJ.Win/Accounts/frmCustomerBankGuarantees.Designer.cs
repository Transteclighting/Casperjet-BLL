namespace CJ.Win.Accounts
{
    partial class frmCustomerBankGuarantees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerBankGuarantees));
            this.lblCustomer = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lvwBankGuaranty = new System.Windows.Forms.ListView();
            this.colTranID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpeningDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBGAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(22, 20);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(74, 17);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(548, 25);
            this.ctlCustomer1.TabIndex = 3;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(668, 15);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 9;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lvwBankGuaranty
            // 
            this.lvwBankGuaranty.AllowColumnReorder = true;
            this.lvwBankGuaranty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBankGuaranty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranID,
            this.colCustomerID,
            this.colRegionName,
            this.colAreaName,
            this.colTerritoryName,
            this.colCustomerName,
            this.colOpeningDate,
            this.colExpiryDate,
            this.colIsActive,
            this.colBGAmount});
            this.lvwBankGuaranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBankGuaranty.FullRowSelect = true;
            this.lvwBankGuaranty.GridLines = true;
            this.lvwBankGuaranty.HideSelection = false;
            this.lvwBankGuaranty.Location = new System.Drawing.Point(25, 63);
            this.lvwBankGuaranty.Name = "lvwBankGuaranty";
            this.lvwBankGuaranty.Size = new System.Drawing.Size(748, 366);
            this.lvwBankGuaranty.TabIndex = 10;
            this.lvwBankGuaranty.UseCompatibleStateImageBehavior = false;
            this.lvwBankGuaranty.View = System.Windows.Forms.View.Details;
            // 
            // colTranID
            // 
            this.colTranID.Text = "TranID";
            this.colTranID.Width = 0;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Text = "CustomerID";
            this.colCustomerID.Width = 0;
            // 
            // colRegionName
            // 
            this.colRegionName.Text = "Region Name";
            this.colRegionName.Width = 150;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area Name";
            this.colAreaName.Width = 150;
            // 
            // colTerritoryName
            // 
            this.colTerritoryName.Text = "Territory Name";
            this.colTerritoryName.Width = 150;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 150;
            // 
            // colOpeningDate
            // 
            this.colOpeningDate.Text = "Opening Date";
            this.colOpeningDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOpeningDate.Width = 79;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.Text = "Expiry Date";
            this.colExpiryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colExpiryDate.Width = 68;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Active";
            this.colIsActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIsActive.Width = 54;
            // 
            // colBGAmount
            // 
            this.colBGAmount.Text = "BG Amount";
            this.colBGAmount.Width = 81;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(798, 313);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(798, 92);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(798, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmCustomerBankGuarantees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 441);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwBankGuaranty);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.ctlCustomer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerBankGuarantees";
            this.Text = "Customer Bank Guarantees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ListView lvwBankGuaranty;
        private System.Windows.Forms.ColumnHeader colTranID;
        private System.Windows.Forms.ColumnHeader colCustomerID;
        private System.Windows.Forms.ColumnHeader colRegionName;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colTerritoryName;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colOpeningDate;
        private System.Windows.Forms.ColumnHeader colExpiryDate;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colBGAmount;
    }
}