namespace CJ.Win.CSD.Store
{
    partial class frmSPIssuetoInternalParty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPIssuetoInternalParty));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgvIssuePart = new System.Windows.Forms.DataGridView();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindParts = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPartyName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Store:";
            // 
            // cmbStore
            // 
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(81, 39);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(171, 21);
            this.cmbStore.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(68, 292);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(681, 20);
            this.txtRemarks.TabIndex = 8;
            // 
            // dgvIssuePart
            // 
            this.dgvIssuePart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssuePart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssuePart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuePart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.btnFindParts,
            this.txtSparePartName,
            this.txtCurrentStock,
            this.txtIssueQty,
            this.txtUnitSP,
            this.txtTotalPrice,
            this.SparePartID,
            this.txtCostPrice});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIssuePart.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvIssuePart.Location = new System.Drawing.Point(16, 66);
            this.dgvIssuePart.Name = "dgvIssuePart";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssuePart.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvIssuePart.Size = new System.Drawing.Size(733, 220);
            this.dgvIssuePart.TabIndex = 6;
            this.dgvIssuePart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellValueChanged);
            this.dgvIssuePart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellContentClick);
            // 
            // txtSparePartCode
            // 
            this.txtSparePartCode.Frozen = true;
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            // 
            // btnFindParts
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.btnFindParts.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnFindParts.Frozen = true;
            this.btnFindParts.HeaderText = "?";
            this.btnFindParts.Name = "btnFindParts";
            this.btnFindParts.Text = "...";
            this.btnFindParts.Width = 35;
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtSparePartName.Frozen = true;
            this.txtSparePartName.HeaderText = "Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 220;
            // 
            // txtCurrentStock
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCurrentStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtCurrentStock.Frozen = true;
            this.txtCurrentStock.HeaderText = "Current Stock";
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Width = 70;
            // 
            // txtIssueQty
            // 
            this.txtIssueQty.Frozen = true;
            this.txtIssueQty.HeaderText = "Issue Qty";
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.Width = 80;
            // 
            // txtUnitSP
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitSP.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtUnitSP.Frozen = true;
            this.txtUnitSP.HeaderText = "Unit Sale Price";
            this.txtUnitSP.Name = "txtUnitSP";
            this.txtUnitSP.ReadOnly = true;
            this.txtUnitSP.Width = 90;
            // 
            // txtTotalPrice
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtTotalPrice.Frozen = true;
            this.txtTotalPrice.HeaderText = "Total Sale Price";
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            // 
            // SparePartID
            // 
            this.SparePartID.Frozen = true;
            this.SparePartID.HeaderText = "SparePartID";
            this.SparePartID.Name = "SparePartID";
            this.SparePartID.Visible = false;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Frozen = true;
            this.txtCostPrice.HeaderText = "CostPrice";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Party Name:";
            // 
            // cmbPartyName
            // 
            this.cmbPartyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartyName.FormattingEnabled = true;
            this.cmbPartyName.Location = new System.Drawing.Point(81, 12);
            this.cmbPartyName.Name = "cmbPartyName";
            this.cmbPartyName.Size = new System.Drawing.Size(337, 21);
            this.cmbPartyName.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(674, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(593, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSPIssuetoInternalParty
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 351);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPartyName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvIssuePart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSPIssuetoInternalParty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP Issue to Internal Party";
            this.Load += new System.EventHandler(this.frmSPIssuetoInternalParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgvIssuePart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPartyName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIssueQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;

    }
}