namespace CJ.Win
{
    partial class frmISVPartsRequisition
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
            this.dgvRequisitionItem = new System.Windows.Forms.DataGridView();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindParts = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnJobSearch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReportNo = new System.Windows.Forms.TextBox();
            this.dtPrepareDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblLineItem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequisitionItem
            // 
            this.dgvRequisitionItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequisitionItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisitionItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.btnFindParts,
            this.txtSparePartName,
            this.txtSalePrice,
            this.txtQty,
            this.txtJobNo,
            this.btnJobSearch,
            this.txtProductName,
            this.SparePartID,
            this.txtJobID,
            this.colID});
            this.dgvRequisitionItem.Location = new System.Drawing.Point(5, 102);
            this.dgvRequisitionItem.Name = "dgvRequisitionItem";
            this.dgvRequisitionItem.Size = new System.Drawing.Size(745, 280);
            this.dgvRequisitionItem.TabIndex = 37;
            this.dgvRequisitionItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisitionItem_CellValueChanged);
            this.dgvRequisitionItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisitionItem_CellContentClick);
            // 
            // txtSparePartCode
            // 
            this.txtSparePartCode.Frozen = true;
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            this.txtSparePartCode.Width = 95;
            // 
            // btnFindParts
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindParts.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindParts.Frozen = true;
            this.btnFindParts.HeaderText = "?";
            this.btnFindParts.Name = "btnFindParts";
            this.btnFindParts.Text = "...";
            this.btnFindParts.Width = 35;
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtSparePartName.Frozen = true;
            this.txtSparePartName.HeaderText = "Spare Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 160;
            // 
            // txtSalePrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSalePrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtSalePrice.HeaderText = "Unit Price";
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.ReadOnly = true;
            this.txtSalePrice.Width = 50;
            // 
            // txtQty
            // 
            this.txtQty.HeaderText = "Qty";
            this.txtQty.Name = "txtQty";
            this.txtQty.Width = 50;
            // 
            // txtJobNo
            // 
            this.txtJobNo.HeaderText = "Job No";
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Width = 75;
            // 
            // btnJobSearch
            // 
            this.btnJobSearch.HeaderText = "?";
            this.btnJobSearch.Name = "btnJobSearch";
            this.btnJobSearch.Width = 35;
            // 
            // txtProductName
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductName.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 200;
            // 
            // SparePartID
            // 
            this.SparePartID.HeaderText = "Spare Part ID";
            this.SparePartID.Name = "SparePartID";
            this.SparePartID.Visible = false;
            // 
            // txtJobID
            // 
            this.txtJobID.HeaderText = "Job ID";
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Visible = false;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(352, 45);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(133, 20);
            this.txtSerialNo.TabIndex = 199;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 198;
            this.label9.Text = "Serial No";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceiveDate.Location = new System.Drawing.Point(148, 18);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(117, 20);
            this.dtReceiveDate.TabIndex = 197;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 196;
            this.label5.Text = "Receive Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 195;
            this.label3.Text = "Report No";
            // 
            // txtReportNo
            // 
            this.txtReportNo.Location = new System.Drawing.Point(352, 18);
            this.txtReportNo.Name = "txtReportNo";
            this.txtReportNo.Size = new System.Drawing.Size(133, 20);
            this.txtReportNo.TabIndex = 194;
            // 
            // dtPrepareDate
            // 
            this.dtPrepareDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPrepareDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPrepareDate.Location = new System.Drawing.Point(148, 44);
            this.dtPrepareDate.Name = "dtPrepareDate";
            this.dtPrepareDate.Size = new System.Drawing.Size(117, 20);
            this.dtPrepareDate.TabIndex = 201;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Requisition Prepare Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 202;
            this.label2.Text = "Inter Service";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(645, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 204;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(534, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 203;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 206;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(74, 419);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(645, 20);
            this.txtRemarks.TabIndex = 205;
            // 
            // lblLineItem
            // 
            this.lblLineItem.AutoSize = true;
            this.lblLineItem.Location = new System.Drawing.Point(132, 393);
            this.lblLineItem.Name = "lblLineItem";
            this.lblLineItem.Size = new System.Drawing.Size(13, 13);
            this.lblLineItem.TabIndex = 207;
            this.lblLineItem.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 208;
            this.label6.Text = "Line Item = ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 210;
            this.label7.Text = "Total Qty = ";
            this.label7.Visible = false;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(473, 393);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(13, 13);
            this.lblTotalQty.TabIndex = 209;
            this.lblTotalQty.Text = "?";
            this.lblTotalQty.Visible = false;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(148, 71);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(447, 25);
            this.ctlInterService1.TabIndex = 193;
            // 
            // frmISVPartsRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 488);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLineItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPrepareDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtReceiveDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReportNo);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.dgvRequisitionItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISVPartsRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISV Parts Requisition";
            this.Load += new System.EventHandler(this.frmISVPartsRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequisitionItem;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReportNo;
        private System.Windows.Forms.DateTimePicker dtPrepareDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblLineItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobNo;
        private System.Windows.Forms.DataGridViewButtonColumn btnJobSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
    }
}