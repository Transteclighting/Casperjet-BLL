namespace CJ.POS.RT
{
    partial class frmProductReceive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductReceive));
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalReqQty = new System.Windows.Forms.TextBox();
            this.txtTotalAuthQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbRequisitionNo = new System.Windows.Forms.Label();
            this.lblRequisitionNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDescription,
            this.RequisitionQty,
            this.CValue,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(17, 55);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(693, 271);
            this.dgvLineItem.TabIndex = 2;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 120;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 300;
            // 
            // RequisitionQty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RequisitionQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.RequisitionQty.HeaderText = "Requisition Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.ReadOnly = true;
            this.RequisitionQty.Width = 120;
            // 
            // CValue
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.CValue.HeaderText = "Authorized Qty";
            this.CValue.Name = "CValue";
            this.CValue.ReadOnly = true;
            this.CValue.Width = 120;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(77, 359);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(633, 21);
            this.txtRemarks.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remarks";
            // 
            // txtTotalReqQty
            // 
            this.txtTotalReqQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReqQty.Location = new System.Drawing.Point(504, 333);
            this.txtTotalReqQty.Name = "txtTotalReqQty";
            this.txtTotalReqQty.ReadOnly = true;
            this.txtTotalReqQty.Size = new System.Drawing.Size(93, 21);
            this.txtTotalReqQty.TabIndex = 4;
            this.txtTotalReqQty.Text = "0";
            this.txtTotalReqQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAuthQty
            // 
            this.txtTotalAuthQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAuthQty.Location = new System.Drawing.Point(603, 332);
            this.txtTotalAuthQty.Name = "txtTotalAuthQty";
            this.txtTotalAuthQty.ReadOnly = true;
            this.txtTotalAuthQty.Size = new System.Drawing.Size(107, 21);
            this.txtTotalAuthQty.TabIndex = 5;
            this.txtTotalAuthQty.Text = "0";
            this.txtTotalAuthQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total: ";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(511, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(616, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbRequisitionNo
            // 
            this.lbRequisitionNo.AutoSize = true;
            this.lbRequisitionNo.Location = new System.Drawing.Point(14, 22);
            this.lbRequisitionNo.Name = "lbRequisitionNo";
            this.lbRequisitionNo.Size = new System.Drawing.Size(82, 15);
            this.lbRequisitionNo.TabIndex = 0;
            this.lbRequisitionNo.Text = "Requisition # ";
            this.lbRequisitionNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRequisitionNo
            // 
            this.lblRequisitionNo.AutoSize = true;
            this.lblRequisitionNo.Location = new System.Drawing.Point(102, 22);
            this.lblRequisitionNo.Name = "lblRequisitionNo";
            this.lblRequisitionNo.Size = new System.Drawing.Size(14, 15);
            this.lblRequisitionNo.TabIndex = 1;
            this.lblRequisitionNo.Text = "?";
            // 
            // frmProductReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 423);
            this.Controls.Add(this.lblRequisitionNo);
            this.Controls.Add(this.lbRequisitionNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalAuthQty);
            this.Controls.Add(this.txtTotalReqQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvLineItem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Receive against Requisiton";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalReqQty;
        private System.Windows.Forms.TextBox txtTotalAuthQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbRequisitionNo;
        private System.Windows.Forms.Label lblRequisitionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}