namespace CJ.Win.HR
{
    partial class frmPositionUnassign
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
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblabc = new System.Windows.Forms.Label();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAssignEmployee = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblSeparationDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.chkMarkAsVacant = new System.Windows.Forms.CheckBox();
            this.chkUndoMarkAsVacant = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(318, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Blue;
            this.lblCompany.Location = new System.Drawing.Point(98, 11);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(21, 13);
            this.lblCompany.TabIndex = 15;
            this.lblCompany.Text = "??";
            // 
            // lblabc
            // 
            this.lblabc.AutoSize = true;
            this.lblabc.Location = new System.Drawing.Point(41, 10);
            this.lblabc.Name = "lblabc";
            this.lblabc.Size = new System.Drawing.Size(51, 13);
            this.lblabc.TabIndex = 14;
            this.lblabc.Text = "Company";
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNode.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectedNode.Location = new System.Drawing.Point(98, 30);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(21, 13);
            this.lblSelectedNode.TabIndex = 13;
            this.lblSelectedNode.Text = "??";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Selected Node";
            // 
            // lblAssignEmployee
            // 
            this.lblAssignEmployee.AutoSize = true;
            this.lblAssignEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignEmployee.ForeColor = System.Drawing.Color.Blue;
            this.lblAssignEmployee.Location = new System.Drawing.Point(98, 49);
            this.lblAssignEmployee.Name = "lblAssignEmployee";
            this.lblAssignEmployee.Size = new System.Drawing.Size(21, 13);
            this.lblAssignEmployee.TabIndex = 17;
            this.lblAssignEmployee.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Assign Employee";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(395, 144);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 27);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(99, 114);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(367, 20);
            this.txtRemarks.TabIndex = 21;
            // 
            // lblSeparationDate
            // 
            this.lblSeparationDate.AutoSize = true;
            this.lblSeparationDate.Location = new System.Drawing.Point(13, 90);
            this.lblSeparationDate.Name = "lblSeparationDate";
            this.lblSeparationDate.Size = new System.Drawing.Size(84, 13);
            this.lblSeparationDate.TabIndex = 20;
            this.lblSeparationDate.Text = "Separation Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(99, 89);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(102, 20);
            this.dtToDate.TabIndex = 19;
            // 
            // chkMarkAsVacant
            // 
            this.chkMarkAsVacant.AutoSize = true;
            this.chkMarkAsVacant.Location = new System.Drawing.Point(101, 67);
            this.chkMarkAsVacant.Name = "chkMarkAsVacant";
            this.chkMarkAsVacant.Size = new System.Drawing.Size(101, 17);
            this.chkMarkAsVacant.TabIndex = 23;
            this.chkMarkAsVacant.Text = "Mark as Vacant";
            this.chkMarkAsVacant.UseVisualStyleBackColor = true;
            // 
            // chkUndoMarkAsVacant
            // 
            this.chkUndoMarkAsVacant.AutoSize = true;
            this.chkUndoMarkAsVacant.Location = new System.Drawing.Point(264, 67);
            this.chkUndoMarkAsVacant.Name = "chkUndoMarkAsVacant";
            this.chkUndoMarkAsVacant.Size = new System.Drawing.Size(130, 17);
            this.chkUndoMarkAsVacant.TabIndex = 24;
            this.chkUndoMarkAsVacant.Text = "Undo Mark as Vacant";
            this.chkUndoMarkAsVacant.UseVisualStyleBackColor = true;
            // 
            // frmPositionUnassign
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 179);
            this.Controls.Add(this.chkUndoMarkAsVacant);
            this.Controls.Add(this.chkMarkAsVacant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblSeparationDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAssignEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblabc);
            this.Controls.Add(this.lblSelectedNode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositionUnassign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPositionUnassign";
            this.Load += new System.EventHandler(this.frmPositionUnassign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblabc;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAssignEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblSeparationDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.CheckBox chkMarkAsVacant;
        private System.Windows.Forms.CheckBox chkUndoMarkAsVacant;
    }
}