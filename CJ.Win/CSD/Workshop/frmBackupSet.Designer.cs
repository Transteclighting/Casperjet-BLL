namespace CJ.Win.CSD.Workshop
{
    partial class frmBackupSet
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
            this.lvwBackupSet = new System.Windows.Forms.ListView();
            this.colBackupSetID = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colAssignJobNo = new System.Windows.Forms.ColumnHeader();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.chkUassignProduct = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colProductSerial = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwBackupSet
            // 
            this.lvwBackupSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBackupSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBackupSetID,
            this.colProductCode,
            this.colProductSerial,
            this.colProductName,
            this.colAssignJobNo});
            this.lvwBackupSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBackupSet.FullRowSelect = true;
            this.lvwBackupSet.GridLines = true;
            this.lvwBackupSet.HideSelection = false;
            this.lvwBackupSet.Location = new System.Drawing.Point(15, 76);
            this.lvwBackupSet.MultiSelect = false;
            this.lvwBackupSet.Name = "lvwBackupSet";
            this.lvwBackupSet.Size = new System.Drawing.Size(877, 420);
            this.lvwBackupSet.TabIndex = 10;
            this.lvwBackupSet.UseCompatibleStateImageBehavior = false;
            this.lvwBackupSet.View = System.Windows.Forms.View.Details;
            // 
            // colBackupSetID
            // 
            this.colBackupSetID.Text = "Backupset ID";
            this.colBackupSetID.Width = 90;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 156;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 423;
            // 
            // colAssignJobNo
            // 
            this.colAssignJobNo.Text = "Assign Job No";
            this.colAssignJobNo.Width = 107;
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssue.Location = new System.Drawing.Point(896, 104);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(92, 27);
            this.btnIssue.TabIndex = 11;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(896, 131);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(92, 27);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "&Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Job";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(898, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 27);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(644, 22);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(86, 27);
            this.btnGet.TabIndex = 17;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // chkUassignProduct
            // 
            this.chkUassignProduct.AutoSize = true;
            this.chkUassignProduct.Location = new System.Drawing.Point(503, 16);
            this.chkUassignProduct.Name = "chkUassignProduct";
            this.chkUassignProduct.Size = new System.Drawing.Size(110, 17);
            this.chkUassignProduct.TabIndex = 20;
            this.chkUassignProduct.Text = "Unassign Product";
            this.chkUassignProduct.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(896, 158);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 27);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(56, 14);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(438, 20);
            this.ctlProduct1.TabIndex = 19;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(63, 36);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(427, 31);
            this.ctlCSDJob1.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(896, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 27);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colProductSerial
            // 
            this.colProductSerial.Text = "Product Serial No";
            this.colProductSerial.Width = 150;
            // 
            // frmBackupSet
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 508);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkUassignProduct);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lvwBackupSet);
            this.Name = "frmBackupSet";
            this.Text = "CSD Backup Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwBackupSet;
        private System.Windows.Forms.ColumnHeader colBackupSetID;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colAssignJobNo;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGet;
        private ctlCSDJob ctlCSDJob1;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.CheckBox chkUassignProduct;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colProductSerial;
    }
}