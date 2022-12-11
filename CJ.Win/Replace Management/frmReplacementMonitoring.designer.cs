namespace CJ.Win.Replace_Management
{
    partial class frmReplacementMonitoring
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
            this.lblCustCode = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelivered = new System.Windows.Forms.Button();
            this.btnApproval = new System.Windows.Forms.Button();
            this.btnReplacement = new System.Windows.Forms.Button();
            this.btLogistic = new System.Windows.Forms.Button();
            this.ClaimedForMonth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwReplaceClaims = new System.Windows.Forms.ListView();
            this.RegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TokenNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConfirmByZI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClaimAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogisticRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReplacementRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ApprovalRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeliveryRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEditDate = new System.Windows.Forms.Button();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.btnSaveDate = new System.Windows.Forms.Button();
            this.lblDateEdit = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSKUrpt = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustCode.Location = new System.Drawing.Point(6, 23);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(92, 13);
            this.lblCustCode.TabIndex = 191;
            this.lblCustCode.Text = "Customer Code";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(757, 48);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(63, 23);
            this.btnGetData.TabIndex = 190;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(608, 53);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 188;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(635, 50);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 189;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(505, 50);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 187;
            // 
            // btnDelivered
            // 
            this.btnDelivered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelivered.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelivered.Enabled = false;
            this.btnDelivered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivered.Location = new System.Drawing.Point(887, 201);
            this.btnDelivered.Name = "btnDelivered";
            this.btnDelivered.Size = new System.Drawing.Size(112, 25);
            this.btnDelivered.TabIndex = 185;
            this.btnDelivered.Text = "Delivered";
            this.btnDelivered.UseVisualStyleBackColor = true;
            this.btnDelivered.Click += new System.EventHandler(this.btnDelivered_Click);
            // 
            // btnApproval
            // 
            this.btnApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproval.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApproval.Enabled = false;
            this.btnApproval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproval.Location = new System.Drawing.Point(887, 170);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(112, 25);
            this.btnApproval.TabIndex = 184;
            this.btnApproval.Text = "Approval";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnReplacement
            // 
            this.btnReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplacement.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReplacement.Enabled = false;
            this.btnReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacement.Location = new System.Drawing.Point(887, 124);
            this.btnReplacement.Name = "btnReplacement";
            this.btnReplacement.Size = new System.Drawing.Size(112, 40);
            this.btnReplacement.TabIndex = 183;
            this.btnReplacement.Text = "Assessment Processing";
            this.btnReplacement.UseVisualStyleBackColor = true;
            this.btnReplacement.Click += new System.EventHandler(this.btnReplacement_Click);
            // 
            // btLogistic
            // 
            this.btLogistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLogistic.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btLogistic.Enabled = false;
            this.btLogistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogistic.Location = new System.Drawing.Point(887, 94);
            this.btLogistic.Name = "btLogistic";
            this.btLogistic.Size = new System.Drawing.Size(112, 25);
            this.btLogistic.TabIndex = 182;
            this.btLogistic.Text = "Logistic Recieve";
            this.btLogistic.UseVisualStyleBackColor = true;
            this.btLogistic.Click += new System.EventHandler(this.btLogistic_Click);
            // 
            // ClaimedForMonth
            // 
            this.ClaimedForMonth.Text = "ClaimedForMonth";
            this.ClaimedForMonth.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Customer Name";
            this.CustomerName.Width = 200;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Text = "CustomerCode";
            this.CustomerCode.Width = 100;
            // 
            // TerritoryName
            // 
            this.TerritoryName.Text = "Territory Name";
            this.TerritoryName.Width = 100;
            // 
            // AreaName
            // 
            this.AreaName.Text = "Area Name";
            this.AreaName.Width = 80;
            // 
            // EntryDate
            // 
            this.EntryDate.Text = "Entry Date";
            this.EntryDate.Width = 87;
            // 
            // lvwReplaceClaims
            // 
            this.lvwReplaceClaims.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReplaceClaims.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RegionName,
            this.AreaName,
            this.TerritoryName,
            this.CustomerCode,
            this.CustomerName,
            this.TokenNo,
            this.ClaimedForMonth,
            this.EntryDate,
            this.ConfirmByZI,
            this.ClaimAmount,
            this.LogisticRecDate,
            this.ReplacementRecDate,
            this.ApprovalRecDate,
            this.DeliveryRecDate});
            this.lvwReplaceClaims.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwReplaceClaims.FullRowSelect = true;
            this.lvwReplaceClaims.GridLines = true;
            this.lvwReplaceClaims.HideSelection = false;
            this.lvwReplaceClaims.Location = new System.Drawing.Point(7, 93);
            this.lvwReplaceClaims.MultiSelect = false;
            this.lvwReplaceClaims.Name = "lvwReplaceClaims";
            this.lvwReplaceClaims.Size = new System.Drawing.Size(874, 337);
            this.lvwReplaceClaims.TabIndex = 181;
            this.lvwReplaceClaims.UseCompatibleStateImageBehavior = false;
            this.lvwReplaceClaims.View = System.Windows.Forms.View.Details;
            this.lvwReplaceClaims.SelectedIndexChanged += new System.EventHandler(this.lvwReplaceClaims_SelectedIndexChanged);
            this.lvwReplaceClaims.Click += new System.EventHandler(this.lvwReplaceClaims_Click);
            // 
            // RegionName
            // 
            this.RegionName.Text = "RegionName";
            // 
            // TokenNo
            // 
            this.TokenNo.Text = "TokenNo";
            // 
            // ConfirmByZI
            // 
            this.ConfirmByZI.Text = "ConfirmByZI/ZSM";
            // 
            // ClaimAmount
            // 
            this.ClaimAmount.Text = "Claim Amount";
            // 
            // LogisticRecDate
            // 
            this.LogisticRecDate.Text = "LogisticRecDate";
            // 
            // ReplacementRecDate
            // 
            this.ReplacementRecDate.Text = "Ass Process Date";
            // 
            // ApprovalRecDate
            // 
            this.ApprovalRecDate.Text = "ApprovalRecDate";
            // 
            // DeliveryRecDate
            // 
            this.DeliveryRecDate.Text = "DeliveryRecDate";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightSalmon;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(117, 433);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 13);
            this.label15.TabIndex = 193;
            this.label15.Text = "Assessment Processing";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Cyan;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(298, 433);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 194;
            this.label13.Text = "Delivered";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Plum;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 433);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 195;
            this.label12.Text = "Recieved By Logistic";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 196;
            this.label1.Text = "Approved";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(887, 263);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 25);
            this.btnPrint.TabIndex = 197;
            this.btnPrint.Text = "Print Summary";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEditDate
            // 
            this.btnEditDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditDate.Enabled = false;
            this.btnEditDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDate.Location = new System.Drawing.Point(887, 232);
            this.btnEditDate.Name = "btnEditDate";
            this.btnEditDate.Size = new System.Drawing.Size(112, 25);
            this.btnEditDate.TabIndex = 198;
            this.btnEditDate.Text = "Edit Date";
            this.btnEditDate.UseVisualStyleBackColor = true;
            this.btnEditDate.Click += new System.EventHandler(this.btnEditDate_Click);
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.btnSaveDate);
            this.pnlDate.Controls.Add(this.lblDateEdit);
            this.pnlDate.Controls.Add(this.dateTimePicker1);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDate.Location = new System.Drawing.Point(0, 449);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(1007, 47);
            this.pnlDate.TabIndex = 199;
            // 
            // btnSaveDate
            // 
            this.btnSaveDate.Location = new System.Drawing.Point(194, 13);
            this.btnSaveDate.Name = "btnSaveDate";
            this.btnSaveDate.Size = new System.Drawing.Size(73, 23);
            this.btnSaveDate.TabIndex = 202;
            this.btnSaveDate.Text = "Save";
            this.btnSaveDate.UseVisualStyleBackColor = true;
            this.btnSaveDate.Click += new System.EventHandler(this.btnSaveDate_Click);
            // 
            // lblDateEdit
            // 
            this.lblDateEdit.AutoSize = true;
            this.lblDateEdit.ForeColor = System.Drawing.Color.Red;
            this.lblDateEdit.Location = new System.Drawing.Point(26, 18);
            this.lblDateEdit.Name = "lblDateEdit";
            this.lblDateEdit.Size = new System.Drawing.Size(51, 13);
            this.lblDateEdit.TabIndex = 201;
            this.lblDateEdit.Text = "Edit Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 200;
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Location = new System.Drawing.Point(104, 53);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(100, 20);
            this.txtTokenNo.TabIndex = 200;
            this.txtTokenNo.TextChanged += new System.EventHandler(this.txtTokenNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 201;
            this.label2.Text = "Token No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(292, 51);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 203;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(465, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 204;
            this.label4.Text = "From";
            // 
            // btnSKUrpt
            // 
            this.btnSKUrpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSKUrpt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSKUrpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSKUrpt.Location = new System.Drawing.Point(887, 294);
            this.btnSKUrpt.Name = "btnSKUrpt";
            this.btnSKUrpt.Size = new System.Drawing.Size(112, 36);
            this.btnSKUrpt.TabIndex = 205;
            this.btnSKUrpt.Text = "Print TokenWise Report";
            this.btnSKUrpt.UseVisualStyleBackColor = true;
            this.btnSKUrpt.Click += new System.EventHandler(this.btnSKUrpt_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(104, 22);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(383, 25);
            this.ctlCustomer1.TabIndex = 192;
            // 
            // frmReplacementMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 496);
            this.Controls.Add(this.btnSKUrpt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTokenNo);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.btnEditDate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lblCustCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnDelivered);
            this.Controls.Add(this.btnApproval);
            this.Controls.Add(this.btnReplacement);
            this.Controls.Add(this.btLogistic);
            this.Controls.Add(this.lvwReplaceClaims);
            this.Name = "frmReplacementMonitoring";
            this.Text = "frmReplacementMonitoring";
            this.Load += new System.EventHandler(this.frmReplacementMonitoring_Load);
            this.Click += new System.EventHandler(this.frmReplacementMonitoring_Click);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnDelivered;
        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.Button btnReplacement;
        private System.Windows.Forms.Button btLogistic;
        private System.Windows.Forms.ColumnHeader ClaimedForMonth;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader CustomerCode;
        private System.Windows.Forms.ColumnHeader TerritoryName;
        private System.Windows.Forms.ColumnHeader AreaName;
        private System.Windows.Forms.ColumnHeader EntryDate;
        private System.Windows.Forms.ListView lvwReplaceClaims;
        private System.Windows.Forms.ColumnHeader ConfirmByZI;
        private System.Windows.Forms.ColumnHeader ClaimAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader RegionName;
        private System.Windows.Forms.ColumnHeader LogisticRecDate;
        private System.Windows.Forms.ColumnHeader ReplacementRecDate;
        private System.Windows.Forms.ColumnHeader ApprovalRecDate;
        private System.Windows.Forms.ColumnHeader DeliveryRecDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader TokenNo;
        private System.Windows.Forms.Button btnEditDate;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label lblDateEdit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSaveDate;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSKUrpt;
    }
}