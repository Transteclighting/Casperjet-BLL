namespace CJ.Win
{
    partial class frmComplains
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
            this.lvwComplains = new System.Windows.Forms.ListView();
            this.colComplainID = new System.Windows.Forms.ColumnHeader();
            this.colComplainReceiveDate = new System.Windows.Forms.ColumnHeader();
            this.colComplainer = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colRefJobNo = new System.Windows.Forms.ColumnHeader();
            this.colComplainDetails = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colAssignto = new System.Windows.Forms.ColumnHeader();
            this.colFurActReq = new System.Windows.Forms.ColumnHeader();
            this.colReceiveBy = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtComplainNo = new System.Windows.Forms.TextBox();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblAssignWhom = new System.Windows.Forms.Label();
            this.btnHappyCall = new System.Windows.Forms.Button();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbComplainStatus = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComplainerName = new System.Windows.Forms.TextBox();
            this.lblComplainerName = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAssignto = new System.Windows.Forms.TextBox();
            this.lvwProActiveList = new System.Windows.Forms.ListView();
            this.colComplainNo = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.All = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrintComplain = new System.Windows.Forms.Button();
            this.txtRefJob = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReceiveBy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbComplainSource = new System.Windows.Forms.ComboBox();
            this.lblComplainerType = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwComplains
            // 
            this.lvwComplains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwComplains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComplainID,
            this.colComplainReceiveDate,
            this.colComplainer,
            this.colContactNo,
            this.colRefJobNo,
            this.colComplainDetails,
            this.colStatus,
            this.colAssignto,
            this.colFurActReq,
            this.colReceiveBy});
            this.lvwComplains.FullRowSelect = true;
            this.lvwComplains.GridLines = true;
            this.lvwComplains.Location = new System.Drawing.Point(-1, 120);
            this.lvwComplains.MultiSelect = false;
            this.lvwComplains.Name = "lvwComplains";
            this.lvwComplains.Size = new System.Drawing.Size(799, 346);
            this.lvwComplains.TabIndex = 0;
            this.lvwComplains.UseCompatibleStateImageBehavior = false;
            this.lvwComplains.View = System.Windows.Forms.View.Details;
            this.lvwComplains.DoubleClick += new System.EventHandler(this.lvwComplains_DoubleClick);
            // 
            // colComplainID
            // 
            this.colComplainID.Text = "Complain No";
            this.colComplainID.Width = 76;
            // 
            // colComplainReceiveDate
            // 
            this.colComplainReceiveDate.Text = "Complain Date";
            this.colComplainReceiveDate.Width = 86;
            // 
            // colComplainer
            // 
            this.colComplainer.Text = "Complainer Name";
            this.colComplainer.Width = 98;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 92;
            // 
            // colRefJobNo
            // 
            this.colRefJobNo.Text = "RefJobNo";
            this.colRefJobNo.Width = 91;
            // 
            // colComplainDetails
            // 
            this.colComplainDetails.Text = "Complain Details";
            this.colComplainDetails.Width = 126;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colAssignto
            // 
            this.colAssignto.Text = "Assign To";
            this.colAssignto.Width = 114;
            // 
            // colFurActReq
            // 
            this.colFurActReq.Text = "FurActReq";
            this.colFurActReq.Width = 66;
            // 
            // colReceiveBy
            // 
            this.colReceiveBy.Text = "Receive By";
            this.colReceiveBy.Width = 73;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(804, 230);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 27);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Tag = "M34.2.2";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(804, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Enabled = false;
            this.btnAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Location = new System.Drawing.Point(804, 164);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(105, 27);
            this.btnAction.TabIndex = 8;
            this.btnAction.Tag = "M34.2.4";
            this.btnAction.Text = "A&ction";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Enabled = false;
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(804, 131);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(105, 27);
            this.btnAssign.TabIndex = 7;
            this.btnAssign.Tag = "M34.2.3";
            this.btnAssign.Text = "&Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(804, 98);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 27);
            this.btnNew.TabIndex = 6;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "M34.2.1";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtComplainNo
            // 
            this.txtComplainNo.Location = new System.Drawing.Point(110, 36);
            this.txtComplainNo.Name = "txtComplainNo";
            this.txtComplainNo.Size = new System.Drawing.Size(67, 20);
            this.txtComplainNo.TabIndex = 59;
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainNo.Location = new System.Drawing.Point(35, 43);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(78, 13);
            this.lblComplainNo.TabIndex = 58;
            this.lblComplainNo.Text = "Complain No";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(217, 19);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 86;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(240, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 84;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(115, 16);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 83;
            // 
            // lblAssignWhom
            // 
            this.lblAssignWhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignWhom.Location = new System.Drawing.Point(183, 38);
            this.lblAssignWhom.Name = "lblAssignWhom";
            this.lblAssignWhom.Size = new System.Drawing.Size(64, 13);
            this.lblAssignWhom.TabIndex = 132;
            this.lblAssignWhom.Text = "Assign To";
            // 
            // btnHappyCall
            // 
            this.btnHappyCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHappyCall.Enabled = false;
            this.btnHappyCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHappyCall.Location = new System.Drawing.Point(804, 197);
            this.btnHappyCall.Name = "btnHappyCall";
            this.btnHappyCall.Size = new System.Drawing.Size(105, 27);
            this.btnHappyCall.TabIndex = 133;
            this.btnHappyCall.Tag = "M34.2.5";
            this.btnHappyCall.Text = "&Happy Call";
            this.btnHappyCall.UseVisualStyleBackColor = true;
            this.btnHappyCall.Click += new System.EventHandler(this.btnHappyCall_Click);
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(389, 21);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(43, 13);
            this.lblComplainStatus.TabIndex = 136;
            this.lblComplainStatus.Text = "Status";
            // 
            // cmbComplainStatus
            // 
            this.cmbComplainStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplainStatus.FormattingEnabled = true;
            this.cmbComplainStatus.Location = new System.Drawing.Point(433, 17);
            this.cmbComplainStatus.Name = "cmbComplainStatus";
            this.cmbComplainStatus.Size = new System.Drawing.Size(171, 21);
            this.cmbComplainStatus.TabIndex = 135;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(804, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 27);
            this.btnCancel.TabIndex = 137;
            this.btnCancel.Tag = "M34.2.6";
            this.btnCancel.Text = "Cance&l";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(142, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 138;
            this.label1.Text = "Receive";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(691, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 139;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(607, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 140;
            this.label3.Text = "HappyCall";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(228, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 142;
            this.label5.Text = "Assign";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtComplainerName
            // 
            this.txtComplainerName.Location = new System.Drawing.Point(115, 64);
            this.txtComplainerName.Name = "txtComplainerName";
            this.txtComplainerName.Size = new System.Drawing.Size(224, 20);
            this.txtComplainerName.TabIndex = 144;
            // 
            // lblComplainerName
            // 
            this.lblComplainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerName.Location = new System.Drawing.Point(9, 66);
            this.lblComplainerName.Name = "lblComplainerName";
            this.lblComplainerName.Size = new System.Drawing.Size(105, 13);
            this.lblComplainerName.TabIndex = 143;
            this.lblComplainerName.Text = "Complainer Name";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(110, 83);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(224, 20);
            this.txtContactNo.TabIndex = 146;
            // 
            // lblContactNo
            // 
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(42, 91);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(71, 13);
            this.lblContactNo.TabIndex = 145;
            this.lblContactNo.Text = "Contact No";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(625, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 30);
            this.button1.TabIndex = 147;
            this.button1.Text = "&Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAssignto
            // 
            this.txtAssignto.Location = new System.Drawing.Point(249, 35);
            this.txtAssignto.Name = "txtAssignto";
            this.txtAssignto.Size = new System.Drawing.Size(115, 20);
            this.txtAssignto.TabIndex = 148;
            // 
            // lvwProActiveList
            // 
            this.lvwProActiveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProActiveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComplainNo});
            this.lvwProActiveList.FullRowSelect = true;
            this.lvwProActiveList.GridLines = true;
            this.lvwProActiveList.Location = new System.Drawing.Point(5, 14);
            this.lvwProActiveList.Name = "lvwProActiveList";
            this.lvwProActiveList.Size = new System.Drawing.Size(101, 105);
            this.lvwProActiveList.TabIndex = 149;
            this.lvwProActiveList.UseCompatibleStateImageBehavior = false;
            this.lvwProActiveList.View = System.Windows.Forms.View.Details;
            // 
            // colComplainNo
            // 
            this.colComplainNo.Text = "Complain No";
            this.colComplainNo.Width = 86;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvwProActiveList);
            this.groupBox1.Location = new System.Drawing.Point(803, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 125);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ProActive List";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cmbComplainSource);
            this.groupBox2.Controls.Add(this.lblComplainerType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtComplainNo);
            this.groupBox2.Controls.Add(this.txtContactNo);
            this.groupBox2.Controls.Add(this.txtAssignto);
            this.groupBox2.Controls.Add(this.lblAssignWhom);
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 109);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = "Receive Date";
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(343, 20);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 152;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Plum;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(312, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 153;
            this.label6.Text = "Solved";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(401, 478);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 154;
            this.label7.Text = "Under Process";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.PowderBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(507, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 155;
            this.label8.Text = "Mgt.ActionReq";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintComplain
            // 
            this.btnPrintComplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintComplain.Enabled = false;
            this.btnPrintComplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintComplain.Location = new System.Drawing.Point(804, 296);
            this.btnPrintComplain.Name = "btnPrintComplain";
            this.btnPrintComplain.Size = new System.Drawing.Size(105, 27);
            this.btnPrintComplain.TabIndex = 156;
            this.btnPrintComplain.Tag = "M34.2.7";
            this.btnPrintComplain.Text = "Print Complain";
            this.btnPrintComplain.UseVisualStyleBackColor = true;
            this.btnPrintComplain.Click += new System.EventHandler(this.btnPrintComplain_Click);
            // 
            // txtRefJob
            // 
            this.txtRefJob.Location = new System.Drawing.Point(433, 65);
            this.txtRefJob.Name = "txtRefJob";
            this.txtRefJob.Size = new System.Drawing.Size(171, 20);
            this.txtRefJob.TabIndex = 158;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(362, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Ref. Job #";
            // 
            // txtReceiveBy
            // 
            this.txtReceiveBy.Location = new System.Drawing.Point(433, 89);
            this.txtReceiveBy.Name = "txtReceiveBy";
            this.txtReceiveBy.Size = new System.Drawing.Size(171, 20);
            this.txtReceiveBy.TabIndex = 160;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(360, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 159;
            this.label9.Text = "Receive By";
            // 
            // cmbComplainSource
            // 
            this.cmbComplainSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplainSource.FormattingEnabled = true;
            this.cmbComplainSource.Location = new System.Drawing.Point(428, 36);
            this.cmbComplainSource.Name = "cmbComplainSource";
            this.cmbComplainSource.Size = new System.Drawing.Size(171, 21);
            this.cmbComplainSource.TabIndex = 161;
            // 
            // lblComplainerType
            // 
            this.lblComplainerType.AutoSize = true;
            this.lblComplainerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerType.Location = new System.Drawing.Point(379, 39);
            this.lblComplainerType.Name = "lblComplainerType";
            this.lblComplainerType.Size = new System.Drawing.Size(47, 13);
            this.lblComplainerType.TabIndex = 162;
            this.lblComplainerType.Text = "Source";
            // 
            // frmComplains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 503);
            this.Controls.Add(this.txtReceiveBy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRefJob);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrintComplain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.All);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.txtComplainerName);
            this.Controls.Add(this.lblComplainerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblComplainStatus);
            this.Controls.Add(this.cmbComplainStatus);
            this.Controls.Add(this.btnHappyCall);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwComplains);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmComplains";
            this.Text = "Complain Management";
            this.Load += new System.EventHandler(this.frmComplain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwComplains;
        private System.Windows.Forms.ColumnHeader colComplainID;
        private System.Windows.Forms.ColumnHeader colComplainer;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colComplainReceiveDate;
        private System.Windows.Forms.ColumnHeader colComplainDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtComplainNo;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lblAssignWhom;
        private System.Windows.Forms.Button btnHappyCall;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbComplainStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colReceiveBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComplainerName;
        private System.Windows.Forms.Label lblComplainerName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.ColumnHeader colFurActReq;
        private System.Windows.Forms.ColumnHeader colAssignto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAssignto;
        private System.Windows.Forms.ListView lvwProActiveList;
        private System.Windows.Forms.ColumnHeader colComplainNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrintComplain;
        private System.Windows.Forms.ColumnHeader colRefJobNo;
        private System.Windows.Forms.TextBox txtRefJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReceiveBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbComplainSource;
        private System.Windows.Forms.Label lblComplainerType;
    }
}