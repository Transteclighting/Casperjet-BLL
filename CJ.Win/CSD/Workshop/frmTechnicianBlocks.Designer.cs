namespace CJ.Win.CSD.Workshop
{
    partial class frmTechnicianBlocks
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwCSDTechnicianBlock = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colTechnicianName = new System.Windows.Forms.ColumnHeader();
            this.colFromDate = new System.Windows.Forms.ColumnHeader();
            this.colToDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colIsFullDay = new System.Windows.Forms.ColumnHeader();
            this.colFromTime = new System.Windows.Forms.ColumnHeader();
            this.colToTime = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colCreateBy = new System.Windows.Forms.ColumnHeader();
            this.colApprovedDate = new System.Windows.Forms.ColumnHeader();
            this.colApprovedBy = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(667, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(667, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 28);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(667, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 28);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwCSDTechnicianBlock
            // 
            this.lvwCSDTechnicianBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDTechnicianBlock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colTechnicianName,
            this.colFromDate,
            this.colToDate,
            this.colStatus,
            this.colIsFullDay,
            this.colFromTime,
            this.colToTime,
            this.colCreateDate,
            this.colCreateBy,
            this.colApprovedDate,
            this.colApprovedBy,
            this.colRemarks});
            this.lvwCSDTechnicianBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDTechnicianBlock.FullRowSelect = true;
            this.lvwCSDTechnicianBlock.GridLines = true;
            this.lvwCSDTechnicianBlock.HideSelection = false;
            this.lvwCSDTechnicianBlock.Location = new System.Drawing.Point(12, 41);
            this.lvwCSDTechnicianBlock.MultiSelect = false;
            this.lvwCSDTechnicianBlock.Name = "lvwCSDTechnicianBlock";
            this.lvwCSDTechnicianBlock.Size = new System.Drawing.Size(649, 360);
            this.lvwCSDTechnicianBlock.TabIndex = 10;
            this.lvwCSDTechnicianBlock.UseCompatibleStateImageBehavior = false;
            this.lvwCSDTechnicianBlock.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            // 
            // colTechnicianName
            // 
            this.colTechnicianName.Text = "Technician Name";
            this.colTechnicianName.Width = 122;
            // 
            // colFromDate
            // 
            this.colFromDate.Text = "From Date";
            this.colFromDate.Width = 141;
            // 
            // colToDate
            // 
            this.colToDate.Text = "To Date";
            this.colToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colToDate.Width = 132;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // colIsFullDay
            // 
            this.colIsFullDay.Text = "Is Full Day";
            this.colIsFullDay.Width = 100;
            // 
            // colFromTime
            // 
            this.colFromTime.Text = "From Time";
            this.colFromTime.Width = 100;
            // 
            // colToTime
            // 
            this.colToTime.Text = "To Time";
            this.colToTime.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 150;
            // 
            // colCreateBy
            // 
            this.colCreateBy.Text = "Create By";
            this.colCreateBy.Width = 150;
            // 
            // colApprovedDate
            // 
            this.colApprovedDate.Text = "Approved Date";
            this.colApprovedDate.Width = 150;
            // 
            // colApprovedBy
            // 
            this.colApprovedBy.Text = "Approved By";
            this.colApprovedBy.Width = 150;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(667, 101);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.Location = new System.Drawing.Point(667, 130);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(101, 28);
            this.btnApproved.TabIndex = 12;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(77, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Create";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Approved";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(60, 13);
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Block Date";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(80, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtFromDate.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Technician Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(292, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 47;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(442, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 22);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 200;
            // 
            // frmTechnicianBlocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 426);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lvwCSDTechnicianBlock);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmTechnicianBlocks";
            this.Text = "frmTechnicianBlocks";
            this.Load += new System.EventHandler(this.frmTechnicianBlocks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwCSDTechnicianBlock;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colFromDate;
        private System.Windows.Forms.ColumnHeader colToDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader colIsFullDay;
        private System.Windows.Forms.ColumnHeader colFromTime;
        private System.Windows.Forms.ColumnHeader colToTime;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colCreateBy;
        private System.Windows.Forms.ColumnHeader colApprovedDate;
        private System.Windows.Forms.ColumnHeader colApprovedBy;
        private System.Windows.Forms.ColumnHeader colRemarks;
    }
}