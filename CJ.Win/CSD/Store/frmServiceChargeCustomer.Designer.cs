namespace CJ.Win.CSD.Store
{
    partial class frmServiceChargeCustomer
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
            this.grbOwnTechnician = new System.Windows.Forms.GroupBox();
            this.txtOwnTechInstallation = new System.Windows.Forms.TextBox();
            this.txtOwnTechHomeCall = new System.Windows.Forms.TextBox();
            this.txtOwnTechWalkIn = new System.Windows.Forms.TextBox();
            this.lblOwnInstallation = new System.Windows.Forms.Label();
            this.lblOwnHomeCall = new System.Windows.Forms.Label();
            this.lblOwnWalkIn = new System.Windows.Forms.Label();
            this.grbThirdPartyTechnician = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThirdPartyInstallation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThirdPartyHomeCall = new System.Windows.Forms.TextBox();
            this.txtThirdPartyWalkIn = new System.Windows.Forms.TextBox();
            this.dgvServiceChargeCustomer = new System.Windows.Forms.DataGridView();
            this.ServiceChargeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServiceChargeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbOwnTechnician.SuspendLayout();
            this.grbThirdPartyTechnician.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceChargeCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // grbOwnTechnician
            // 
            this.grbOwnTechnician.Controls.Add(this.txtOwnTechInstallation);
            this.grbOwnTechnician.Controls.Add(this.txtOwnTechHomeCall);
            this.grbOwnTechnician.Controls.Add(this.txtOwnTechWalkIn);
            this.grbOwnTechnician.Controls.Add(this.lblOwnInstallation);
            this.grbOwnTechnician.Controls.Add(this.lblOwnHomeCall);
            this.grbOwnTechnician.Controls.Add(this.lblOwnWalkIn);
            this.grbOwnTechnician.Location = new System.Drawing.Point(12, 12);
            this.grbOwnTechnician.Name = "grbOwnTechnician";
            this.grbOwnTechnician.Size = new System.Drawing.Size(190, 103);
            this.grbOwnTechnician.TabIndex = 0;
            this.grbOwnTechnician.TabStop = false;
            this.grbOwnTechnician.Text = "Own Technician";
            // 
            // txtOwnTechInstallation
            // 
            this.txtOwnTechInstallation.Location = new System.Drawing.Point(58, 66);
            this.txtOwnTechInstallation.Name = "txtOwnTechInstallation";
            this.txtOwnTechInstallation.Size = new System.Drawing.Size(122, 20);
            this.txtOwnTechInstallation.TabIndex = 5;
            // 
            // txtOwnTechHomeCall
            // 
            this.txtOwnTechHomeCall.Location = new System.Drawing.Point(58, 42);
            this.txtOwnTechHomeCall.Name = "txtOwnTechHomeCall";
            this.txtOwnTechHomeCall.Size = new System.Drawing.Size(122, 20);
            this.txtOwnTechHomeCall.TabIndex = 3;
            // 
            // txtOwnTechWalkIn
            // 
            this.txtOwnTechWalkIn.Location = new System.Drawing.Point(58, 19);
            this.txtOwnTechWalkIn.Name = "txtOwnTechWalkIn";
            this.txtOwnTechWalkIn.Size = new System.Drawing.Size(122, 20);
            this.txtOwnTechWalkIn.TabIndex = 1;
            // 
            // lblOwnInstallation
            // 
            this.lblOwnInstallation.AutoSize = true;
            this.lblOwnInstallation.Location = new System.Drawing.Point(2, 69);
            this.lblOwnInstallation.Name = "lblOwnInstallation";
            this.lblOwnInstallation.Size = new System.Drawing.Size(57, 13);
            this.lblOwnInstallation.TabIndex = 4;
            this.lblOwnInstallation.Text = "Installation";
            // 
            // lblOwnHomeCall
            // 
            this.lblOwnHomeCall.AutoSize = true;
            this.lblOwnHomeCall.Location = new System.Drawing.Point(5, 45);
            this.lblOwnHomeCall.Name = "lblOwnHomeCall";
            this.lblOwnHomeCall.Size = new System.Drawing.Size(55, 13);
            this.lblOwnHomeCall.TabIndex = 2;
            this.lblOwnHomeCall.Text = "Home Call";
            // 
            // lblOwnWalkIn
            // 
            this.lblOwnWalkIn.AutoSize = true;
            this.lblOwnWalkIn.Location = new System.Drawing.Point(12, 25);
            this.lblOwnWalkIn.Name = "lblOwnWalkIn";
            this.lblOwnWalkIn.Size = new System.Drawing.Size(44, 13);
            this.lblOwnWalkIn.TabIndex = 0;
            this.lblOwnWalkIn.Text = "Walk In";
            // 
            // grbThirdPartyTechnician
            // 
            this.grbThirdPartyTechnician.Controls.Add(this.label1);
            this.grbThirdPartyTechnician.Controls.Add(this.label2);
            this.grbThirdPartyTechnician.Controls.Add(this.txtThirdPartyInstallation);
            this.grbThirdPartyTechnician.Controls.Add(this.label3);
            this.grbThirdPartyTechnician.Controls.Add(this.txtThirdPartyHomeCall);
            this.grbThirdPartyTechnician.Controls.Add(this.txtThirdPartyWalkIn);
            this.grbThirdPartyTechnician.Location = new System.Drawing.Point(223, 12);
            this.grbThirdPartyTechnician.Name = "grbThirdPartyTechnician";
            this.grbThirdPartyTechnician.Size = new System.Drawing.Size(198, 103);
            this.grbThirdPartyTechnician.TabIndex = 1;
            this.grbThirdPartyTechnician.TabStop = false;
            this.grbThirdPartyTechnician.Text = "Third Party Technician";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Installation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Home Call";
            // 
            // txtThirdPartyInstallation
            // 
            this.txtThirdPartyInstallation.Location = new System.Drawing.Point(61, 66);
            this.txtThirdPartyInstallation.Name = "txtThirdPartyInstallation";
            this.txtThirdPartyInstallation.Size = new System.Drawing.Size(122, 20);
            this.txtThirdPartyInstallation.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Walk In";
            // 
            // txtThirdPartyHomeCall
            // 
            this.txtThirdPartyHomeCall.Location = new System.Drawing.Point(61, 41);
            this.txtThirdPartyHomeCall.Name = "txtThirdPartyHomeCall";
            this.txtThirdPartyHomeCall.Size = new System.Drawing.Size(122, 20);
            this.txtThirdPartyHomeCall.TabIndex = 3;
            // 
            // txtThirdPartyWalkIn
            // 
            this.txtThirdPartyWalkIn.Location = new System.Drawing.Point(61, 18);
            this.txtThirdPartyWalkIn.Name = "txtThirdPartyWalkIn";
            this.txtThirdPartyWalkIn.Size = new System.Drawing.Size(122, 20);
            this.txtThirdPartyWalkIn.TabIndex = 1;
            // 
            // dgvServiceChargeCustomer
            // 
            this.dgvServiceChargeCustomer.AllowUserToAddRows = false;
            this.dgvServiceChargeCustomer.AllowUserToDeleteRows = false;
            this.dgvServiceChargeCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceChargeCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceChargeTypeID,
            this.colServiceChargeType,
            this.colAmount});
            this.dgvServiceChargeCustomer.Location = new System.Drawing.Point(13, 138);
            this.dgvServiceChargeCustomer.Name = "dgvServiceChargeCustomer";
            this.dgvServiceChargeCustomer.Size = new System.Drawing.Size(408, 150);
            this.dgvServiceChargeCustomer.TabIndex = 2;
            // 
            // ServiceChargeTypeID
            // 
            this.ServiceChargeTypeID.HeaderText = "Service Charge Type ID";
            this.ServiceChargeTypeID.Name = "ServiceChargeTypeID";
            this.ServiceChargeTypeID.ReadOnly = true;
            this.ServiceChargeTypeID.Visible = false;
            // 
            // colServiceChargeType
            // 
            this.colServiceChargeType.HeaderText = "Service Charge Type";
            this.colServiceChargeType.Name = "colServiceChargeType";
            this.colServiceChargeType.ReadOnly = true;
            this.colServiceChargeType.Width = 200;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(328, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 26);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Service Charge Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Service Charge Type ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmServiceChargeCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvServiceChargeCustomer);
            this.Controls.Add(this.grbThirdPartyTechnician);
            this.Controls.Add(this.grbOwnTechnician);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceChargeCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Service Charge";
            this.Load += new System.EventHandler(this.frmServiceChargeCustomer_Load);
            this.grbOwnTechnician.ResumeLayout(false);
            this.grbOwnTechnician.PerformLayout();
            this.grbThirdPartyTechnician.ResumeLayout(false);
            this.grbThirdPartyTechnician.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceChargeCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOwnTechnician;
        private System.Windows.Forms.GroupBox grbThirdPartyTechnician;
        private System.Windows.Forms.Label lblOwnInstallation;
        private System.Windows.Forms.Label lblOwnHomeCall;
        private System.Windows.Forms.Label lblOwnWalkIn;
        private System.Windows.Forms.TextBox txtOwnTechInstallation;
        private System.Windows.Forms.TextBox txtOwnTechHomeCall;
        private System.Windows.Forms.TextBox txtOwnTechWalkIn;
        private System.Windows.Forms.TextBox txtThirdPartyInstallation;
        private System.Windows.Forms.TextBox txtThirdPartyHomeCall;
        private System.Windows.Forms.TextBox txtThirdPartyWalkIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvServiceChargeCustomer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceChargeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceChargeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}