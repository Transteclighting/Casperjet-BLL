namespace CJ.Win
{
    partial class frmBarcodeSystem
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
            this.lvwProductBarcode = new System.Windows.Forms.ListView();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtfromdate = new System.Windows.Forms.DateTimePicker();
            this.dttodate = new System.Windows.Forms.DateTimePicker();
            this.lbfrom = new System.Windows.Forms.Label();
            this.lbto = new System.Windows.Forms.Label();
            this.btgetdata = new System.Windows.Forms.Button();
            this.btGenaretBarcode = new System.Windows.Forms.Button();
            this.txttranno = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwProductBarcode
            // 
            this.lvwProductBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductBarcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.TranDate,
            this.colStatus});
            this.lvwProductBarcode.FullRowSelect = true;
            this.lvwProductBarcode.GridLines = true;
            this.lvwProductBarcode.Location = new System.Drawing.Point(16, 89);
            this.lvwProductBarcode.Name = "lvwProductBarcode";
            this.lvwProductBarcode.Size = new System.Drawing.Size(458, 420);
            this.lvwProductBarcode.TabIndex = 0;
            this.lvwProductBarcode.UseCompatibleStateImageBehavior = false;
            this.lvwProductBarcode.View = System.Windows.Forms.View.Details;
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Transaction No";
            this.colTranNo.Width = 150;
            // 
            // TranDate
            // 
            this.TranDate.Text = "Transaction Date";
            this.TranDate.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Barcode Generate Status";
            this.colStatus.Width = 250;
            // 
            // dtfromdate
            // 
            this.dtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfromdate.Location = new System.Drawing.Point(62, 13);
            this.dtfromdate.Name = "dtfromdate";
            this.dtfromdate.Size = new System.Drawing.Size(97, 20);
            this.dtfromdate.TabIndex = 1;
            // 
            // dttodate
            // 
            this.dttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttodate.Location = new System.Drawing.Point(205, 13);
            this.dttodate.Name = "dttodate";
            this.dttodate.Size = new System.Drawing.Size(97, 20);
            this.dttodate.TabIndex = 2;
            // 
            // lbfrom
            // 
            this.lbfrom.AutoSize = true;
            this.lbfrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfrom.Location = new System.Drawing.Point(13, 12);
            this.lbfrom.Name = "lbfrom";
            this.lbfrom.Size = new System.Drawing.Size(44, 19);
            this.lbfrom.TabIndex = 3;
            this.lbfrom.Text = "From";
            // 
            // lbto
            // 
            this.lbto.AutoSize = true;
            this.lbto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbto.Location = new System.Drawing.Point(171, 14);
            this.lbto.Name = "lbto";
            this.lbto.Size = new System.Drawing.Size(26, 19);
            this.lbto.TabIndex = 4;
            this.lbto.Text = "To";
            // 
            // btgetdata
            // 
            this.btgetdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btgetdata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btgetdata.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btgetdata.Location = new System.Drawing.Point(309, 48);
            this.btgetdata.Name = "btgetdata";
            this.btgetdata.Size = new System.Drawing.Size(95, 28);
            this.btgetdata.TabIndex = 5;
            this.btgetdata.Text = "Get Data";
            this.btgetdata.UseVisualStyleBackColor = false;
            this.btgetdata.Click += new System.EventHandler(this.btgetdata_Click);
            // 
            // btGenaretBarcode
            // 
            this.btGenaretBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenaretBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btGenaretBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btGenaretBarcode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenaretBarcode.Location = new System.Drawing.Point(480, 89);
            this.btGenaretBarcode.Name = "btGenaretBarcode";
            this.btGenaretBarcode.Size = new System.Drawing.Size(90, 49);
            this.btGenaretBarcode.TabIndex = 6;
            this.btGenaretBarcode.Text = "Generate Barcode";
            this.btGenaretBarcode.UseVisualStyleBackColor = false;
            this.btGenaretBarcode.Click += new System.EventHandler(this.btGenaretBarcode_Click);
            // 
            // txttranno
            // 
            this.txttranno.Location = new System.Drawing.Point(16, 52);
            this.txttranno.Name = "txttranno";
            this.txttranno.Size = new System.Drawing.Size(286, 20);
            this.txttranno.TabIndex = 7;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(480, 164);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(90, 49);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmBarcodeSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 523);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txttranno);
            this.Controls.Add(this.btGenaretBarcode);
            this.Controls.Add(this.btgetdata);
            this.Controls.Add(this.lbto);
            this.Controls.Add(this.lbfrom);
            this.Controls.Add(this.dttodate);
            this.Controls.Add(this.dtfromdate);
            this.Controls.Add(this.lvwProductBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBarcodeSystem";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.Load += new System.EventHandler(this.frmProductBarcode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductBarcode;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader TranDate;
        private System.Windows.Forms.Label lbfrom;
        private System.Windows.Forms.Label lbto;
        private System.Windows.Forms.Button btgetdata;
        public System.Windows.Forms.DateTimePicker dtfromdate;
        public System.Windows.Forms.DateTimePicker dttodate;
        private System.Windows.Forms.Button btGenaretBarcode;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.TextBox txttranno;
        private System.Windows.Forms.Button btClose;



    }
}