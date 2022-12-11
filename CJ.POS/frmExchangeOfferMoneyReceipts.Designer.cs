namespace CJ.POS
{
    partial class frmExchangeOfferMoneyReceipts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeOfferMoneyReceipts));
            this.lvwMR = new System.Windows.Forms.ListView();
            this.colMRNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMRDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateWH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTransferWH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMRAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMRStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbVenderName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMRNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetMR = new System.Windows.Forms.Button();
            this.lvwExchangeOfferJob = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVenderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParentCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTerminal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwMR
            // 
            this.lvwMR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMRNo,
            this.colMRDate,
            this.colJob,
            this.colCreateWH,
            this.colTransferWH,
            this.colMRAmount,
            this.colMRStatus});
            this.lvwMR.FullRowSelect = true;
            this.lvwMR.GridLines = true;
            this.lvwMR.Location = new System.Drawing.Point(14, 447);
            this.lvwMR.Name = "lvwMR";
            this.lvwMR.Size = new System.Drawing.Size(798, 161);
            this.lvwMR.TabIndex = 23;
            this.lvwMR.UseCompatibleStateImageBehavior = false;
            this.lvwMR.View = System.Windows.Forms.View.Details;
            // 
            // colMRNo
            // 
            this.colMRNo.Text = "MR No";
            this.colMRNo.Width = 121;
            // 
            // colMRDate
            // 
            this.colMRDate.Text = "Create Date";
            this.colMRDate.Width = 82;
            // 
            // colJob
            // 
            this.colJob.Text = "JOB No";
            this.colJob.Width = 119;
            // 
            // colCreateWH
            // 
            this.colCreateWH.Text = "Create WH";
            this.colCreateWH.Width = 103;
            // 
            // colTransferWH
            // 
            this.colTransferWH.Text = "Transfer WH";
            this.colTransferWH.Width = 86;
            // 
            // colMRAmount
            // 
            this.colMRAmount.Text = "MR Amount";
            this.colMRAmount.Width = 84;
            // 
            // colMRStatus
            // 
            this.colMRStatus.Text = "MR Status";
            this.colMRStatus.Width = 82;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(820, 579);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(820, 447);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 29);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(820, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 29);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(453, 118);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(219, 20);
            this.txtContactNo.TabIndex = 218;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(374, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "Conatct No:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(453, 85);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(219, 20);
            this.txtCustomerName.TabIndex = 216;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(350, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 215;
            this.label5.Text = "Customer Name:";
            // 
            // cmbVenderName
            // 
            this.cmbVenderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenderName.FormattingEnabled = true;
            this.cmbVenderName.Location = new System.Drawing.Point(104, 118);
            this.cmbVenderName.Name = "cmbVenderName";
            this.cmbVenderName.Size = new System.Drawing.Size(234, 23);
            this.cmbVenderName.TabIndex = 214;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 213;
            this.label4.Text = "Vender Name: ";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(65, 40);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(193, 20);
            this.dtFromDate.TabIndex = 211;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 210;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 65);
            this.groupBox1.TabIndex = 212;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 185;
            this.label2.Text = "To";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(9, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(179, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(287, 27);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(184, 20);
            this.dtToDate.TabIndex = 186;
            // 
            // txtJobNo
            // 
            this.txtJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNo.Location = new System.Drawing.Point(104, 85);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(234, 20);
            this.txtJobNo.TabIndex = 209;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 208;
            this.label1.Text = "Job No. ";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(693, 113);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(85, 30);
            this.btnGo.TabIndex = 207;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMRNo
            // 
            this.txtMRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRNo.Location = new System.Drawing.Point(72, 417);
            this.txtMRNo.Name = "txtMRNo";
            this.txtMRNo.Size = new System.Drawing.Size(234, 20);
            this.txtMRNo.TabIndex = 221;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 220;
            this.label7.Text = "MR No:";
            // 
            // btnGetMR
            // 
            this.btnGetMR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetMR.Location = new System.Drawing.Point(320, 414);
            this.btnGetMR.Name = "btnGetMR";
            this.btnGetMR.Size = new System.Drawing.Size(85, 30);
            this.btnGetMR.TabIndex = 219;
            this.btnGetMR.Text = "Get Data";
            this.btnGetMR.UseVisualStyleBackColor = true;
            this.btnGetMR.Click += new System.EventHandler(this.btnGetMR_Click);
            // 
            // lvwExchangeOfferJob
            // 
            this.lvwExchangeOfferJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwExchangeOfferJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colContactDate,
            this.colCustomerName,
            this.colAddress,
            this.colContactNo,
            this.colEmail,
            this.colVenderName,
            this.colParentCustomerName,
            this.colBalance,
            this.colTerminal,
            this.colStatus});
            this.lvwExchangeOfferJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwExchangeOfferJob.FullRowSelect = true;
            this.lvwExchangeOfferJob.GridLines = true;
            this.lvwExchangeOfferJob.HideSelection = false;
            this.lvwExchangeOfferJob.Location = new System.Drawing.Point(14, 152);
            this.lvwExchangeOfferJob.MultiSelect = false;
            this.lvwExchangeOfferJob.Name = "lvwExchangeOfferJob";
            this.lvwExchangeOfferJob.Size = new System.Drawing.Size(798, 257);
            this.lvwExchangeOfferJob.TabIndex = 222;
            this.lvwExchangeOfferJob.UseCompatibleStateImageBehavior = false;
            this.lvwExchangeOfferJob.View = System.Windows.Forms.View.Details;
            this.lvwExchangeOfferJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwExchangeOfferJob_KeyDown);
            this.lvwExchangeOfferJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwExchangeOfferJob_KeyPress);
            this.lvwExchangeOfferJob.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwExchangeOfferJob_KeyUp);
            this.lvwExchangeOfferJob.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwExchangeOfferJob_MouseClick);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 55;
            // 
            // colContactDate
            // 
            this.colContactDate.Text = "Contact Date";
            this.colContactDate.Width = 76;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 99;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 92;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 72;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 57;
            // 
            // colVenderName
            // 
            this.colVenderName.Text = "Assigned Vender Name";
            this.colVenderName.Width = 82;
            // 
            // colParentCustomerName
            // 
            this.colParentCustomerName.Text = "Parent Customer";
            this.colParentCustomerName.Width = 71;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            // 
            // colTerminal
            // 
            this.colTerminal.Text = "Terminal";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // frmExchangeOfferMoneyReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 627);
            this.Controls.Add(this.lvwExchangeOfferJob);
            this.Controls.Add(this.txtMRNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGetMR);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbVenderName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lvwMR);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmExchangeOfferMoneyReceipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Offer Money Receipts";
            this.Load += new System.EventHandler(this.frmExchangeOfferMoneyReceipts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMR;
        private System.Windows.Forms.ColumnHeader colMRDate;
        private System.Windows.Forms.ColumnHeader colMRNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbVenderName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMRNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetMR;
        private System.Windows.Forms.ListView lvwExchangeOfferJob;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colContactDate;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colVenderName;
        private System.Windows.Forms.ColumnHeader colParentCustomerName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colTerminal;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.ColumnHeader colJob;
        private System.Windows.Forms.ColumnHeader colCreateWH;
        private System.Windows.Forms.ColumnHeader colTransferWH;
        private System.Windows.Forms.ColumnHeader colMRAmount;
        private System.Windows.Forms.ColumnHeader colMRStatus;

    }
}