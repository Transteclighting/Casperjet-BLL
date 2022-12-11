namespace CJ.Win.Promotion
{
    partial class frmSPDiscountScratchCards
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
            this.btnIsActive = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPromoName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPromoNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEditCentral = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.colEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coldescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.colPromotionNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPromotionList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnIsActive
            // 
            this.btnIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIsActive.Location = new System.Drawing.Point(787, 256);
            this.btnIsActive.Name = "btnIsActive";
            this.btnIsActive.Size = new System.Drawing.Size(83, 27);
            this.btnIsActive.TabIndex = 121;
            this.btnIsActive.Text = "Active";
            this.btnIsActive.UseVisualStyleBackColor = true;
            this.btnIsActive.Click += new System.EventHandler(this.btnIsActive_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnApprove.Location = new System.Drawing.Point(787, 190);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(83, 27);
            this.btnApprove.TabIndex = 120;
            this.btnApprove.Tag = "M1.15";
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(283, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 108;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(62, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 106;
            this.label5.Text = "IsActive";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(330, 64);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbStatus.TabIndex = 109;
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(115, 64);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(144, 23);
            this.cmbIsActive.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(62, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 119;
            this.label4.Text = "Approved";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MistyRose;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(12, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 118;
            this.label3.Text = "Create";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 110;
            this.label2.Text = "Scratch Card:";
            // 
            // txtPromoName
            // 
            this.txtPromoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPromoName.Location = new System.Drawing.Point(115, 95);
            this.txtPromoName.Name = "txtPromoName";
            this.txtPromoName.Size = new System.Drawing.Size(345, 21);
            this.txtPromoName.TabIndex = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 104;
            this.label1.Text = "Scratch Card No:";
            // 
            // txtPromoNo
            // 
            this.txtPromoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPromoNo.Location = new System.Drawing.Point(115, 37);
            this.txtPromoNo.Name = "txtPromoNo";
            this.txtPromoNo.Size = new System.Drawing.Size(345, 21);
            this.txtPromoNo.TabIndex = 105;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(787, 371);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 27);
            this.btnClose.TabIndex = 117;
            this.btnClose.Tag = "M1.15";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnEditCentral
            // 
            this.btnEditCentral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCentral.Enabled = false;
            this.btnEditCentral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnEditCentral.Location = new System.Drawing.Point(787, 157);
            this.btnEditCentral.Name = "btnEditCentral";
            this.btnEditCentral.Size = new System.Drawing.Size(83, 27);
            this.btnEditCentral.TabIndex = 115;
            this.btnEditCentral.Tag = "M1.15";
            this.btnEditCentral.Text = "Edit";
            this.btnEditCentral.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAdd.Location = new System.Drawing.Point(787, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 27);
            this.btnAdd.TabIndex = 114;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Enabled = false;
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btPrint.Location = new System.Drawing.Point(787, 223);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(83, 27);
            this.btPrint.TabIndex = 116;
            this.btPrint.Tag = "M1.15";
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnGo.Location = new System.Drawing.Point(466, 92);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 26);
            this.btnGo.TabIndex = 112;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTo.Location = new System.Drawing.Point(289, 13);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 102;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDate.Location = new System.Drawing.Point(73, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 15);
            this.lblDate.TabIndex = 100;
            this.lblDate.Text = "From";
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 108;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "Start Date";
            this.colStartDate.Width = 104;
            // 
            // coldescription
            // 
            this.coldescription.Text = "ScratchCard Name";
            this.coldescription.Width = 227;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(115, 10);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 21);
            this.dtFromDate.TabIndex = 101;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 91;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(316, 11);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 21);
            this.dtToDate.TabIndex = 103;
            // 
            // colPromotionNo
            // 
            this.colPromotionNo.Text = "ScratchCard Code";
            this.colPromotionNo.Width = 115;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            this.colIsActive.Width = 91;
            // 
            // lvwPromotionList
            // 
            this.lvwPromotionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPromotionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPromotionNo,
            this.coldescription,
            this.colStartDate,
            this.colEndDate,
            this.colIsActive,
            this.colStatus});
            this.lvwPromotionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lvwPromotionList.FullRowSelect = true;
            this.lvwPromotionList.GridLines = true;
            this.lvwPromotionList.HideSelection = false;
            this.lvwPromotionList.Location = new System.Drawing.Point(12, 124);
            this.lvwPromotionList.MultiSelect = false;
            this.lvwPromotionList.Name = "lvwPromotionList";
            this.lvwPromotionList.Size = new System.Drawing.Size(769, 274);
            this.lvwPromotionList.TabIndex = 113;
            this.lvwPromotionList.UseCompatibleStateImageBehavior = false;
            this.lvwPromotionList.View = System.Windows.Forms.View.Details;
            this.lvwPromotionList.SelectedIndexChanged += new System.EventHandler(this.lvwPromotionList_SelectedIndexChanged);
            // 
            // frmSPDiscountScratchCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 475);
            this.Controls.Add(this.btnIsActive);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPromoName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPromoNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEditCentral);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.lvwPromotionList);
            this.Name = "frmSPDiscountScratchCards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSPDiscountScratchCards";
            this.Load += new System.EventHandler(this.frmSPDiscountScratchCards_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIsActive;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPromoName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPromoNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEditCentral;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ColumnHeader coldescription;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ColumnHeader colPromotionNo;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ListView lvwPromotionList;
    }
}