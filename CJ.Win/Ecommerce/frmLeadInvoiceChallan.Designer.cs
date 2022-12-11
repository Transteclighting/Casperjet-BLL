namespace CJ.Win.Ecommerce
{
    partial class frmLeadInvoiceChallan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeadInvoiceChallan));
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProcessChallan = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTranNo = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lvwLeadChallan = new System.Windows.Forms.ListView();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.colOrderNo = new System.Windows.Forms.ColumnHeader();
            this.colOrderDate = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceAmount = new System.Windows.Forms.ColumnHeader();
            this.colConsumerName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colDeliveryAddress = new System.Windows.Forms.ColumnHeader();
            this.colPaymentType = new System.Windows.Forms.ColumnHeader();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnCheckedAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(100, 58);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(427, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Delivery Address: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contact No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(364, 32);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(163, 20);
            this.txtContactNo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Consumer Name";
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Location = new System.Drawing.Point(100, 32);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(191, 20);
            this.txtConsumerName.TabIndex = 5;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(440, 84);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 25);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(645, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 25);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProcessChallan
            // 
            this.btnProcessChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessChallan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessChallan.Location = new System.Drawing.Point(645, 117);
            this.btnProcessChallan.Name = "btnProcessChallan";
            this.btnProcessChallan.Size = new System.Drawing.Size(101, 27);
            this.btnProcessChallan.TabIndex = 12;
            this.btnProcessChallan.Text = "Prepared Challan";
            this.btnProcessChallan.UseVisualStyleBackColor = true;
            this.btnProcessChallan.Click += new System.EventHandler(this.btnProcessChallan_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(39, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Invoice No";
            // 
            // lblTranNo
            // 
            this.lblTranNo.AutoSize = true;
            this.lblTranNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranNo.Location = new System.Drawing.Point(310, 9);
            this.lblTranNo.Name = "lblTranNo";
            this.lblTranNo.Size = new System.Drawing.Size(50, 13);
            this.lblTranNo.TabIndex = 2;
            this.lblTranNo.Text = "Order No";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(363, 6);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(164, 20);
            this.txtOrderNo.TabIndex = 3;
            // 
            // lvwLeadChallan
            // 
            this.lvwLeadChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLeadChallan.CheckBoxes = true;
            this.lvwLeadChallan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colOrderNo,
            this.colOrderDate,
            this.colInvoiceAmount,
            this.colConsumerName,
            this.colContactNo,
            this.colDeliveryAddress,
            this.colPaymentType});
            this.lvwLeadChallan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwLeadChallan.FullRowSelect = true;
            this.lvwLeadChallan.GridLines = true;
            this.lvwLeadChallan.Location = new System.Drawing.Point(9, 117);
            this.lvwLeadChallan.MultiSelect = false;
            this.lvwLeadChallan.Name = "lvwLeadChallan";
            this.lvwLeadChallan.Size = new System.Drawing.Size(630, 244);
            this.lvwLeadChallan.TabIndex = 11;
            this.lvwLeadChallan.UseCompatibleStateImageBehavior = false;
            this.lvwLeadChallan.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 94;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 83;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Order No";
            this.colOrderNo.Width = 81;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Text = "Order Date";
            this.colOrderDate.Width = 78;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Invoice Amount";
            this.colInvoiceAmount.Width = 88;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 99;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 92;
            // 
            // colDeliveryAddress
            // 
            this.colDeliveryAddress.Text = "Delivery Address";
            this.colDeliveryAddress.Width = 138;
            // 
            // colPaymentType
            // 
            this.colPaymentType.Text = "Payment Type";
            this.colPaymentType.Width = 85;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(100, 6);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(191, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // btnCheckedAll
            // 
            this.btnCheckedAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckedAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCheckedAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckedAll.Location = new System.Drawing.Point(9, 90);
            this.btnCheckedAll.Name = "btnCheckedAll";
            this.btnCheckedAll.Size = new System.Drawing.Size(72, 21);
            this.btnCheckedAll.TabIndex = 14;
            this.btnCheckedAll.Text = "Checked All";
            this.btnCheckedAll.UseVisualStyleBackColor = true;
            this.btnCheckedAll.Click += new System.EventHandler(this.btnCheckedAll_Click);
            // 
            // frmLeadInvoiceChallan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 373);
            this.Controls.Add(this.btnCheckedAll);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.lvwLeadChallan);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProcessChallan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTranNo);
            this.Controls.Add(this.txtOrderNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLeadInvoiceChallan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLeadInvoiceChallan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProcessChallan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTranNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.ListView lvwLeadChallan;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colOrderDate;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colDeliveryAddress;
        private System.Windows.Forms.ColumnHeader colPaymentType;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.Button btnCheckedAll;
    }
}