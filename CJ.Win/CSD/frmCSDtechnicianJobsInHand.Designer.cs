namespace CJ.Win.CSD
{
    partial class frmCSDtechnicianJobsInHand
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
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblTechnicianName = new System.Windows.Forms.Label();
            this.lvwTechnicianJobInHand = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTimeStart = new System.Windows.Forms.ColumnHeader();
            this.colTimeEnd = new System.Windows.Forms.ColumnHeader();
            this.ColJobNo = new System.Windows.Forms.ColumnHeader();
            this.colJobType = new System.Windows.Forms.ColumnHeader();
            this.colCustomerAddress = new System.Windows.Forms.ColumnHeader();
            this.colThana = new System.Windows.Forms.ColumnHeader();
            this.colDistrict = new System.Windows.Forms.ColumnHeader();
            this.lblThirdPartyName = new System.Windows.Forms.Label();
            this.lvwTechnicianBlock = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colFromdate = new System.Windows.Forms.ColumnHeader();
            this.colToDate = new System.Windows.Forms.ColumnHeader();
            this.colFullDay = new System.Windows.Forms.ColumnHeader();
            this.colFromTime = new System.Windows.Forms.ColumnHeader();
            this.colToTime = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colCreateBy = new System.Windows.Forms.ColumnHeader();
            this.colApprovedDate = new System.Windows.Forms.ColumnHeader();
            this.colApprovedBy = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Technician Name";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(40, 27);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(58, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Third Party";
            // 
            // lblTechnicianName
            // 
            this.lblTechnicianName.AutoSize = true;
            this.lblTechnicianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechnicianName.Location = new System.Drawing.Point(101, 9);
            this.lblTechnicianName.Name = "lblTechnicianName";
            this.lblTechnicianName.Size = new System.Drawing.Size(14, 13);
            this.lblTechnicianName.TabIndex = 0;
            this.lblTechnicianName.Text = "?";
            // 
            // lvwTechnicianJobInHand
            // 
            this.lvwTechnicianJobInHand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colTimeStart,
            this.colTimeEnd,
            this.ColJobNo,
            this.colJobType,
            this.colCustomerAddress,
            this.colThana,
            this.colDistrict});
            this.lvwTechnicianJobInHand.FullRowSelect = true;
            this.lvwTechnicianJobInHand.GridLines = true;
            this.lvwTechnicianJobInHand.Location = new System.Drawing.Point(9, 65);
            this.lvwTechnicianJobInHand.Name = "lvwTechnicianJobInHand";
            this.lvwTechnicianJobInHand.Size = new System.Drawing.Size(790, 276);
            this.lvwTechnicianJobInHand.TabIndex = 3;
            this.lvwTechnicianJobInHand.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicianJobInHand.View = System.Windows.Forms.View.Details;
            this.lvwTechnicianJobInHand.DoubleClick += new System.EventHandler(this.lvwTechnicianJobInHand_DoubleClick);
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 76;
            // 
            // colTimeStart
            // 
            this.colTimeStart.Text = "Time Start";
            this.colTimeStart.Width = 77;
            // 
            // colTimeEnd
            // 
            this.colTimeEnd.Text = "Time End";
            this.colTimeEnd.Width = 73;
            // 
            // ColJobNo
            // 
            this.ColJobNo.Text = "JobNo";
            this.ColJobNo.Width = 108;
            // 
            // colJobType
            // 
            this.colJobType.Text = "JobType";
            this.colJobType.Width = 105;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Text = "Customer Address";
            this.colCustomerAddress.Width = 190;
            // 
            // colThana
            // 
            this.colThana.Text = "Thana";
            this.colThana.Width = 69;
            // 
            // colDistrict
            // 
            this.colDistrict.Text = "District";
            this.colDistrict.Width = 70;
            // 
            // lblThirdPartyName
            // 
            this.lblThirdPartyName.AutoSize = true;
            this.lblThirdPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdPartyName.Location = new System.Drawing.Point(101, 27);
            this.lblThirdPartyName.Name = "lblThirdPartyName";
            this.lblThirdPartyName.Size = new System.Drawing.Size(14, 13);
            this.lblThirdPartyName.TabIndex = 2;
            this.lblThirdPartyName.Text = "?";
            // 
            // lvwTechnicianBlock
            // 
            this.lvwTechnicianBlock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colFromdate,
            this.colToDate,
            this.colFullDay,
            this.colFromTime,
            this.colToTime,
            this.colCreateDate,
            this.colCreateBy,
            this.colApprovedDate,
            this.colApprovedBy});
            this.lvwTechnicianBlock.FullRowSelect = true;
            this.lvwTechnicianBlock.GridLines = true;
            this.lvwTechnicianBlock.Location = new System.Drawing.Point(9, 371);
            this.lvwTechnicianBlock.Name = "lvwTechnicianBlock";
            this.lvwTechnicianBlock.Size = new System.Drawing.Size(790, 112);
            this.lvwTechnicianBlock.TabIndex = 4;
            this.lvwTechnicianBlock.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicianBlock.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 76;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // colFromdate
            // 
            this.colFromdate.Text = "Fromdate";
            this.colFromdate.Width = 150;
            // 
            // colToDate
            // 
            this.colToDate.Text = "ToDate";
            this.colToDate.Width = 150;
            // 
            // colFullDay
            // 
            this.colFullDay.Text = "FullDay";
            this.colFullDay.Width = 69;
            // 
            // colFromTime
            // 
            this.colFromTime.Text = "FromTime";
            this.colFromTime.Width = 100;
            // 
            // colToTime
            // 
            this.colToTime.Text = "ToTime";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Block Schedule";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jobs In Hand";
            // 
            // frmCSDtechnicianJobsInHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 486);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwTechnicianBlock);
            this.Controls.Add(this.lblThirdPartyName);
            this.Controls.Add(this.lvwTechnicianJobInHand);
            this.Controls.Add(this.lblTechnicianName);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmCSDtechnicianJobsInHand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technician Jobs In Hand";
            this.Load += new System.EventHandler(this.frmCSDtechnicianJobsInHand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblTechnicianName;
        private System.Windows.Forms.ListView lvwTechnicianJobInHand;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTimeStart;
        private System.Windows.Forms.ColumnHeader colTimeEnd;
        private System.Windows.Forms.ColumnHeader ColJobNo;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.Label lblThirdPartyName;
        private System.Windows.Forms.ColumnHeader colCustomerAddress;
        private System.Windows.Forms.ColumnHeader colThana;
        private System.Windows.Forms.ColumnHeader colDistrict;
        private System.Windows.Forms.ListView lvwTechnicianBlock;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colFromdate;
        private System.Windows.Forms.ColumnHeader colToDate;
        private System.Windows.Forms.ColumnHeader colFromTime;
        private System.Windows.Forms.ColumnHeader colToTime;
        private System.Windows.Forms.ColumnHeader colFullDay;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colCreateBy;
        private System.Windows.Forms.ColumnHeader colApprovedDate;
        private System.Windows.Forms.ColumnHeader colApprovedBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}