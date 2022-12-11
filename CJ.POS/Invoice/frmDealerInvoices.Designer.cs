namespace CJ.POS.Invoice
{
    partial class frmDealerInvoices
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
            this.lvwDealerInvoice = new System.Windows.Forms.ListView();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colConsumer = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceType = new System.Windows.Forms.ColumnHeader();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnMoneyReceiptPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInvoicePrint = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btnCancelInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwDealerInvoice
            // 
            this.lvwDealerInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDealerInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colAmount,
            this.colConsumer,
            this.colInvoiceType});
            this.lvwDealerInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDealerInvoice.FullRowSelect = true;
            this.lvwDealerInvoice.GridLines = true;
            this.lvwDealerInvoice.HideSelection = false;
            this.lvwDealerInvoice.Location = new System.Drawing.Point(-1, 83);
            this.lvwDealerInvoice.MultiSelect = false;
            this.lvwDealerInvoice.Name = "lvwDealerInvoice";
            this.lvwDealerInvoice.Size = new System.Drawing.Size(614, 385);
            this.lvwDealerInvoice.TabIndex = 146;
            this.lvwDealerInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwDealerInvoice.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 100;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 100;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 100;
            // 
            // colConsumer
            // 
            this.colConsumer.Text = "Consumer";
            this.colConsumer.Width = 200;
            // 
            // colInvoiceType
            // 
            this.colInvoiceType.Text = "Invoice Type";
            this.colInvoiceType.Width = 120;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(91, 41);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(170, 20);
            this.txtInvoiceNo.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "Invoice No";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(274, 41);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(77, 24);
            this.btnGo.TabIndex = 159;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(213, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 158;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(8, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 13);
            this.lblDate.TabIndex = 157;
            this.lblDate.Text = "Invoice Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(238, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(113, 20);
            this.dtToDate.TabIndex = 156;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(91, 11);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(117, 20);
            this.dtFromDate.TabIndex = 155;
            // 
            // btnMoneyReceiptPrint
            // 
            this.btnMoneyReceiptPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoneyReceiptPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoneyReceiptPrint.Location = new System.Drawing.Point(619, 150);
            this.btnMoneyReceiptPrint.Name = "btnMoneyReceiptPrint";
            this.btnMoneyReceiptPrint.Size = new System.Drawing.Size(109, 38);
            this.btnMoneyReceiptPrint.TabIndex = 166;
            this.btnMoneyReceiptPrint.Text = "Money Receipt Print ";
            this.btnMoneyReceiptPrint.UseVisualStyleBackColor = true;
            this.btnMoneyReceiptPrint.Visible = false;
            this.btnMoneyReceiptPrint.Click += new System.EventHandler(this.btnMoneyReceiptPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(619, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 27);
            this.btnAdd.TabIndex = 165;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInvoicePrint
            // 
            this.btnInvoicePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoicePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoicePrint.Location = new System.Drawing.Point(619, 116);
            this.btnInvoicePrint.Name = "btnInvoicePrint";
            this.btnInvoicePrint.Size = new System.Drawing.Size(109, 29);
            this.btnInvoicePrint.TabIndex = 164;
            this.btnInvoicePrint.Text = " Invoice Print ";
            this.btnInvoicePrint.UseVisualStyleBackColor = true;
            this.btnInvoicePrint.Click += new System.EventHandler(this.btnInvoicePrint_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(619, 441);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(109, 27);
            this.btClose.TabIndex = 162;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnCancelInvoice
            // 
            this.btnCancelInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInvoice.Location = new System.Drawing.Point(619, 231);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new System.Drawing.Size(109, 27);
            this.btnCancelInvoice.TabIndex = 167;
            this.btnCancelInvoice.Text = "Cancel Invoice";
            this.btnCancelInvoice.UseVisualStyleBackColor = true;
            this.btnCancelInvoice.Visible = false;
            this.btnCancelInvoice.Click += new System.EventHandler(this.btnCancelInvoice_Click);
            // 
            // frmDealerInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 480);
            this.Controls.Add(this.btnCancelInvoice);
            this.Controls.Add(this.btnMoneyReceiptPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnInvoicePrint);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwDealerInvoice);
            this.Name = "frmDealerInvoices";
            this.Text = "Dealer Invoices";
            this.Load += new System.EventHandler(this.frmDealerInvoices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDealerInvoice;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colConsumer;
        private System.Windows.Forms.ColumnHeader colInvoiceType;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnMoneyReceiptPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInvoicePrint;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btnCancelInvoice;
    }
}