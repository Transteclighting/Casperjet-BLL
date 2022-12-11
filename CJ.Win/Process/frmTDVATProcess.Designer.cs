namespace CJ.Win.Process
{
    partial class frmTDVATProcess
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
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.colOutlet = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwInvoice = new System.Windows.Forms.ListView();
            this.pbTransfer = new System.Windows.Forms.ProgressBar();
            this.rdbTD = new System.Windows.Forms.RadioButton();
            this.rdbHO = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(79, 26);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(212, 20);
            this.txtInvoiceNo.TabIndex = 154;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 153;
            this.label1.Text = "Invoice No";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(475, 500);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(76, 27);
            this.btClose.TabIndex = 152;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(475, 71);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 27);
            this.btnSave.TabIndex = 151;
            this.btnSave.Text = "&Process";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(324, 26);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(77, 24);
            this.btnGo.TabIndex = 150;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(232, 5);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 149;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(42, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 148;
            this.lblDate.Text = "From";
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 100;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(257, 2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 147;
            // 
            // colOutlet
            // 
            this.colOutlet.Text = "Outlet/Warehouse Name";
            this.colOutlet.Width = 200;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 120;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(79, 1);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(132, 20);
            this.dtFromDate.TabIndex = 146;
            // 
            // lvwInvoice
            // 
            this.lvwInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colOutlet});
            this.lvwInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwInvoice.FullRowSelect = true;
            this.lvwInvoice.GridLines = true;
            this.lvwInvoice.HideSelection = false;
            this.lvwInvoice.Location = new System.Drawing.Point(1, 71);
            this.lvwInvoice.MultiSelect = false;
            this.lvwInvoice.Name = "lvwInvoice";
            this.lvwInvoice.Size = new System.Drawing.Size(468, 459);
            this.lvwInvoice.TabIndex = 145;
            this.lvwInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwInvoice.View = System.Windows.Forms.View.Details;
            // 
            // pbTransfer
            // 
            this.pbTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTransfer.Location = new System.Drawing.Point(1, 51);
            this.pbTransfer.Name = "pbTransfer";
            this.pbTransfer.Size = new System.Drawing.Size(552, 18);
            this.pbTransfer.TabIndex = 155;
            this.pbTransfer.Visible = false;
            // 
            // rdbTD
            // 
            this.rdbTD.AutoSize = true;
            this.rdbTD.Checked = true;
            this.rdbTD.Location = new System.Drawing.Point(429, 5);
            this.rdbTD.Name = "rdbTD";
            this.rdbTD.Size = new System.Drawing.Size(150, 17);
            this.rdbTD.TabIndex = 156;
            this.rdbTD.TabStop = true;
            this.rdbTD.Text = "TD Old Stock Vat Process";
            this.rdbTD.UseVisualStyleBackColor = true;
            this.rdbTD.CheckedChanged += new System.EventHandler(this.rdbTD_CheckedChanged);
            // 
            // rdbHO
            // 
            this.rdbHO.AutoSize = true;
            this.rdbHO.Location = new System.Drawing.Point(429, 29);
            this.rdbHO.Name = "rdbHO";
            this.rdbHO.Size = new System.Drawing.Size(139, 17);
            this.rdbHO.TabIndex = 157;
            this.rdbHO.Text = "HO Invoice Vat Process";
            this.rdbHO.UseVisualStyleBackColor = true;
            this.rdbHO.CheckedChanged += new System.EventHandler(this.rdbHO_CheckedChanged);
            // 
            // frmTDVATProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 527);
            this.Controls.Add(this.rdbHO);
            this.Controls.Add(this.rdbTD);
            this.Controls.Add(this.pbTransfer);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwInvoice);
            this.Name = "frmTDVATProcess";
            this.Load += new System.EventHandler(this.frmTDVATProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ColumnHeader colOutlet;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwInvoice;
        private System.Windows.Forms.ProgressBar pbTransfer;
        private System.Windows.Forms.RadioButton rdbTD;
        private System.Windows.Forms.RadioButton rdbHO;
    }
}