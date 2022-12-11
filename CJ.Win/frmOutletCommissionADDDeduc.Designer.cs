namespace CJ.Win
{
    partial class frmOutletCommissionADDDeduc
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
            this.dgvAddDuduct = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.ColShowroomCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeducCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNetCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddDuduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddDuduct
            // 
            this.dgvAddDuduct.AllowUserToAddRows = false;
            this.dgvAddDuduct.AllowUserToDeleteRows = false;
            this.dgvAddDuduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAddDuduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddDuduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColShowroomCode,
            this.ColEmployeeCode,
            this.ColEmployeeName,
            this.ColTotalCommission,
            this.ColAddCommission,
            this.ColDeducCommission,
            this.ColNetCommission,
            this.txtEmployeeID,
            this.txtID,
            this.txtProductGroup});
            this.dgvAddDuduct.Location = new System.Drawing.Point(25, 48);
            this.dgvAddDuduct.Name = "dgvAddDuduct";
            this.dgvAddDuduct.Size = new System.Drawing.Size(739, 310);
            this.dgvAddDuduct.TabIndex = 44;
            this.dgvAddDuduct.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(608, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(689, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.Location = new System.Drawing.Point(122, 413);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(37, 13);
            this.lblAmountInWord.TabIndex = 49;
            this.lblAmountInWord.Text = "?????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "AmountInWord:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(34, 378);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(82, 13);
            this.lblTotalAmount.TabIndex = 214;
            this.lblTotalAmount.Text = "TotalAmount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 216;
            this.label2.Text = "Month:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(74, 19);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(13, 13);
            this.lblMonth.TabIndex = 217;
            this.lblMonth.Text = "?";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(193, 19);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(13, 13);
            this.lblYear.TabIndex = 218;
            this.lblYear.Text = "?";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(313, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(13, 13);
            this.lblType.TabIndex = 219;
            this.lblType.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(146, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 220;
            this.label6.Text = "Year: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(264, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 221;
            this.label7.Text = "Type: ";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(122, 378);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(28, 13);
            this.lblTotalAmt.TabIndex = 222;
            this.lblTotalAmt.Text = "???";
            // 
            // ColShowroomCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColShowroomCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColShowroomCode.HeaderText = "ShowroomCode";
            this.ColShowroomCode.Name = "ColShowroomCode";
            this.ColShowroomCode.ReadOnly = true;
            // 
            // ColEmployeeCode
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColEmployeeCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColEmployeeCode.HeaderText = "EmployeeCode";
            this.ColEmployeeCode.Name = "ColEmployeeCode";
            this.ColEmployeeCode.ReadOnly = true;
            // 
            // ColEmployeeName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColEmployeeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColEmployeeName.HeaderText = "EmployeeName";
            this.ColEmployeeName.Name = "ColEmployeeName";
            this.ColEmployeeName.ReadOnly = true;
            // 
            // ColTotalCommission
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColTotalCommission.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalCommission.HeaderText = "TotalCommission";
            this.ColTotalCommission.Name = "ColTotalCommission";
            this.ColTotalCommission.ReadOnly = true;
            // 
            // ColAddCommission
            // 
            this.ColAddCommission.HeaderText = "AddCommission";
            this.ColAddCommission.Name = "ColAddCommission";
            // 
            // ColDeducCommission
            // 
            this.ColDeducCommission.HeaderText = "DeductCommission";
            this.ColDeducCommission.Name = "ColDeducCommission";
            // 
            // ColNetCommission
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColNetCommission.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColNetCommission.HeaderText = "NetCommission";
            this.ColNetCommission.Name = "ColNetCommission";
            this.ColNetCommission.ReadOnly = true;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.HeaderText = "EmployeeID";
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Visible = false;
            // 
            // txtID
            // 
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.Visible = false;
            // 
            // txtProductGroup
            // 
            this.txtProductGroup.HeaderText = "ProductGroup";
            this.txtProductGroup.Name = "txtProductGroup";
            // 
            // frmOutletCommissionADDDeduc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 449);
            this.Controls.Add(this.lblTotalAmt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAddDuduct);
            this.Name = "frmOutletCommissionADDDeduc";
            this.Text = "frmOutletCommissionADDDeduc";
            this.Load += new System.EventHandler(this.frmOutletCommissionADDDeduc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddDuduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddDuduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColShowroomCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeducCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNetCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductGroup;

    }
}