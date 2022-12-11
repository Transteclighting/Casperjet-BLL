namespace CJ.Win
{
    partial class frmInquiryCommunication
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
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCommuRemarks = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtProductASG = new System.Windows.Forms.TextBox();
            this.lblProductASG = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwSalesNoExecuated = new System.Windows.Forms.ListView();
            this.colSalesNoExecuated = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(27, 261);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 126;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(340, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 124;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCommuRemarks
            // 
            this.txtCommuRemarks.AcceptsReturn = true;
            this.txtCommuRemarks.Location = new System.Drawing.Point(28, 276);
            this.txtCommuRemarks.Multiline = true;
            this.txtCommuRemarks.Name = "txtCommuRemarks";
            this.txtCommuRemarks.Size = new System.Drawing.Size(492, 38);
            this.txtCommuRemarks.TabIndex = 122;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(105, 20);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(171, 20);
            this.txtInvoiceNo.TabIndex = 130;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(34, 23);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(69, 13);
            this.lblInvoiceNo.TabIndex = 132;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.Location = new System.Drawing.Point(23, 51);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(80, 13);
            this.lblInvoiceDate.TabIndex = 129;
            this.lblInvoiceDate.Text = "Invoice Date";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoiceDate.Location = new System.Drawing.Point(105, 47);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(130, 20);
            this.dtInvoiceDate.TabIndex = 131;
            // 
            // txtProductASG
            // 
            this.txtProductASG.Location = new System.Drawing.Point(105, 74);
            this.txtProductASG.Name = "txtProductASG";
            this.txtProductASG.Size = new System.Drawing.Size(171, 20);
            this.txtProductASG.TabIndex = 135;
            // 
            // lblProductASG
            // 
            this.lblProductASG.AutoSize = true;
            this.lblProductASG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductASG.Location = new System.Drawing.Point(16, 77);
            this.lblProductASG.Name = "lblProductASG";
            this.lblProductASG.Size = new System.Drawing.Size(88, 13);
            this.lblProductASG.TabIndex = 136;
            this.lblProductASG.Text = "Product (ASG)";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(105, 101);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(171, 20);
            this.txtAmount.TabIndex = 137;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(54, 104);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 138;
            this.lblAmount.Text = "Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.txtProductASG);
            this.groupBox1.Controls.Add(this.lblProductASG);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.lblInvoiceNo);
            this.groupBox1.Controls.Add(this.lblInvoiceDate);
            this.groupBox1.Controls.Add(this.dtInvoiceDate);
            this.groupBox1.Location = new System.Drawing.Point(28, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 159);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "If Yes";
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNo.Location = new System.Drawing.Point(311, 14);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(41, 17);
            this.rdbNo.TabIndex = 141;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            this.rdbNo.CheckedChanged += new System.EventHandler(this.rdbNo_CheckedChanged);
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Checked = true;
            this.rdbYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYes.Location = new System.Drawing.Point(105, 14);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(46, 17);
            this.rdbYes.TabIndex = 140;
            this.rdbYes.TabStop = true;
            this.rdbYes.Text = "Yes";
            this.rdbYes.UseVisualStyleBackColor = true;
            this.rdbYes.CheckedChanged += new System.EventHandler(this.rdbYes_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwSalesNoExecuated);
            this.groupBox2.Location = new System.Drawing.Point(338, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 160);
            this.groupBox2.TabIndex = 142;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "If No";
            // 
            // lvwSalesNoExecuated
            // 
            this.lvwSalesNoExecuated.CheckBoxes = true;
            this.lvwSalesNoExecuated.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSalesNoExecuated});
            this.lvwSalesNoExecuated.GridLines = true;
            this.lvwSalesNoExecuated.HideSelection = false;
            this.lvwSalesNoExecuated.Location = new System.Drawing.Point(8, 21);
            this.lvwSalesNoExecuated.MultiSelect = false;
            this.lvwSalesNoExecuated.Name = "lvwSalesNoExecuated";
            this.lvwSalesNoExecuated.Size = new System.Drawing.Size(174, 129);
            this.lvwSalesNoExecuated.TabIndex = 6;
            this.lvwSalesNoExecuated.UseCompatibleStateImageBehavior = false;
            this.lvwSalesNoExecuated.View = System.Windows.Forms.View.Details;
            // 
            // colSalesNoExecuated
            // 
            this.colSalesNoExecuated.Text = "Sales No Execuated";
            this.colSalesNoExecuated.Width = 166;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbYes);
            this.groupBox3.Controls.Add(this.rdbNo);
            this.groupBox3.Location = new System.Drawing.Point(28, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 39);
            this.groupBox3.TabIndex = 143;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales Executed?";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(431, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 27);
            this.btnClose.TabIndex = 144;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmInquiryCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 368);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCommuRemarks);
            this.Name = "frmInquiryCommunication";
            this.Text = "Sales Information";
            this.Load += new System.EventHandler(this.frmInquiryCommunication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCommuRemarks;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.TextBox txtProductASG;
        private System.Windows.Forms.Label lblProductASG;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbYes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvwSalesNoExecuated;
        private System.Windows.Forms.ColumnHeader colSalesNoExecuated;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
    }
}