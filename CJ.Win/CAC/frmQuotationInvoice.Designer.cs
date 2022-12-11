namespace CJ.Win.CAC
{
    partial class frmQuotationInvoice
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvCACQuotationInvoice = new System.Windows.Forms.DataGridView();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDate = new CJ.Win.Control.CalenderControl();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblPoAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTon = new System.Windows.Forms.TextBox();
            this.txtInvAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCACOtherInvoice = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new CJ.Win.Control.CalenderControl();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOtherAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACQuotationInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACOtherInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Quotation #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "PO Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Invoice #:";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(81, 43);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(157, 20);
            this.txtInvoiceNo.TabIndex = 22;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(244, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 24);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvCACQuotationInvoice
            // 
            this.dgvCACQuotationInvoice.AllowUserToAddRows = false;
            this.dgvCACQuotationInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCACQuotationInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.txtInvoice,
            this.dtDate,
            this.Ton,
            this.txtAmount});
            this.dgvCACQuotationInvoice.Location = new System.Drawing.Point(4, 102);
            this.dgvCACQuotationInvoice.Name = "dgvCACQuotationInvoice";
            this.dgvCACQuotationInvoice.Size = new System.Drawing.Size(404, 91);
            this.dgvCACQuotationInvoice.TabIndex = 62;
            this.dgvCACQuotationInvoice.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACQuotationInvoice_CellValueChanged);
            this.dgvCACQuotationInvoice.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCACQuotationInvoice_RowsRemoved);
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Visible = false;
            // 
            // txtInvoice
            // 
            this.txtInvoice.HeaderText = "Invoice #";
            this.txtInvoice.Name = "txtInvoice";
            // 
            // dtDate
            // 
            this.dtDate.HeaderText = "Date";
            this.dtDate.Name = "dtDate";
            this.dtDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Ton
            // 
            this.Ton.HeaderText = "Ton";
            this.Ton.Name = "Ton";
            this.Ton.Width = 60;
            // 
            // txtAmount
            // 
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Total Amount";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(327, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 24);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(84, 10);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(13, 13);
            this.lblCode.TabIndex = 66;
            this.lblCode.Text = "?";
            // 
            // lblPoAmount
            // 
            this.lblPoAmount.AutoSize = true;
            this.lblPoAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoAmount.Location = new System.Drawing.Point(84, 27);
            this.lblPoAmount.Name = "lblPoAmount";
            this.lblPoAmount.Size = new System.Drawing.Size(13, 13);
            this.lblPoAmount.TabIndex = 67;
            this.lblPoAmount.Text = "?";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(282, 347);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(126, 20);
            this.txtTotalAmount.TabIndex = 70;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Ton";
            // 
            // txtTon
            // 
            this.txtTon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTon.Location = new System.Drawing.Point(81, 65);
            this.txtTon.Name = "txtTon";
            this.txtTon.Size = new System.Drawing.Size(157, 20);
            this.txtTon.TabIndex = 72;
            // 
            // txtInvAmount
            // 
            this.txtInvAmount.Location = new System.Drawing.Point(285, 199);
            this.txtInvAmount.Name = "txtInvAmount";
            this.txtInvAmount.ReadOnly = true;
            this.txtInvAmount.Size = new System.Drawing.Size(123, 20);
            this.txtInvAmount.TabIndex = 74;
            this.txtInvAmount.Text = "0.00";
            this.txtInvAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(218, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Inv Amount";
            // 
            // dgvCACOtherInvoice
            // 
            this.dgvCACOtherInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCACOtherInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn2,
            this.Date,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvCACOtherInvoice.Location = new System.Drawing.Point(4, 225);
            this.dgvCACOtherInvoice.Name = "dgvCACOtherInvoice";
            this.dgvCACOtherInvoice.Size = new System.Drawing.Size(404, 91);
            this.dgvCACOtherInvoice.TabIndex = 75;
            this.dgvCACOtherInvoice.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACOtherInvoice_CellValueChanged);
            this.dgvCACOtherInvoice.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCACOtherInvoice_RowsRemoved);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Number #";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Ton";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // txtOtherAmount
            // 
            this.txtOtherAmount.Location = new System.Drawing.Point(282, 321);
            this.txtOtherAmount.Name = "txtOtherAmount";
            this.txtOtherAmount.ReadOnly = true;
            this.txtOtherAmount.Size = new System.Drawing.Size(126, 20);
            this.txtOtherAmount.TabIndex = 77;
            this.txtOtherAmount.Text = "0.00";
            this.txtOtherAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Other Amount";
            // 
            // frmQuotationInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 407);
            this.Controls.Add(this.txtOtherAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvCACOtherInvoice);
            this.Controls.Add(this.txtInvAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTon);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblPoAmount);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCACQuotationInvoice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "frmQuotationInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotation Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACQuotationInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACOtherInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCACQuotationInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPoAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTon;
        private System.Windows.Forms.TextBox txtInvAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvCACOtherInvoice;
        private System.Windows.Forms.TextBox txtOtherAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoice;
        private CJ.Win.Control.CalenderControl dtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CJ.Win.Control.CalenderControl Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}