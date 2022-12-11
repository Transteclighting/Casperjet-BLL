namespace CJ.Win.CSD.Workshop
{
    partial class frmTechnicianBlock
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
            this.label8 = new System.Windows.Forms.Label();
            this.ctlCSDTechnician1 = new CJ.Win.ctlCSDTechnician();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkFullDay = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtToTime = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Technician";
            // 
            // ctlCSDTechnician1
            // 
            this.ctlCSDTechnician1.Location = new System.Drawing.Point(72, 3);
            this.ctlCSDTechnician1.Name = "ctlCSDTechnician1";
            this.ctlCSDTechnician1.Size = new System.Drawing.Size(508, 31);
            this.ctlCSDTechnician1.TabIndex = 24;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(191, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(46, 13);
            this.lblTo.TabIndex = 40;
            this.lblTo.Text = "To Date";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(17, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(56, 13);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "From Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(252, 38);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(104, 20);
            this.dtToDate.TabIndex = 41;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(81, 38);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtFromDate.TabIndex = 39;
            // 
            // chkFullDay
            // 
            this.chkFullDay.AutoSize = true;
            this.chkFullDay.Location = new System.Drawing.Point(362, 40);
            this.chkFullDay.Name = "chkFullDay";
            this.chkFullDay.Size = new System.Drawing.Size(75, 17);
            this.chkFullDay.TabIndex = 42;
            this.chkFullDay.Text = "Is Full Day";
            this.chkFullDay.UseVisualStyleBackColor = true;
            this.chkFullDay.CheckedChanged += new System.EventHandler(this.chkFullDay_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "To Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "From Time";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(474, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtFromTime
            // 
            this.dtFromTime.CustomFormat = "hh:mm tt";
            this.dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromTime.Location = new System.Drawing.Point(81, 66);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.ShowUpDown = true;
            this.dtFromTime.Size = new System.Drawing.Size(79, 20);
            this.dtFromTime.TabIndex = 52;
            // 
            // dtToTime
            // 
            this.dtToTime.CustomFormat = "hh:mm tt";
            this.dtToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToTime.Location = new System.Drawing.Point(252, 66);
            this.dtToTime.Name = "dtToTime";
            this.dtToTime.ShowUpDown = true;
            this.dtToTime.Size = new System.Drawing.Size(79, 20);
            this.dtToTime.TabIndex = 53;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(81, 90);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(477, 20);
            this.txtRemarks.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Remarks";
            // 
            // frmTechnicianBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 156);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dtToTime);
            this.Controls.Add(this.dtFromTime);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkFullDay);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.ctlCSDTechnician1);
            this.Controls.Add(this.label8);
            this.Name = "frmTechnicianBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTechnicianBlock";
            this.Load += new System.EventHandler(this.frmTechnicianBlock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ctlCSDTechnician ctlCSDTechnician1;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox chkFullDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtFromTime;
        private System.Windows.Forms.DateTimePicker dtToTime;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;

    }
}