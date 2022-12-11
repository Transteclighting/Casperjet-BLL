namespace TEL.SMS.UI.Win
{
    partial class frmCustomers
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
            this.components = new System.ComponentModel.Container();
            this.deleteProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.colCustomerID = new System.Windows.Forms.ColumnHeader();
            this.lvwCustomer = new System.Windows.Forms.ListView();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colMainChannelID = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteProductToolStripMenuItem
            // 
            this.deleteProductToolStripMenuItem.Name = "deleteProductToolStripMenuItem";
            this.deleteProductToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteProductToolStripMenuItem.Text = "Delete Product";
            // 
            // modifyProductToolStripMenuItem
            // 
            this.modifyProductToolStripMenuItem.Name = "modifyProductToolStripMenuItem";
            this.modifyProductToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modifyProductToolStripMenuItem.Text = "Modify Product";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(589, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(229, 7);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(352, 20);
            this.txtFind.TabIndex = 52;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // colCustomerID
            // 
            this.colCustomerID.Text = "Customer ID";
            this.colCustomerID.Width = 82;
            // 
            // lvwCustomer
            // 
            this.lvwCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerID,
            this.colCustomerName,
            this.colMainChannelID});
            this.lvwCustomer.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwCustomer.FullRowSelect = true;
            this.lvwCustomer.GridLines = true;
            this.lvwCustomer.HideSelection = false;
            this.lvwCustomer.Location = new System.Drawing.Point(12, 36);
            this.lvwCustomer.Name = "lvwCustomer";
            this.lvwCustomer.Size = new System.Drawing.Size(652, 291);
            this.lvwCustomer.TabIndex = 51;
            this.lvwCustomer.UseCompatibleStateImageBehavior = false;
            this.lvwCustomer.View = System.Windows.Forms.View.Details;
            this.lvwCustomer.DoubleClick += new System.EventHandler(this.lvwCustomer_DoubleClick);
            this.lvwCustomer.SelectedIndexChanged += new System.EventHandler(this.lvwCustomer_SelectedIndexChanged);
            this.lvwCustomer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwCustomer_ColumnClick);
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer  Name";
            this.colCustomerName.Width = 412;
            // 
            // colMainChannelID
            // 
            this.colMainChannelID.Text = "Channel Name";
            this.colMainChannelID.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.modifyProductToolStripMenuItem,
            this.deleteProductToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 70);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addNewProductToolStripMenuItem.Text = "Add new Product";
            // 
            // cboChannel
            // 
            this.cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Location = new System.Drawing.Point(95, 7);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(128, 21);
            this.cboChannel.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Channel Name";
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboChannel);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvwCustomer);
            this.Name = "frmCustomers";
            this.Text = "frmCustomers";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyProductToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ColumnHeader colCustomerID;
        private System.Windows.Forms.ListView lvwCustomer;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colMainChannelID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label label1;
    }
}