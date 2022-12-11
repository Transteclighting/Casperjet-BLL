namespace CJ.Win.Plan
{
    partial class frmPlanBudgetTragetUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanBudgetTragetUploader));
            this.btnSave = new System.Windows.Forms.Button();
            this.pbInvoice = new System.Windows.Forms.ProgressBar();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBrowseData = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblColumnHead = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersionName = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblS1Qty = new System.Windows.Forms.Label();
            this.lblS1Value = new System.Windows.Forms.Label();
            this.lblS2Value = new System.Windows.Forms.Label();
            this.lblS2Qty = new System.Windows.Forms.Label();
            this.lblS3Value = new System.Windows.Forms.Label();
            this.lblS3Qty = new System.Windows.Forms.Label();
            this.lblSlab1Qty = new System.Windows.Forms.Label();
            this.lblSlab1Value = new System.Windows.Forms.Label();
            this.lblSlab2Value = new System.Windows.Forms.Label();
            this.lblSlab2Qty = new System.Windows.Forms.Label();
            this.lblSlab3Value = new System.Windows.Forms.Label();
            this.lblSlab3Qty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(590, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 26);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbInvoice
            // 
            this.pbInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInvoice.Location = new System.Drawing.Point(14, 422);
            this.pbInvoice.Name = "pbInvoice";
            this.pbInvoice.Size = new System.Drawing.Size(572, 23);
            this.pbInvoice.TabIndex = 12;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(14, 104);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(727, 260);
            this.dgvData.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(668, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBrowseData
            // 
            this.txtBrowseData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrowseData.Location = new System.Drawing.Point(61, 59);
            this.txtBrowseData.Name = "txtBrowseData";
            this.txtBrowseData.ReadOnly = true;
            this.txtBrowseData.Size = new System.Drawing.Size(601, 20);
            this.txtBrowseData.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(667, 57);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(61, 8);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(184, 21);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialogData";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(538, 370);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(201, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "?";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblColumnHead
            // 
            this.lblColumnHead.AutoSize = true;
            this.lblColumnHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnHead.Location = new System.Drawing.Point(12, 85);
            this.lblColumnHead.Name = "lblColumnHead";
            this.lblColumnHead.Size = new System.Drawing.Size(74, 13);
            this.lblColumnHead.TabIndex = 9;
            this.lblColumnHead.Text = "Field Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version Name";
            // 
            // txtVersionName
            // 
            this.txtVersionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersionName.Location = new System.Drawing.Point(346, 8);
            this.txtVersionName.Name = "txtVersionName";
            this.txtVersionName.Size = new System.Drawing.Size(316, 20);
            this.txtVersionName.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(61, 34);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(601, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Path";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(331, 370);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalQty.Size = new System.Drawing.Size(201, 13);
            this.lblTotalQty.TabIndex = 15;
            this.lblTotalQty.Text = "?";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblS1Qty
            // 
            this.lblS1Qty.AutoSize = true;
            this.lblS1Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS1Qty.Location = new System.Drawing.Point(15, 371);
            this.lblS1Qty.Name = "lblS1Qty";
            this.lblS1Qty.Size = new System.Drawing.Size(93, 13);
            this.lblS1Qty.TabIndex = 16;
            this.lblS1Qty.Text = "Slab-1 Target Qty:";
            // 
            // lblS1Value
            // 
            this.lblS1Value.AutoSize = true;
            this.lblS1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS1Value.Location = new System.Drawing.Point(4, 395);
            this.lblS1Value.Name = "lblS1Value";
            this.lblS1Value.Size = new System.Drawing.Size(104, 13);
            this.lblS1Value.TabIndex = 17;
            this.lblS1Value.Text = "Slab-1 Target Value:";
            // 
            // lblS2Value
            // 
            this.lblS2Value.AutoSize = true;
            this.lblS2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2Value.Location = new System.Drawing.Point(283, 395);
            this.lblS2Value.Name = "lblS2Value";
            this.lblS2Value.Size = new System.Drawing.Size(104, 13);
            this.lblS2Value.TabIndex = 19;
            this.lblS2Value.Text = "Slab-2 Target Value:";
            // 
            // lblS2Qty
            // 
            this.lblS2Qty.AutoSize = true;
            this.lblS2Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2Qty.Location = new System.Drawing.Point(294, 371);
            this.lblS2Qty.Name = "lblS2Qty";
            this.lblS2Qty.Size = new System.Drawing.Size(93, 13);
            this.lblS2Qty.TabIndex = 18;
            this.lblS2Qty.Text = "Slab-2 Target Qty:";
            // 
            // lblS3Value
            // 
            this.lblS3Value.AutoSize = true;
            this.lblS3Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS3Value.Location = new System.Drawing.Point(558, 395);
            this.lblS3Value.Name = "lblS3Value";
            this.lblS3Value.Size = new System.Drawing.Size(104, 13);
            this.lblS3Value.TabIndex = 21;
            this.lblS3Value.Text = "Slab-3 Target Value:";
            // 
            // lblS3Qty
            // 
            this.lblS3Qty.AutoSize = true;
            this.lblS3Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS3Qty.Location = new System.Drawing.Point(569, 371);
            this.lblS3Qty.Name = "lblS3Qty";
            this.lblS3Qty.Size = new System.Drawing.Size(93, 13);
            this.lblS3Qty.TabIndex = 20;
            this.lblS3Qty.Text = "Slab-3 Target Qty:";
            // 
            // lblSlab1Qty
            // 
            this.lblSlab1Qty.AutoSize = true;
            this.lblSlab1Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab1Qty.Location = new System.Drawing.Point(109, 371);
            this.lblSlab1Qty.Name = "lblSlab1Qty";
            this.lblSlab1Qty.Size = new System.Drawing.Size(14, 13);
            this.lblSlab1Qty.TabIndex = 22;
            this.lblSlab1Qty.Text = "?";
            this.lblSlab1Qty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlab1Value
            // 
            this.lblSlab1Value.AutoSize = true;
            this.lblSlab1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab1Value.Location = new System.Drawing.Point(109, 395);
            this.lblSlab1Value.Name = "lblSlab1Value";
            this.lblSlab1Value.Size = new System.Drawing.Size(14, 13);
            this.lblSlab1Value.TabIndex = 24;
            this.lblSlab1Value.Text = "?";
            this.lblSlab1Value.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlab2Value
            // 
            this.lblSlab2Value.AutoSize = true;
            this.lblSlab2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab2Value.Location = new System.Drawing.Point(389, 395);
            this.lblSlab2Value.Name = "lblSlab2Value";
            this.lblSlab2Value.Size = new System.Drawing.Size(14, 13);
            this.lblSlab2Value.TabIndex = 26;
            this.lblSlab2Value.Text = "?";
            this.lblSlab2Value.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlab2Qty
            // 
            this.lblSlab2Qty.AutoSize = true;
            this.lblSlab2Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab2Qty.Location = new System.Drawing.Point(389, 371);
            this.lblSlab2Qty.Name = "lblSlab2Qty";
            this.lblSlab2Qty.Size = new System.Drawing.Size(14, 13);
            this.lblSlab2Qty.TabIndex = 25;
            this.lblSlab2Qty.Text = "?";
            this.lblSlab2Qty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlab3Value
            // 
            this.lblSlab3Value.AutoSize = true;
            this.lblSlab3Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab3Value.Location = new System.Drawing.Point(664, 395);
            this.lblSlab3Value.Name = "lblSlab3Value";
            this.lblSlab3Value.Size = new System.Drawing.Size(14, 13);
            this.lblSlab3Value.TabIndex = 28;
            this.lblSlab3Value.Text = "?";
            this.lblSlab3Value.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSlab3Qty
            // 
            this.lblSlab3Qty.AutoSize = true;
            this.lblSlab3Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlab3Qty.Location = new System.Drawing.Point(664, 371);
            this.lblSlab3Qty.Name = "lblSlab3Qty";
            this.lblSlab3Qty.Size = new System.Drawing.Size(14, 13);
            this.lblSlab3Qty.TabIndex = 27;
            this.lblSlab3Qty.Text = "?";
            this.lblSlab3Qty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmPlanBudgetTragetUploader
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 457);
            this.Controls.Add(this.lblSlab3Value);
            this.Controls.Add(this.lblSlab3Qty);
            this.Controls.Add(this.lblSlab2Value);
            this.Controls.Add(this.lblSlab2Qty);
            this.Controls.Add(this.lblSlab1Value);
            this.Controls.Add(this.lblSlab1Qty);
            this.Controls.Add(this.lblS3Value);
            this.Controls.Add(this.lblS3Qty);
            this.Controls.Add(this.lblS2Value);
            this.Controls.Add(this.lblS2Qty);
            this.Controls.Add(this.lblS1Value);
            this.Controls.Add(this.lblS1Qty);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVersionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblColumnHead);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbInvoice);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBrowseData);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlanBudgetTragetUploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plan Budget Traget Uploader";
            this.Load += new System.EventHandler(this.frmPlanBudgetTragetUploader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar pbInvoice;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBrowseData;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblColumnHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersionName;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblS1Qty;
        private System.Windows.Forms.Label lblS1Value;
        private System.Windows.Forms.Label lblS2Value;
        private System.Windows.Forms.Label lblS2Qty;
        private System.Windows.Forms.Label lblS3Value;
        private System.Windows.Forms.Label lblS3Qty;
        private System.Windows.Forms.Label lblSlab1Qty;
        private System.Windows.Forms.Label lblSlab1Value;
        private System.Windows.Forms.Label lblSlab2Value;
        private System.Windows.Forms.Label lblSlab2Qty;
        private System.Windows.Forms.Label lblSlab3Value;
        private System.Windows.Forms.Label lblSlab3Qty;
    }
}