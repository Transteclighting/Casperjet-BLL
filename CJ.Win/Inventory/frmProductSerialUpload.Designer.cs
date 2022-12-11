namespace CJ.Win.Inventory
{
    partial class frmProductSerialUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductSerialUpload));
            this.label3 = new System.Windows.Forms.Label();
            this.lblColumnHead = new System.Windows.Forms.Label();
            this.txtBrowseData = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbInvoice = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRefTranNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBENo = new System.Windows.Forms.TextBox();
            this.lblBENo = new System.Windows.Forms.Label();
            this.dtBEDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "File Path";
            // 
            // lblColumnHead
            // 
            this.lblColumnHead.AutoSize = true;
            this.lblColumnHead.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnHead.Location = new System.Drawing.Point(14, 132);
            this.lblColumnHead.Name = "lblColumnHead";
            this.lblColumnHead.Size = new System.Drawing.Size(76, 16);
            this.lblColumnHead.TabIndex = 19;
            this.lblColumnHead.Text = "Field Name:";
            // 
            // txtBrowseData
            // 
            this.txtBrowseData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrowseData.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowseData.Location = new System.Drawing.Point(143, 103);
            this.txtBrowseData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBrowseData.Name = "txtBrowseData";
            this.txtBrowseData.ReadOnly = true;
            this.txtBrowseData.Size = new System.Drawing.Size(299, 23);
            this.txtBrowseData.TabIndex = 17;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(448, 98);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(84, 32);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialogData";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(15, 152);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(524, 314);
            this.dgvData.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(364, 500);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbInvoice
            // 
            this.pbInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInvoice.Location = new System.Drawing.Point(17, 500);
            this.pbInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbInvoice.Name = "pbInvoice";
            this.pbInvoice.Size = new System.Drawing.Size(341, 28);
            this.pbInvoice.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(455, 500);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 32);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRefTranNo
            // 
            this.txtRefTranNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefTranNo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtRefTranNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefTranNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRefTranNo.Location = new System.Drawing.Point(143, 13);
            this.txtRefTranNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefTranNo.Name = "txtRefTranNo";
            this.txtRefTranNo.ReadOnly = true;
            this.txtRefTranNo.Size = new System.Drawing.Size(208, 23);
            this.txtRefTranNo.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ref. GRD No#";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(308, 470);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(234, 16);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "?";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "BE/VAT Challan Date";
            // 
            // txtBENo
            // 
            this.txtBENo.Location = new System.Drawing.Point(143, 43);
            this.txtBENo.Name = "txtBENo";
            this.txtBENo.Size = new System.Drawing.Size(208, 23);
            this.txtBENo.TabIndex = 29;
            // 
            // lblBENo
            // 
            this.lblBENo.AutoSize = true;
            this.lblBENo.Location = new System.Drawing.Point(31, 46);
            this.lblBENo.Name = "lblBENo";
            this.lblBENo.Size = new System.Drawing.Size(106, 16);
            this.lblBENo.TabIndex = 28;
            this.lblBENo.Text = "BE/VAT Challan #";
            // 
            // dtBEDate
            // 
            this.dtBEDate.CustomFormat = "dd-MMM-yyyy";
            this.dtBEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBEDate.Location = new System.Drawing.Point(143, 73);
            this.dtBEDate.Name = "dtBEDate";
            this.dtBEDate.Size = new System.Drawing.Size(208, 23);
            this.dtBEDate.TabIndex = 27;
            // 
            // frmProductSerialUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 545);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBENo);
            this.Controls.Add(this.lblBENo);
            this.Controls.Add(this.dtBEDate);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtRefTranNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbInvoice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblColumnHead);
            this.Controls.Add(this.txtBrowseData);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmProductSerialUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Serial Upload";
            this.Load += new System.EventHandler(this.frmProductSerialUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblColumnHead;
        private System.Windows.Forms.TextBox txtBrowseData;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar pbInvoice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRefTranNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBENo;
        private System.Windows.Forms.Label lblBENo;
        private System.Windows.Forms.DateTimePicker dtBEDate;
    }
}