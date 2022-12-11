namespace CJ.Win.Ecommerce
{
    partial class frmLeadConsumerSarch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeadConsumerSarch));
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerType = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.colCompanyName = new System.Windows.Forms.ColumnHeader();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.colLeadNo = new System.Windows.Forms.ColumnHeader();
            this.btSearch = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lvwSalesLead = new System.Windows.Forms.ListView();
            this.SuspendLayout();
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
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Company Like";
            // 
            // colCompanyName
            // 
            this.colCompanyName.Text = "Company";
            this.colCompanyName.Width = 84;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(89, 12);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(258, 20);
            this.txtCompany.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Contact No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(89, 61);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(258, 20);
            this.txtContactNo.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Name Like";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 20);
            this.txtName.TabIndex = 102;
            // 
            // colLeadNo
            // 
            this.colLeadNo.Text = "Lead No";
            this.colLeadNo.Width = 80;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(424, 55);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 26);
            this.btSearch.TabIndex = 105;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(424, 341);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 26);
            this.btClose.TabIndex = 104;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
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
            this.lvwSalesLead.Location = new System.Drawing.Point(13, 87);
            this.lvwSalesLead.MultiSelect = false;
            this.lvwSalesLead.Name = "lvwSalesLead";
            this.lvwSalesLead.Size = new System.Drawing.Size(486, 248);
            this.lvwSalesLead.TabIndex = 101;
            this.lvwSalesLead.UseCompatibleStateImageBehavior = false;
            this.lvwSalesLead.View = System.Windows.Forms.View.Details;
            this.lvwSalesLead.DoubleClick += new System.EventHandler(this.lvwSalesLead_DoubleClick);
            this.lvwSalesLead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwSalesLead_KeyPress);
            // 
            // frmLeadConsumerSarch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 373);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lvwSalesLead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLeadConsumerSarch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLeadConsumerSarch";
            this.Load += new System.EventHandler(this.frmLeadConsumerSarch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colCustomerType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colCompanyName;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ColumnHeader colLeadNo;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView lvwSalesLead;
    }
}