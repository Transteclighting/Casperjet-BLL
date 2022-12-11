namespace CJ.Win.Dealer
{
    partial class frmSetBarcodes
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
            this.dgvBarcodes = new System.Windows.Forms.DataGridView();
            this.txtBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBarcodes
            // 
            this.dgvBarcodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtBarcode});
            this.dgvBarcodes.Location = new System.Drawing.Point(12, 21);
            this.dgvBarcodes.Name = "dgvBarcodes";
            this.dgvBarcodes.Size = new System.Drawing.Size(250, 246);
            this.dgvBarcodes.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.HeaderText = "Barcode";
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Width = 200;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(189, 273);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSetBarcodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 308);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvBarcodes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetBarcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetBarcodes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBarcodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBarcode;
        private System.Windows.Forms.Button btnOk;
    }
}