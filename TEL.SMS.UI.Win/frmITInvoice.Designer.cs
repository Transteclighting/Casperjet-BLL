namespace TEL.SMS.UI.Win
{
    partial class frmITInvoice
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGRDNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtChalanNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpChalanDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpGRDDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lvwInvoiceItem = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductDesc = new System.Windows.Forms.ColumnHeader();
            this.colPartNo = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.colUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.colSerialNo = new System.Windows.Forms.ColumnHeader();
            this.cmnuITProductInvoice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmnuITProductInvoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(622, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGRDNo
            // 
            this.txtGRDNo.Location = new System.Drawing.Point(119, 70);
            this.txtGRDNo.Name = "txtGRDNo";
            this.txtGRDNo.Size = new System.Drawing.Size(168, 20);
            this.txtGRDNo.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "GRD No*";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(12, 340);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(786, 27);
            this.txtRemarks.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Remarks";
            // 
            // txtChalanNo
            // 
            this.txtChalanNo.Location = new System.Drawing.Point(119, 41);
            this.txtChalanNo.Name = "txtChalanNo";
            this.txtChalanNo.Size = new System.Drawing.Size(168, 20);
            this.txtChalanNo.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Chalan No*";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpInvoiceDate.CalendarTitleForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(407, 8);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(109, 20);
            this.dtpInvoiceDate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Invoice Date *";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(119, 8);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(168, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No *";
            // 
            // dtpChalanDate
            // 
            this.dtpChalanDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpChalanDate.CalendarTitleForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtpChalanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChalanDate.Location = new System.Drawing.Point(407, 44);
            this.dtpChalanDate.Name = "dtpChalanDate";
            this.dtpChalanDate.Size = new System.Drawing.Size(109, 20);
            this.dtpChalanDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Chalan Date*";
            // 
            // dtpGRDDate
            // 
            this.dtpGRDDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpGRDDate.CalendarTitleForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtpGRDDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGRDDate.Location = new System.Drawing.Point(407, 73);
            this.dtpGRDDate.Name = "dtpGRDDate";
            this.dtpGRDDate.Size = new System.Drawing.Size(109, 20);
            this.dtpGRDDate.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "GRD Date*";
            // 
            // lvwInvoiceItem
            // 
            this.lvwInvoiceItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoiceItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductDesc,
            this.colPartNo,
            this.colQty,
            this.colUnitPrice,
            this.colSerialNo});
            this.lvwInvoiceItem.ContextMenuStrip = this.cmnuITProductInvoice;
            this.lvwInvoiceItem.FullRowSelect = true;
            this.lvwInvoiceItem.GridLines = true;
            this.lvwInvoiceItem.HideSelection = false;
            this.lvwInvoiceItem.Location = new System.Drawing.Point(12, 129);
            this.lvwInvoiceItem.Name = "lvwInvoiceItem";
            this.lvwInvoiceItem.Size = new System.Drawing.Size(786, 188);
            this.lvwInvoiceItem.TabIndex = 14;
            this.lvwInvoiceItem.UseCompatibleStateImageBehavior = false;
            this.lvwInvoiceItem.View = System.Windows.Forms.View.Details;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 82;
            // 
            // colProductDesc
            // 
            this.colProductDesc.Text = "Product Description";
            this.colProductDesc.Width = 240;
            // 
            // colPartNo
            // 
            this.colPartNo.Text = "Part No";
            this.colPartNo.Width = 111;
            // 
            // colQty
            // 
            this.colQty.Text = "Quantity";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Text = "UnitPrice";
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "SerialNo";
            this.colSerialNo.Width = 227;
            // 
            // cmnuITProductInvoice
            // 
            this.cmnuITProductInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.cmnuITProductInvoice.Name = "cmnuITProductInvoice";
            this.cmnuITProductInvoice.Size = new System.Drawing.Size(125, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Supplier*";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(119, 101);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(397, 21);
            this.cboSupplier.TabIndex = 13;
            this.cboSupplier.Enter += new System.EventHandler(this.cboSupplierGenerate);
            this.cboSupplier.TabIndexChanged += new System.EventHandler(this.cboSupplierGenerate);
            this.cboSupplier.Click += new System.EventHandler(this.cboSupplierGenerate);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(724, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmITInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 409);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGRDNo);
            this.Controls.Add(this.lvwInvoiceItem);
            this.Controls.Add(this.dtpGRDDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpChalanDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtChalanNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmITInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Product Invoice";
            this.Load += new System.EventHandler(this.frmITInvoice_Load);
            this.cmnuITProductInvoice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGRDNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtChalanNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpChalanDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpGRDDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvwInvoiceItem;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductDesc;
        private System.Windows.Forms.ColumnHeader colPartNo;
        private System.Windows.Forms.ContextMenuStrip cmnuITProductInvoice;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colUnitPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader colSerialNo;
    }
}