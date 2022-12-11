namespace CJ.Win.Control
{
    partial class frmSundryCustomerSearch
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
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lvwCustomer = new System.Windows.Forms.ListView();
            this.btClose = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 245;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Customer Code";
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(119, 5);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(219, 20);
            this.txtCustCode.TabIndex = 77;
            this.txtCustCode.TextChanged += new System.EventHandler(this.txtCustCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Customer Name Like";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(119, 31);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(286, 20);
            this.txtFind.TabIndex = 75;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lvwCustomer
            // 
            this.lvwCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerCode,
            this.colCustomerName});
            this.lvwCustomer.FullRowSelect = true;
            this.lvwCustomer.GridLines = true;
            this.lvwCustomer.HideSelection = false;
            this.lvwCustomer.Location = new System.Drawing.Point(1, 57);
            this.lvwCustomer.MultiSelect = false;
            this.lvwCustomer.Name = "lvwCustomer";
            this.lvwCustomer.Size = new System.Drawing.Size(493, 275);
            this.lvwCustomer.TabIndex = 74;
            this.lvwCustomer.UseCompatibleStateImageBehavior = false;
            this.lvwCustomer.View = System.Windows.Forms.View.Details;
            this.lvwCustomer.DoubleClick += new System.EventHandler(this.lvwCustomer_DoubleClick_1);
            this.lvwCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwCustomer_KeyPress);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(420, 333);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 79;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(417, 29);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 80;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // frmSundryCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 357);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lvwCustomer);
            this.Name = "frmSundryCustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sundry Customer Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ListView lvwCustomer;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSearch;
    }
}