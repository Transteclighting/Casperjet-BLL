namespace CJ.Win.CSD
{
    partial class frmCustomerSatisfaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdoSatisfy = new System.Windows.Forms.RadioButton();
            this.rdoModerate = new System.Windows.Forms.RadioButton();
            this.rdoDissatisfy = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSwitchedOff = new System.Windows.Forms.RadioButton();
            this.rdoNumbusy = new System.Windows.Forms.RadioButton();
            this.chkBanForever = new System.Windows.Forms.CheckBox();
            this.rdoNoResponse = new System.Windows.Forms.RadioButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJobCreationDate = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPhonehome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCustAddress = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblMAG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblASG = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAG = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblPhoneOffice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblJobType = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoSatisfy
            // 
            this.rdoSatisfy.AutoSize = true;
            this.rdoSatisfy.Checked = true;
            this.rdoSatisfy.Location = new System.Drawing.Point(6, 19);
            this.rdoSatisfy.Name = "rdoSatisfy";
            this.rdoSatisfy.Size = new System.Drawing.Size(56, 17);
            this.rdoSatisfy.TabIndex = 0;
            this.rdoSatisfy.TabStop = true;
            this.rdoSatisfy.Text = "Satisfy";
            this.rdoSatisfy.UseVisualStyleBackColor = true;
            // 
            // rdoModerate
            // 
            this.rdoModerate.AutoSize = true;
            this.rdoModerate.Location = new System.Drawing.Point(66, 19);
            this.rdoModerate.Name = "rdoModerate";
            this.rdoModerate.Size = new System.Drawing.Size(70, 17);
            this.rdoModerate.TabIndex = 1;
            this.rdoModerate.Text = "Moderate";
            this.rdoModerate.UseVisualStyleBackColor = true;
            // 
            // rdoDissatisfy
            // 
            this.rdoDissatisfy.AutoSize = true;
            this.rdoDissatisfy.Location = new System.Drawing.Point(140, 19);
            this.rdoDissatisfy.Name = "rdoDissatisfy";
            this.rdoDissatisfy.Size = new System.Drawing.Size(69, 17);
            this.rdoDissatisfy.TabIndex = 2;
            this.rdoDissatisfy.Text = "Dissatisfy";
            this.rdoDissatisfy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSwitchedOff);
            this.groupBox1.Controls.Add(this.rdoNumbusy);
            this.groupBox1.Controls.Add(this.chkBanForever);
            this.groupBox1.Controls.Add(this.rdoNoResponse);
            this.groupBox1.Controls.Add(this.rdoSatisfy);
            this.groupBox1.Controls.Add(this.rdoDissatisfy);
            this.groupBox1.Controls.Add(this.rdoModerate);
            this.groupBox1.Location = new System.Drawing.Point(15, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 43);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Happy Call Status";
            // 
            // rdoSwitchedOff
            // 
            this.rdoSwitchedOff.AutoSize = true;
            this.rdoSwitchedOff.Location = new System.Drawing.Point(291, 20);
            this.rdoSwitchedOff.Name = "rdoSwitchedOff";
            this.rdoSwitchedOff.Size = new System.Drawing.Size(86, 17);
            this.rdoSwitchedOff.TabIndex = 9;
            this.rdoSwitchedOff.Text = "Switched Off";
            this.rdoSwitchedOff.UseVisualStyleBackColor = true;
            // 
            // rdoNumbusy
            // 
            this.rdoNumbusy.AutoSize = true;
            this.rdoNumbusy.Location = new System.Drawing.Point(215, 19);
            this.rdoNumbusy.Name = "rdoNumbusy";
            this.rdoNumbusy.Size = new System.Drawing.Size(72, 17);
            this.rdoNumbusy.TabIndex = 5;
            this.rdoNumbusy.Text = "Num busy";
            this.rdoNumbusy.UseVisualStyleBackColor = true;
            // 
            // chkBanForever
            // 
            this.chkBanForever.AutoSize = true;
            this.chkBanForever.Location = new System.Drawing.Point(476, 19);
            this.chkBanForever.Name = "chkBanForever";
            this.chkBanForever.Size = new System.Drawing.Size(87, 17);
            this.chkBanForever.TabIndex = 4;
            this.chkBanForever.Text = "Ban Forever ";
            this.chkBanForever.UseVisualStyleBackColor = true;
            // 
            // rdoNoResponse
            // 
            this.rdoNoResponse.AutoSize = true;
            this.rdoNoResponse.Location = new System.Drawing.Point(379, 19);
            this.rdoNoResponse.Name = "rdoNoResponse";
            this.rdoNoResponse.Size = new System.Drawing.Size(87, 17);
            this.rdoNoResponse.TabIndex = 3;
            this.rdoNoResponse.Text = "NoResponse";
            this.rdoNoResponse.UseVisualStyleBackColor = true;
            this.rdoNoResponse.CheckedChanged += new System.EventHandler(this.rdoNoResponse_CheckedChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(70, 521);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(511, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remarks ";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtUnitPW});
            this.dgvLineItem.Location = new System.Drawing.Point(15, 295);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(567, 215);
            this.dgvLineItem.TabIndex = 4;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtProductCode.HeaderText = "Questiones";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 350;
            // 
            // txtUnitPW
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitPW.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtUnitPW.HeaderText = "QuestionesID";
            this.txtUnitPW.Name = "txtUnitPW";
            this.txtUnitPW.ReadOnly = true;
            this.txtUnitPW.Visible = false;
            this.txtUnitPW.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Job No:";
            // 
            // lblJobCreationDate
            // 
            this.lblJobCreationDate.AutoSize = true;
            this.lblJobCreationDate.Location = new System.Drawing.Point(294, 18);
            this.lblJobCreationDate.Name = "lblJobCreationDate";
            this.lblJobCreationDate.Size = new System.Drawing.Size(13, 13);
            this.lblJobCreationDate.TabIndex = 5;
            this.lblJobCreationDate.Text = "?";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(202, 18);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(95, 13);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Job Creation Date:";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(474, 18);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(13, 13);
            this.lblDeliveryDate.TabIndex = 9;
            this.lblDeliveryDate.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Delivery Date:";
            // 
            // lblPhonehome
            // 
            this.lblPhonehome.AutoSize = true;
            this.lblPhonehome.Location = new System.Drawing.Point(101, 68);
            this.lblPhonehome.Name = "lblPhonehome";
            this.lblPhonehome.Size = new System.Drawing.Size(13, 13);
            this.lblPhonehome.TabIndex = 5;
            this.lblPhonehome.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone Home:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Mobile No:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(102, 20);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(13, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Customer Name:";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(274, 67);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(13, 13);
            this.lblSerial.TabIndex = 11;
            this.lblSerial.Text = "?";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(201, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Product Serial:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(274, 19);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(13, 13);
            this.lblProductName.TabIndex = 7;
            this.lblProductName.Text = "?";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(199, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Product Name:";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(77, 19);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(13, 13);
            this.lblProductCode.TabIndex = 1;
            this.lblProductCode.Text = "?";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Product Code:";
            // 
            // lblCustAddress
            // 
            this.lblCustAddress.AutoSize = true;
            this.lblCustAddress.Location = new System.Drawing.Point(102, 45);
            this.lblCustAddress.Name = "lblCustAddress";
            this.lblCustAddress.Size = new System.Drawing.Size(13, 13);
            this.lblCustAddress.TabIndex = 3;
            this.lblCustAddress.Text = "?";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Customer Address:";
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Location = new System.Drawing.Point(461, 43);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(13, 13);
            this.lblMAG.TabIndex = 13;
            this.lblMAG.Text = "?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(399, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "MAG Serial:";
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Location = new System.Drawing.Point(274, 43);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(13, 13);
            this.lblASG.TabIndex = 9;
            this.lblASG.Text = "?";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(214, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "ASG Name:";
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Location = new System.Drawing.Point(77, 42);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(13, 13);
            this.lblAG.TabIndex = 3;
            this.lblAG.Text = "?";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "AG Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPG);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblMAG);
            this.groupBox2.Controls.Add(this.lblProductCode);
            this.groupBox2.Controls.Add(this.lblSerial);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblASG);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblAG);
            this.groupBox2.Location = new System.Drawing.Point(15, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Info";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblPG
            // 
            this.lblPG.AutoSize = true;
            this.lblPG.Location = new System.Drawing.Point(77, 67);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(13, 13);
            this.lblPG.TabIndex = 5;
            this.lblPG.Text = "?";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "PG Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMobile);
            this.groupBox3.Controls.Add(this.lblPhoneOffice);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblCustomerName);
            this.groupBox3.Controls.Add(this.lblPhonehome);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblCustAddress);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(15, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 89);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Info";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(298, 64);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.Size = new System.Drawing.Size(115, 20);
            this.txtMobile.TabIndex = 10;
            // 
            // lblPhoneOffice
            // 
            this.lblPhoneOffice.AutoSize = true;
            this.lblPhoneOffice.Location = new System.Drawing.Point(481, 68);
            this.lblPhoneOffice.Name = "lblPhoneOffice";
            this.lblPhoneOffice.Size = new System.Drawing.Size(13, 13);
            this.lblPhoneOffice.TabIndex = 9;
            this.lblPhoneOffice.Text = "?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Phone Office:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtJobNo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lblJobType);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.lblServiceType);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.lbl3);
            this.groupBox4.Controls.Add(this.lblDeliveryDate);
            this.groupBox4.Controls.Add(this.lblJobCreationDate);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(15, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(567, 64);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Job Info";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(67, 15);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Size = new System.Drawing.Size(123, 20);
            this.txtJobNo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Job Type:";
            // 
            // lblJobType
            // 
            this.lblJobType.AutoSize = true;
            this.lblJobType.Location = new System.Drawing.Point(66, 45);
            this.lblJobType.Name = "lblJobType";
            this.lblJobType.Size = new System.Drawing.Size(13, 13);
            this.lblJobType.TabIndex = 3;
            this.lblJobType.Text = "?";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(224, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Service Type:";
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Location = new System.Drawing.Point(297, 45);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(13, 13);
            this.lblServiceType.TabIndex = 7;
            this.lblServiceType.Text = "?";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(507, 547);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(426, 547);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "Questiones";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 350;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "QuestionesID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // frmCustomerSatisfaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 575);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCustomerSatisfaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Satisfaction";
            this.Load += new System.EventHandler(this.frmCustomerSatisfaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoSatisfy;
        private System.Windows.Forms.RadioButton rdoModerate;
        private System.Windows.Forms.RadioButton rdoDissatisfy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJobCreationDate;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPhonehome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCustAddress;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblPhoneOffice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblJobType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdoNoResponse;
        private System.Windows.Forms.CheckBox chkBanForever;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.RadioButton rdoSwitchedOff;
        private System.Windows.Forms.RadioButton rdoNumbusy;
    }
}