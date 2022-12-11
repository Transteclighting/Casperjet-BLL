namespace CJ.Win.CSD.Reception
{
    partial class frmForcelyStatusUpdate
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
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.cmbJobStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProductPhysicalLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProductLocation = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(67, 8);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Size = new System.Drawing.Size(171, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // cmbJobStatus
            // 
            this.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobStatus.FormattingEnabled = true;
            this.cmbJobStatus.Location = new System.Drawing.Point(67, 35);
            this.cmbJobStatus.Name = "cmbJobStatus";
            this.cmbJobStatus.Size = new System.Drawing.Size(171, 21);
            this.cmbJobStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Job Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prod. Phy. Location";
            // 
            // cmbProductPhysicalLocation
            // 
            this.cmbProductPhysicalLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductPhysicalLocation.FormattingEnabled = true;
            this.cmbProductPhysicalLocation.Location = new System.Drawing.Point(342, 7);
            this.cmbProductPhysicalLocation.Name = "cmbProductPhysicalLocation";
            this.cmbProductPhysicalLocation.Size = new System.Drawing.Size(171, 21);
            this.cmbProductPhysicalLocation.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Product Location";
            // 
            // cmbProductLocation
            // 
            this.cmbProductLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductLocation.FormattingEnabled = true;
            this.cmbProductLocation.Location = new System.Drawing.Point(342, 36);
            this.cmbProductLocation.Name = "cmbProductLocation";
            this.cmbProductLocation.Size = new System.Drawing.Size(171, 21);
            this.cmbProductLocation.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(435, 63);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(78, 27);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmForcelyStatusUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 101);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbProductLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProductPhysicalLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbJobStatus);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForcelyStatusUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forcely Status Update";
            this.Load += new System.EventHandler(this.frmForcelyStatusUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.ComboBox cmbJobStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductPhysicalLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProductLocation;
        private System.Windows.Forms.Button btnUpdate;
    }
}