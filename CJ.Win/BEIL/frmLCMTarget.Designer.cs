namespace CJ.Win.BEIL
{
    partial class frmLCMTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLCMTarget));
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.dtTargetDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTargetQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(78, 18);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(277, 21);
            this.cmbAG.TabIndex = 0;
            // 
            // dtTargetDate
            // 
            this.dtTargetDate.CustomFormat = "dd-MMMM-yyyy";
            this.dtTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTargetDate.Location = new System.Drawing.Point(78, 45);
            this.dtTargetDate.Name = "dtTargetDate";
            this.dtTargetDate.Size = new System.Drawing.Size(154, 20);
            this.dtTargetDate.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(276, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AG Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Date:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(195, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTargetQty
            // 
            this.txtTargetQty.Location = new System.Drawing.Point(78, 71);
            this.txtTargetQty.Name = "txtTargetQty";
            this.txtTargetQty.Size = new System.Drawing.Size(154, 20);
            this.txtTargetQty.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Target Qty:";
            // 
            // frmLCMTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 132);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtTargetDate);
            this.Controls.Add(this.cmbAG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLCMTarget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LCM Target";
            this.Load += new System.EventHandler(this.frmLCMTarget_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.DateTimePicker dtTargetDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTargetQty;
        private System.Windows.Forms.Label label3;
    }
}