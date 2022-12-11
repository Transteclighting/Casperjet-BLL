namespace CJ.Win
{
    partial class frmSCMPSIItemExeclUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMPSIItemExeclUploader));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXLFilePath = new System.Windows.Forms.TextBox();
            this.dgvSCMPSIItem = new System.Windows.Forms.DataGridView();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbAddSales = new System.Windows.Forms.RadioButton();
            this.rbAddPlan = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPSINo = new System.Windows.Forms.TextBox();
            this.lblColumnHead = new System.Windows.Forms.Label();
            this.pbInvoice = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSCMPSIItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(587, 497);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpload.Location = new System.Drawing.Point(535, 68);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(87, 30);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Browse";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "XL File Path";
            // 
            // txtXLFilePath
            // 
            this.txtXLFilePath.Location = new System.Drawing.Point(88, 71);
            this.txtXLFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXLFilePath.Name = "txtXLFilePath";
            this.txtXLFilePath.ReadOnly = true;
            this.txtXLFilePath.Size = new System.Drawing.Size(440, 23);
            this.txtXLFilePath.TabIndex = 1;
            // 
            // dgvSCMPSIItem
            // 
            this.dgvSCMPSIItem.AllowUserToAddRows = false;
            this.dgvSCMPSIItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSCMPSIItem.Location = new System.Drawing.Point(15, 118);
            this.dgvSCMPSIItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSCMPSIItem.Name = "dgvSCMPSIItem";
            this.dgvSCMPSIItem.Size = new System.Drawing.Size(685, 372);
            this.dgvSCMPSIItem.TabIndex = 6;
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialogData";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mobile No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "EmployeeCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Employee Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Current Bill";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // rbAddSales
            // 
            this.rbAddSales.AutoSize = true;
            this.rbAddSales.Location = new System.Drawing.Point(176, 12);
            this.rbAddSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAddSales.Name = "rbAddSales";
            this.rbAddSales.Size = new System.Drawing.Size(82, 20);
            this.rbAddSales.TabIndex = 106;
            this.rbAddSales.Text = "Sales Plan";
            this.rbAddSales.UseVisualStyleBackColor = true;
            this.rbAddSales.CheckedChanged += new System.EventHandler(this.rbAddSales_CheckedChanged);
            // 
            // rbAddPlan
            // 
            this.rbAddPlan.AutoSize = true;
            this.rbAddPlan.Location = new System.Drawing.Point(88, 12);
            this.rbAddPlan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAddPlan.Name = "rbAddPlan";
            this.rbAddPlan.Size = new System.Drawing.Size(88, 20);
            this.rbAddPlan.TabIndex = 105;
            this.rbAddPlan.Text = "Arrival Plan";
            this.rbAddPlan.UseVisualStyleBackColor = true;
            this.rbAddPlan.CheckedChanged += new System.EventHandler(this.rbAddPlan_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 107;
            this.label2.Text = "PSI No";
            // 
            // txtPSINo
            // 
            this.txtPSINo.Location = new System.Drawing.Point(88, 40);
            this.txtPSINo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPSINo.Name = "txtPSINo";
            this.txtPSINo.ReadOnly = true;
            this.txtPSINo.Size = new System.Drawing.Size(217, 23);
            this.txtPSINo.TabIndex = 108;
            // 
            // lblColumnHead
            // 
            this.lblColumnHead.AutoSize = true;
            this.lblColumnHead.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnHead.Location = new System.Drawing.Point(85, 98);
            this.lblColumnHead.Name = "lblColumnHead";
            this.lblColumnHead.Size = new System.Drawing.Size(76, 16);
            this.lblColumnHead.TabIndex = 109;
            this.lblColumnHead.Text = "Field Name:";
            // 
            // pbInvoice
            // 
            this.pbInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInvoice.Location = new System.Drawing.Point(15, 497);
            this.pbInvoice.Name = "pbInvoice";
            this.pbInvoice.Size = new System.Drawing.Size(563, 32);
            this.pbInvoice.TabIndex = 110;
            // 
            // frmSCMPSIItemExeclUploader
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 535);
            this.Controls.Add(this.pbInvoice);
            this.Controls.Add(this.lblColumnHead);
            this.Controls.Add(this.txtPSINo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbAddSales);
            this.Controls.Add(this.rbAddPlan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXLFilePath);
            this.Controls.Add(this.dgvSCMPSIItem);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSCMPSIItemExeclUploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSI Execl Uploader";
            this.Load += new System.EventHandler(this.frmSCMPSIItemExeclUploader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSCMPSIItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXLFilePath;
        private System.Windows.Forms.DataGridView dgvSCMPSIItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.RadioButton rbAddSales;
        private System.Windows.Forms.RadioButton rbAddPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPSINo;
        private System.Windows.Forms.Label lblColumnHead;
        private System.Windows.Forms.ProgressBar pbInvoice;
    }
}