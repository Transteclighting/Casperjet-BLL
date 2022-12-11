namespace CJ.Win
{
    partial class frmISVPartsRequisitionCommunication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRequisitionItemCommu = new System.Windows.Forms.DataGridView();
            this.ChkIsCommu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtISVCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtISVName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequisitionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.txtSerialNos = new System.Windows.Forms.TextBox();
            this.lblRequisitionNo = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRequisitionIDs = new System.Windows.Forms.TextBox();
            this.txtJobNos = new System.Windows.Forms.TextBox();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReportNos = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItemCommu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRequisitionItemCommu
            // 
            this.dgvRequisitionItemCommu.AllowUserToAddRows = false;
            this.dgvRequisitionItemCommu.AllowUserToDeleteRows = false;
            this.dgvRequisitionItemCommu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequisitionItemCommu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisitionItemCommu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChkIsCommu,
            this.txtSparePartCode,
            this.txtSparePartName,
            this.txtQty,
            this.txtJobNo,
            this.txtRemarks,
            this.txtStatus,
            this.txtProductName,
            this.txtEDD,
            this.txtISVCode,
            this.txtISVName,
            this.txtRequisitionID,
            this.txtSerialNo,
            this.txtReportNo,
            this.txtID});
            this.dgvRequisitionItemCommu.Location = new System.Drawing.Point(20, 101);
            this.dgvRequisitionItemCommu.Name = "dgvRequisitionItemCommu";
            this.dgvRequisitionItemCommu.Size = new System.Drawing.Size(744, 231);
            this.dgvRequisitionItemCommu.TabIndex = 39;
            // 
            // ChkIsCommu
            // 
            this.ChkIsCommu.Frozen = true;
            this.ChkIsCommu.HeaderText = "IsCommu?";
            this.ChkIsCommu.Name = "ChkIsCommu";
            this.ChkIsCommu.Width = 60;
            // 
            // txtSparePartCode
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartCode.DefaultCellStyle = dataGridViewCellStyle13;
            this.txtSparePartCode.Frozen = true;
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            this.txtSparePartCode.ReadOnly = true;
            this.txtSparePartCode.Width = 95;
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle14;
            this.txtSparePartName.Frozen = true;
            this.txtSparePartName.HeaderText = "Spare Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 160;
            // 
            // txtQty
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtQty.DefaultCellStyle = dataGridViewCellStyle15;
            this.txtQty.Frozen = true;
            this.txtQty.HeaderText = "Claim Qty";
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Width = 50;
            // 
            // txtJobNo
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtJobNo.DefaultCellStyle = dataGridViewCellStyle16;
            this.txtJobNo.HeaderText = "Job No";
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Width = 75;
            // 
            // txtRemarks
            // 
            this.txtRemarks.HeaderText = "Remarks";
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Width = 160;
            // 
            // txtStatus
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStatus.DefaultCellStyle = dataGridViewCellStyle17;
            this.txtStatus.HeaderText = "Status";
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            // 
            // txtProductName
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductName.DefaultCellStyle = dataGridViewCellStyle18;
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 150;
            // 
            // txtEDD
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEDD.DefaultCellStyle = dataGridViewCellStyle19;
            this.txtEDD.HeaderText = "EDD";
            this.txtEDD.Name = "txtEDD";
            this.txtEDD.ReadOnly = true;
            this.txtEDD.Width = 70;
            // 
            // txtISVCode
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtISVCode.DefaultCellStyle = dataGridViewCellStyle20;
            this.txtISVCode.HeaderText = "ISVCode";
            this.txtISVCode.Name = "txtISVCode";
            this.txtISVCode.ReadOnly = true;
            this.txtISVCode.Width = 50;
            // 
            // txtISVName
            // 
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtISVName.DefaultCellStyle = dataGridViewCellStyle21;
            this.txtISVName.HeaderText = "Inter Service Name";
            this.txtISVName.Name = "txtISVName";
            this.txtISVName.ReadOnly = true;
            this.txtISVName.Width = 150;
            // 
            // txtRequisitionID
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRequisitionID.DefaultCellStyle = dataGridViewCellStyle22;
            this.txtRequisitionID.HeaderText = "Requisition ID";
            this.txtRequisitionID.Name = "txtRequisitionID";
            this.txtRequisitionID.ReadOnly = true;
            this.txtRequisitionID.Width = 50;
            // 
            // txtSerialNo
            // 
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSerialNo.DefaultCellStyle = dataGridViewCellStyle23;
            this.txtSerialNo.HeaderText = "Serial No";
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Width = 60;
            // 
            // txtReportNo
            // 
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtReportNo.DefaultCellStyle = dataGridViewCellStyle24;
            this.txtReportNo.HeaderText = "Report No";
            this.txtReportNo.Name = "txtReportNo";
            this.txtReportNo.ReadOnly = true;
            this.txtReportNo.Width = 60;
            // 
            // txtID
            // 
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(663, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 208;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(552, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 207;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(62, 78);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(70, 17);
            this.ckbSelect.TabIndex = 209;
            this.ckbSelect.Text = "Select All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // txtSerialNos
            // 
            this.txtSerialNos.Location = new System.Drawing.Point(232, 15);
            this.txtSerialNos.Name = "txtSerialNos";
            this.txtSerialNos.Size = new System.Drawing.Size(78, 20);
            this.txtSerialNos.TabIndex = 216;
            // 
            // lblRequisitionNo
            // 
            this.lblRequisitionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionNo.Location = new System.Drawing.Point(16, 17);
            this.lblRequisitionNo.Name = "lblRequisitionNo";
            this.lblRequisitionNo.Size = new System.Drawing.Size(87, 13);
            this.lblRequisitionNo.TabIndex = 212;
            this.lblRequisitionNo.Text = "Requisition ID";
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.Location = new System.Drawing.Point(172, 17);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(59, 13);
            this.lblSerialNo.TabIndex = 213;
            this.lblSerialNo.Text = "Serial No";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 217;
            this.label11.Text = "Inter Service";
            // 
            // txtRequisitionIDs
            // 
            this.txtRequisitionIDs.Location = new System.Drawing.Point(105, 14);
            this.txtRequisitionIDs.Name = "txtRequisitionIDs";
            this.txtRequisitionIDs.Size = new System.Drawing.Size(54, 20);
            this.txtRequisitionIDs.TabIndex = 210;
            // 
            // txtJobNos
            // 
            this.txtJobNos.Location = new System.Drawing.Point(372, 14);
            this.txtJobNos.Name = "txtJobNos";
            this.txtJobNos.Size = new System.Drawing.Size(81, 20);
            this.txtJobNos.TabIndex = 211;
            // 
            // lblJobNo
            // 
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(323, 17);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 214;
            this.lblJobNo.Text = "Job No";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 219;
            this.label4.Text = "Report No";
            // 
            // txtReportNos
            // 
            this.txtReportNos.Location = new System.Drawing.Point(535, 14);
            this.txtReportNos.Name = "txtReportNos";
            this.txtReportNos.Size = new System.Drawing.Size(81, 20);
            this.txtReportNos.TabIndex = 220;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(690, 62);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(74, 31);
            this.btnGo.TabIndex = 215;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(17, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 221;
            this.label2.Text = "Local Purchase";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(120, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 222;
            this.label1.Text = "Loan Requisition";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(229, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 223;
            this.label3.Text = "Foreign Order";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DeepPink;
            this.label5.Location = new System.Drawing.Point(321, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 224;
            this.label5.Text = "Suspend";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(414, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 225;
            this.label6.Text = "Reject";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(151, 44);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(518, 25);
            this.ctlInterService1.TabIndex = 218;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSerialNos);
            this.groupBox1.Controls.Add(this.lblRequisitionNo);
            this.groupBox1.Controls.Add(this.lblSerialNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtRequisitionIDs);
            this.groupBox1.Controls.Add(this.txtJobNos);
            this.groupBox1.Controls.Add(this.lblJobNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtReportNos);
            this.groupBox1.Location = new System.Drawing.Point(46, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 68);
            this.groupBox1.TabIndex = 226;
            this.groupBox1.TabStop = false;
            // 
            // frmISVPartsRequisitionCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 371);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvRequisitionItemCommu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISVPartsRequisitionCommunication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISV Parts Requisition Communication";
            this.Load += new System.EventHandler(this.frmISVPartsRequisitionCommunication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItemCommu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequisitionItemCommu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.TextBox txtSerialNos;
        private System.Windows.Forms.Label lblRequisitionNo;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label label11;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.TextBox txtRequisitionIDs;
        private System.Windows.Forms.TextBox txtJobNos;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReportNos;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChkIsCommu;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtISVCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtISVName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequisitionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReportNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}