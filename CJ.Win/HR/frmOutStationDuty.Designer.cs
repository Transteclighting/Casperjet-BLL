namespace CJ.Win.HR
{
    partial class frmOutStationDuty
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvOutStation = new System.Windows.Forms.DataGridView();
            this.ColFromdate = new RSMS.BaseItems.DateTimePickerColumn();
            this.ColTodate = new RSMS.BaseItems.DateTimePickerColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 191;
            this.label1.Text = "Employee";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(577, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 183;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvOutStation
            // 
            this.dgvOutStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFromdate,
            this.ColTodate,
            this.ColAddress,
            this.ColReason});
            this.dgvOutStation.Location = new System.Drawing.Point(57, 37);
            this.dgvOutStation.Name = "dgvOutStation";
            this.dgvOutStation.Size = new System.Drawing.Size(604, 113);
            this.dgvOutStation.TabIndex = 194;
            // 
            // ColFromdate
            // 
            this.ColFromdate.HeaderText = "From Date";
            this.ColFromdate.Name = "ColFromdate";
            this.ColFromdate.Width = 80;
            // 
            // ColTodate
            // 
            this.ColTodate.HeaderText = "To Date";
            this.ColTodate.Name = "ColTodate";
            this.ColTodate.Width = 80;
            // 
            // ColAddress
            // 
            this.ColAddress.HeaderText = "Address";
            this.ColAddress.Name = "ColAddress";
            this.ColAddress.Width = 200;
            // 
            // ColReason
            // 
            this.ColReason.HeaderText = "Reason";
            this.ColReason.Name = "ColReason";
            this.ColReason.Width = 200;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(57, 6);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(543, 25);
            this.ctlEmployee1.TabIndex = 188;
            // 
            // frmOutStationDuty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 185);
            this.Controls.Add(this.dgvOutStation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.btnSave);
            this.Name = "frmOutStationDuty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutStationDuty";
            this.Load += new System.EventHandler(this.frmOutStationDuty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvOutStation;
        private RSMS.BaseItems.DateTimePickerColumn ColFromdate;
        private RSMS.BaseItems.DateTimePickerColumn ColTodate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReason;
    }
}