namespace CJ.Win.CSD.Store
{
    partial class frmCSDTechnicianTransportationApprove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSDTechnicianTransportationApprove));
            this.lblPartialAmt = new System.Windows.Forms.Label();
            this.txtPartialAmt = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTechName = new System.Windows.Forms.Label();
            this.lblTechnicianName = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFullAmt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdFullAmount = new System.Windows.Forms.RadioButton();
            this.rdPartialAmt = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblPartialAmt
            // 
            this.lblPartialAmt.AutoSize = true;
            this.lblPartialAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartialAmt.Location = new System.Drawing.Point(42, 123);
            this.lblPartialAmt.Name = "lblPartialAmt";
            this.lblPartialAmt.Size = new System.Drawing.Size(93, 15);
            this.lblPartialAmt.TabIndex = 19;
            this.lblPartialAmt.Text = "Partial Amount :";
            // 
            // txtPartialAmt
            // 
            this.txtPartialAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartialAmt.Location = new System.Drawing.Point(141, 123);
            this.txtPartialAmt.Name = "txtPartialAmt";
            this.txtPartialAmt.Size = new System.Drawing.Size(135, 21);
            this.txtPartialAmt.TabIndex = 20;
            this.txtPartialAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartialAmt_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(403, 132);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(318, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(61, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 15);
            this.lblDate.TabIndex = 21;
            this.lblDate.Text = "From Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(141, 37);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(135, 21);
            this.dtFromDate.TabIndex = 22;
            // 
            // lblTechName
            // 
            this.lblTechName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechName.Location = new System.Drawing.Point(12, 9);
            this.lblTechName.Name = "lblTechName";
            this.lblTechName.Size = new System.Drawing.Size(120, 18);
            this.lblTechName.TabIndex = 13;
            this.lblTechName.Text = "Technician Name :";
            this.lblTechName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTechnicianName
            // 
            this.lblTechnicianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechnicianName.Location = new System.Drawing.Point(138, 12);
            this.lblTechnicianName.Name = "lblTechnicianName";
            this.lblTechnicianName.Size = new System.Drawing.Size(344, 15);
            this.lblTechnicianName.TabIndex = 14;
            this.lblTechnicianName.Text = "Name";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(285, 37);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(56, 15);
            this.lblToDate.TabIndex = 26;
            this.lblToDate.Text = "To Date :";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(347, 37);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(135, 21);
            this.dtToDate.TabIndex = 27;
            // 
            // lblFullAmt
            // 
            this.lblFullAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullAmt.Location = new System.Drawing.Point(138, 67);
            this.lblFullAmt.Name = "lblFullAmt";
            this.lblFullAmt.Size = new System.Drawing.Size(344, 15);
            this.lblFullAmt.TabIndex = 29;
            this.lblFullAmt.Text = "Amount";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Full Amount :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rdFullAmount
            // 
            this.rdFullAmount.AutoSize = true;
            this.rdFullAmount.Location = new System.Drawing.Point(141, 90);
            this.rdFullAmount.Name = "rdFullAmount";
            this.rdFullAmount.Size = new System.Drawing.Size(90, 19);
            this.rdFullAmount.TabIndex = 30;
            this.rdFullAmount.TabStop = true;
            this.rdFullAmount.Text = "Full Amount";
            this.rdFullAmount.UseVisualStyleBackColor = true;
            this.rdFullAmount.CheckedChanged += new System.EventHandler(this.rdFullAmount_CheckedChanged);
            // 
            // rdPartialAmt
            // 
            this.rdPartialAmt.AutoSize = true;
            this.rdPartialAmt.Location = new System.Drawing.Point(246, 90);
            this.rdPartialAmt.Name = "rdPartialAmt";
            this.rdPartialAmt.Size = new System.Drawing.Size(105, 19);
            this.rdPartialAmt.TabIndex = 31;
            this.rdPartialAmt.TabStop = true;
            this.rdPartialAmt.Text = "Partial Amount";
            this.rdPartialAmt.UseVisualStyleBackColor = true;
            this.rdPartialAmt.CheckedChanged += new System.EventHandler(this.rdPartialAmt_CheckedChanged);
            // 
            // frmCSDTechnicianTransportationApprove
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 174);
            this.Controls.Add(this.rdPartialAmt);
            this.Controls.Add(this.rdFullAmount);
            this.Controls.Add(this.lblFullAmt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.lblPartialAmt);
            this.Controls.Add(this.txtPartialAmt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblTechName);
            this.Controls.Add(this.lblTechnicianName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCSDTechnicianTransportationApprove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve CSD Technician Transportation";
            this.Load += new System.EventHandler(this.frmCSDTechnicianTransportationApprove_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPartialAmt;
        private System.Windows.Forms.TextBox txtPartialAmt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lblTechName;
        private System.Windows.Forms.Label lblTechnicianName;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label lblFullAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdFullAmount;
        private System.Windows.Forms.RadioButton rdPartialAmt;
    }
}