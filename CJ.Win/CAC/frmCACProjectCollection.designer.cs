namespace CJ.Win.CAC
{
    partial class frmCACProjectCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjectCollection));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCTNO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.grpTransactionMap = new System.Windows.Forms.GroupBox();
            this.lvwTransactionMap = new System.Windows.Forms.ListView();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label25 = new System.Windows.Forms.Label();
            this.txtTotalSecurityAmount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpTransactionMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(362, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(446, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Code:";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(219, 41);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(67, 23);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(98, 9);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.ReadOnly = true;
            this.txtProjectCode.Size = new System.Drawing.Size(115, 21);
            this.txtProjectCode.TabIndex = 1;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(306, 9);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(215, 21);
            this.txtProjectName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project Name:";
            // 
            // txtCTNO
            // 
            this.txtCTNO.Location = new System.Drawing.Point(98, 41);
            this.txtCTNO.Name = "txtCTNO";
            this.txtCTNO.Size = new System.Drawing.Size(115, 21);
            this.txtCTNO.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tran No:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(98, 72);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(115, 21);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "0";
            // 
            // grpTransactionMap
            // 
            this.grpTransactionMap.Controls.Add(this.lvwTransactionMap);
            this.grpTransactionMap.Controls.Add(this.label25);
            this.grpTransactionMap.Controls.Add(this.txtTotalSecurityAmount);
            this.grpTransactionMap.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F);
            this.grpTransactionMap.Location = new System.Drawing.Point(12, 96);
            this.grpTransactionMap.Name = "grpTransactionMap";
            this.grpTransactionMap.Size = new System.Drawing.Size(515, 124);
            this.grpTransactionMap.TabIndex = 81;
            this.grpTransactionMap.TabStop = false;
            this.grpTransactionMap.Text = "Transaction Map";
            // 
            // lvwTransactionMap
            // 
            this.lvwTransactionMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTransactionMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.colAmount});
            this.lvwTransactionMap.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwTransactionMap.FullRowSelect = true;
            this.lvwTransactionMap.GridLines = true;
            this.lvwTransactionMap.Location = new System.Drawing.Point(6, 20);
            this.lvwTransactionMap.Name = "lvwTransactionMap";
            this.lvwTransactionMap.Size = new System.Drawing.Size(503, 98);
            this.lvwTransactionMap.TabIndex = 12;
            this.lvwTransactionMap.UseCompatibleStateImageBehavior = false;
            this.lvwTransactionMap.View = System.Windows.Forms.View.Details;
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Tran No";
            this.colTranNo.Width = 140;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 140;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(342, 172);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 14);
            this.label25.TabIndex = 10;
            this.label25.Text = "Total:";
            // 
            // txtTotalSecurityAmount
            // 
            this.txtTotalSecurityAmount.Location = new System.Drawing.Point(386, 169);
            this.txtTotalSecurityAmount.Name = "txtTotalSecurityAmount";
            this.txtTotalSecurityAmount.ReadOnly = true;
            this.txtTotalSecurityAmount.Size = new System.Drawing.Size(90, 21);
            this.txtTotalSecurityAmount.TabIndex = 11;
            this.txtTotalSecurityAmount.Text = "0";
            this.txtTotalSecurityAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtTotal.Location = new System.Drawing.Point(411, 226);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(110, 23);
            this.txtTotal.TabIndex = 84;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(369, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 83;
            this.label5.Text = "Total";
            // 
            // frmCACProjectCollection
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 287);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpTransactionMap);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCTNO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectCode);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjectCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Project Collection";
            this.Load += new System.EventHandler(this.CACProjectCollection_Load);
            this.grpTransactionMap.ResumeLayout(false);
            this.grpTransactionMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCTNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox grpTransactionMap;
        private System.Windows.Forms.ListView lvwTransactionMap;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTotalSecurityAmount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
    }
}