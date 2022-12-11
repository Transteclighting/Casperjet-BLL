namespace CJ.Win
{
    partial class frmReplaces
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
            this.lvwReplaces = new System.Windows.Forms.ListView();
            this.colReplaceID = new System.Windows.Forms.ColumnHeader();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colPapersLocation = new System.Windows.Forms.ColumnHeader();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPaperAcknowledge = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendToCSD = new System.Windows.Forms.Button();
            this.btnReceiveAtCSD = new System.Windows.Forms.Button();
            this.btnInformToCustomer = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnHappyCall = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.txtReplaceID = new System.Windows.Forms.TextBox();
            this.lblReplaceID = new System.Windows.Forms.Label();
            this.All = new System.Windows.Forms.CheckBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPaperLocation = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFormPrint = new System.Windows.Forms.Button();
            this.btnPaperSend = new System.Windows.Forms.Button();
            this.btnPaperReceive = new System.Windows.Forms.Button();
            this.GBPrint = new System.Windows.Forms.GroupBox();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.btnEditComments = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.GBPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwReplaces
            // 
            this.lvwReplaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReplaces.CheckBoxes = true;
            this.lvwReplaces.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReplaceID,
            this.colJobNo,
            this.colCustomerName,
            this.colAddress,
            this.colContactNo,
            this.colStatus,
            this.colPapersLocation});
            this.lvwReplaces.FullRowSelect = true;
            this.lvwReplaces.GridLines = true;
            this.lvwReplaces.Location = new System.Drawing.Point(-1, 146);
            this.lvwReplaces.MultiSelect = false;
            this.lvwReplaces.Name = "lvwReplaces";
            this.lvwReplaces.Size = new System.Drawing.Size(782, 323);
            this.lvwReplaces.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwReplaces.TabIndex = 0;
            this.lvwReplaces.UseCompatibleStateImageBehavior = false;
            this.lvwReplaces.View = System.Windows.Forms.View.Details;
            this.lvwReplaces.DoubleClick += new System.EventHandler(this.lvwReplaces_DoubleClick);
            // 
            // colReplaceID
            // 
            this.colReplaceID.Text = "Replace ID";
            this.colReplaceID.Width = 70;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job Number";
            this.colJobNo.Width = 94;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 127;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 195;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 107;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 118;
            // 
            // colPapersLocation
            // 
            this.colPapersLocation.Text = "Paper Location";
            this.colPapersLocation.Width = 95;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(183, 14);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 90;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(2, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 13);
            this.lblDate.TabIndex = 89;
            this.lblDate.Text = "Raise Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(208, 11);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 1;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(80, 11);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 0;
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(80, 57);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(136, 20);
            this.txtJobNo.TabIndex = 6;
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(30, 60);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 91;
            this.lblJobNo.Text = "Job No";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(336, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 139;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(380, 11);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(145, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(466, 112);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(81, 28);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(787, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 25);
            this.btnCancel.TabIndex = 147;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cance&l";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPaperAcknowledge
            // 
            this.btnPaperAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaperAcknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaperAcknowledge.Location = new System.Drawing.Point(787, 263);
            this.btnPaperAcknowledge.Name = "btnPaperAcknowledge";
            this.btnPaperAcknowledge.Size = new System.Drawing.Size(105, 25);
            this.btnPaperAcknowledge.TabIndex = 146;
            this.btnPaperAcknowledge.Tag = "";
            this.btnPaperAcknowledge.Text = "&Paper Acknow.";
            this.btnPaperAcknowledge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaperAcknowledge.UseVisualStyleBackColor = true;
            this.btnPaperAcknowledge.Click += new System.EventHandler(this.btnPaperAcknowledge_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(787, 119);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(105, 25);
            this.btnIssue.TabIndex = 145;
            this.btnIssue.Tag = "M1.20";
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(787, 361);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 25);
            this.btnEdit.TabIndex = 143;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(787, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 144;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.Location = new System.Drawing.Point(787, 90);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(105, 25);
            this.btnDeposit.TabIndex = 142;
            this.btnDeposit.Tag = "M1.20";
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(787, 63);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(105, 25);
            this.btnApprove.TabIndex = 141;
            this.btnApprove.Tag = "M1.18";
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(787, 33);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 25);
            this.btnNew.TabIndex = 140;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(289, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 152;
            this.label5.Text = "Send";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(359, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 151;
            this.label4.Text = "Receive";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Khaki;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(429, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 150;
            this.label3.Text = "Inform";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(719, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 149;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DarkKhaki;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(218, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 148;
            this.label1.Text = "Issue";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSendToCSD
            // 
            this.btnSendToCSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendToCSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToCSD.Location = new System.Drawing.Point(787, 148);
            this.btnSendToCSD.Name = "btnSendToCSD";
            this.btnSendToCSD.Size = new System.Drawing.Size(105, 25);
            this.btnSendToCSD.TabIndex = 153;
            this.btnSendToCSD.Tag = "M1.20";
            this.btnSendToCSD.Text = "Send to CSD";
            this.btnSendToCSD.UseVisualStyleBackColor = true;
            this.btnSendToCSD.Click += new System.EventHandler(this.btnSendToCSD_Click);
            // 
            // btnReceiveAtCSD
            // 
            this.btnReceiveAtCSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveAtCSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveAtCSD.Location = new System.Drawing.Point(787, 177);
            this.btnReceiveAtCSD.Name = "btnReceiveAtCSD";
            this.btnReceiveAtCSD.Size = new System.Drawing.Size(105, 25);
            this.btnReceiveAtCSD.TabIndex = 154;
            this.btnReceiveAtCSD.Tag = "M1.20";
            this.btnReceiveAtCSD.Text = "Rcv. at CSD";
            this.btnReceiveAtCSD.UseVisualStyleBackColor = true;
            this.btnReceiveAtCSD.Click += new System.EventHandler(this.btnReceiveAtCSD_Click);
            // 
            // btnInformToCustomer
            // 
            this.btnInformToCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInformToCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformToCustomer.Location = new System.Drawing.Point(787, 206);
            this.btnInformToCustomer.Name = "btnInformToCustomer";
            this.btnInformToCustomer.Size = new System.Drawing.Size(105, 25);
            this.btnInformToCustomer.TabIndex = 155;
            this.btnInformToCustomer.Tag = "M1.20";
            this.btnInformToCustomer.Text = "Inform to Cus.";
            this.btnInformToCustomer.UseVisualStyleBackColor = true;
            this.btnInformToCustomer.Click += new System.EventHandler(this.btnInformToCustomer_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Location = new System.Drawing.Point(787, 235);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(105, 25);
            this.btnDelivery.TabIndex = 156;
            this.btnDelivery.Tag = "M1.20";
            this.btnDelivery.Text = "Delivery";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(4, 117);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(70, 17);
            this.ckbSelect.TabIndex = 163;
            this.ckbSelect.Text = "Select All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(78, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 166;
            this.label6.Text = "Approve";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(148, 478);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 165;
            this.label7.Text = "Deposit";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 164;
            this.label8.Text = "Reise";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Violet;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(499, 478);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 168;
            this.label9.Text = "Delivery";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.CadetBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(643, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 167;
            this.label10.Text = "HappyCall";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHappyCall
            // 
            this.btnHappyCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHappyCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHappyCall.Location = new System.Drawing.Point(787, 291);
            this.btnHappyCall.Name = "btnHappyCall";
            this.btnHappyCall.Size = new System.Drawing.Size(105, 25);
            this.btnHappyCall.TabIndex = 169;
            this.btnHappyCall.Tag = "M1.20";
            this.btnHappyCall.Text = "Happy Call";
            this.btnHappyCall.UseVisualStyleBackColor = true;
            this.btnHappyCall.Click += new System.EventHandler(this.btnHappyCall_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Green;
            this.btnHistory.Location = new System.Drawing.Point(11, 15);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(92, 25);
            this.btnHistory.TabIndex = 170;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // txtReplaceID
            // 
            this.txtReplaceID.Location = new System.Drawing.Point(80, 34);
            this.txtReplaceID.Name = "txtReplaceID";
            this.txtReplaceID.Size = new System.Drawing.Size(136, 20);
            this.txtReplaceID.TabIndex = 4;
            // 
            // lblReplaceID
            // 
            this.lblReplaceID.AutoSize = true;
            this.lblReplaceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceID.Location = new System.Drawing.Point(7, 37);
            this.lblReplaceID.Name = "lblReplaceID";
            this.lblReplaceID.Size = new System.Drawing.Size(71, 13);
            this.lblReplaceID.TabIndex = 171;
            this.lblReplaceID.Text = "Replace ID";
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(312, 14);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 2;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(335, 36);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(190, 20);
            this.txtCustomerName.TabIndex = 5;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(237, 39);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerName.TabIndex = 174;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(335, 59);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(190, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(280, 63);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 13);
            this.lblAddress.TabIndex = 176;
            this.lblAddress.Text = "Address";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(80, 80);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(136, 20);
            this.txtContactNo.TabIndex = 8;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(18, 83);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(59, 13);
            this.lblContactNo.TabIndex = 178;
            this.lblContactNo.Text = "Contact#";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbPaperLocation);
            this.groupBox1.Controls.Add(this.txtContactNo);
            this.groupBox1.Controls.Add(this.lblContactNo);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.lblAddress);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.All);
            this.groupBox1.Controls.Add(this.txtReplaceID);
            this.groupBox1.Controls.Add(this.lblReplaceID);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.txtJobNo);
            this.groupBox1.Controls.Add(this.lblJobNo);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(16, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 109);
            this.groupBox1.TabIndex = 180;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(284, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 181;
            this.label12.Text = "Paper Location";
            // 
            // cmbPaperLocation
            // 
            this.cmbPaperLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaperLocation.FormattingEnabled = true;
            this.cmbPaperLocation.Location = new System.Drawing.Point(380, 82);
            this.cmbPaperLocation.Name = "cmbPaperLocation";
            this.cmbPaperLocation.Size = new System.Drawing.Size(145, 21);
            this.cmbPaperLocation.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Thistle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(567, 478);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 181;
            this.label11.Text = "Paper Ack";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFormPrint
            // 
            this.btnFormPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormPrint.ForeColor = System.Drawing.Color.Green;
            this.btnFormPrint.Location = new System.Drawing.Point(11, 44);
            this.btnFormPrint.Name = "btnFormPrint";
            this.btnFormPrint.Size = new System.Drawing.Size(92, 25);
            this.btnFormPrint.TabIndex = 182;
            this.btnFormPrint.Text = "Form Print";
            this.btnFormPrint.UseVisualStyleBackColor = true;
            this.btnFormPrint.Click += new System.EventHandler(this.btnFormPrint_Click);
            // 
            // btnPaperSend
            // 
            this.btnPaperSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaperSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaperSend.Location = new System.Drawing.Point(787, 388);
            this.btnPaperSend.Name = "btnPaperSend";
            this.btnPaperSend.Size = new System.Drawing.Size(105, 25);
            this.btnPaperSend.TabIndex = 183;
            this.btnPaperSend.Tag = "";
            this.btnPaperSend.Text = "Paper Send";
            this.btnPaperSend.UseVisualStyleBackColor = true;
            this.btnPaperSend.Click += new System.EventHandler(this.btnPaperSend_Click);
            // 
            // btnPaperReceive
            // 
            this.btnPaperReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaperReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaperReceive.Location = new System.Drawing.Point(787, 415);
            this.btnPaperReceive.Name = "btnPaperReceive";
            this.btnPaperReceive.Size = new System.Drawing.Size(105, 25);
            this.btnPaperReceive.TabIndex = 184;
            this.btnPaperReceive.Tag = "";
            this.btnPaperReceive.Text = "Paper Receive";
            this.btnPaperReceive.UseVisualStyleBackColor = true;
            this.btnPaperReceive.Click += new System.EventHandler(this.btnPaperReceive_Click);
            // 
            // GBPrint
            // 
            this.GBPrint.Controls.Add(this.btnAcknowledge);
            this.GBPrint.Controls.Add(this.btnFormPrint);
            this.GBPrint.Controls.Add(this.btnHistory);
            this.GBPrint.Location = new System.Drawing.Point(559, 0);
            this.GBPrint.Name = "GBPrint";
            this.GBPrint.Size = new System.Drawing.Size(112, 109);
            this.GBPrint.TabIndex = 185;
            this.GBPrint.TabStop = false;
            this.GBPrint.Text = "Print";
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcknowledge.ForeColor = System.Drawing.Color.Green;
            this.btnAcknowledge.Location = new System.Drawing.Point(11, 75);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(92, 25);
            this.btnAcknowledge.TabIndex = 186;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // btnEditComments
            // 
            this.btnEditComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditComments.Location = new System.Drawing.Point(787, 444);
            this.btnEditComments.Name = "btnEditComments";
            this.btnEditComments.Size = new System.Drawing.Size(105, 25);
            this.btnEditComments.TabIndex = 186;
            this.btnEditComments.Tag = "";
            this.btnEditComments.Text = "Edit Comments";
            this.btnEditComments.UseVisualStyleBackColor = true;
            this.btnEditComments.Click += new System.EventHandler(this.btnEditComments_Click);
            // 
            // frmReplaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 503);
            this.Controls.Add(this.btnEditComments);
            this.Controls.Add(this.GBPrint);
            this.Controls.Add(this.btnPaperReceive);
            this.Controls.Add(this.btnPaperSend);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHappyCall);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnInformToCustomer);
            this.Controls.Add(this.btnReceiveAtCSD);
            this.Controls.Add(this.btnSendToCSD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPaperAcknowledge);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lvwReplaces);
            this.Name = "frmReplaces";
            this.ShowInTaskbar = false;
            this.Text = "Replaces";
            this.Load += new System.EventHandler(this.frmReplaces_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBPrint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwReplaces;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colReplaceID;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPaperAcknowledge;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendToCSD;
        private System.Windows.Forms.Button btnReceiveAtCSD;
        private System.Windows.Forms.Button btnInformToCustomer;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnHappyCall;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.TextBox txtReplaceID;
        private System.Windows.Forms.Label lblReplaceID;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFormPrint;
        private System.Windows.Forms.Button btnPaperSend;
        private System.Windows.Forms.Button btnPaperReceive;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPaperLocation;
        private System.Windows.Forms.GroupBox GBPrint;
        private System.Windows.Forms.ColumnHeader colPapersLocation;
        private System.Windows.Forms.Button btnAcknowledge;
        private System.Windows.Forms.Button btnEditComments;
    }
}