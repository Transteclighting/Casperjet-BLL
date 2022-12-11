namespace CJ.Win.BEIL
{
    partial class frmBEILMaterialRequisition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.dgvRequisitionItem = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAuthorisedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApprovedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIssuedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItem)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(92, 16);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(457, 25);
            this.ctlProduct1.TabIndex = 0;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // dgvRequisitionItem
            // 
            this.dgvRequisitionItem.AllowUserToAddRows = false;
            this.dgvRequisitionItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisitionItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtDescription,
            this.txtCurrentStock,
            this.txtRequisitionQty,
            this.ColAuthorisedQty,
            this.txtApprovedQty,
            this.txtIssuedQty,
            this.txtReceiveQty,
            this.txtProductID,
            this.txtBOMID});
            this.dgvRequisitionItem.Location = new System.Drawing.Point(15, 47);
            this.dgvRequisitionItem.Name = "dgvRequisitionItem";
            this.dgvRequisitionItem.Size = new System.Drawing.Size(721, 238);
            this.dgvRequisitionItem.TabIndex = 130;
            // 
            // txtDescription
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtDescription.Frozen = true;
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Width = 200;
            // 
            // txtCurrentStock
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCurrentStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtCurrentStock.FillWeight = 80F;
            this.txtCurrentStock.Frozen = true;
            this.txtCurrentStock.HeaderText = "Current Stock";
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Width = 80;
            // 
            // txtRequisitionQty
            // 
            this.txtRequisitionQty.FillWeight = 80F;
            this.txtRequisitionQty.HeaderText = "Requisition Qty";
            this.txtRequisitionQty.Name = "txtRequisitionQty";
            this.txtRequisitionQty.Width = 80;
            // 
            // ColAuthorisedQty
            // 
            this.ColAuthorisedQty.FillWeight = 80F;
            this.ColAuthorisedQty.HeaderText = "Authorised Qty";
            this.ColAuthorisedQty.Name = "ColAuthorisedQty";
            this.ColAuthorisedQty.Width = 80;
            // 
            // txtApprovedQty
            // 
            this.txtApprovedQty.FillWeight = 80F;
            this.txtApprovedQty.HeaderText = "Approved Qty";
            this.txtApprovedQty.Name = "txtApprovedQty";
            this.txtApprovedQty.Width = 80;
            // 
            // txtIssuedQty
            // 
            this.txtIssuedQty.FillWeight = 80F;
            this.txtIssuedQty.HeaderText = "Issue Qty";
            this.txtIssuedQty.Name = "txtIssuedQty";
            this.txtIssuedQty.Width = 80;
            // 
            // txtReceiveQty
            // 
            this.txtReceiveQty.FillWeight = 80F;
            this.txtReceiveQty.HeaderText = "Receive Qty";
            this.txtReceiveQty.Name = "txtReceiveQty";
            this.txtReceiveQty.Width = 80;
            // 
            // txtProductID
            // 
            this.txtProductID.HeaderText = "ProductID";
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Visible = false;
            // 
            // txtBOMID
            // 
            this.txtBOMID.FillWeight = 80F;
            this.txtBOMID.HeaderText = "BOMID";
            this.txtBOMID.Name = "txtBOMID";
            this.txtBOMID.ReadOnly = true;
            this.txtBOMID.Visible = false;
            this.txtBOMID.Width = 80;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(72, 301);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(664, 20);
            this.txtRemarks.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Product Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(580, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 134;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(661, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 135;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBEILMaterialRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 357);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvRequisitionItem);
            this.Controls.Add(this.ctlProduct1);
            this.Name = "frmBEILMaterialRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBEILMaterialRequisition";
            this.Load += new System.EventHandler(this.frmBEILMaterialRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.DataGridView dgvRequisitionItem;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAuthorisedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApprovedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIssuedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMID;
    }
}