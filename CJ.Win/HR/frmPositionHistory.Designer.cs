namespace CJ.Win.HR
{
    partial class frmPositionHistory
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
            this.lvwItem = new System.Windows.Forms.ListView();
            this.colEmployee = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colFromDate = new System.Windows.Forms.ColumnHeader();
            this.colToDate = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblabc = new System.Windows.Forms.Label();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwItem
            // 
            this.lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployee,
            this.colDesignation,
            this.colFromDate,
            this.colToDate,
            this.colRemarks});
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.GridLines = true;
            this.lvwItem.Location = new System.Drawing.Point(12, 72);
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.Size = new System.Drawing.Size(582, 157);
            this.lvwItem.TabIndex = 0;
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.Details;
            this.lvwItem.SelectedIndexChanged += new System.EventHandler(this.lvwItem_SelectedIndexChanged);
            // 
            // colEmployee
            // 
            this.colEmployee.Text = "Employee";
            this.colEmployee.Width = 230;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 150;
            // 
            // colFromDate
            // 
            this.colFromDate.Text = "From Date";
            this.colFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFromDate.Width = 75;
            // 
            // colToDate
            // 
            this.colToDate.Text = "To Date";
            this.colToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colToDate.Width = 75;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 130;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(519, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Blue;
            this.lblCompany.Location = new System.Drawing.Point(98, 22);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(21, 13);
            this.lblCompany.TabIndex = 15;
            this.lblCompany.Text = "??";
            // 
            // lblabc
            // 
            this.lblabc.AutoSize = true;
            this.lblabc.Location = new System.Drawing.Point(41, 21);
            this.lblabc.Name = "lblabc";
            this.lblabc.Size = new System.Drawing.Size(51, 13);
            this.lblabc.TabIndex = 14;
            this.lblabc.Text = "Company";
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNode.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectedNode.Location = new System.Drawing.Point(98, 43);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(21, 13);
            this.lblSelectedNode.TabIndex = 13;
            this.lblSelectedNode.Text = "??";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Selected Node";
            // 
            // frmPositionHistory
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 274);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblabc);
            this.Controls.Add(this.lblSelectedNode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Position Assign History";
            this.Load += new System.EventHandler(this.frmPositionHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.ColumnHeader colEmployee;
        private System.Windows.Forms.ColumnHeader colFromDate;
        private System.Windows.Forms.ColumnHeader colToDate;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblabc;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colDesignation;
    }
}