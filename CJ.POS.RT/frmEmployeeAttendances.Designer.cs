namespace CJ.POS.RT
{
    partial class frmEmployeeAttendances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeAttendances));
            this.lvwAttendInfo = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutelt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNoOfEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnChkInOutstation = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwAttendInfo
            // 
            this.lvwAttendInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttendInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDate,
            this.colOutelt,
            this.colNoOfEmployee,
            this.colCreateDate,
            this.colStatus});
            this.lvwAttendInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAttendInfo.FullRowSelect = true;
            this.lvwAttendInfo.GridLines = true;
            this.lvwAttendInfo.HideSelection = false;
            this.lvwAttendInfo.Location = new System.Drawing.Point(17, 81);
            this.lvwAttendInfo.MultiSelect = false;
            this.lvwAttendInfo.Name = "lvwAttendInfo";
            this.lvwAttendInfo.Size = new System.Drawing.Size(760, 402);
            this.lvwAttendInfo.TabIndex = 2;
            this.lvwAttendInfo.UseCompatibleStateImageBehavior = false;
            this.lvwAttendInfo.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "Attendance ID";
            this.colID.Width = 88;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 78;
            // 
            // colOutelt
            // 
            this.colOutelt.Text = "Outelt";
            this.colOutelt.Width = 90;
            // 
            // colNoOfEmployee
            // 
            this.colNoOfEmployee.Text = "No Of Employee";
            this.colNoOfEmployee.Width = 93;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 87;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(783, 157);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 32);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(783, 81);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Check In";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(783, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(14, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(179, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(51, 28);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(122, 21);
            this.dtFromdate.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Location = new System.Drawing.Point(17, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 58);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(235, 28);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(121, 21);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(205, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(10, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(402, 40);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(90, 32);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOut.Location = new System.Drawing.Point(783, 119);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(90, 32);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Check Out ";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnChkInOutstation
            // 
            this.btnChkInOutstation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChkInOutstation.Location = new System.Drawing.Point(783, 309);
            this.btnChkInOutstation.Name = "btnChkInOutstation";
            this.btnChkInOutstation.Size = new System.Drawing.Size(90, 40);
            this.btnChkInOutstation.TabIndex = 6;
            this.btnChkInOutstation.Text = "Check In (Outstation)";
            this.btnChkInOutstation.UseVisualStyleBackColor = true;
            this.btnChkInOutstation.Visible = false;
            this.btnChkInOutstation.Click += new System.EventHandler(this.btnChkInOutstation_Click);
            // 
            // frmEmployeeAttendances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 495);
            this.Controls.Add(this.btnChkInOutstation);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwAttendInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeeAttendances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeAttendances";
            this.Load += new System.EventHandler(this.frmEmployeeAttendances_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAttendInfo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colOutelt;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colNoOfEmployee;
        private System.Windows.Forms.Button btnChkInOutstation;
    }
}