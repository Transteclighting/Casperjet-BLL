namespace CJ.Win.Distribution
{
    partial class frmProductTransferProductSerial
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
            this.btnMove = new System.Windows.Forms.Button();
            this.txtBarcodeList = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductSerial = new System.Windows.Forms.DataGridView();
            this.txtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.Location = new System.Drawing.Point(643, 252);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(41, 39);
            this.btnMove.TabIndex = 33;
            this.btnMove.Text = "<<";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // txtBarcodeList
            // 
            this.txtBarcodeList.Location = new System.Drawing.Point(693, 107);
            this.txtBarcodeList.Multiline = true;
            this.txtBarcodeList.Name = "txtBarcodeList";
            this.txtBarcodeList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBarcodeList.Size = new System.Drawing.Size(152, 364);
            this.txtBarcodeList.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(688, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 382);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Barcode";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(109, 55);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(14, 13);
            this.lblCustomerName.TabIndex = 31;
            this.lblCustomerName.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "To Warehouse :";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.Location = new System.Drawing.Point(109, 35);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(14, 13);
            this.lblCustomerCode.TabIndex = 29;
            this.lblCustomerCode.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "From Warehouse :";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(110, 15);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(14, 13);
            this.lblInvoiceNo.TabIndex = 27;
            this.lblInvoiceNo.Text = "?";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(567, 48);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.HeaderText = "InvoiceID";
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Visible = false;
            // 
            // dgvProductSerial
            // 
            this.dgvProductSerial.AllowUserToAddRows = false;
            this.dgvProductSerial.AllowUserToDeleteRows = false;
            this.dgvProductSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtInvoiceID,
            this.txtProductID,
            this.txtProductCode,
            this.txtProductName,
            this.txtSerialNo,
            this.txtBarcode});
            this.dgvProductSerial.Location = new System.Drawing.Point(7, 81);
            this.dgvProductSerial.Name = "dgvProductSerial";
            this.dgvProductSerial.Size = new System.Drawing.Size(630, 392);
            this.dgvProductSerial.TabIndex = 25;
            // 
            // txtProductID
            // 
            this.txtProductID.HeaderText = "ProductID";
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Visible = false;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // txtProductName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Width = 250;
            // 
            // txtSerialNo
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSerialNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtSerialNo.HeaderText = "Serial No";
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Width = 80;
            // 
            // txtBarcode
            // 
            this.txtBarcode.HeaderText = "Barcode";
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Width = 145;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tran No :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(486, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmProductTransferProductSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 481);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.txtBarcodeList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProductSerial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Name = "frmProductTransferProductSerial";
            this.Text = "frmProductTransferProductSerial";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSerial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox txtBarcodeList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoiceID;
        private System.Windows.Forms.DataGridView dgvProductSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBarcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
    }
}