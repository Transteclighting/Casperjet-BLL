namespace CJ.Win
{
    partial class frmAttendData
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
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtPunchDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPunchTime = new System.Windows.Forms.DateTimePicker();
            this.cboStation = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(87, 10);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(188, 20);
            this.txtCardNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Station No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card No";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(476, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Punch Date";
            // 
            // dtPunchDate
            // 
            this.dtPunchDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPunchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPunchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPunchDate.Location = new System.Drawing.Point(87, 36);
            this.dtPunchDate.Name = "dtPunchDate";
            this.dtPunchDate.Size = new System.Drawing.Size(144, 20);
            this.dtPunchDate.TabIndex = 5;
            this.dtPunchDate.ValueChanged += new System.EventHandler(this.dtPunchDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(281, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Punch Time";
            // 
            // dtPunchTime
            // 
            this.dtPunchTime.CustomFormat = "hh:mm tt";
            this.dtPunchTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPunchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPunchTime.Location = new System.Drawing.Point(351, 36);
            this.dtPunchTime.Name = "dtPunchTime";
            this.dtPunchTime.ShowUpDown = true;
            this.dtPunchTime.Size = new System.Drawing.Size(87, 20);
            this.dtPunchTime.TabIndex = 7;
            // 
            // cboStation
            // 
            this.cboStation.FormattingEnabled = true;
            this.cboStation.Items.AddRange(new object[] {
            "001 (TEL Door Access)",
            "002 (TEL Attendance)",
            "003 (BLL Door Access)",
            "004 (BLL Attendance)",
            "005 (Homecare)",
            "006 (BEIL)",
            "008 (Logistics & BEIL)"});
            this.cboStation.Location = new System.Drawing.Point(351, 9);
            this.cboStation.Name = "cboStation";
            this.cboStation.Size = new System.Drawing.Size(177, 21);
            this.cboStation.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(284, 62);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 26);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmAttendData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 96);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cboStation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtPunchTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtPunchDate);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "frmAttendData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAttendData";
            this.Load += new System.EventHandler(this.frmAttendData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtPunchDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPunchTime;
        private System.Windows.Forms.ComboBox cboStation;
        private System.Windows.Forms.Button btnSend;
    }
}