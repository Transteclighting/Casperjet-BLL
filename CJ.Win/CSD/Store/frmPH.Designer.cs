namespace CJ.Win
{
    partial class frmPH
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
            this.cboActiveInactive = new System.Windows.Forms.ComboBox();
            this.tvwPH = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvProductPrice = new System.Windows.Forms.DataGridView();
            this.txtAGName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProdpriceTML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cboActiveInactive
            // 
            this.cboActiveInactive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActiveInactive.FormattingEnabled = true;
            this.cboActiveInactive.Location = new System.Drawing.Point(12, 12);
            this.cboActiveInactive.Name = "cboActiveInactive";
            this.cboActiveInactive.Size = new System.Drawing.Size(150, 21);
            this.cboActiveInactive.TabIndex = 22;
            // 
            // tvwPH
            // 
            this.tvwPH.AllowDrop = true;
            this.tvwPH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwPH.Indent = 19;
            this.tvwPH.LineColor = System.Drawing.Color.Empty;
            this.tvwPH.Location = new System.Drawing.Point(12, 39);
            this.tvwPH.Name = "tvwPH";
            this.tvwPH.ShowNodeToolTips = true;
            this.tvwPH.Size = new System.Drawing.Size(649, 353);
            this.tvwPH.TabIndex = 23;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(582, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 27);
            this.btnClose.TabIndex = 154;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvProductPrice
            // 
            this.dgvProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtAGName,
            this.txtProductName,
            this.txtPetName});
            this.dgvProductPrice.Location = new System.Drawing.Point(30, 77);
            this.dgvProductPrice.Name = "dgvProductPrice";
            this.dgvProductPrice.Size = new System.Drawing.Size(668, 297);
            this.dgvProductPrice.TabIndex = 12;
            // 
            // txtAGName
            // 
            this.txtAGName.HeaderText = "AG Name";
            this.txtAGName.Name = "txtAGName";
            this.txtAGName.ReadOnly = true;
            this.txtAGName.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Visible = false;
            // 
            // txtPetName
            // 
            this.txtPetName.HeaderText = "Pet Name";
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.ReadOnly = true;
            this.txtPetName.Visible = false;
            // 
            // btnProdpriceTML
            // 
            this.btnProdpriceTML.Location = new System.Drawing.Point(558, 12);
            this.btnProdpriceTML.Name = "btnProdpriceTML";
            this.btnProdpriceTML.Size = new System.Drawing.Size(97, 42);
            this.btnProdpriceTML.TabIndex = 13;
            this.btnProdpriceTML.Text = "Button";
            this.btnProdpriceTML.UseVisualStyleBackColor = true;
            this.btnProdpriceTML.Click += new System.EventHandler(this.btnProdpriceTML_Click);
            // 
            // frmPH
            // 
            this.ClientSize = new System.Drawing.Size(764, 433);
            this.Controls.Add(this.btnProdpriceTML);
            this.Controls.Add(this.dgvProductPrice);
            this.Name = "frmPH";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboActiveInactive;
        private System.Windows.Forms.TreeView tvwPH;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAGName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPetName;
        private System.Windows.Forms.Button btnProdpriceTML;
    }
}