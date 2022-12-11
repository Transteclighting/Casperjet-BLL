namespace CJ.Win
{
    partial class frmPartsIssueToJob
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lvwSPIssues = new System.Windows.Forms.ListView();
            this.colPartCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIssueQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIssuedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvIssuePart = new System.Windows.Forms.DataGridView();
            this.btnFindParts = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkIsUSP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlJobAll1 = new CJ.Win.ctlCSDJob();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromStoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreviousQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPTranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSPQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePart)).BeginInit();
            this.SuspendLayout();
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
            this.lvwSPIssues.Location = new System.Drawing.Point(12, 296);
            this.lvwSPIssues.MultiSelect = false;
            this.lvwSPIssues.Name = "lvwSPIssues";
            this.lvwSPIssues.Size = new System.Drawing.Size(824, 153);
            this.lvwSPIssues.TabIndex = 9;
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
            this.colIssuedDate.Text = "Last Issued Date";
            this.colIssuedDate.Width = 96;
            // 
            // dgvIssuePart
            // 
            this.dgvIssuePart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssuePart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssuePart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuePart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.btnFindParts,
            this.txtSparePartName,
            this.txtCurrentStock,
            this.txtIssueQty,
            this.txtUnitSP,
            this.txtTotalPrice,
            this.SparePartID,
            this.txtCostPrice,
            this.colFromStoreID,
            this.colPreviousQty,
            this.colSPTranID,
            this.chkIsUSP,
            this.colUSPQty});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIssuePart.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvIssuePart.Location = new System.Drawing.Point(12, 73);
            this.dgvIssuePart.Name = "dgvIssuePart";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssuePart.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvIssuePart.Size = new System.Drawing.Size(824, 213);
            this.dgvIssuePart.TabIndex = 8;
            this.dgvIssuePart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellContentClick);
            this.dgvIssuePart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellValueChanged);
            // 
            // btnFindParts
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.btnFindParts.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnFindParts.HeaderText = "?";
            this.btnFindParts.Name = "btnFindParts";
            this.btnFindParts.Text = "...";
            this.btnFindParts.Width = 35;
            // 
            // chkIsUSP
            // 
            this.chkIsUSP.HeaderText = "Is USP?";
            this.chkIsUSP.Name = "chkIsUSP";
            this.chkIsUSP.Visible = false;
            this.chkIsUSP.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(747, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(656, 454);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(89, 26);
            this.btnIssue.TabIndex = 11;
            this.btnIssue.Text = "&Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Location = new System.Drawing.Point(10, 14);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblJobNo.Size = new System.Drawing.Size(13, 13);
            this.lblJobNo.TabIndex = 0;
            this.lblJobNo.Text = "?";
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnician.FormattingEnabled = true;
            this.cmbTechnician.Location = new System.Drawing.Point(106, 12);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(235, 21);
            this.cmbTechnician.TabIndex = 3;
            this.cmbTechnician.SelectedIndexChanged += new System.EventHandler(this.cmbTechnician_SelectedIndexChanged);
            this.cmbTechnician.SelectedValueChanged += new System.EventHandler(this.cmbTechnician_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(106, 43);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(444, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(106, 12);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(235, 21);
            this.cmbBranch.TabIndex = 1;
            // 
            // cmbStore
            // 
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(619, 42);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(217, 21);
            this.cmbStore.TabIndex = 7;
            this.cmbStore.SelectedIndexChanged += new System.EventHandler(this.cmbStore_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Store";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(12, 454);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 26);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Part Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Part Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Current Stock";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Unit Sale Price";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Total Sale Price";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "SparePartID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "CostPrice";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "From Store ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Previous Qty";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "SPTranID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn12.HeaderText = "UPS Qty";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // ctlJobAll1
            // 
            this.ctlJobAll1.Location = new System.Drawing.Point(106, 6);
            this.ctlJobAll1.Name = "ctlJobAll1";
            this.ctlJobAll1.Size = new System.Drawing.Size(440, 31);
            this.ctlJobAll1.TabIndex = 2;
            this.ctlJobAll1.ChangeSelection += new System.EventHandler(this.ctlJobAll1_ChangeSelection);
            this.ctlJobAll1.Load += new System.EventHandler(this.ctlCSDJob1_Load);
            // 
            // txtSparePartCode
            // 
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtSparePartName.HeaderText = "Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 220;
            // 
            // txtCurrentStock
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCurrentStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtCurrentStock.HeaderText = "Current Stock";
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Width = 70;
            // 
            // txtIssueQty
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtIssueQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtIssueQty.HeaderText = "Issue Qty";
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.Width = 80;
            // 
            // txtUnitSP
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitSP.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtUnitSP.HeaderText = "Unit Sale Price";
            this.txtUnitSP.Name = "txtUnitSP";
            this.txtUnitSP.ReadOnly = true;
            this.txtUnitSP.Width = 80;
            // 
            // txtTotalPrice
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtTotalPrice.HeaderText = "Total Sale Price";
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Width = 90;
            // 
            // SparePartID
            // 
            this.SparePartID.HeaderText = "SparePartID";
            this.SparePartID.Name = "SparePartID";
            this.SparePartID.ReadOnly = true;
            this.SparePartID.Visible = false;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.HeaderText = "CostPrice";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Visible = false;
            // 
            // colFromStoreID
            // 
            this.colFromStoreID.HeaderText = "From Store ID";
            this.colFromStoreID.Name = "colFromStoreID";
            this.colFromStoreID.ReadOnly = true;
            this.colFromStoreID.Visible = false;
            // 
            // colPreviousQty
            // 
            this.colPreviousQty.HeaderText = "Previous Qty";
            this.colPreviousQty.Name = "colPreviousQty";
            this.colPreviousQty.ReadOnly = true;
            this.colPreviousQty.Visible = false;
            // 
            // colSPTranID
            // 
            this.colSPTranID.HeaderText = "SPTranID";
            this.colSPTranID.Name = "colSPTranID";
            this.colSPTranID.ReadOnly = true;
            this.colSPTranID.Visible = false;
            // 
            // colUSPQty
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colUSPQty.DefaultCellStyle = dataGridViewCellStyle8;
            this.colUSPQty.HeaderText = "USP Qty";
            this.colUSPQty.Name = "colUSPQty";
            this.colUSPQty.ReadOnly = true;
            this.colUSPQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUSPQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUSPQty.Visible = false;
            this.colUSPQty.Width = 55;
            // 
            // frmPartsIssueToJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 484);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.ctlJobAll1);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.cmbTechnician);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.dgvIssuePart);
            this.Controls.Add(this.lvwSPIssues);
            this.Name = "frmPartsIssueToJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parts Issue to Job";
            this.Load += new System.EventHandler(this.frmSparePartsReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSPIssues;
        private System.Windows.Forms.ColumnHeader colPartCode;
        private System.Windows.Forms.ColumnHeader colPartName;
        private System.Windows.Forms.ColumnHeader colIssueQty;
        private System.Windows.Forms.DataGridView dgvIssuePart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.ColumnHeader colTotalPrice;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.ComboBox cmbTechnician;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbBranch;
        private ctlCSDJob ctlJobAll1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader colIssuedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIssueQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromStoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreviousQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPTranID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkIsUSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUSPQty;
    }
}