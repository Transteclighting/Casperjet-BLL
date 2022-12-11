namespace CJ.Win.DMS
{
    partial class frmDMSDSRRoute
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
            this.rdoNewDSR = new System.Windows.Forms.RadioButton();
            this.rdoReplaceDSR = new System.Windows.Forms.RadioButton();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblDSR = new System.Windows.Forms.Label();
            this.cmbNewDSR = new System.Windows.Forms.ComboBox();
            this.lblReplaceDSR = new System.Windows.Forms.Label();
            this.cmbReplaceDSR = new System.Windows.Forms.ComboBox();
            this.dgvDMSRoute = new System.Windows.Forms.DataGridView();
            this.colRouteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDMSRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoNewDSR
            // 
            this.rdoNewDSR.AutoSize = true;
            this.rdoNewDSR.Location = new System.Drawing.Point(12, 12);
            this.rdoNewDSR.Name = "rdoNewDSR";
            this.rdoNewDSR.Size = new System.Drawing.Size(73, 17);
            this.rdoNewDSR.TabIndex = 0;
            this.rdoNewDSR.TabStop = true;
            this.rdoNewDSR.Text = "New DSR";
            this.rdoNewDSR.UseVisualStyleBackColor = true;
            this.rdoNewDSR.CheckedChanged += new System.EventHandler(this.rdoNewDSR_CheckedChanged);
            // 
            // rdoReplaceDSR
            // 
            this.rdoReplaceDSR.AutoSize = true;
            this.rdoReplaceDSR.Location = new System.Drawing.Point(106, 12);
            this.rdoReplaceDSR.Name = "rdoReplaceDSR";
            this.rdoReplaceDSR.Size = new System.Drawing.Size(91, 17);
            this.rdoReplaceDSR.TabIndex = 1;
            this.rdoReplaceDSR.TabStop = true;
            this.rdoReplaceDSR.Text = "Replace DSR";
            this.rdoReplaceDSR.UseVisualStyleBackColor = true;
            this.rdoReplaceDSR.CheckedChanged += new System.EventHandler(this.rdoReplaceDSR_CheckedChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(28, 50);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            // 
            // lblDSR
            // 
            this.lblDSR.AutoSize = true;
            this.lblDSR.Location = new System.Drawing.Point(16, 76);
            this.lblDSR.Name = "lblDSR";
            this.lblDSR.Size = new System.Drawing.Size(63, 13);
            this.lblDSR.TabIndex = 4;
            this.lblDSR.Text = "Select DSR";
            // 
            // cmbNewDSR
            // 
            this.cmbNewDSR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewDSR.FormattingEnabled = true;
            this.cmbNewDSR.Location = new System.Drawing.Point(85, 73);
            this.cmbNewDSR.Name = "cmbNewDSR";
            this.cmbNewDSR.Size = new System.Drawing.Size(231, 21);
            this.cmbNewDSR.TabIndex = 5;
            this.cmbNewDSR.SelectedIndexChanged += new System.EventHandler(this.cmbNewDSR_SelectedIndexChanged);
            // 
            // lblReplaceDSR
            // 
            this.lblReplaceDSR.AutoSize = true;
            this.lblReplaceDSR.Location = new System.Drawing.Point(6, 108);
            this.lblReplaceDSR.Name = "lblReplaceDSR";
            this.lblReplaceDSR.Size = new System.Drawing.Size(73, 13);
            this.lblReplaceDSR.TabIndex = 6;
            this.lblReplaceDSR.Text = "Replace DSR";
            // 
            // cmbReplaceDSR
            // 
            this.cmbReplaceDSR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReplaceDSR.FormattingEnabled = true;
            this.cmbReplaceDSR.Location = new System.Drawing.Point(85, 104);
            this.cmbReplaceDSR.Name = "cmbReplaceDSR";
            this.cmbReplaceDSR.Size = new System.Drawing.Size(231, 21);
            this.cmbReplaceDSR.TabIndex = 7;
            this.cmbReplaceDSR.SelectedIndexChanged += new System.EventHandler(this.cmbReplaceDSR_SelectedIndexChanged);
            // 
            // dgvDMSRoute
            // 
            this.dgvDMSRoute.AllowUserToAddRows = false;
            this.dgvDMSRoute.AllowUserToDeleteRows = false;
            this.dgvDMSRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDMSRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDMSRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRouteCode,
            this.colRouteName,
            this.colMobileNo,
            this.colDesignation,
            this.chkIsActive,
            this.colRouteID});
            this.dgvDMSRoute.Location = new System.Drawing.Point(9, 146);
            this.dgvDMSRoute.Name = "dgvDMSRoute";
            this.dgvDMSRoute.Size = new System.Drawing.Size(544, 166);
            this.dgvDMSRoute.TabIndex = 8;
            this.dgvDMSRoute.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDMSRoute_CellContentClick);
            // 
            // colRouteCode
            // 
            this.colRouteCode.HeaderText = "Route Code";
            this.colRouteCode.Name = "colRouteCode";
            // 
            // colRouteName
            // 
            this.colRouteName.HeaderText = "Route Name";
            this.colRouteName.Name = "colRouteName";
            // 
            // colMobileNo
            // 
            this.colMobileNo.HeaderText = "Mobile No";
            this.colMobileNo.Name = "colMobileNo";
            // 
            // colDesignation
            // 
            this.colDesignation.HeaderText = "Designation";
            this.colDesignation.Name = "colDesignation";
            // 
            // chkIsActive
            // 
            this.chkIsActive.HeaderText = "Is Active";
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colRouteID
            // 
            this.colRouteID.HeaderText = "RouteID";
            this.colRouteID.Name = "colRouteID";
            this.colRouteID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(380, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(475, 339);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Route Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Route Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Mobile No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Designation";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "RouteID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(85, 43);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(426, 25);
            this.ctlCustomer1.TabIndex = 3;
            this.ctlCustomer1.Load += new System.EventHandler(this.ctlCustomer1_Load);
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            // 
            // frmDMSDSRRoute
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 382);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDMSRoute);
            this.Controls.Add(this.cmbReplaceDSR);
            this.Controls.Add(this.lblReplaceDSR);
            this.Controls.Add(this.cmbNewDSR);
            this.Controls.Add(this.lblDSR);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.rdoReplaceDSR);
            this.Controls.Add(this.rdoNewDSR);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMSDSRRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMS DSR Route";
            this.Load += new System.EventHandler(this.frmDMSDSRRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDMSRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoNewDSR;
        private System.Windows.Forms.RadioButton rdoReplaceDSR;
        private System.Windows.Forms.Label lblCustomer;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label lblDSR;
        private System.Windows.Forms.ComboBox cmbNewDSR;
        private System.Windows.Forms.Label lblReplaceDSR;
        private System.Windows.Forms.ComboBox cmbReplaceDSR;
        private System.Windows.Forms.DataGridView dgvDMSRoute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteID;
    }
}