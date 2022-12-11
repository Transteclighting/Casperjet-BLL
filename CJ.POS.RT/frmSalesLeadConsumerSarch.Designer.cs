namespace CJ.POS.RT
{
    partial class frmSalesLeadConsumerSarch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesLeadConsumerSarch));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lvwSalesLead = new System.Windows.Forms.ListView();
            this.colLeadNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 98;
            this.label1.Text = "Contact No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(103, 67);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(300, 21);
            this.txtContactNo.TabIndex = 97;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(409, 62);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(90, 30);
            this.btSearch.TabIndex = 96;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(493, 388);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(90, 30);
            this.btClose.TabIndex = 95;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Name Like";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 21);
            this.txtName.TabIndex = 91;
            // 
            // lvwSalesLead
            // 
            this.lvwSalesLead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSalesLead.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLeadNo,
            this.colCompanyName,
            this.colName,
            this.colContactNo,
            this.colCustomerType});
            this.lvwSalesLead.FullRowSelect = true;
            this.lvwSalesLead.GridLines = true;
            this.lvwSalesLead.HideSelection = false;
            this.lvwSalesLead.Location = new System.Drawing.Point(13, 98);
            this.lvwSalesLead.MultiSelect = false;
            this.lvwSalesLead.Name = "lvwSalesLead";
            this.lvwSalesLead.Size = new System.Drawing.Size(570, 284);
            this.lvwSalesLead.TabIndex = 90;
            this.lvwSalesLead.UseCompatibleStateImageBehavior = false;
            this.lvwSalesLead.View = System.Windows.Forms.View.Details;
            this.lvwSalesLead.DoubleClick += new System.EventHandler(this.lvwSalesLead_DoubleClick);
            this.lvwSalesLead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwSalesLead_KeyPress);
            // 
            // colLeadNo
            // 
            this.colLeadNo.Text = "Lead No";
            this.colLeadNo.Width = 80;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Text = "Company";
            this.colCompanyName.Width = 84;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 131;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 108;
            // 
            // colCustomerType
            // 
            this.colCustomerType.Text = "Cust. Type";
            this.colCustomerType.Width = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Company Like";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(103, 13);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(300, 21);
            this.txtCompany.TabIndex = 99;
            // 
            // frmSalesLeadConsumerSarch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lvwSalesLead);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesLeadConsumerSarch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Lead Consumer List";
            this.Load += new System.EventHandler(this.frmSalesLeadConsumerSarch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListView lvwSalesLead;
        private System.Windows.Forms.ColumnHeader colLeadNo;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colCustomerType;
        private System.Windows.Forms.ColumnHeader colCompanyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompany;
    }
}