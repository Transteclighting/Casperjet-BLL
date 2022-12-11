namespace CJ.Win
{
    partial class frmUpdateTPCharge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInterServiceJobs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillMonth = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGasCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTPBillDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterServiceJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInterServiceJobs
            // 
            this.dgvInterServiceJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterServiceJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInterServiceName,
            this.colJobNo,
            this.colMaterialCharge,
            this.colGasCharge,
            this.colOtherCharge,
            this.colTPBillDetailID});
            this.dgvInterServiceJobs.Location = new System.Drawing.Point(12, 64);
            this.dgvInterServiceJobs.Name = "dgvInterServiceJobs";
            this.dgvInterServiceJobs.Size = new System.Drawing.Size(754, 379);
            this.dgvInterServiceJobs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Month";
            // 
            // txtBillMonth
            // 
            this.txtBillMonth.Location = new System.Drawing.Point(68, 23);
            this.txtBillMonth.Name = "txtBillMonth";
            this.txtBillMonth.ReadOnly = true;
            this.txtBillMonth.Size = new System.Drawing.Size(139, 20);
            this.txtBillMonth.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(599, 449);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 26);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(684, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Inter Service Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Job No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Material Charge";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Gas Charge";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Other Charge";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "TP Bill Detail ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // colInterServiceName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.colInterServiceName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colInterServiceName.HeaderText = "Inter Service Name";
            this.colInterServiceName.Name = "colInterServiceName";
            this.colInterServiceName.ReadOnly = true;
            this.colInterServiceName.Width = 300;
            // 
            // colJobNo
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.colJobNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colJobNo.HeaderText = "Job No";
            this.colJobNo.Name = "colJobNo";
            this.colJobNo.ReadOnly = true;
            // 
            // colMaterialCharge
            // 
            this.colMaterialCharge.HeaderText = "Material Charge";
            this.colMaterialCharge.Name = "colMaterialCharge";
            // 
            // colGasCharge
            // 
            this.colGasCharge.HeaderText = "Gas Charge";
            this.colGasCharge.Name = "colGasCharge";
            // 
            // colOtherCharge
            // 
            this.colOtherCharge.HeaderText = "Other Charge";
            this.colOtherCharge.Name = "colOtherCharge";
            // 
            // colTPBillDetailID
            // 
            this.colTPBillDetailID.HeaderText = "TP Bill Detail ID";
            this.colTPBillDetailID.Name = "colTPBillDetailID";
            this.colTPBillDetailID.ReadOnly = true;
            this.colTPBillDetailID.Visible = false;
            // 
            // frmUpdateTPCharge
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 483);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtBillMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInterServiceJobs);
            this.MaximizeBox = false;
            this.Name = "frmUpdateTPCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update TP Charge";
            this.Load += new System.EventHandler(this.frmUpdateTPCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterServiceJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInterServiceJobs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillMonth;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGasCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTPBillDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}