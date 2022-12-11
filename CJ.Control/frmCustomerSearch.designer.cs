namespace CJ.Win.Control
{
    partial class frmCustomerSearch
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lvwCustomer = new System.Windows.Forms.ListView();
            this.colCustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Territory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btSearch = new System.Windows.Forms.Button();
            this.colCustomerTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Customer Code";
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(125, 2);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(174, 20);
            this.txtCustCode.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Customer Name Like";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(125, 28);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(310, 20);
            this.txtFind.TabIndex = 70;
            // 
            // lvwCustomer
            // 
            this.lvwCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerCode,
            this.colCustomerName,
            this.colChannel,
            this.colCustomerTypeName,
            this.colArea,
            this.Territory,
            this.colIsActive});
            this.lvwCustomer.FullRowSelect = true;
            this.lvwCustomer.GridLines = true;
            this.lvwCustomer.HideSelection = false;
            this.lvwCustomer.Location = new System.Drawing.Point(7, 54);
            this.lvwCustomer.MultiSelect = false;
            this.lvwCustomer.Name = "lvwCustomer";
            this.lvwCustomer.Size = new System.Drawing.Size(828, 351);
            this.lvwCustomer.TabIndex = 69;
            this.lvwCustomer.UseCompatibleStateImageBehavior = false;
            this.lvwCustomer.View = System.Windows.Forms.View.Details;
            this.lvwCustomer.DoubleClick += new System.EventHandler(this.lvwCustomer_DoubleClick);
            this.lvwCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwCustomer_KeyPress);
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 245;
            // 
            // colChannel
            // 
            this.colChannel.Text = "Channel";
            this.colChannel.Width = 150;
            // 
            // colArea
            // 
            this.colArea.Text = "Area";
            this.colArea.Width = 150;
            // 
            // Territory
            // 
            this.Territory.Text = "Territory";
            this.Territory.Width = 118;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(636, 26);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 75;
            this.btSearch.Text = "Get Data";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // colCustomerTypeName
            // 
            this.colCustomerTypeName.Text = "Customer Type";
            this.colCustomerTypeName.Width = 113;
            // 
            // frmCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 426);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lvwCustomer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ListView lvwCustomer;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colChannel;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader Territory;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colCustomerTypeName;
    }
}