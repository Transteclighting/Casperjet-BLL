namespace CJ.Win.HR
{
    partial class frmHRPositionRoleType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHRPositionRoleType));
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoleTypeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChassisSerial = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkIsActive
            // 
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(113, 40);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(80, 31);
            this.chkIsActive.TabIndex = 2;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtClose
            // 
            this.txtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClose.Location = new System.Drawing.Point(270, 76);
            this.txtClose.Name = "txtClose";
            this.txtClose.Size = new System.Drawing.Size(92, 30);
            this.txtClose.TabIndex = 4;
            this.txtClose.Text = "Close";
            this.txtClose.UseVisualStyleBackColor = true;
            this.txtClose.Click += new System.EventHandler(this.txtClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Role Type Name";
            // 
            // txtRoleTypeName
            // 
            this.txtRoleTypeName.Location = new System.Drawing.Point(113, 13);
            this.txtRoleTypeName.Name = "txtRoleTypeName";
            this.txtRoleTypeName.Size = new System.Drawing.Size(249, 21);
            this.txtRoleTypeName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-50, -325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 62;
            this.label4.Text = "AG Name";
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(38, -329);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(284, 23);
            this.cmbAG.TabIndex = 63;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(172, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-81, -283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 60;
            this.label1.Text = "Chassis Serial";
            // 
            // txtChassisSerial
            // 
            this.txtChassisSerial.Location = new System.Drawing.Point(38, -287);
            this.txtChassisSerial.Name = "txtChassisSerial";
            this.txtChassisSerial.Size = new System.Drawing.Size(754, 21);
            this.txtChassisSerial.TabIndex = 61;
            // 
            // frmHRPositionRoleType
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 118);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRoleTypeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChassisSerial);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHRPositionRoleType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Position Role Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button txtClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoleTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChassisSerial;
    }
}