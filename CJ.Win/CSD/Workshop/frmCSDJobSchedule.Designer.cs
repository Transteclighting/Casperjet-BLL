namespace CJ.Win.CSD.Workshop
{
    partial class frmCSDJobSchedule
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblVisitingTime = new System.Windows.Forms.Label();
            this.dtVisitingTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtVisitingTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtVisitingDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(149, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Schedule Prepare";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblVisitingTime
            // 
            this.lblVisitingTime.Location = new System.Drawing.Point(6, 44);
            this.lblVisitingTime.Name = "lblVisitingTime";
            this.lblVisitingTime.Size = new System.Drawing.Size(95, 16);
            this.lblVisitingTime.TabIndex = 2;
            this.lblVisitingTime.Text = "Visiting Time From";
            this.lblVisitingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtVisitingTimeTo
            // 
            this.dtVisitingTimeTo.CustomFormat = "hh:mm tt";
            this.dtVisitingTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingTimeTo.Location = new System.Drawing.Point(107, 70);
            this.dtVisitingTimeTo.Name = "dtVisitingTimeTo";
            this.dtVisitingTimeTo.ShowUpDown = true;
            this.dtVisitingTimeTo.Size = new System.Drawing.Size(146, 20);
            this.dtVisitingTimeTo.TabIndex = 5;
            // 
            // dtVisitingTimeFrom
            // 
            this.dtVisitingTimeFrom.CustomFormat = "hh:mm tt";
            this.dtVisitingTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingTimeFrom.Location = new System.Drawing.Point(107, 44);
            this.dtVisitingTimeFrom.Name = "dtVisitingTimeFrom";
            this.dtVisitingTimeFrom.ShowUpDown = true;
            this.dtVisitingTimeFrom.Size = new System.Drawing.Size(146, 20);
            this.dtVisitingTimeFrom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Visiting Time To";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(34, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Visiting Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtVisitingDate
            // 
            this.dtVisitingDate.CustomFormat = "dd-MMM-yyyy";
            this.dtVisitingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitingDate.Location = new System.Drawing.Point(107, 18);
            this.dtVisitingDate.Name = "dtVisitingDate";
            this.dtVisitingDate.Size = new System.Drawing.Size(146, 20);
            this.dtVisitingDate.TabIndex = 1;
            // 
            // frmCSDJobSchedule
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 130);
            this.ControlBox = false;
            this.Controls.Add(this.dtVisitingDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVisitingTime);
            this.Controls.Add(this.dtVisitingTimeTo);
            this.Controls.Add(this.dtVisitingTimeFrom);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCSDJobSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD Job Schedule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblVisitingTime;
        private System.Windows.Forms.DateTimePicker dtVisitingTimeTo;
        private System.Windows.Forms.DateTimePicker dtVisitingTimeFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtVisitingDate;
    }
}