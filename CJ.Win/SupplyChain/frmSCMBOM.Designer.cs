namespace CJ.Win.SupplyChain
{
    partial class frmSCMBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMBOM));
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.dgvBOMQty = new System.Windows.Forms.DataGridView();
            this.txtBOMDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtBOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(12, 86);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(35, 13);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "label2";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.ForeColor = System.Drawing.Color.Black;
            this.lblProductCode.Location = new System.Drawing.Point(12, 59);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(35, 13);
            this.lblProductCode.TabIndex = 2;
            this.lblProductCode.Text = "label1";
            // 
            // dgvBOMQty
            // 
            this.dgvBOMQty.AllowUserToAddRows = false;
            this.dgvBOMQty.AllowUserToDeleteRows = false;
            this.dgvBOMQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtBOMDetails,
            this.txtBOMQty,
            this.TxtBOMID,
            this.txtProductID});
            this.dgvBOMQty.Location = new System.Drawing.Point(12, 124);
            this.dgvBOMQty.Name = "dgvBOMQty";
            this.dgvBOMQty.Size = new System.Drawing.Size(361, 154);
            this.dgvBOMQty.TabIndex = 4;
            // 
            // txtBOMDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBOMDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtBOMDetails.HeaderText = "BOM Details";
            this.txtBOMDetails.Name = "txtBOMDetails";
            this.txtBOMDetails.Width = 240;
            // 
            // txtBOMQty
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBOMQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtBOMQty.HeaderText = "BOM Qty";
            this.txtBOMQty.Name = "txtBOMQty";
            this.txtBOMQty.Width = 80;
            // 
            // TxtBOMID
            // 
            this.TxtBOMID.HeaderText = "BOMID";
            this.TxtBOMID.Name = "TxtBOMID";
            this.TxtBOMID.Visible = false;
            // 
            // txtProductID
            // 
            this.txtProductID.HeaderText = "ProductID";
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(217, 284);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(298, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.ForeColor = System.Drawing.Color.Black;
            this.lblOrderID.Location = new System.Drawing.Point(12, 36);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(35, 13);
            this.lblOrderID.TabIndex = 7;
            this.lblOrderID.Text = "label1";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(12, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(35, 13);
            this.lblText.TabIndex = 8;
            this.lblText.Text = "label1";
            // 
            // frmSCMBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 323);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvBOMQty);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmSCMBOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOM List";
            this.Load += new System.EventHandler(this.frmSCMBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.DataGridView dgvBOMQty;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtBOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductID;
    }
}