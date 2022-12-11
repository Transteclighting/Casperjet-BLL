namespace CJ.Win
{
    partial class frmVehicleScheduleHistory
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
            this.btnReplaceHistoryPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblVRID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.lvwVehicleScheduleHistroy = new System.Windows.Forms.ListView();
            this.colEntryDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTimeFrom = new System.Windows.Forms.ColumnHeader();
            this.colTimeTo = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnReplaceHistoryPrint
            // 
            this.btnReplaceHistoryPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceHistoryPrint.Location = new System.Drawing.Point(403, 324);
            this.btnReplaceHistoryPrint.Name = "btnReplaceHistoryPrint";
            this.btnReplaceHistoryPrint.Size = new System.Drawing.Size(105, 33);
            this.btnReplaceHistoryPrint.TabIndex = 164;
            this.btnReplaceHistoryPrint.Tag = "";
            this.btnReplaceHistoryPrint.Text = "&Print";
            this.btnReplaceHistoryPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(519, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 33);
            this.btnClose.TabIndex = 163;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblJob
            // 
            this.lblJob.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(46, 50);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(54, 20);
            this.lblJob.TabIndex = 210;
            this.lblJob.Text = "Job#";
            // 
            // lblJobNo
            // 
            this.lblJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobNo.Location = new System.Drawing.Point(99, 50);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(170, 20);
            this.lblJobNo.TabIndex = 209;
            this.lblJobNo.Text = "JobNo";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 207;
            this.label3.Text = "Mobile";
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContactNo.Location = new System.Drawing.Point(324, 50);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(194, 20);
            this.lblContactNo.TabIndex = 206;
            this.lblContactNo.Text = "ContactNo";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(46, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(54, 20);
            this.lblID.TabIndex = 205;
            this.lblID.Text = "VR ID";
            // 
            // lblVRID
            // 
            this.lblVRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVRID.Location = new System.Drawing.Point(99, 27);
            this.lblVRID.Name = "lblVRID";
            this.lblVRID.Size = new System.Drawing.Size(87, 20);
            this.lblVRID.TabIndex = 204;
            this.lblVRID.Text = "VRID";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 203;
            this.label2.Text = "Customer";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 202;
            this.label1.Text = "Address";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Location = new System.Drawing.Point(253, 27);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(265, 20);
            this.lblCustomerName.TabIndex = 201;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.Location = new System.Drawing.Point(99, 73);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(419, 20);
            this.lblAddress.TabIndex = 200;
            this.lblAddress.Text = "Address";
            // 
            // grpBasic
            // 
            this.grpBasic.Location = new System.Drawing.Point(37, 13);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Size = new System.Drawing.Size(490, 87);
            this.grpBasic.TabIndex = 208;
            this.grpBasic.TabStop = false;
            // 
            // lvwVehicleScheduleHistroy
            // 
            this.lvwVehicleScheduleHistroy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEntryDate,
            this.colStatus,
            this.colDate,
            this.colTimeFrom,
            this.colTimeTo,
            this.colUserName,
            this.colRemarks});
            this.lvwVehicleScheduleHistroy.FullRowSelect = true;
            this.lvwVehicleScheduleHistroy.GridLines = true;
            this.lvwVehicleScheduleHistroy.Location = new System.Drawing.Point(39, 115);
            this.lvwVehicleScheduleHistroy.Name = "lvwVehicleScheduleHistroy";
            this.lvwVehicleScheduleHistroy.Size = new System.Drawing.Size(576, 196);
            this.lvwVehicleScheduleHistroy.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwVehicleScheduleHistroy.TabIndex = 211;
            this.lvwVehicleScheduleHistroy.UseCompatibleStateImageBehavior = false;
            this.lvwVehicleScheduleHistroy.View = System.Windows.Forms.View.Details;
            // 
            // colEntryDate
            // 
            this.colEntryDate.Text = "Entry Date";
            this.colEntryDate.Width = 149;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 80;
            // 
            // colTimeFrom
            // 
            this.colTimeFrom.Text = "Time (From)";
            this.colTimeFrom.Width = 70;
            // 
            // colTimeTo
            // 
            this.colTimeTo.Text = "Time (To)";
            this.colTimeTo.Width = 70;
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 90;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 100;
            // 
            // frmVehicleScheduleHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 365);
            this.Controls.Add(this.lvwVehicleScheduleHistroy);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblVRID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.grpBasic);
            this.Controls.Add(this.btnReplaceHistoryPrint);
            this.Controls.Add(this.btnClose);
            this.Name = "frmVehicleScheduleHistory";
            this.Text = "Vehicle Schedule History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReplaceHistoryPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblVRID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.ListView lvwVehicleScheduleHistroy;
        private System.Windows.Forms.ColumnHeader colEntryDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTimeFrom;
        private System.Windows.Forms.ColumnHeader colTimeTo;
    }
}