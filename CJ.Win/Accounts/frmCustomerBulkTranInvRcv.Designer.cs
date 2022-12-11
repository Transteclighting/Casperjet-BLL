namespace CJ.Win.Accounts
{
    partial class frmCustomerBulkTranInvRcv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtInvoiceAmtTotal = new System.Windows.Forms.TextBox();
            this.txtCurrentDueTotal = new System.Windows.Forms.TextBox();
            this.txtReceiveAmtTotal = new System.Windows.Forms.TextBox();
            this.txtPaymentDueTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.InvoiceDate,
            this.InvoiceAmount,
            this.PaymentDue,
            this.ReceivedAmount,
            this.CurrentDue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLineItem.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLineItem.Location = new System.Drawing.Point(12, 59);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLineItem.Size = new System.Drawing.Size(654, 169);
            this.dgvLineItem.TabIndex = 14;
            this.dgvLineItem.TabStop = false;
            // 
            // txtInvoiceAmtTotal
            // 
            this.txtInvoiceAmtTotal.Location = new System.Drawing.Point(264, 233);
            this.txtInvoiceAmtTotal.Name = "txtInvoiceAmtTotal";
            this.txtInvoiceAmtTotal.ReadOnly = true;
            this.txtInvoiceAmtTotal.Size = new System.Drawing.Size(95, 20);
            this.txtInvoiceAmtTotal.TabIndex = 25;
            this.txtInvoiceAmtTotal.Text = "0.00";
            this.txtInvoiceAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentDueTotal
            // 
            this.txtCurrentDueTotal.Location = new System.Drawing.Point(555, 233);
            this.txtCurrentDueTotal.Name = "txtCurrentDueTotal";
            this.txtCurrentDueTotal.ReadOnly = true;
            this.txtCurrentDueTotal.Size = new System.Drawing.Size(95, 20);
            this.txtCurrentDueTotal.TabIndex = 24;
            this.txtCurrentDueTotal.Text = "0.00";
            this.txtCurrentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReceiveAmtTotal
            // 
            this.txtReceiveAmtTotal.Location = new System.Drawing.Point(458, 233);
            this.txtReceiveAmtTotal.Name = "txtReceiveAmtTotal";
            this.txtReceiveAmtTotal.ReadOnly = true;
            this.txtReceiveAmtTotal.Size = new System.Drawing.Size(95, 20);
            this.txtReceiveAmtTotal.TabIndex = 23;
            this.txtReceiveAmtTotal.Text = "0.00";
            this.txtReceiveAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPaymentDueTotal
            // 
            this.txtPaymentDueTotal.Location = new System.Drawing.Point(361, 233);
            this.txtPaymentDueTotal.Name = "txtPaymentDueTotal";
            this.txtPaymentDueTotal.ReadOnly = true;
            this.txtPaymentDueTotal.Size = new System.Drawing.Size(95, 20);
            this.txtPaymentDueTotal.TabIndex = 22;
            this.txtPaymentDueTotal.Text = "0.00";
            this.txtPaymentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Total : >> ";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(591, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Customer: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Receive Amount: ";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(116, 12);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(14, 13);
            this.lblCustomer.TabIndex = 29;
            this.lblCustomer.Text = "?";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(116, 32);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(14, 13);
            this.lblAmount.TabIndex = 30;
            this.lblAmount.Text = "?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 52);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Width = 90;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvoiceAmount.HeaderText = "Invoice Amount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            this.InvoiceAmount.Width = 110;
            // 
            // PaymentDue
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PaymentDue.DefaultCellStyle = dataGridViewCellStyle3;
            this.PaymentDue.HeaderText = "Payment Due";
            this.PaymentDue.Name = "PaymentDue";
            this.PaymentDue.ReadOnly = true;
            // 
            // ReceivedAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReceivedAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ReceivedAmount.HeaderText = "Received Amount";
            this.ReceivedAmount.Name = "ReceivedAmount";
            this.ReceivedAmount.ReadOnly = true;
            this.ReceivedAmount.Width = 120;
            // 
            // CurrentDue
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CurrentDue.DefaultCellStyle = dataGridViewCellStyle5;
            this.CurrentDue.HeaderText = "Current Due";
            this.CurrentDue.Name = "CurrentDue";
            this.CurrentDue.ReadOnly = true;
            this.CurrentDue.Width = 90;
            // 
            // frmCustomerBulkTranInvRcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 290);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtInvoiceAmtTotal);
            this.Controls.Add(this.txtCurrentDueTotal);
            this.Controls.Add(this.txtReceiveAmtTotal);
            this.Controls.Add(this.txtPaymentDueTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLineItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerBulkTranInvRcv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Wise Receive Amount";
            this.Load += new System.EventHandler(this.frmCustomerBulkTranInvRcv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.TextBox txtInvoiceAmtTotal;
        private System.Windows.Forms.TextBox txtCurrentDueTotal;
        private System.Windows.Forms.TextBox txtReceiveAmtTotal;
        private System.Windows.Forms.TextBox txtPaymentDueTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDue;
    }
}