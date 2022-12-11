namespace CJ.Win.Distribution
{
    partial class frmShipmentVehicle
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.rdoLog = new System.Windows.Forms.RadioButton();
            this.rdoRent = new System.Windows.Forms.RadioButton();
            this.rdoParcel = new System.Windows.Forms.RadioButton();
            this.rdoSelf = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 26);
            this.button1.TabIndex = 37;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(59, 35);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(256, 21);
            this.cmbVehicle.TabIndex = 35;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Vehicle";
            // 
            // rdoLog
            // 
            this.rdoLog.AutoSize = true;
            this.rdoLog.Checked = true;
            this.rdoLog.Location = new System.Drawing.Point(14, 12);
            this.rdoLog.Name = "rdoLog";
            this.rdoLog.Size = new System.Drawing.Size(81, 17);
            this.rdoLog.TabIndex = 39;
            this.rdoLog.TabStop = true;
            this.rdoLog.Text = "Log Vehicle";
            this.rdoLog.UseVisualStyleBackColor = true;
            this.rdoLog.CheckedChanged += new System.EventHandler(this.rdoLog_CheckedChanged);
            // 
            // rdoRent
            // 
            this.rdoRent.AutoSize = true;
            this.rdoRent.Location = new System.Drawing.Point(180, 12);
            this.rdoRent.Name = "rdoRent";
            this.rdoRent.Size = new System.Drawing.Size(86, 17);
            this.rdoRent.TabIndex = 40;
            this.rdoRent.Text = "Rent Vehicle";
            this.rdoRent.UseVisualStyleBackColor = true;
            this.rdoRent.CheckedChanged += new System.EventHandler(this.rdoRent_CheckedChanged);
            // 
            // rdoParcel
            // 
            this.rdoParcel.AutoSize = true;
            this.rdoParcel.Location = new System.Drawing.Point(110, 12);
            this.rdoParcel.Name = "rdoParcel";
            this.rdoParcel.Size = new System.Drawing.Size(55, 17);
            this.rdoParcel.TabIndex = 41;
            this.rdoParcel.Text = "Parcel";
            this.rdoParcel.UseVisualStyleBackColor = true;
            this.rdoParcel.CheckedChanged += new System.EventHandler(this.rdoParcel_CheckedChanged);
            // 
            // rdoSelf
            // 
            this.rdoSelf.AutoSize = true;
            this.rdoSelf.Location = new System.Drawing.Point(272, 12);
            this.rdoSelf.Name = "rdoSelf";
            this.rdoSelf.Size = new System.Drawing.Size(43, 17);
            this.rdoSelf.TabIndex = 42;
            this.rdoSelf.Text = "Self";
            this.rdoSelf.UseVisualStyleBackColor = true;
            this.rdoSelf.CheckedChanged += new System.EventHandler(this.rdoSelf_CheckedChanged);
            // 
            // frmShipmentVehicle
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 97);
            this.Controls.Add(this.rdoSelf);
            this.Controls.Add(this.rdoParcel);
            this.Controls.Add(this.rdoRent);
            this.Controls.Add(this.rdoLog);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbVehicle);
            this.Controls.Add(this.btnSave);
            this.Name = "frmShipmentVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShipmentVehicle";
            this.Load += new System.EventHandler(this.frmShipmentVehicle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoLog;
        private System.Windows.Forms.RadioButton rdoRent;
        private System.Windows.Forms.RadioButton rdoParcel;
        private System.Windows.Forms.RadioButton rdoSelf;
    }
}