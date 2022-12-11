namespace TEL.SMS.UI.Win
{
    partial class frmRollingForecast
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
            this.dgvRollingForecast = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollingForecast)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRollingForecast
            // 
            this.dgvRollingForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRollingForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRollingForecast.Location = new System.Drawing.Point(12, 45);
            this.dgvRollingForecast.Name = "dgvRollingForecast";
            this.dgvRollingForecast.Size = new System.Drawing.Size(606, 301);
            this.dgvRollingForecast.TabIndex = 0;
            this.dgvRollingForecast.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRollingForecast_CellValueChanged);
            this.dgvRollingForecast.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRollingForecast_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Supplier";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(64, 12);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(128, 21);
            this.cboSupplier.TabIndex = 57;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            // 
            // dtpMonthYear
            // 
            this.dtpMonthYear.CustomFormat = "MMM-yyyy";
            this.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthYear.Location = new System.Drawing.Point(198, 12);
            this.dtpMonthYear.Name = "dtpMonthYear";
            this.dtpMonthYear.ShowUpDown = true;
            this.dtpMonthYear.Size = new System.Drawing.Size(78, 20);
            this.dtpMonthYear.TabIndex = 59;
            this.dtpMonthYear.Value = new System.DateTime(2007, 12, 1, 0, 0, 0, 0);
            this.dtpMonthYear.ValueChanged += new System.EventHandler(this.dtpMonthYear_ValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(298, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(77, 22);
            this.btnLoad.TabIndex = 60;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmRollingForecast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 358);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpMonthYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.dgvRollingForecast);
            this.Name = "frmRollingForecast";
            this.Text = "frmRollingForecast";
            this.Load += new System.EventHandler(this.frmRollingForecast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollingForecast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRollingForecast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.DateTimePicker dtpMonthYear;
        private System.Windows.Forms.Button btnLoad;
    }
}