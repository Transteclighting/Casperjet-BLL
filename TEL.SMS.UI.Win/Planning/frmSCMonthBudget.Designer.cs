namespace TEL.SMS.UI.Win
{
    partial class frmSCMonthBudget
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.dgvRollingForecast = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollingForecast)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(553, 8);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(77, 22);
            this.btnLoad.TabIndex = 65;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpMonthYear
            // 
            this.dtpMonthYear.CustomFormat = "yyyy";
            this.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthYear.Location = new System.Drawing.Point(319, 7);
            this.dtpMonthYear.Name = "dtpMonthYear";
            this.dtpMonthYear.ShowUpDown = true;
            this.dtpMonthYear.Size = new System.Drawing.Size(78, 20);
            this.dtpMonthYear.TabIndex = 64;
            this.dtpMonthYear.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Supplier";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(64, 8);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(249, 21);
            this.cboSupplier.TabIndex = 62;
            // 
            // dgvRollingForecast
            // 
            this.dgvRollingForecast.AllowUserToAddRows = false;
            this.dgvRollingForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRollingForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRollingForecast.Location = new System.Drawing.Point(12, 36);
            this.dgvRollingForecast.Name = "dgvRollingForecast";
            this.dgvRollingForecast.Size = new System.Drawing.Size(618, 353);
            this.dgvRollingForecast.TabIndex = 61;
            this.dgvRollingForecast.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRollingForecast_CellValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(553, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 22);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSCMonthBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 429);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpMonthYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.dgvRollingForecast);
            this.Name = "frmSCMonthBudget";
            this.Text = "frmSCMonthBudget";
            this.Load += new System.EventHandler(this.frmSCMonthBudget_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollingForecast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpMonthYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.DataGridView dgvRollingForecast;
        private System.Windows.Forms.Button btnSave;
    }
}