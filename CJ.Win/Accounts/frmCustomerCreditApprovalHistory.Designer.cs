namespace CJ.Win.Accounts
{
    partial class frmCustomerCreditApprovalHistory
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
            this.lblDue = new System.Windows.Forms.Label();
            this.colCollectionDate = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCollectedAmount = new System.Windows.Forms.Label();
            this.colCollectionAmount = new System.Windows.Forms.ColumnHeader();
            this.label15 = new System.Windows.Forms.Label();
            this.lvwInvoice = new System.Windows.Forms.ListView();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colCreditExpireDate = new System.Windows.Forms.ColumnHeader();
            this.label16 = new System.Windows.Forms.Label();
            this.lvwCollection = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCreditPeriod = new System.Windows.Forms.Label();
            this.lblCreditApprovalNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblInvoicedAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCreditAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDue
            // 
            this.lblDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(110, 84);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(85, 13);
            this.lblDue.TabIndex = 34;
            this.lblDue.Text = "?";
            this.lblDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colCollectionDate
            // 
            this.colCollectionDate.Text = "Collection Date";
            this.colCollectionDate.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(423, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Collection History";
            // 
            // lblCollectedAmount
            // 
            this.lblCollectedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectedAmount.Location = new System.Drawing.Point(110, 67);
            this.lblCollectedAmount.Name = "lblCollectedAmount";
            this.lblCollectedAmount.Size = new System.Drawing.Size(85, 13);
            this.lblCollectedAmount.TabIndex = 32;
            this.lblCollectedAmount.Text = "?";
            this.lblCollectedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colCollectionAmount
            // 
            this.colCollectionAmount.Text = "CollectionAmount ";
            this.colCollectionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCollectionAmount.Width = 101;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Collected Amount: ";
            // 
            // lvwInvoice
            // 
            this.lvwInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colAmount,
            this.colCreditExpireDate});
            this.lvwInvoice.FullRowSelect = true;
            this.lvwInvoice.GridLines = true;
            this.lvwInvoice.Location = new System.Drawing.Point(22, 158);
            this.lvwInvoice.Name = "lvwInvoice";
            this.lvwInvoice.Size = new System.Drawing.Size(370, 150);
            this.lvwInvoice.TabIndex = 49;
            this.lvwInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwInvoice.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 88;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 85;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 84;
            // 
            // colCreditExpireDate
            // 
            this.colCreditExpireDate.Text = "Credit Expire Date";
            this.colCreditExpireDate.Width = 105;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(83, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Due: ";
            // 
            // lvwCollection
            // 
            this.lvwCollection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCollectionDate,
            this.colCollectionAmount});
            this.lvwCollection.FullRowSelect = true;
            this.lvwCollection.GridLines = true;
            this.lvwCollection.Location = new System.Drawing.Point(420, 158);
            this.lvwCollection.Name = "lvwCollection";
            this.lvwCollection.Size = new System.Drawing.Size(231, 150);
            this.lvwCollection.TabIndex = 48;
            this.lvwCollection.UseCompatibleStateImageBehavior = false;
            this.lvwCollection.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProduct);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblCreateDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblCreditPeriod);
            this.groupBox2.Controls.Add(this.lblCreditApprovalNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblCustomer);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 132);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(112, 88);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(291, 37);
            this.lblProduct.TabIndex = 36;
            this.lblProduct.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Product/Service: ";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(113, 71);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(13, 13);
            this.lblCreateDate.TabIndex = 24;
            this.lblCreateDate.Text = "?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(44, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Create Date: ";
            // 
            // lblCreditPeriod
            // 
            this.lblCreditPeriod.AutoSize = true;
            this.lblCreditPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditPeriod.Location = new System.Drawing.Point(113, 53);
            this.lblCreditPeriod.Name = "lblCreditPeriod";
            this.lblCreditPeriod.Size = new System.Drawing.Size(13, 13);
            this.lblCreditPeriod.TabIndex = 21;
            this.lblCreditPeriod.Text = "?";
            // 
            // lblCreditApprovalNo
            // 
            this.lblCreditApprovalNo.AutoSize = true;
            this.lblCreditApprovalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditApprovalNo.Location = new System.Drawing.Point(113, 18);
            this.lblCreditApprovalNo.Name = "lblCreditApprovalNo";
            this.lblCreditApprovalNo.Size = new System.Drawing.Size(16, 13);
            this.lblCreditApprovalNo.TabIndex = 20;
            this.lblCreditApprovalNo.Text = "? ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Credit Period (Days): ";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(113, 35);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(13, 13);
            this.lblCustomer.TabIndex = 18;
            this.lblCustomer.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Credit Approval No: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Customer: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDue);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblCollectedAmount);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblInvoicedAmount);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblCreditAmount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(424, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 133);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(110, 50);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(85, 13);
            this.lblBalance.TabIndex = 30;
            this.lblBalance.Text = "?";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(64, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Balance: ";
            // 
            // lblInvoicedAmount
            // 
            this.lblInvoicedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicedAmount.Location = new System.Drawing.Point(110, 32);
            this.lblInvoicedAmount.Name = "lblInvoicedAmount";
            this.lblInvoicedAmount.Size = new System.Drawing.Size(85, 13);
            this.lblInvoicedAmount.TabIndex = 28;
            this.lblInvoicedAmount.Text = "?";
            this.lblInvoicedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Invoiced Amount: ";
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditAmount.Location = new System.Drawing.Point(110, 14);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(85, 13);
            this.lblCreditAmount.TabIndex = 26;
            this.lblCreditAmount.Text = "?";
            this.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Credit Amount: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Invoice History";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(591, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCustomerCreditApprovalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 347);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwInvoice);
            this.Controls.Add(this.lvwCollection);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerCreditApprovalHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Credit Approval History";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.ColumnHeader colCollectionDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCollectedAmount;
        private System.Windows.Forms.ColumnHeader colCollectionAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView lvwInvoice;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colCreditExpireDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView lvwCollection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCreditPeriod;
        private System.Windows.Forms.Label lblCreditApprovalNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblInvoicedAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCreditAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}