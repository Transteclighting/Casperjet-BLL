namespace CJ.Win
{
    partial class frmAttendDataDownload
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.txtBrowseData = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadBLL = new System.Windows.Forms.Button();
            this.btnLoadTML = new System.Windows.Forms.Button();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOnlyFactory = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.btnProcessNew = new System.Windows.Forms.Button();
            this.ckbShift = new System.Windows.Forms.CheckBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.pbEmployee = new System.Windows.Forms.ProgressBar();
            this.pbDays = new System.Windows.Forms.ProgressBar();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(482, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialog1";
            // 
            // txtBrowseData
            // 
            this.txtBrowseData.Location = new System.Drawing.Point(6, 28);
            this.txtBrowseData.Name = "txtBrowseData";
            this.txtBrowseData.Size = new System.Drawing.Size(470, 20);
            this.txtBrowseData.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(9, 86);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(117, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load TEL, BEIL";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(227, 32);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(41, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(253, 28);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 7;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(74, 28);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 20);
            this.dtFromDate.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(240, 174);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 186;
            this.label3.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(74, 54);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(323, 21);
            this.cboCompany.TabIndex = 185;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 184;
            this.label8.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(74, 81);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(323, 21);
            this.cboDepartment.TabIndex = 183;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadBLL);
            this.groupBox1.Controls.Add(this.btnLoadTML);
            this.groupBox1.Controls.Add(this.pbLoad);
            this.groupBox1.Controls.Add(this.txtBrowseData);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 118);
            this.groupBox1.TabIndex = 187;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Data from Machine";
            // 
            // btnLoadBLL
            // 
            this.btnLoadBLL.Location = new System.Drawing.Point(440, 86);
            this.btnLoadBLL.Name = "btnLoadBLL";
            this.btnLoadBLL.Size = new System.Drawing.Size(117, 23);
            this.btnLoadBLL.TabIndex = 5;
            this.btnLoadBLL.Text = "Load All Data";
            this.btnLoadBLL.UseVisualStyleBackColor = true;
            this.btnLoadBLL.Click += new System.EventHandler(this.btnLoadBLL_Click);
            // 
            // btnLoadTML
            // 
            this.btnLoadTML.Location = new System.Drawing.Point(230, 89);
            this.btnLoadTML.Name = "btnLoadTML";
            this.btnLoadTML.Size = new System.Drawing.Size(59, 23);
            this.btnLoadTML.TabIndex = 4;
            this.btnLoadTML.Text = "Load TML";
            this.btnLoadTML.UseVisualStyleBackColor = true;
            this.btnLoadTML.Visible = false;
            this.btnLoadTML.Click += new System.EventHandler(this.btnLoadTML_Click);
            // 
            // pbLoad
            // 
            this.pbLoad.Location = new System.Drawing.Point(9, 65);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(548, 15);
            this.pbLoad.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOnlyFactory);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ctlEmployee1);
            this.groupBox2.Controls.Add(this.btnProcessNew);
            this.groupBox2.Controls.Add(this.ckbShift);
            this.groupBox2.Controls.Add(this.cmbShift);
            this.groupBox2.Controls.Add(this.pbEmployee);
            this.groupBox2.Controls.Add(this.pbDays);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.cboDepartment);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboCompany);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Location = new System.Drawing.Point(8, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 257);
            this.groupBox2.TabIndex = 188;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Data";
            // 
            // chkOnlyFactory
            // 
            this.chkOnlyFactory.AutoSize = true;
            this.chkOnlyFactory.Location = new System.Drawing.Point(413, 56);
            this.chkOnlyFactory.Name = "chkOnlyFactory";
            this.chkOnlyFactory.Size = new System.Drawing.Size(85, 17);
            this.chkOnlyFactory.TabIndex = 195;
            this.chkOnlyFactory.Text = "Only Factory";
            this.chkOnlyFactory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 194;
            this.label1.Text = "Employee";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(74, 135);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(483, 25);
            this.ctlEmployee1.TabIndex = 193;
            // 
            // btnProcessNew
            // 
            this.btnProcessNew.Location = new System.Drawing.Point(382, 173);
            this.btnProcessNew.Name = "btnProcessNew";
            this.btnProcessNew.Size = new System.Drawing.Size(90, 23);
            this.btnProcessNew.TabIndex = 192;
            this.btnProcessNew.Text = "Process";
            this.btnProcessNew.UseVisualStyleBackColor = true;
            this.btnProcessNew.Click += new System.EventHandler(this.btnProcessNew_Click);
            // 
            // ckbShift
            // 
            this.ckbShift.AutoSize = true;
            this.ckbShift.Location = new System.Drawing.Point(24, 109);
            this.ckbShift.Name = "ckbShift";
            this.ckbShift.Size = new System.Drawing.Size(47, 17);
            this.ckbShift.TabIndex = 191;
            this.ckbShift.Text = "Shift";
            this.ckbShift.UseVisualStyleBackColor = true;
            this.ckbShift.CheckedChanged += new System.EventHandler(this.ckbShift_CheckedChanged);
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Enabled = false;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(74, 107);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(323, 21);
            this.cmbShift.TabIndex = 190;
            // 
            // pbEmployee
            // 
            this.pbEmployee.Location = new System.Drawing.Point(9, 203);
            this.pbEmployee.Name = "pbEmployee";
            this.pbEmployee.Size = new System.Drawing.Size(467, 15);
            this.pbEmployee.TabIndex = 189;
            // 
            // pbDays
            // 
            this.pbDays.Location = new System.Drawing.Point(9, 224);
            this.pbDays.Name = "pbDays";
            this.pbDays.Size = new System.Drawing.Size(467, 15);
            this.pbDays.TabIndex = 188;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(74, 173);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 187;
            this.btnDelete.Text = "Delete All";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmAttendDataDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAttendDataDownload";
            this.Text = "Attendance Data Download & Process";
            this.Load += new System.EventHandler(this.frmAttendDataDownload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.TextBox txtBrowseData;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.ProgressBar pbDays;
        private System.Windows.Forms.ProgressBar pbEmployee;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.CheckBox ckbShift;
        private System.Windows.Forms.Button btnLoadTML;
        private System.Windows.Forms.Button btnProcessNew;
        private System.Windows.Forms.Label label1;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Button btnLoadBLL;
        private System.Windows.Forms.CheckBox chkOnlyFactory;
    }
}