namespace CJ.Win.Accounts
{
    partial class frmVeriableExpenseProvision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTELMCAnalysisSettings = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValuePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbTel = new System.Windows.Forms.RadioButton();
            this.rbHO = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBillMonth = new System.Windows.Forms.Label();
            this.dtMonth = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbTML = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTELMCAnalysisSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTELMCAnalysisSettings
            // 
            this.dgvTELMCAnalysisSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTELMCAnalysisSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtDescription,
            this.txtSalesType,
            this.txtValuePercentage,
            this.txtID});
            this.dgvTELMCAnalysisSettings.Location = new System.Drawing.Point(12, 50);
            this.dgvTELMCAnalysisSettings.Name = "dgvTELMCAnalysisSettings";
            this.dgvTELMCAnalysisSettings.Size = new System.Drawing.Size(468, 347);
            this.dgvTELMCAnalysisSettings.TabIndex = 0;
            // 
            // txtDescription
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.txtDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Width = 200;
            // 
            // txtSalesType
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.txtSalesType.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtSalesType.HeaderText = "Sales type";
            this.txtSalesType.Name = "txtSalesType";
            this.txtSalesType.ReadOnly = true;
            // 
            // txtValuePercentage
            // 
            this.txtValuePercentage.HeaderText = "Value Percentage";
            this.txtValuePercentage.Name = "txtValuePercentage";
            // 
            // txtID
            // 
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // rbTel
            // 
            this.rbTel.AutoSize = true;
            this.rbTel.Checked = true;
            this.rbTel.Location = new System.Drawing.Point(94, 19);
            this.rbTel.Name = "rbTel";
            this.rbTel.Size = new System.Drawing.Size(45, 17);
            this.rbTel.TabIndex = 1;
            this.rbTel.TabStop = true;
            this.rbTel.Text = "TEL";
            this.rbTel.UseVisualStyleBackColor = true;
            this.rbTel.CheckedChanged += new System.EventHandler(this.rbTel_CheckedChanged);
            // 
            // rbHO
            // 
            this.rbHO.AutoSize = true;
            this.rbHO.Location = new System.Drawing.Point(145, 19);
            this.rbHO.Name = "rbHO";
            this.rbHO.Size = new System.Drawing.Size(41, 17);
            this.rbHO.TabIndex = 2;
            this.rbHO.Text = "HO";
            this.rbHO.UseVisualStyleBackColor = true;
            this.rbHO.CheckedChanged += new System.EventHandler(this.rbHO_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Business Type:";
            // 
            // lblBillMonth
            // 
            this.lblBillMonth.AutoSize = true;
            this.lblBillMonth.Location = new System.Drawing.Point(333, 25);
            this.lblBillMonth.Name = "lblBillMonth";
            this.lblBillMonth.Size = new System.Drawing.Size(37, 13);
            this.lblBillMonth.TabIndex = 8;
            this.lblBillMonth.Text = "Month";
            // 
            // dtMonth
            // 
            this.dtMonth.CustomFormat = "MMM-yyyy";
            this.dtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMonth.Location = new System.Drawing.Point(372, 21);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.ShowUpDown = true;
            this.dtMonth.Size = new System.Drawing.Size(108, 23);
            this.dtMonth.TabIndex = 9;
            this.dtMonth.Value = new System.DateTime(2020, 9, 3, 12, 13, 5, 0);
            this.dtMonth.ValueChanged += new System.EventHandler(this.dtMonth_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(405, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbTML
            // 
            this.rbTML.AutoSize = true;
            this.rbTML.Location = new System.Drawing.Point(192, 19);
            this.rbTML.Name = "rbTML";
            this.rbTML.Size = new System.Drawing.Size(47, 17);
            this.rbTML.TabIndex = 12;
            this.rbTML.Text = "TML";
            this.rbTML.UseVisualStyleBackColor = true;
            this.rbTML.CheckedChanged += new System.EventHandler(this.rbTML_CheckedChanged);
            // 
            // frmVeriableExpenseProvision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 438);
            this.Controls.Add(this.rbTML);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblBillMonth);
            this.Controls.Add(this.dtMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbHO);
            this.Controls.Add(this.rbTel);
            this.Controls.Add(this.dgvTELMCAnalysisSettings);
            this.Name = "frmVeriableExpenseProvision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVeriableExpenseProvision";
            this.Load += new System.EventHandler(this.frmVeriableExpenseProvision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTELMCAnalysisSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTELMCAnalysisSettings;
        private System.Windows.Forms.RadioButton rbTel;
        private System.Windows.Forms.RadioButton rbHO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.DateTimePicker dtMonth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtValuePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.RadioButton rbTML;
    }
}