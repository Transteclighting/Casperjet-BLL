namespace CJ.Win
{
    partial class frmInquirys
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
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtInquiryNo = new System.Windows.Forms.TextBox();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.lvwInquirys = new System.Windows.Forms.ListView();
            this.colInqueryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInqueryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceiveBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefOutletName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommunication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSolveBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWEBQuery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWebTrackNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCommunication = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.All = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtReceiveBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbIsWebQuery = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(193, 18);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 90;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(42, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 89;
            this.lblDate.Text = "Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(218, 15);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(106, 20);
            this.dtToDate.TabIndex = 88;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(79, 15);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(108, 20);
            this.dtFromDate.TabIndex = 87;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(497, 56);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(83, 26);
            this.btnGo.TabIndex = 91;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtInquiryNo
            // 
            this.txtInquiryNo.AcceptsReturn = true;
            this.txtInquiryNo.Location = new System.Drawing.Point(79, 39);
            this.txtInquiryNo.Name = "txtInquiryNo";
            this.txtInquiryNo.Size = new System.Drawing.Size(126, 20);
            this.txtInquiryNo.TabIndex = 93;
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.AutoSize = true;
            this.lblComplainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainNo.Location = new System.Drawing.Point(28, 46);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(60, 13);
            this.lblComplainNo.TabIndex = 92;
            this.lblComplainNo.Text = "Query No";
            // 
            // lvwInquirys
            // 
            this.lvwInquirys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInquirys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInqueryID,
            this.colInqueryDate,
            this.colName,
            this.colContactNo,
            this.colReceiveBy,
            this.colRefOutletName,
            this.colCommunication,
            this.colSolveBy,
            this.colWEBQuery,
            this.colWebTrackNo});
            this.lvwInquirys.FullRowSelect = true;
            this.lvwInquirys.GridLines = true;
            this.lvwInquirys.Location = new System.Drawing.Point(-1, 102);
            this.lvwInquirys.Name = "lvwInquirys";
            this.lvwInquirys.Size = new System.Drawing.Size(730, 354);
            this.lvwInquirys.TabIndex = 94;
            this.lvwInquirys.UseCompatibleStateImageBehavior = false;
            this.lvwInquirys.View = System.Windows.Forms.View.Details;
            this.lvwInquirys.DoubleClick += new System.EventHandler(this.lvwInquirys_DoubleClick);
            // 
            // colInqueryID
            // 
            this.colInqueryID.Text = "Query No";
            this.colInqueryID.Width = 69;
            // 
            // colInqueryDate
            // 
            this.colInqueryDate.Text = "Date";
            this.colInqueryDate.Width = 113;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 157;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 114;
            // 
            // colReceiveBy
            // 
            this.colReceiveBy.Text = "Receive By";
            this.colReceiveBy.Width = 77;
            // 
            // colRefOutletName
            // 
            this.colRefOutletName.Text = "Outlet";
            this.colRefOutletName.Width = 68;
            // 
            // colCommunication
            // 
            this.colCommunication.Text = "Is Commu.";
            this.colCommunication.Width = 72;
            // 
            // colSolveBy
            // 
            this.colSolveBy.Text = "Solve By";
            // 
            // colWEBQuery
            // 
            this.colWEBQuery.Text = "IsWEBQuery";
            // 
            // colWebTrackNo
            // 
            this.colWebTrackNo.Text = "WEB Track No";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(735, 264);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 27);
            this.btnDelete.TabIndex = 144;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCommunication
            // 
            this.btnCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunication.Location = new System.Drawing.Point(735, 166);
            this.btnCommunication.Name = "btnCommunication";
            this.btnCommunication.Size = new System.Drawing.Size(105, 27);
            this.btnCommunication.TabIndex = 143;
            this.btnCommunication.Tag = "M1.20";
            this.btnCommunication.Text = "Co&mmunication";
            this.btnCommunication.UseVisualStyleBackColor = true;
            this.btnCommunication.Click += new System.EventHandler(this.btnInqCommunication_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(735, 133);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 27);
            this.btnEdit.TabIndex = 141;
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
            this.btnClose.Location = new System.Drawing.Point(735, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 142;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(735, 100);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 27);
            this.btnNew.TabIndex = 138;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(330, 17);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 145;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.AcceptsReturn = true;
            this.txtName.Location = new System.Drawing.Point(294, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(136, 20);
            this.txtName.TabIndex = 147;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(244, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 146;
            this.lblName.Text = "Name";
            // 
            // txtContactNo
            // 
            this.txtContactNo.AcceptsReturn = true;
            this.txtContactNo.Location = new System.Drawing.Point(91, 66);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(126, 20);
            this.txtContactNo.TabIndex = 149;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(18, 69);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(71, 13);
            this.lblContact.TabIndex = 148;
            this.lblContact.Text = "Contact No";
            // 
            // txtReceiveBy
            // 
            this.txtReceiveBy.AcceptsReturn = true;
            this.txtReceiveBy.Location = new System.Drawing.Point(306, 66);
            this.txtReceiveBy.Name = "txtReceiveBy";
            this.txtReceiveBy.Size = new System.Drawing.Size(136, 20);
            this.txtReceiveBy.TabIndex = 151;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 150;
            this.label1.Text = "Receive By";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbIsWebQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.All);
            this.groupBox1.Controls.Add(this.txtInquiryNo);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 89);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // cmbIsWebQuery
            // 
            this.cmbIsWebQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsWebQuery.FormattingEnabled = true;
            this.cmbIsWebQuery.Location = new System.Drawing.Point(461, 15);
            this.cmbIsWebQuery.Name = "cmbIsWebQuery";
            this.cmbIsWebQuery.Size = new System.Drawing.Size(113, 21);
            this.cmbIsWebQuery.TabIndex = 152;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "Is Web Query";
            // 
            // frmInquirys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 468);
            this.Controls.Add(this.txtReceiveBy);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCommunication);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwInquirys);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInquirys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerQueries";
            this.Load += new System.EventHandler(this.frmInquirys_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtInquiryNo;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.ListView lvwInquirys;
        private System.Windows.Forms.ColumnHeader colInqueryDate;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colReceiveBy;
        private System.Windows.Forms.ColumnHeader colCommunication;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCommunication;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.ColumnHeader colInqueryID;
        private System.Windows.Forms.ColumnHeader colRefOutletName;
        private System.Windows.Forms.TextBox txtReceiveBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader colSolveBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIsWebQuery;
        private System.Windows.Forms.ColumnHeader colWEBQuery;
        private System.Windows.Forms.ColumnHeader colWebTrackNo;
    }
}