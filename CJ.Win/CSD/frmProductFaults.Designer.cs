namespace CJ.Win.CSD
{
    partial class frmProductFaults
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lvwProductFaults = new System.Windows.Forms.ListView();
            this.colFaultDescription = new System.Windows.Forms.ColumnHeader();
            this.colFaultType = new System.Windows.Forms.ColumnHeader();
            this.colParentFault = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbParentFault = new System.Windows.Forms.ComboBox();
            this.lblParentFault = new System.Windows.Forms.Label();
            this.txtFaultDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(584, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(584, 98);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 27);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lvwProductFaults
            // 
            this.lvwProductFaults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductFaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFaultDescription,
            this.colFaultType,
            this.colParentFault,
            this.colCreatedBy});
            this.lvwProductFaults.FullRowSelect = true;
            this.lvwProductFaults.GridLines = true;
            this.lvwProductFaults.Location = new System.Drawing.Point(12, 69);
            this.lvwProductFaults.MultiSelect = false;
            this.lvwProductFaults.Name = "lvwProductFaults";
            this.lvwProductFaults.Size = new System.Drawing.Size(566, 334);
            this.lvwProductFaults.TabIndex = 2;
            this.lvwProductFaults.UseCompatibleStateImageBehavior = false;
            this.lvwProductFaults.View = System.Windows.Forms.View.Details;
            // 
            // colFaultDescription
            // 
            this.colFaultDescription.Text = "Fault Description";
            this.colFaultDescription.Width = 242;
            // 
            // colFaultType
            // 
            this.colFaultType.Text = "Fault Type";
            this.colFaultType.Width = 85;
            // 
            // colParentFault
            // 
            this.colParentFault.Text = "Parent Fault";
            this.colParentFault.Width = 150;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "CreatedBy";
            this.colCreatedBy.Width = 81;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(584, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 27);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(341, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbParentFault
            // 
            this.cmbParentFault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentFault.FormattingEnabled = true;
            this.cmbParentFault.Location = new System.Drawing.Point(101, 14);
            this.cmbParentFault.Name = "cmbParentFault";
            this.cmbParentFault.Size = new System.Drawing.Size(233, 21);
            this.cmbParentFault.TabIndex = 10;
            // 
            // lblParentFault
            // 
            this.lblParentFault.AutoSize = true;
            this.lblParentFault.Location = new System.Drawing.Point(33, 18);
            this.lblParentFault.Name = "lblParentFault";
            this.lblParentFault.Size = new System.Drawing.Size(64, 13);
            this.lblParentFault.TabIndex = 9;
            this.lblParentFault.Text = "Parent Fault";
            // 
            // txtFaultDescription
            // 
            this.txtFaultDescription.Location = new System.Drawing.Point(101, 41);
            this.txtFaultDescription.Name = "txtFaultDescription";
            this.txtFaultDescription.Size = new System.Drawing.Size(234, 20);
            this.txtFaultDescription.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fault Description";
            // 
            // frmProductFaults
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 415);
            this.Controls.Add(this.cmbParentFault);
            this.Controls.Add(this.lblParentFault);
            this.Controls.Add(this.txtFaultDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwProductFaults);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductFaults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Faults";
            this.Load += new System.EventHandler(this.frmProductFaults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lvwProductFaults;
        private System.Windows.Forms.ColumnHeader colFaultDescription;
        private System.Windows.Forms.ColumnHeader colFaultType;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colParentFault;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbParentFault;
        private System.Windows.Forms.Label lblParentFault;
        private System.Windows.Forms.TextBox txtFaultDescription;
        private System.Windows.Forms.Label label1;
    }
}