namespace CJ.Win.CSD.Workshop
{
    partial class frmJobUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.lblFeedbackDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblJobType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJobCreateDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPartsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEstimatedRemarks = new System.Windows.Forms.TextBox();
            this.lblEstimatedRemarks = new System.Windows.Forms.Label();
            this.chkEDD = new System.Windows.Forms.CheckBox();
            this.dtEDDExten = new System.Windows.Forms.DateTimePicker();
            this.lblSubStatus = new System.Windows.Forms.Label();
            this.cmbSubStatus = new System.Windows.Forms.ComboBox();
            this.btnJobHistory = new System.Windows.Forms.Button();
            this.dtVisitingDate = new System.Windows.Forms.DateTimePicker();
            this.lblVisitingDate = new System.Windows.Forms.Label();
            this.lblVisitingTimeTo = new System.Windows.Forms.Label();
            this.lblVisitingTimeFrom = new System.Windows.Forms.Label();
            this.dtVisitingTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtVisitingTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.btnCommunication = new System.Windows.Forms.Button();
            this.lvwSPIssues = new System.Windows.Forms.ListView();
            this.colPartCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIssueQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIssuedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSpareCharge = new System.Windows.Forms.Label();
            this.txtTotalSpareCharge = new System.Windows.Forms.TextBox();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.lblServiceCharge = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTpMatCharge = new System.Windows.Forms.TextBox();
            this.txtTpGasCharge = new System.Windows.Forms.TextBox();
            this.txtTpOtherCharge = new System.Windows.Forms.TextBox();
            this.grbTpCharge = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.grbTpCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job No:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJobNo
            // 
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblJobNo.Location = new System.Drawing.Point(74, 13);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(218, 16);
            this.lblJobNo.TabIndex = 1;
            this.lblJobNo.Text = "Job No";
            this.lblJobNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFeedbackDate
            // 
            this.lblFeedbackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedbackDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFeedbackDate.Location = new System.Drawing.Point(402, 34);
            this.lblFeedbackDate.Name = "lblFeedbackDate";
            this.lblFeedbackDate.Size = new System.Drawing.Size(179, 16);
            this.lblFeedbackDate.TabIndex = 13;
            this.lblFeedbackDate.Text = "FeedBack";
            this.lblFeedbackDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(301, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Feedback Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJobType
            // 
            this.lblJobType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobType.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblJobType.Location = new System.Drawing.Point(75, 33);
            this.lblJobType.Name = "lblJobType";
            this.lblJobType.Size = new System.Drawing.Size(220, 16);
            this.lblJobType.TabIndex = 3;
            this.lblJobType.Text = "JobType";
            this.lblJobType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Job Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblProduct.Location = new System.Drawing.Point(74, 69);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(509, 16);
            this.lblProduct.TabIndex = 7;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Product:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCustomer.Location = new System.Drawing.Point(74, 51);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(218, 16);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Customer:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRemarks.Location = new System.Drawing.Point(74, 89);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(507, 16);
            this.lblRemarks.TabIndex = 9;
            this.lblRemarks.Text = "Remarks";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Remarks:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCurrentStatus.Location = new System.Drawing.Point(401, 53);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(179, 16);
            this.lblCurrentStatus.TabIndex = 15;
            this.lblCurrentStatus.Text = "Current Status";
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(304, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Current Status:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJobCreateDate
            // 
            this.lblJobCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobCreateDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblJobCreateDate.Location = new System.Drawing.Point(401, 14);
            this.lblJobCreateDate.Name = "lblJobCreateDate";
            this.lblJobCreateDate.Size = new System.Drawing.Size(181, 16);
            this.lblJobCreateDate.TabIndex = 11;
            this.lblJobCreateDate.Text = "Job Create Date";
            this.lblJobCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(294, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Job Create Date:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblJobCreateDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblCurrentStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblJobType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblFeedbackDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblJobNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(8, 216);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(589, 148);
            this.txtRemarks.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(519, 549);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 25);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(439, 549);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 25);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(11, 181);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(65, 13);
            this.label.TabIndex = 11;
            this.label.Text = "Spare Parts:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvParts
            // 
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtName,
            this.txtUnitPrice,
            this.txtQuantity,
            this.txtAmount,
            this.ColPartsID});
            this.dgvParts.Location = new System.Drawing.Point(9, 198);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.Size = new System.Drawing.Size(589, 106);
            this.dgvParts.TabIndex = 12;
            this.dgvParts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellContentClick);
            this.dgvParts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellValueChanged);
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // txtName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtName.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtName.HeaderText = "Name";
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Width = 220;
            // 
            // txtUnitPrice
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtUnitPrice.HeaderText = "Unit Price";
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Width = 70;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 70;
            // 
            // txtAmount
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Width = 70;
            // 
            // ColPartsID
            // 
            this.ColPartsID.HeaderText = "PartsID";
            this.ColPartsID.Name = "ColPartsID";
            this.ColPartsID.ReadOnly = true;
            this.ColPartsID.Visible = false;
            // 
            // txtEstimatedRemarks
            // 
            this.txtEstimatedRemarks.Location = new System.Drawing.Point(8, 343);
            this.txtEstimatedRemarks.Multiline = true;
            this.txtEstimatedRemarks.Name = "txtEstimatedRemarks";
            this.txtEstimatedRemarks.Size = new System.Drawing.Size(590, 39);
            this.txtEstimatedRemarks.TabIndex = 19;
            // 
            // lblEstimatedRemarks
            // 
            this.lblEstimatedRemarks.AutoSize = true;
            this.lblEstimatedRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedRemarks.Location = new System.Drawing.Point(5, 327);
            this.lblEstimatedRemarks.Name = "lblEstimatedRemarks";
            this.lblEstimatedRemarks.Size = new System.Drawing.Size(85, 13);
            this.lblEstimatedRemarks.TabIndex = 18;
            this.lblEstimatedRemarks.Text = "Status Remarks:";
            this.lblEstimatedRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEDD
            // 
            this.chkEDD.AutoSize = true;
            this.chkEDD.Location = new System.Drawing.Point(335, 133);
            this.chkEDD.Name = "chkEDD";
            this.chkEDD.Size = new System.Drawing.Size(142, 17);
            this.chkEDD.TabIndex = 5;
            this.chkEDD.Text = "Propose Feedback Date";
            this.chkEDD.UseVisualStyleBackColor = true;
            this.chkEDD.CheckedChanged += new System.EventHandler(this.chkEDD_CheckedChanged);
            // 
            // dtEDDExten
            // 
            this.dtEDDExten.CustomFormat = "dd-MMM-yyyy";
            this.dtEDDExten.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEDDExten.Location = new System.Drawing.Point(476, 133);
            this.dtEDDExten.Name = "dtEDDExten";
            this.dtEDDExten.Size = new System.Drawing.Size(115, 20);
            this.dtEDDExten.TabIndex = 6;
            // 
            // lblSubStatus
            // 
            this.lblSubStatus.AutoSize = true;
            this.lblSubStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubStatus.Location = new System.Drawing.Point(5, 133);
            this.lblSubStatus.Name = "lblSubStatus";
            this.lblSubStatus.Size = new System.Drawing.Size(56, 13);
            this.lblSubStatus.TabIndex = 1;
            this.lblSubStatus.Text = "Sub-Staus";
            // 
            // cmbSubStatus
            // 
            this.cmbSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubStatus.FormattingEnabled = true;
            this.cmbSubStatus.Location = new System.Drawing.Point(63, 130);
            this.cmbSubStatus.Name = "cmbSubStatus";
            this.cmbSubStatus.Size = new System.Drawing.Size(180, 21);
            this.cmbSubStatus.TabIndex = 2;
            this.cmbSubStatus.SelectedIndexChanged += new System.EventHandler(this.cmbSubStatus_SelectedIndexChanged);
            // 
            // btnJobHistory
            // 
            this.btnJobHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobHistory.Location = new System.Drawing.Point(8, 549);
            this.btnJobHistory.Name = "btnJobHistory";
            this.btnJobHistory.Size = new System.Drawing.Size(77, 25);
            this.btnJobHistory.TabIndex = 23;
            this.btnJobHistory.Text = "Job History";
            this.btnJobHistory.UseVisualStyleBackColor = true;
            this.btnJobHistory.Click += new System.EventHandler(this.btnJobHistory_Click);
            // 
            // dtVisitingDate
            // 
            this.dtVisitingDate.CustomFormat = "dd-MMM-yyyy";
            this.dtVisitingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingDate.Location = new System.Drawing.Point(63, 157);
            this.dtVisitingDate.Name = "dtVisitingDate";
            this.dtVisitingDate.Size = new System.Drawing.Size(180, 20);
            this.dtVisitingDate.TabIndex = 4;
            this.dtVisitingDate.Visible = false;
            // 
            // lblVisitingDate
            // 
            this.lblVisitingDate.Location = new System.Drawing.Point(6, 157);
            this.lblVisitingDate.Name = "lblVisitingDate";
            this.lblVisitingDate.Size = new System.Drawing.Size(56, 19);
            this.lblVisitingDate.TabIndex = 3;
            this.lblVisitingDate.Text = "Visit Date";
            this.lblVisitingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVisitingDate.Visible = false;
            // 
            // lblVisitingTimeTo
            // 
            this.lblVisitingTimeTo.Location = new System.Drawing.Point(452, 158);
            this.lblVisitingTimeTo.Name = "lblVisitingTimeTo";
            this.lblVisitingTimeTo.Size = new System.Drawing.Size(20, 16);
            this.lblVisitingTimeTo.TabIndex = 9;
            this.lblVisitingTimeTo.Text = "To";
            this.lblVisitingTimeTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVisitingTimeTo.Visible = false;
            // 
            // lblVisitingTimeFrom
            // 
            this.lblVisitingTimeFrom.Location = new System.Drawing.Point(342, 158);
            this.lblVisitingTimeFrom.Name = "lblVisitingTimeFrom";
            this.lblVisitingTimeFrom.Size = new System.Drawing.Size(31, 16);
            this.lblVisitingTimeFrom.TabIndex = 7;
            this.lblVisitingTimeFrom.Text = "From";
            this.lblVisitingTimeFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVisitingTimeFrom.Visible = false;
            // 
            // dtVisitingTimeTo
            // 
            this.dtVisitingTimeTo.CustomFormat = "hh:mm tt";
            this.dtVisitingTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingTimeTo.Location = new System.Drawing.Point(477, 156);
            this.dtVisitingTimeTo.Name = "dtVisitingTimeTo";
            this.dtVisitingTimeTo.ShowUpDown = true;
            this.dtVisitingTimeTo.Size = new System.Drawing.Size(67, 20);
            this.dtVisitingTimeTo.TabIndex = 10;
            this.dtVisitingTimeTo.Visible = false;
            // 
            // dtVisitingTimeFrom
            // 
            this.dtVisitingTimeFrom.CustomFormat = "hh:mm tt";
            this.dtVisitingTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingTimeFrom.Location = new System.Drawing.Point(375, 157);
            this.dtVisitingTimeFrom.Name = "dtVisitingTimeFrom";
            this.dtVisitingTimeFrom.ShowUpDown = true;
            this.dtVisitingTimeFrom.Size = new System.Drawing.Size(72, 20);
            this.dtVisitingTimeFrom.TabIndex = 8;
            this.dtVisitingTimeFrom.Visible = false;
            // 
            // btnCommunication
            // 
            this.btnCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunication.Location = new System.Drawing.Point(91, 549);
            this.btnCommunication.Name = "btnCommunication";
            this.btnCommunication.Size = new System.Drawing.Size(92, 25);
            this.btnCommunication.TabIndex = 24;
            this.btnCommunication.Text = "Communication";
            this.btnCommunication.UseVisualStyleBackColor = true;
            this.btnCommunication.Click += new System.EventHandler(this.btnCommunication_Click);
            // 
            // lvwSPIssues
            // 
            this.lvwSPIssues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSPIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPartCode,
            this.colPartName,
            this.colIssueQty,
            this.colTotalPrice,
            this.colIssuedDate});
            this.lvwSPIssues.FullRowSelect = true;
            this.lvwSPIssues.GridLines = true;
            this.lvwSPIssues.Location = new System.Drawing.Point(8, 399);
            this.lvwSPIssues.MultiSelect = false;
            this.lvwSPIssues.Name = "lvwSPIssues";
            this.lvwSPIssues.Size = new System.Drawing.Size(588, 100);
            this.lvwSPIssues.TabIndex = 21;
            this.lvwSPIssues.UseCompatibleStateImageBehavior = false;
            this.lvwSPIssues.View = System.Windows.Forms.View.Details;
            // 
            // colPartCode
            // 
            this.colPartCode.Text = "Part Code";
            this.colPartCode.Width = 138;
            // 
            // colPartName
            // 
            this.colPartName.Text = "Part Name";
            this.colPartName.Width = 248;
            // 
            // colIssueQty
            // 
            this.colIssueQty.Text = "Issue Qty";
            this.colIssueQty.Width = 80;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Text = "Total Price";
            this.colTotalPrice.Width = 169;
            // 
            // colIssuedDate
            // 
            this.colIssuedDate.Text = "Issued Date";
            this.colIssuedDate.Width = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Spare Use List:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSpareCharge
            // 
            this.lblTotalSpareCharge.AutoSize = true;
            this.lblTotalSpareCharge.Location = new System.Drawing.Point(388, 314);
            this.lblTotalSpareCharge.Name = "lblTotalSpareCharge";
            this.lblTotalSpareCharge.Size = new System.Drawing.Size(99, 13);
            this.lblTotalSpareCharge.TabIndex = 16;
            this.lblTotalSpareCharge.Text = "Total Spare Charge";
            this.lblTotalSpareCharge.Visible = false;
            // 
            // txtTotalSpareCharge
            // 
            this.txtTotalSpareCharge.Location = new System.Drawing.Point(488, 311);
            this.txtTotalSpareCharge.Name = "txtTotalSpareCharge";
            this.txtTotalSpareCharge.Size = new System.Drawing.Size(110, 20);
            this.txtTotalSpareCharge.TabIndex = 17;
            this.txtTotalSpareCharge.Visible = false;
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Enabled = false;
            this.txtServiceCharge.Location = new System.Drawing.Point(274, 311);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.ReadOnly = true;
            this.txtServiceCharge.Size = new System.Drawing.Size(110, 20);
            this.txtServiceCharge.TabIndex = 15;
            this.txtServiceCharge.Visible = false;
            // 
            // lblServiceCharge
            // 
            this.lblServiceCharge.AutoSize = true;
            this.lblServiceCharge.Location = new System.Drawing.Point(191, 314);
            this.lblServiceCharge.Name = "lblServiceCharge";
            this.lblServiceCharge.Size = new System.Drawing.Size(80, 13);
            this.lblServiceCharge.TabIndex = 14;
            this.lblServiceCharge.Text = "Service Charge";
            this.lblServiceCharge.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Unit Price";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "PartsID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Material";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Gas";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(397, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Other";
            // 
            // txtTpMatCharge
            // 
            this.txtTpMatCharge.Location = new System.Drawing.Point(58, 13);
            this.txtTpMatCharge.Name = "txtTpMatCharge";
            this.txtTpMatCharge.Size = new System.Drawing.Size(147, 20);
            this.txtTpMatCharge.TabIndex = 1;
            // 
            // txtTpGasCharge
            // 
            this.txtTpGasCharge.Location = new System.Drawing.Point(240, 13);
            this.txtTpGasCharge.Name = "txtTpGasCharge";
            this.txtTpGasCharge.Size = new System.Drawing.Size(147, 20);
            this.txtTpGasCharge.TabIndex = 3;
            // 
            // txtTpOtherCharge
            // 
            this.txtTpOtherCharge.Location = new System.Drawing.Point(434, 13);
            this.txtTpOtherCharge.Name = "txtTpOtherCharge";
            this.txtTpOtherCharge.Size = new System.Drawing.Size(147, 20);
            this.txtTpOtherCharge.TabIndex = 5;
            // 
            // grbTpCharge
            // 
            this.grbTpCharge.Controls.Add(this.txtTpMatCharge);
            this.grbTpCharge.Controls.Add(this.txtTpOtherCharge);
            this.grbTpCharge.Controls.Add(this.txtTpGasCharge);
            this.grbTpCharge.Controls.Add(this.label12);
            this.grbTpCharge.Controls.Add(this.label10);
            this.grbTpCharge.Controls.Add(this.label11);
            this.grbTpCharge.Location = new System.Drawing.Point(7, 505);
            this.grbTpCharge.Name = "grbTpCharge";
            this.grbTpCharge.Size = new System.Drawing.Size(589, 40);
            this.grbTpCharge.TabIndex = 22;
            this.grbTpCharge.TabStop = false;
            this.grbTpCharge.Text = "TP Charge";
            this.grbTpCharge.Visible = false;
            // 
            // frmJobUpdate
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 577);
            this.Controls.Add(this.grbTpCharge);
            this.Controls.Add(this.txtServiceCharge);
            this.Controls.Add(this.lblServiceCharge);
            this.Controls.Add(this.txtTotalSpareCharge);
            this.Controls.Add(this.lblTotalSpareCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwSPIssues);
            this.Controls.Add(this.btnCommunication);
            this.Controls.Add(this.lblVisitingTimeTo);
            this.Controls.Add(this.lblVisitingTimeFrom);
            this.Controls.Add(this.dtVisitingTimeTo);
            this.Controls.Add(this.dtVisitingTimeFrom);
            this.Controls.Add(this.dtVisitingDate);
            this.Controls.Add(this.lblVisitingDate);
            this.Controls.Add(this.btnJobHistory);
            this.Controls.Add(this.lblSubStatus);
            this.Controls.Add(this.cmbSubStatus);
            this.Controls.Add(this.dtEDDExten);
            this.Controls.Add(this.chkEDD);
            this.Controls.Add(this.lblEstimatedRemarks);
            this.Controls.Add(this.txtEstimatedRemarks);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJobUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJobUpdate";
            this.Load += new System.EventHandler(this.frmJobUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.grbTpCharge.ResumeLayout(false);
            this.grbTpCharge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Label lblFeedbackDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblJobType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJobCreateDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.TextBox txtEstimatedRemarks;
        private System.Windows.Forms.Label lblEstimatedRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.CheckBox chkEDD;
        private System.Windows.Forms.DateTimePicker dtEDDExten;
        private System.Windows.Forms.Label lblSubStatus;
        private System.Windows.Forms.ComboBox cmbSubStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPartsID;
        private System.Windows.Forms.Button btnJobHistory;
        private System.Windows.Forms.DateTimePicker dtVisitingDate;
        private System.Windows.Forms.Label lblVisitingDate;
        private System.Windows.Forms.Label lblVisitingTimeTo;
        private System.Windows.Forms.Label lblVisitingTimeFrom;
        private System.Windows.Forms.DateTimePicker dtVisitingTimeTo;
        private System.Windows.Forms.DateTimePicker dtVisitingTimeFrom;
        private System.Windows.Forms.Button btnCommunication;
        private System.Windows.Forms.ListView lvwSPIssues;
        private System.Windows.Forms.ColumnHeader colPartCode;
        private System.Windows.Forms.ColumnHeader colPartName;
        private System.Windows.Forms.ColumnHeader colIssueQty;
        private System.Windows.Forms.ColumnHeader colTotalPrice;
        private System.Windows.Forms.ColumnHeader colIssuedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSpareCharge;
        private System.Windows.Forms.TextBox txtTotalSpareCharge;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.Label lblServiceCharge;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTpMatCharge;
        private System.Windows.Forms.TextBox txtTpGasCharge;
        private System.Windows.Forms.TextBox txtTpOtherCharge;
        private System.Windows.Forms.GroupBox grbTpCharge;
    }
}